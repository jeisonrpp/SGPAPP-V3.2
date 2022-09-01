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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime;
using System.Runtime.InteropServices;
using Telerik.WinControls;
namespace SGPAPP
{
    public partial class frmResultsO : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;

        public frmResultsO()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn3 = new GridViewCommandColumn();
            commandColumn3.Name = "commandColumn3";
            commandColumn3.UseDefaultText = true;
            commandColumn3.Image = Properties.Resources.icons8_checkmark_16;
            commandColumn3.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn3.FieldName = "select";
            commandColumn3.HeaderText = "Seleccionar";
            radGridView5.MasterTemplate.Columns.Add(commandColumn3);
            radGridView5.CommandCellClick += new CommandCellClickEventHandler(radGridView5_CommandCellClick);
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        DateTime Fecharegi;
        byte[] PDFDOC;
        SqlCommand cmd = null;
        String cambiada1;
        String cambiada2;
        String docname;
        String QrLink;
        String ResultID;
        String PacienteId;
        String Nombre;
        String Ced = "";
        String Fechan;
        bool English = false;
        string Empresa;
        string Fechareg;
        bool existe = false;
        String ID;
        String Pac;
        public String Tipop;
        public String Prueba;
        public String Metodo;
        public String Time;
        String CED = "";
        bool Pruebas = false;
        bool Pnew = false;
        bool validapr;
        string realname;
        int PrID;
        String Resultado;
        String CT;
        String Resultado2;
        String CT2;
        String PacienteNom;
        String Age;
        String Mail;
        String Dir;
        String Tipo;
        String Fecham;
        bool Citas;
        String HoraMuestra;
        int EmpresaID;
        String HoraEmision;
        bool enviado;
        DateTime Fecha = DateTime.Now;

        public void CargaEmpresas()
        {

            using (var con = new SqlConnection(conect))
            {

                String fechar = Fecharegi.ToString();
                int Rows;
                Rows = dataGridView5.RowCount - 1;
                try
                {
                    con.Open();
                    cmd = new SqlCommand("select  Distinct b.ppId as [ID de Prueba], RTRIM(b.ppPacid) as [ID del Paciente], RTRIM(b.ppPrueba) as [Prueba] , RTRIM(b.ppfecha) as [Fecha]  from tbPacientes a join tbPruebasPendientes b on a.pId = b.ppPacid JOIN tbEmpresas c on a.pEmpresa = c.EmNom where a.pEmpresa = '" + Empresa + "'", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "Paciente");
                    dataGridView5.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                    dataGridView5.Columns["ID de Prueba"].Visible = false;
                    dataGridView5.Columns["ID del Paciente"].DisplayIndex = 0;

                    con.Close();
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
                        else if (Prueba == "Antigeno" && English == true)
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
                                string fileName = Application.StartupPath + @"\\resourses\" + PacienteId + "-" + realname;
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
        public void EditPlantilla()
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
                imagen.Save("qrimagen-" + PacienteId + ".png", ImageFormat.Png);

                getPlantilla();
                System.IO.Directory.CreateDirectory(@"C:\SGP");
                docname = PacienteNom + " - " + cambiada1 + ".pdf";
                object ObjMiss = System.Reflection.Missing.Value;
                Word.Application ObjWord = new Word.Application();
                string ruta = Application.StartupPath + @"\\resourses\" + PacienteId + "-plantillaresults.docx";
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
                    var shape = ObjDoc.Bookmarks["image"].Range.InlineShapes.AddPicture(Application.StartupPath + @"\\qrimagen-" + PacienteId + ".png", false, true);
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
                if (Prueba == "Sars Cov-2" || Prueba == "Antigeno")
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

                    var shape = ObjDoc.Bookmarks["image"].Range.InlineShapes.AddPicture(Application.StartupPath + @"\\qrimagen-" + PacienteId + ".png", false, true);
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
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                    File.Delete(Application.StartupPath + @"\\qrimagen-" + PacienteId + ".png");
                }

                dataGridView4.Rows.Add(docname, PacienteId);
                enviado = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                enviado = false;
            }

        }
        public void sendmail(string mailto)
        {
            clsMail cm = new clsMail();

            if (enviado == false)
            {
                try
                {

                    cm.GetMailSetup();


                    var mailtxt = new MailMessage();

                    mailtxt.To.Add(mailto);
                    mailtxt.From = new MailAddress(cm.MailFrom, cm.MailName, System.Text.Encoding.UTF8);
                    mailtxt.Subject = cm.MailSubject;
                    mailtxt.IsBodyHtml = true;
                    mailtxt.Body = "Saludos, Adjunto a este correo, se encuentran los resultados de las pruebas solicitadas.";

                    System.Net.Mail.Attachment attachment;
                    //attachment = new System.Net.Mail.Attachment(filename);
                    foreach (DataGridViewRow row in dataGridView4.Rows)
                    {
                        string doc = (string)row.Cells["pdocname"].Value;
                        PacienteId = (string)row.Cells["paid"].Value;

                        string filename = @"C:\SGP\" + doc + "";
                        attachment = new System.Net.Mail.Attachment(filename);
                        mailtxt.Attachments.Add(attachment);

                    }

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
        }
        private void txtConsultaR_TextChanged(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetEmpresas", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", txtConsultaR.Text);
                    da.SelectCommand.Parameters.AddWithValue("@Prueba", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@Resultados", "Si");
                    da.Fill(dt);
                    this.radGridView5.DataSource = dt;
                    this.radGridView5.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    radGridView5.Columns[6].IsVisible = false;
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }

        public void GetDataR()
        {


            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetEmpresas", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@Prueba", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@Resultados", "Si");
                    da.Fill(dt);
                    this.radGridView5.DataSource = dt;
                    this.radGridView5.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    if (radGridView5.Columns[0].Name == "commandColumn3")
                    {
                        radGridView5.Columns.Move(0, 4);
                    }
                    radGridView5.Columns[5].IsVisible = false;
                    radGridView5.Columns[6].IsVisible = false;
                    con.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }

        }

        private void btnRs_Click(object sender, EventArgs e)
        {
           
        }
        public void ResultadoEmpresa()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "update tbEmpresas set emResultados = 1 where emnom = '" + Empresa + "'";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        SaveLog();
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
        public void DelPrueba()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    String Sql = "delete from tbPruebasPendientes where ppid = '" + PrID + "'";

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
        public void SaveLog()
        {
            Logs log = new Logs();
            log.Accion = "Paciente: " + Nombre + " Guardado";
            log.Form = "Registro de Pacientes: Empresas";
            log.SaveLog();

        }
        public void GetResultID()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT Max(reiD) as [ID] from tbresultados";
                try
                {
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
        void radGridView5_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
      
                if (UserCache.EmpresaRoles.Any(item => item.EmpresaRol == (string)e.Row.Cells["Empresa"].Value) || UserCache.EmpresaRoles.Any(item => item.EmpresaRol == "Todas*"))
                {

                    Empresa = (string)e.Row.Cells["Empresa"].Value;
                    Fecharegi = (DateTime)e.Row.Cells["Fecha Registro"].Value;
                    EmpresaID = (int)e.Row.Cells["ID de Lote"].Value;
                    Mail = (string)e.Row.Cells["Email"].Value;

                    frmReportO rp = new frmReportO();
                    rp.Empresa = Empresa;
                    rp.mail = Mail;
                    rp.PruebaEmpresa = (int)e.Row.Cells["Prueba ID"].Value;
                    rp.LoteID = EmpresaID;
                    rp.ShowDialog();
                    if (rp.DialogResult == DialogResult.OK)
                    {
                        GetDataR();
                    }
                }


                else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
            catch
            {

            }
        }
        public void AddResults()
        {
          
        }
        private void btndel_Click(object sender, EventArgs e)
        {
 
        }

        private void frmResultsO_Load(object sender, EventArgs e)
        {
            GetDataR();
        
        }
      
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtConsultaR_Enter(object sender, EventArgs e)
        {
            if (txtConsultaR.Text == "Digite Nombre de la Empresa")
            {
                txtConsultaR.Text = "";
                txtConsultaR.ForeColor = Color.MidnightBlue;
            }
        }

        private void txtConsultaR_Leave(object sender, EventArgs e)
        {
            if (txtConsultaR.Text == "")
            {
                txtConsultaR.Text = "Digite Nombre de la Empresa";
                txtConsultaR.ForeColor = Color.Silver;


            }
        }
    }
}
