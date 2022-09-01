using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Word = Microsoft.Office.Interop.Word;

namespace SGPAPP
{
    public partial class frmEmpresas : Form
    {
        public frmEmpresas()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn2 = new GridViewCommandColumn();
            commandColumn2.Name = "CommandColumn2";
            commandColumn2.UseDefaultText = true;
            commandColumn2.Image = Properties.Resources.icons8_checkmark_16;
            commandColumn2.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn2.FieldName = "select";
            commandColumn2.HeaderText = "Seleccionar";
            radGridView1.MasterTemplate.Columns.Add(commandColumn2);
            radGridView1.CommandCellClick += new CommandCellClickEventHandler(radGridView1_CommandCellClick);
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        public String PacienteID;
        public String PacienteNom;
        public int PrID;
        public String Resultado;
        public String CT;
        String docname;
        String docs;
        String Ced;
        String Age;
        String Mail;
        String Dir;
        String Fechan;
        String Tipo;
        String Prueba;
        String Fecham;
        String cambiada1;
        bool English= false;
        DateTime Fecha = DateTime.Now;
        String day;
        String mes;
        String year;
        frmCPG pgb = new frmCPG();
        bool enviado;
        clsMail cm = new clsMail();
        bool Citas;
        String HoraMuestra;
        String HoraEmision;
        String Empresa;
        DateTime Fechareg;
        String direct;
        byte[] PDFDOC;
        String QrLink;
        String ResultID;
        String Resultado2;
        String CT2;
        bool validaEmpresa = false;
        SqlDataReader rdr = null;
        public void GetData()
        {
            try
            {
                
                    using (var con = new SqlConnection(conect))
                    {
                 
                        SqlDataAdapter da = new SqlDataAdapter("spGetPruebasPendientes", con);
                        DataTable dt = new DataTable();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@Pruebas", "1");
                    da.Fill(dt);
                        this.radGridView1.DataSource = dt;
                        this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                        if (radGridView1.Columns[0].Name == "CommandColumn2")
                        {
                            radGridView1.Columns.Move(0, 9);
                        }

                        con.Close();
                    }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEmpresas_Load(object sender, EventArgs e)
        {
           

            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GetData();
        }
        public void CargaEmpresas()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                { 
                int Rows;
                Rows = dataGridView3.RowCount - 1;
                con.Open();
                cmd = new SqlCommand("select b.ppId as [ID de Prueba], RTRIM(b.ppPacid) as [ID del Paciente], RTRIM(b.ppPaciente) as [Paciente], RTRIM(b.ppCedula) as [Cedula],  RTRIM(b.ppTipo) as [Tipo de Prueba], RTRIM(b.ppPrueba) as [Prueba], RTRIM(b.ppFecha) as [Fecha de Muestra],RTRIM(b.ppTiempo) as [Duracion], RTRIM(b.ppMetodo) as [Metodo], RTRIM(b.ppHora) as [Hora de Muestra]  from tbPacientes a inner join tbPruebasPendientes b on a.pId = b.ppPacid where a.pEmpresa IS NOT NULL and a.pEmpresa = '" + Empresa+"' and a.pFechareg = '"+Fechareg+"'", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Paciente");
                dataGridView3.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                dataGridView3.Columns["ID de Prueba"].Visible = false;
                dataGridView3.Columns["ID del Paciente"].DisplayIndex = 0;
                dataGridView3.Columns["Paciente"].DisplayIndex = 1;
                dataGridView3.Columns["Cedula"].DisplayIndex = 2;
                dataGridView3.Columns["Tipo de Prueba"].DisplayIndex = 3;
                dataGridView3.Columns["Prueba"].DisplayIndex = 4;
                dataGridView3.Columns["Fecha de Muestra"].DisplayIndex = 5;
                dataGridView3.Columns["Duracion"].Visible = false;
                dataGridView3.Columns["Metodo"].Visible = false;
                dataGridView3.Columns["Hora de Muestra"].DisplayIndex = 6;


                con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        public void AddResults()
        {
            bool existe = false;

            if (dataGridView2.RowCount >= 1)
            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if (Convert.ToString(dataGridView2.Rows[i].Cells["pid"].Value) == PacienteID)

                    {
                        MessageBox.Show("Este Paciente ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        existe = true;
                        break;

                    }
                    else
                    {
                        existe = false;
                    }
                }
            }
            if (existe == false)
            {
                String Ingles;
                if (English == true)
                {
                    Ingles = "true";
                }
                else
                {
                    Ingles = "false";
                }
                conviertefecha();
                dataGridView2.Rows.Add(PacienteID, PacienteNom, Dir, Mail, Fechan, Age, Ced, Tipo, Prueba, Resultado, CT, Resultado2, CT2, cambiada1, Fecham, HoraMuestra, PrID, Ingles);
 

            }
        }
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;


                fecha1 = Fecha;

                day = fecha1.Day.ToString();
                mes = fecha1.Month.ToString();
                year = fecha1.Year.ToString();

                cambiada1 = year + "-" + mes + "-" + day;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

        private void btnSav_Click(object sender, EventArgs e)
        {

            if (dataGridView2.RowCount >= 1)
            {

                using (var con = new SqlConnection(conect))
                {
                    try
                    { 
                    SqlCommand AddResultados = new SqlCommand("Insert into tbResultados values (@rePacid, @rePaciente, @reDir, @reFechan, @reEdad, @reCed, @reTipop, @rePrueba, @reResultado, @reCT, @reFecha, @refecham, @reHora, @reHoram, @PDFDOC, @reResultado1, @reResultado2, @reCT2, @reEmpresa, @rePruebaID, @reFacturacionID)", con);
                    con.Open();
                   
                        foreach (DataGridViewRow row in dataGridView2.Rows)

                        {
                            HoraEmision = DateTime.Now.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                            //HoraEmision = DateTime.Parse(HoraEmision.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                            AddResultados.Parameters.Clear();
                            AddResultados.Parameters.AddWithValue("@rePacid", Convert.ToString(row.Cells["pid"].Value));
                            AddResultados.Parameters.AddWithValue("@rePaciente", Convert.ToString(row.Cells["pname"].Value));
                            AddResultados.Parameters.AddWithValue("@reDir", Convert.ToString(row.Cells["pdir"].Value));
                             if (Convert.ToString(row.Cells["pfechan"].Value) == "-")
                                {
                                    AddResultados.Parameters.AddWithValue("@reFechan", "1900-01-01"); 
                                }
                                else
                                {
                                    AddResultados.Parameters.AddWithValue("@reFechan", Convert.ToString(row.Cells["pfechan"].Value));
                                }
                            AddResultados.Parameters.AddWithValue("@reEdad", Convert.ToString(row.Cells["pedad"].Value));
                            AddResultados.Parameters.AddWithValue("@reCed", Convert.ToString(row.Cells["pced"].Value));
                            AddResultados.Parameters.AddWithValue("@reTipop", Convert.ToString(row.Cells["ptipo"].Value));
                            AddResultados.Parameters.AddWithValue("@rePrueba", Convert.ToString(row.Cells["pprueba"].Value));
                            if (Resultado == "Detectado" && Prueba == "Influenza" || Resultado2 == "Detectado" && Prueba == "Influenza" || Resultado == "Positivo" && Prueba == "Anticuerpo-Covid" || Resultado2 == "Positivo" && Prueba == "Anticuerpo-Covid")
                            {
                                AddResultados.Parameters.AddWithValue("@reResultado", "Positivo");
                            }
                            else
                            {
                                AddResultados.Parameters.AddWithValue("@reResultado", Convert.ToString(row.Cells["pres"].Value));
                            }
                            AddResultados.Parameters.AddWithValue("@reResultado1", Convert.ToString(row.Cells["pres"].Value));
                            AddResultados.Parameters.AddWithValue("@reCT", Convert.ToString(row.Cells["pct"].Value));
                            AddResultados.Parameters.AddWithValue("@reResultado2", Convert.ToString(row.Cells["pres2"].Value));
                            AddResultados.Parameters.AddWithValue("@reCT2", Convert.ToString(row.Cells["pct2"].Value));
                            AddResultados.Parameters.AddWithValue("@reFecha", Convert.ToString(row.Cells["pfecha"].Value));
                            AddResultados.Parameters.AddWithValue("@reFecham", Convert.ToString(row.Cells["pfecham"].Value));
                            AddResultados.Parameters.AddWithValue("@reHoram", Convert.ToString(row.Cells["pHora"].Value));
                            AddResultados.Parameters.AddWithValue("@reHora", HoraEmision.ToString());
                            AddResultados.Parameters.AddWithValue("@reEmpresa", DBNull.Value);
                            AddResultados.Parameters.AddWithValue("@reFacturacionID", DBNull.Value);

                            PrID = (int)row.Cells["PruebaID"].Value;
                            PacienteID = (string)row.Cells["pid"].Value;
                            PacienteNom = (string)row.Cells["pname"].Value;
                            Dir = (string)row.Cells["pdir"].Value;
                            Mail = (string)row.Cells["pmail"].Value;
                            Fechan = (string)row.Cells["pfechan"].Value;
                            Age = (string)row.Cells["pedad"].Value;
                            Ced = (string)row.Cells["pced"].Value;
                            Tipo = (string)row.Cells["ptipo"].Value;
                            Prueba = (string)row.Cells["pPrueba"].Value;
                            Resultado = (string)row.Cells["pRes"].Value;
                            CT = (string)row.Cells["pCT"].Value;
                            Resultado2 = (string)row.Cells["pRes2"].Value;
                            CT2 = (string)row.Cells["pCT2"].Value;
                            Fecham = (string)row.Cells["pfecham"].Value;
                            HoraMuestra = (string)row.Cells["phora"].Value;

                            if ((string)row.Cells["cIng"].Value == "true")
                            {
                                English = true;
                            }
                            else
                            {
                                English = false;
                            }

                            GetResultID();
                            EditPlantilla();
                        AddResultados.Parameters.AddWithValue("@rePruebaID", PrID);
                        AddResultados.Parameters.AddWithValue("@PDFDOC", SqlDbType.VarBinary).Value = PDFDOC;
                            if (enviado == true)
                                {
                                    AddResultados.ExecuteNonQuery();
                                    row.DefaultCellStyle.BackColor = Color.Green;
                                    DelPrueba();
                                
                                    String doc = PacienteNom+ " - " + cambiada1 + ".pdf";
                                    sendmail(Mail, doc);
                                
                                //if (Citas == true)
                                //{
                                //    UpdateCitas();
                                //}
                                SaveLog();
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = Color.Red;
                                }
                                                     

                            enviado = false;
                            

                        }
                        MessageBox.Show("Resultados marcados en verde han sido generados de manera satisfactoria.", "Envio de Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        radGridView1.Enabled = false;
                        btnSav.Enabled = false;
                        btndel.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }

                    finally
                    {
                        con.Close();
                    }
                }
            }

        }
        public void SaveLog()
        {
            Logs log = new Logs();
            log.Accion = "Resultados Asignados al Paciente: " + PacienteNom + "";
            log.Form = "Asignar Resultados Masivos";
            log.SaveLog();
        }
        public void UpdateCitas()
        {
            using (var con = new SqlConnection(conect))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    cmd.CommandText = @"update tbCitas set cEstatus= @Status where pid = '" + PacienteID + "' and cestatus = 'Programada'";
                    cmd.Parameters.AddWithValue("@Status", "Completada");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                }
                finally
                {
                    con.Close();
                }

                con.Open();
                cmd.ExecuteScalar();
                con.Close();
            }

        }
        public void DelPrueba()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                { 
                String Sql = "delete from tbPruebasPendientes where ppid = '" + PrID+ "'";

                SqlCommand cmd = new SqlCommand(Sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

               
                    int i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        String realname;
        public void getPlantilla()
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                try
                { 
                con.Open();
                using (SqlCommand cm = con.CreateCommand())
                {
                    //string fileName = Application.StartupPath + @"\\resourses\" + PacID+"-plantillaresults";
                    if (Prueba == "Sars Cov-2")
                    {
                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plid = @id  ";
                        if (Resultado == "Detectado" && Prueba == "Sars Cov-2" && English == false)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 1;
                        }
                        if (Prueba == "Sars Cov-2" && Resultado == "No Detectado" && English == false || Prueba == "Sars Cov-2" && Resultado == "Indeterminado" && English == false)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 2;
                        }
                        if (Prueba == "Sars Cov-2" && English == true)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 6;
                        }
                    }
                    else if(Prueba == "Antigeno" && English == true)
                        {
                            cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = 'Antigen Test'  ";
                        }
                    else
                    {
                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = '" + Prueba + "'  ";
                    }
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            realname = dr[1].ToString();
                            int size = 1024 * 1024;
                            byte[] buffer = new byte[size];
                            int readBytes = 0;
                            int index = 0;
                            string fileName = Application.StartupPath + @"\\resourses\" + PacienteID + "-" + realname;
                            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                while ((readBytes = (int)dr.GetBytes(0, index, buffer, 0, size)) > 0)
                                {
                                    fs.Write(buffer, 0, readBytes);
                                    index += readBytes;
                                }
                            }

                        }
                    }
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }            
        }
        public void getQR()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                { 
                string sql = "SELECT qrLink from tbQRinfo where qrID = 1";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                 reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        QrLink = reader[0].ToString();

                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado link registrado!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void GetResultID()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                { 
                string sql = "SELECT Max(reiD) as [ID] from tbresultados";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ResultID = reader[0].ToString();

                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado registro de resultados!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public async Task EditPlantilla()
        {
            try
            {
                getQR();
                ResultID = Convert.ToString(int.Parse(ResultID) + 1);
                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                QrCode qrCode = new QrCode();
                String Value = QrLink + ResultID;
                qrEncoder.TryEncode(Value, out qrCode);
                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.SteelBlue, Brushes.White);
                MemoryStream ms = new MemoryStream();
                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                var imageTemporal = new Bitmap(ms);
                var imagen = new Bitmap(imageTemporal, new Size(new Point(120, 120)));

                imagen.Save("qrimagen-" + PacienteID + ".png", ImageFormat.Png);
                getPlantilla();
                System.IO.Directory.CreateDirectory(@"C:\SGP");
                docname = PacienteNom + " - " + cambiada1 + ".pdf";
                object ObjMiss = System.Reflection.Missing.Value;
                Word.Application ObjWord = new Word.Application();
                string ruta = Application.StartupPath + @"\\resourses\" + PacienteID + "-" + realname;
                string rutasave = @"C:\SGP\" + docname + "";
                object parametro = ruta;
                object save = rutasave;
                if (Prueba == "Influenza" || Prueba == "Anticuerpo-Covid")
                {
                    object paciente = "paciente";
                    object edad = "edad";
                    object fechan = "fechan";
                    object ced = "ced";
                    object res = "resultado";
                    object res2 = "Resultado2";
                    object ct = "no";
                    object ct2 = "no2";
                    object fechae = "fechae";
                    object dire = "dir";
                    object fechamu = "fecham";
                    Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss, ReadOnly: true);
                    Word.Range nom = ObjDoc.Bookmarks.get_Item(ref paciente).Range;
                    nom.Text = PacienteNom;
                    Word.Range age = ObjDoc.Bookmarks.get_Item(ref edad).Range;
                    age.Text = Age;
                    Word.Range fech = ObjDoc.Bookmarks.get_Item(ref fechan).Range;
                    fech.Text = Fechan;
                    Word.Range cedu = ObjDoc.Bookmarks.get_Item(ref ced).Range;
                    cedu.Text = Ced;
                    Word.Range resu = ObjDoc.Bookmarks.get_Item(ref res).Range;          
                    resu.Text = Resultado;          
                    Word.Range cts = ObjDoc.Bookmarks.get_Item(ref ct).Range;
                    cts.Text = CT;
                    Word.Range resu2 = ObjDoc.Bookmarks.get_Item(ref res2).Range;
                    resu2.Text = Resultado2;
                    Word.Range cts2 = ObjDoc.Bookmarks.get_Item(ref ct2).Range;
                    cts2.Text = CT2;
                    Word.Range fechaem = ObjDoc.Bookmarks.get_Item(ref fechae).Range;
                    fechaem.Text = DateTime.Parse(Fecham).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + " " + HoraMuestra;
                    Word.Range direction = ObjDoc.Bookmarks.get_Item(ref dire).Range;
                    direction.Text = Dir;
                    Word.Range fechamue = ObjDoc.Bookmarks.get_Item(ref fechamu).Range;
                    fechamue.Text = DateTime.Parse(Fecham).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + " " + HoraMuestra;
                    object rango1 = nom;
                    object rango2 = age;
                    object rango3 = fech;
                    object rango4 = cedu;
                    object rango5 = resu;
                    object rango6 = cts;
                    object rango7 = resu2;
                    object rango8 = cts2;
                    object rango9 = fechaem;
                    object rango10 = direction;
                    object rango11 = fechamue;
                    ObjDoc.Bookmarks.Add("paciente", ref rango1);
                    ObjDoc.Bookmarks.Add("edad", ref rango2);
                    ObjDoc.Bookmarks.Add("fechan", ref rango3);
                    ObjDoc.Bookmarks.Add("ced", ref rango4);
                    ObjDoc.Bookmarks.Add("resultado", ref rango5);
                    ObjDoc.Bookmarks.Add("no", ref rango6);
                    ObjDoc.Bookmarks.Add("Resultado2", ref rango7);
                    ObjDoc.Bookmarks.Add("no2", ref rango8);
                    ObjDoc.Bookmarks.Add("fechae", ref rango9);
                    ObjDoc.Bookmarks.Add("dir", ref rango10);
                    ObjDoc.Bookmarks.Add("fecham", ref rango11);
                    var shape = ObjDoc.Bookmarks["image"].Range.InlineShapes.AddPicture(Application.StartupPath + @"\\qrimagen-" + PacienteID + ".png", false, true);
                    ObjWord.Visible = false;



                    if (File.Exists(rutasave))
                    {
                        File.Delete(rutasave);
                    }
                    ObjDoc.ExportAsFixedFormat(rutasave, Word.WdExportFormat.wdExportFormatPDF);
                    object DoNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                    ObjDoc.Close(ref DoNotSaveChanges);
                    ObjWord.Quit();
                    PDFDOC = System.IO.File.ReadAllBytes(rutasave);
                }
                if(Prueba == "Sars Cov-2" || Prueba == "Antigeno")
                {
                    object paciente = "paciente";
                    object edad = "edad";
                    object fechan = "fechan";
                    object ced = "ced";
                    object res = "resultado";
                    object ct = "no";
                    object fechae = "fechae";
                    object dire = "dir";
                    object fechamu = "fecham";
                    Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss, ReadOnly: true);
                    Word.Range nom = ObjDoc.Bookmarks.get_Item(ref paciente).Range;
                    nom.Text = PacienteNom;
                    Word.Range age = ObjDoc.Bookmarks.get_Item(ref edad).Range;
                    age.Text = Age;
                    Word.Range fech = ObjDoc.Bookmarks.get_Item(ref fechan).Range;
                    fech.Text = Fechan;
                    Word.Range cedu = ObjDoc.Bookmarks.get_Item(ref ced).Range;
                    cedu.Text = Ced;
                    Word.Range resu = ObjDoc.Bookmarks.get_Item(ref res).Range;
                    if (English == true)
                    {
                        if (Resultado == "Detectado")
                        {
                            resu.Text = "Detected";
                        }
                        if (Resultado == "No Detectado")
                        {
                            resu.Text = "Not Detected";
                        }
                        if (Resultado == "Indeterminado")
                        {
                            resu.Text = "Undetermined";
                        }
                        if (Resultado == "Positivo")
                        {
                            resu.Text = "Positive";
                        }
                        if (Resultado == "Negativo")
                        {
                            resu.Text = "Negative";
                        }
                    }
                    else
                    {
                        resu.Text = Resultado;
                    }
                    Word.Range cts = ObjDoc.Bookmarks.get_Item(ref ct).Range;
                    cts.Text = CT;
                    Word.Range fechaem = ObjDoc.Bookmarks.get_Item(ref fechae).Range;
                    fechaem.Text = cambiada1 + " / " + HoraEmision;
                    Word.Range direction = ObjDoc.Bookmarks.get_Item(ref dire).Range;
                    direction.Text = Dir;
                    Word.Range fechamue = ObjDoc.Bookmarks.get_Item(ref fechamu).Range;
                    fechamue.Text = DateTime.Parse(Fecham).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + " " + HoraMuestra;
                    object rango1 = nom;
                    object rango2 = age;
                    object rango3 = fech;
                    object rango4 = cedu;
                    object rango5 = resu;
                    object rango6 = cts;
                    object rango7 = fechaem;
                    object rango8 = direction;
                    object rango9 = fechamue;
                    ObjDoc.Bookmarks.Add("paciente", ref rango1);
                    ObjDoc.Bookmarks.Add("edad", ref rango2);
                    ObjDoc.Bookmarks.Add("fechan", ref rango3);
                    ObjDoc.Bookmarks.Add("ced", ref rango4);
                    ObjDoc.Bookmarks.Add("resultado", ref rango5);
                    ObjDoc.Bookmarks.Add("no", ref rango6);
                    ObjDoc.Bookmarks.Add("fechae", ref rango7);
                    ObjDoc.Bookmarks.Add("dir", ref rango8);
                    ObjDoc.Bookmarks.Add("fecham", ref rango9);
                    var shape = ObjDoc.Bookmarks["image"].Range.InlineShapes.AddPicture(Application.StartupPath + @"\\qrimagen-" + PacienteID + ".png", false, true);
                    ObjWord.Visible = false;

                    if (File.Exists(rutasave))
                    {
                        File.Delete(rutasave);
                        File.Delete(Application.StartupPath + @"\\qrimagen-" + PacienteID + ".png");
                    }
                    ObjDoc.ExportAsFixedFormat(rutasave, Word.WdExportFormat.wdExportFormatPDF);

                    object DoNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;

                    ObjDoc.Close(ref DoNotSaveChanges);
                    ObjWord.Quit();
                    PDFDOC = System.IO.File.ReadAllBytes(rutasave);
                }
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
                enviado = true;
            }
            catch
            {
                enviado = false;
            }
          


        }

        
        
        private void txtConsulta_Leave(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "")
            {
                txtConsulta.Text = "Digite nombre o cedula";
                txtConsulta.ForeColor = Color.Silver;
                GetData();
            }
        }

        private void txtConsulta_Enter(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "Digite nombre o cedula")
            {
                txtConsulta.Text = "";
                txtConsulta.ForeColor = Color.MidnightBlue;
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
           
               
            
            }

        public async Task sendmail(string mailto, string doc)
        {

            try
            {

                cm.GetMailSetup();

                string filename = @"C:\SGP\" + doc + "";
                var mailtxt = new MailMessage();

                mailtxt.To.Add(mailto);
                mailtxt.From = new MailAddress(cm.MailFrom, cm.MailName, System.Text.Encoding.UTF8);
                mailtxt.Subject = cm.MailSubject;
                mailtxt.IsBodyHtml = true;
                mailtxt.Body = cm.MailText;

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filename);
                mailtxt.Attachments.Add(attachment);

                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(cm.MailSMTP);

                client.Port = int.Parse(cm.MailPort);
                client.EnableSsl = cm.MailSSL;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                client.UseDefaultCredentials = true;
                NetworkCredential cred = new System.Net.NetworkCredential(cm.MailUser, cm.MailPass);

                client.Credentials = cred;
                client.SendAsync(mailtxt, null);

                enviado = true;
            }
            catch (Exception ex)
            {
                enviado = false;
            }
            }
        

        private void client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView2.Rows.Count > 0)
                {
                    dataGridView2.Rows.RemoveAt(this.dataGridView2.SelectedRows[0].Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione el registro que desea eliminar de la lista.");
            }
        }

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {


                using (var con = new SqlConnection(conect))
                {
                    try
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("spGetPruebasPendientes", con);
                        DataTable dt = new DataTable();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.AddWithValue("@Nombre", txtConsulta.Text);
                        da.SelectCommand.Parameters.AddWithValue("@Pruebas", "1");
                        da.Fill(dt);
                        this.radGridView1.DataSource = dt;
                        this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                        if (radGridView1.Columns[0].Name == "Column1")
                        {
                            radGridView1.Columns.Move(0, 9);
                        }


                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                }
            }
        }
       

        private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.Name == "Column1")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = System.Drawing.Color.WhiteSmoke;

               
              
            }
        }
       
        private void radGridView1_RowFormatting(object sender, RowFormattingEventArgs e)
        {

            if (e.RowElement.IsSelected)
            {
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = System.Drawing.Color.LightBlue;
                e.RowElement.DrawFill = true;
            }
            else
            {
                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
            }
        }
        public void ValidaEmpresa()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    string ct2 = "select pempresa from tbpacientes where pid = '" + PacienteID + "'";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        String Empresa = rdr[0].ToString();
                        if (Empresa.Length > 0)
                        {
                            validaEmpresa = true;
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }
        void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                GridViewRowInfo row = radGridView1.CurrentRow;
                PacienteID = (string)radGridView1.Rows[row.Index].Cells["ID del Paciente"].Value;
                PrID = (int)radGridView1.Rows[row.Index].Cells["ID de Prueba"].Value;
                ValidaEmpresa();
                if (validaEmpresa == true)
                {
                    MessageBox.Show("Este paciente pertenece a una empresa, los resultados no pueden ser reportados por esta via.", "Pruebas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    validaEmpresa = false;
                }
                else
                {
                    Resultsm resu = new Resultsm();
                    resu.pacID = Convert.ToInt32(PacienteID);
                    resu.PrID = PrID;
                    resu.ShowDialog();
                    if (resu.DialogResult == DialogResult.OK)
                    {
                        Resultado = resu.cbbResult.Text;
                        CT = resu.txtCt.Text;
                        PacienteNom = resu.lblname.Text;
                        Ced = resu.lblCed.Text;
                        Age = resu.lblage.Text;
                        Fechan = resu.lblFecha.Text;
                        Mail = resu.mail;
                        Dir = resu.dir;
                        Tipo = resu.lblTipo.Text;
                        Prueba = resu.lbltest.Text;
                        Fecham = resu.FechaMuestra;
                        Citas = resu.Citas;
                        Resultado2 = resu.cbbResults1.Text;
                        English = resu.Ingles;
                        CT2 = resu.txtCt1.Text;
                        if (resu.HoraMuestra != "")
                        {
                            HoraMuestra = DateTime.Parse(resu.HoraMuestra).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            HoraMuestra = "";
                        }
                        AddResults();
                    }
                }
            }
            catch
            {

            }
        }
        }
}
