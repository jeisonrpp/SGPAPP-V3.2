using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Word = Microsoft.Office.Interop.Word;

namespace SGPAPP
{
    public partial class frmPruebasEs : Telerik.WinControls.UI.RadForm
    {
        public frmPruebasEs()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        public String Age;
        public String mail;
        public String dir;
        String Sql;
        public int PruebaID;
        public String Pruebalab;
        String Prueba;
        public int pacID;
        public String Method;
        DateTime Fecha = DateTime.Now;
        String HoraMuestra;
        String FechaRegistro;      
        DateTime HoraRegistro = DateTime.Now;
        public String docname;
        String day;
        String mes;
        String year;
        public string cambiada1;
        public String FechaMuestra;
        byte[] PDFDOC;
        String Resultado;
        String Und;
        String Valoresref;
        public String Tipop;
        String prid;        
        clsMail cm = new clsMail();
        DataTable dt = new DataTable();
        String Test;
        int num = 0;
        clsRandomNo rd = new clsRandomNo();
       static int Rows;
        bool Merge = false;
        int es = 0;
        string[] fileArray;
        public int Counter;
        String Nofact;
        bool HIV = false;
        public bool Colotect = false;
        public bool Special = false;

        private void frmPruebasEs_Load(object sender, EventArgs e)
        {
            frmNoFact nf = new frmNoFact();
            nf.ShowDialog();
            if (nf.DialogResult == DialogResult.OK)
            {
                Nofact = nf.txtNoFact.Text;
                GetPaciente();
                GetPrueba();
            }
        }
      
        public void GetPaciente()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT RTRIM(pNom) as [Paciente], RTRIM(pced) as [Cedula], RTRIM(pFecha) as [Edad] , RTRIM(pemail) as [Email] , RTRIM(pdir) as [Direccion] from tbpacientes where pID = '" + pacID + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblname.Text = reader[0].ToString();
                        lblCed.Text = reader[1].ToString();
                        Age = reader[2].ToString();
                        if (Age == "1900-01-01")
                        {
                            lblage.Text = "-";
                            lblFecha.Text = "-";
                        }
                        else
                        {
                            Age = Convert.ToString(DateTime.Today.AddTicks(-DateTime.Parse(Age).Ticks).Year - 1);
                            lblage.Text = Age.ToString() + " años";
                            lblFecha.Text = reader[2].ToString();
                        }
                        mail = reader[3].ToString();
                        lblmail.Text = mail;
                        dir = reader[4].ToString();

                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado registro de paciente!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
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
            log.Accion = "Resultados Asignados a Prueba ID: " + PruebaID + " del Paciente: " + lblname.Text + "";
            log.Form = "Asignar Resultados";
            log.SaveLog();
        }
        public void GetPrueba()
        {
            //if (Counter > 1)
            //{
            //    DialogResult resulta = MessageBox.Show("Desea cargar todas las analiticas pendientes de este paciente?", "Reporte de Pruebas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (resulta == DialogResult.Yes)
            //    {
            //        using (var con = new SqlConnection(conect))
            //        {
            //            con.Open();
            //            SqlDataAdapter da = new SqlDataAdapter("spGetPruebasEspeciales", con);
            //            DataTable dt = new DataTable();
            //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //            da.SelectCommand.Parameters.AddWithValue("@Pacid", pacID);
            //            da.SelectCommand.Parameters.AddWithValue("@Pruebas", (object)DBNull.Value);
            //            da.Fill(dt);
            //            this.radGridView1.DataSource = dt;
            //            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            //            radGridView1.Columns[2].IsVisible = false;
            //            //radGridView1.Columns[4].IsVisible = false;
            //            radGridView1.Columns[5].IsVisible = false;
            //            radGridView1.Columns[6].IsVisible = false;
            //            radGridView1.Columns[7].IsVisible = false;
            //            radGridView1.Columns[10].IsVisible = false;
            //            radGridView1.Columns[11].IsVisible = false;
            //            radGridView1.Columns[12].IsVisible = false;
            //            radGridView1.Columns[4].ReadOnly = true;
            //            radGridView1.Columns[3].ReadOnly = true;
            //            radGridView1.Columns[8].ReadOnly = true;
            //            radGridView1.Columns[9].ReadOnly = true;
            //            radGridView1.Columns.Move(0, 11);

            //            con.Close();


            //            con.Open();
            //            cmd = new SqlCommand("SELECT Distinct(prDpto) as [Departamento] from tbPruebasPendientes inner join tbpruebas on ppTipo = prTipo where prLaboratorios = 1 and ppPacid = '" + pacID + "'", con);
            //            SqlDataAdapter myDA = new SqlDataAdapter(cmd);
            //            DataSet myDataSet = new DataSet();
            //            myDA.Fill(myDataSet, "Paciente");
            //            dataGridView1.DataSource = myDataSet.Tables["Paciente"].DefaultView;
            //            dataGridView1.Columns["Departamento"].DisplayIndex = 0;

            //            con.Close();
            //        }
            //    }
            //    else
            //    {
            //        using (var con = new SqlConnection(conect))
            //        {
            //            con.Open();
            //            SqlDataAdapter da = new SqlDataAdapter("spGetPruebasEspeciales", con);
            //            DataTable dt = new DataTable();
            //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //            da.SelectCommand.Parameters.AddWithValue("@Pacid", pacID);
            //            da.SelectCommand.Parameters.AddWithValue("@Pruebas", Tipop);
            //            da.Fill(dt);
            //            this.radGridView1.DataSource = dt;
            //            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            //            radGridView1.Columns[2].IsVisible = false;
            //            //radGridView1.Columns[4].IsVisible = false;
            //            radGridView1.Columns[5].IsVisible = false;
            //            radGridView1.Columns[6].IsVisible = false;
            //            radGridView1.Columns[7].IsVisible = false;
            //            radGridView1.Columns[10].IsVisible = false;
            //            radGridView1.Columns[11].IsVisible = false;
            //            radGridView1.Columns[12].IsVisible = false;
            //            radGridView1.Columns[4].ReadOnly = true;
            //            radGridView1.Columns[3].ReadOnly = true;
            //            radGridView1.Columns[8].ReadOnly = true;
            //            radGridView1.Columns[9].ReadOnly = true;
            //            radGridView1.Columns.Move(0, 11);

            //            con.Close();

            //            con.Open();
            //            cmd = new SqlCommand("SELECT Distinct(prDpto) as [Departamento] from tbPruebasPendientes inner join tbpruebas on ppTipo = prTipo where prLaboratorios = 1 and ppPacid = '" + pacID + "' and prTipo = '" + Tipop + "'", con);
            //            SqlDataAdapter myDA = new SqlDataAdapter(cmd);
            //            DataSet myDataSet = new DataSet();
            //            myDA.Fill(myDataSet, "Paciente");
            //            dataGridView1.DataSource = myDataSet.Tables["Paciente"].DefaultView;
            //            dataGridView1.Columns["Departamento"].DisplayIndex = 0;

            //            con.Close();
            //        }
            //    }
            //}
            //else
            //{
                using (var con = new SqlConnection(conect))
                {
                con.Open();
                string ct = "select repruebaID from tbpreresultados where repruebaid = " + PruebaID + "";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Esta prueba ya fue reportada y se encuentra pendiente de aprobacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    this.Close();
                }
                
                else
                {
                    con.Close();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetPruebasEspeciales", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@ppid", PruebaID);
                    da.SelectCommand.Parameters.AddWithValue("@Pruebas", Tipop);
                    da.SelectCommand.Parameters.AddWithValue("@Pacid", pacID);
                    da.SelectCommand.Parameters.AddWithValue("@special", Special);
                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    radGridView1.Columns[2].IsVisible = false;
                    //radGridView1.Columns[1].IsVisible = false;
                    radGridView1.Columns[5].IsVisible = false;
                    radGridView1.Columns[6].IsVisible = false;
                    radGridView1.Columns[7].IsVisible = false;
                    radGridView1.Columns[10].IsVisible = false;
                    radGridView1.Columns[11].IsVisible = false;
                    radGridView1.Columns[12].IsVisible = false;
                    radGridView1.Columns[4].ReadOnly = true;
                    radGridView1.Columns[3].ReadOnly = true;
                    radGridView1.Columns[8].ReadOnly = true;
                    radGridView1.Columns[9].ReadOnly = true;
                    radGridView1.Columns.Move(0, 11);
                    //if (radGridView1.RowCount == 1)
                    //{                    
                    //    radGridView1.Columns[0].ReadOnly = true;
                    //}
                    con.Close();

                    con.Open();
                    cmd = new SqlCommand("SELECT Distinct(prDpto) as [Departamento] from tbPruebasPendientes inner join tbpruebas on ppTipo = prTipo where prLaboratorios = 1 and ppPacid = '" + pacID + "' and prTipo = '" + Tipop + "'", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "Paciente");
                    dataGridView1.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                    dataGridView1.Columns["Departamento"].DisplayIndex = 0;

                    con.Close();
                }

            }
     
        }

        //}



        String testvalue;
        private void btnSav_Click(object sender, EventArgs e)
        {
            
            }
        string realname;
        public void GetPlantilla()
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                con.Open();
                using (SqlCommand cm = con.CreateCommand())
                {
                    if (Colotect == true)
                    {
                        foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
                        {
                            if (radGridView1.Rows[rowInfo.Index].Cells[11].Value != null)
                            {
                                Resultado = radGridView1.Rows[rowInfo.Index].Cells[11].Value.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Debe colocar un resultado: Negativo o Positivo, para reportar esta prueba.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                        if (Resultado == "Negativo" || Resultado == "negativo")
                        {
                            cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = 'Colotect neg'";
                        }
                        else if (Resultado == "Positivo" || Resultado == "positivo")
                        {
                            cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = 'Colotect pos'";
                        }
                        else
                        {
                            MessageBox.Show("Debe colocar un resultado: Negativo o Positivo, para reportar esta prueba.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = 'ALT'";
                    }
                    rd.GetNo();
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            realname = dr[1].ToString();
                            int size = 1024 * 1024;
                            byte[] buffer = new byte[size];
                            int readBytes = 0;
                            int index = 0;
                            string fileName = Application.StartupPath + @"\\resourses\" + rd.RandomNo + "-" + realname;
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

        

        public void EditPlantilla()
        {
            try
            {

                conviertefecha();
                //GetPlantilla();
                //System.IO.Directory.CreateDirectory(@"C:\SGP");
                //docname = lblname.Text + " - " + rd.RandomNo + " - " + cambiada1 + ".pdf";
                //object ObjMiss = System.Reflection.Missing.Value;
                //Word.Application ObjWord = new Word.Application();
                //string ruta = Application.StartupPath + @"\\resourses\" + rd.RandomNo + "-" + realname;
                //string rutasave = @"C:\SGP\" + docname + "";
                //object parametro = ruta;
                //object save = rutasave;
                //object paciente = "paciente";
                //object edad = "edad";
                //object fechan = "fechan";
                //object ced = "ced";
                //object DEPTO = "DEPTO";
                //object fechae = "fechae";
                //object dire = "dir";
                //object fechamu = "fecham";
                //object DefaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
                //object WdAutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
                //Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss, ReadOnly: true);
                //Word.Range nom = ObjDoc.Bookmarks.get_Item(ref paciente).Range;
                //nom.Text = lblname.Text;
                //Word.Range age = ObjDoc.Bookmarks.get_Item(ref edad).Range;
                //age.Text = lblage.Text;
                //Word.Range fech = ObjDoc.Bookmarks.get_Item(ref fechan).Range;
                //fech.Text = lblFecha.Text;
                //Word.Range cedu = ObjDoc.Bookmarks.get_Item(ref ced).Range;
                //cedu.Text = lblCed.Text;
                //Word.Range deptos = ObjDoc.Bookmarks.get_Item(ref DEPTO).Range;
                //deptos.Text = testvalue;
                //Word.Range fechaem = ObjDoc.Bookmarks.get_Item(ref fechae).Range;
                //fechaem.Text = cambiada1 + " / " + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                //Word.Range direction = ObjDoc.Bookmarks.get_Item(ref dire).Range;
                //direction.Text = dir;
                //Word.Range fechamue = ObjDoc.Bookmarks.get_Item(ref fechamu).Range;
                //fechamue.Text = DateTime.Parse(FechaMuestra).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                //Word.Table table = ObjDoc.Tables[2];
                //table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                //int i = 3;

                //String valmin;
                //String valmax;
                foreach (GridViewRowInfo rowInfo in radGridView1.Rows) //if (radGridView1.Rows[rowInfo.Index].Cells[0].Value == null && radGridView1.Rows[rowInfo.Index].Cells[2].Value.ToString() == testvalue || radGridView1.Rows[rowInfo.Index].Cells[0].Value == null && radGridView1.Rows[rowInfo.Index].Cells[2].Value.ToString() == "Hemograma")
                    {

                        int rowcount = radGridView1.Rows.Count;

                        PruebaID = int.Parse(radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString());
                        Prueba = radGridView1.Rows[rowInfo.Index].Cells[3].Value.ToString();
                        //if (Prueba == "HIV")
                        //{
                        //    HIV = true;
                        //}
                        if (radGridView1.Rows[rowInfo.Index].Cells[11].Value != null)
                        {
                            Resultado = radGridView1.Rows[rowInfo.Index].Cells[11].Value.ToString();
                        }
                        else
                        {
                            Resultado = "-";
                        }
                        Und = radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString();
                        Valoresref = radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString();
                        Tipop = radGridView1.Rows[rowInfo.Index].Cells[2].Value.ToString();
                    //    string result = "";
                    //    if (radGridView1.Rows[rowInfo.Index].Cells[9].Value.ToString() != "-" && radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString() != "-")
                    //    {
                    //        valmin = radGridView1.Rows[rowInfo.Index].Cells[9].Value.ToString();
                    //        valmax = radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString();
                    //        decimal value;
                    //        if (Resultado != "-" && Decimal.TryParse(Resultado, out value) && Double.Parse(Resultado) < Double.Parse(valmin))
                    //        {
                    //            result = " ↓ " + Resultado;
                    //        }
                    //        else if (Resultado != "-" && Decimal.TryParse(Resultado, out value) && Double.Parse(Resultado) > Double.Parse(valmax))
                    //        {
                    //            result = " ↑ " + Resultado;
                    //        }
                    //        else
                    //        {
                    //            result = Resultado;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        result = Resultado;
                    //}
                    //    table.Cell(i, 1).Range.Text = Prueba;
                    //    table.Cell(i, 2).Range.Text = result;
                    //    table.Cell(i, 3).Range.Text = Und;
                    //    table.Cell(i, 4).Range.Text = Valoresref;
                    //    if (i <= num)
                    //    {
                    //        i++;
                    //        table.Rows.Add(ref ObjMiss);
                    //    }

                        dataGridView2.Rows.Add(PruebaID, pacID, lblname.Text, dir, lblFecha.Text, lblage.Text, lblCed.Text, Tipop, Prueba, Resultado, "null", "null", "null", "null", cambiada1, FechaMuestra, HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture), HoraMuestra, "null");
                        
                    }

                //object rango1 = nom;
                //object rango2 = age;
                //object rango3 = fech;
                //object rango4 = cedu;
                //object rango5 = fechaem;
                //object rango6 = direction;
                //object rango7 = fechamue;
                //object rango8 = deptos;
                //ObjDoc.Bookmarks.Add("paciente", ref rango1);
                //ObjDoc.Bookmarks.Add("edad", ref rango2);
                //ObjDoc.Bookmarks.Add("fechan", ref rango3);
                //ObjDoc.Bookmarks.Add("ced", ref rango4);
                //ObjDoc.Bookmarks.Add("fechae", ref rango5);
                //ObjDoc.Bookmarks.Add("dir", ref rango6);
                //ObjDoc.Bookmarks.Add("fecham", ref rango7);
                //ObjDoc.Bookmarks.Add("DEPTO", ref rango8);
                //ObjWord.Visible = false;
                //if (File.Exists(rutasave))
                //{
                //    File.Delete(rutasave);
                //}
                
                //ObjDoc.ExportAsFixedFormat(rutasave, Word.WdExportFormat.wdExportFormatPDF);
                //object DoNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                //ObjDoc.Close(ref DoNotSaveChanges);
                //ObjWord.Quit();
                //if (File.Exists(ruta))
                //{
                //    File.Delete(ruta);
                //}

                //String doc = lblname.Text + " - " + rd.RandomNo + " - " + cambiada1 + ".pdf";

                //fileArray[es] = @"C:\SGP\" + doc;
                //es++;

                //if (Merge == true)
                //{
                //    string outputPdfPath;
                //    PdfReader reader = null;
                //    Document sourceDocument = null;
                //    PdfCopy pdfCopyProvider = null;
                //    PdfImportedPage importedPage;
                //    rd.GetNo();
                //    outputPdfPath = @"C:\SGP\" + lblname.Text + " - " + rd.RandomNo + " - " + Fecha.ToString("yyyy-MM-dd") + ".pdf";
                //    sourceDocument = new Document();
                //    pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

                //    //output file Open  
                //    sourceDocument.Open();


                //    //files list wise Loop  
                //    for (int f = 0; f < fileArray.Length; f++)
                //    {
                //        int pages = TotalPageCount(fileArray[f]);

                //        reader = new PdfReader(fileArray[f]);
                //        //Add pages in new file  
                //        for (int e = 1; e <= pages; e++)
                //        {
                //            importedPage = pdfCopyProvider.GetImportedPage(reader, e);
                //            pdfCopyProvider.AddPage(importedPage);
                //        }

                //        reader.Close();
                //    }

                //    sourceDocument.Close();
                //    PDFDOC = System.IO.File.ReadAllBytes(outputPdfPath);
                    InsertpreResults();
                frmLoadPDF lpdf = new frmLoadPDF();
                lpdf.Factid = Nofact;
                lpdf.ShowDialog();
                //if (HIV != true)
                //{
                //    //sendmail(mail, outputPdfPath);
                //}
                //Process prc = new Process();
                //prc.StartInfo.FileName = outputPdfPath;
                //prc.Start();
                if (lpdf.DialogResult == DialogResult.Yes)
                {
                    DialogResult resulta = MessageBox.Show("Desea procesar estos resultados?", "Procesar Resultados", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (resulta == DialogResult.Yes)
                    {
                        try
                        {
                            InsertResults();

                            //if (HIV != true)
                            //{
                            //    sendmail(mail, outputPdfPath);
                            //}
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                    else if (resulta == DialogResult.Cancel)
                    {
                        using (var con = new SqlConnection(conect))
                        {

                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {

                                PruebaID = (int)row.Cells["IDPrueba"].Value;
                                try
                                {
                                    String Sql = "delete from tbpreResultados where rePruebaID = '" + PruebaID + "'";

                                    SqlCommand cmd = new SqlCommand(Sql, con);
                                    cmd.CommandType = CommandType.Text;
                                    con.Open();


                                    int e = cmd.ExecuteNonQuery();
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
                    else if (resulta == DialogResult.No)
                    {

                    }
                }
                else if (lpdf.DialogResult == DialogResult.No)
                {
                    MessageBox.Show("El PDF ha tardado demasiado en generarse, puede consultar el PDF en Resultados Pendientes una vez se genere. En caso contrario consulte al Soporte del Sistema.", "Generacion PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                testvalue = "";
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      
        }
       
       
        private int TotalPageCount(string file)
        {
            using (StreamReader sr = new StreamReader(System.IO.File.OpenRead(file)))
            {
                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());

                return matches.Count;
            }
        }
        //public void sendmail(string mailto, string doc)
        //{
        //    try
        //    {
        //        cm.GetMailSetup();

        //        string filename = doc;
        //        var mailtxt = new MailMessage();

        //        mailtxt.To.Add(mailto);
        //        mailtxt.From = new MailAddress(cm.MailFrom, cm.MailName, System.Text.Encoding.UTF8);
        //        mailtxt.Subject = cm.MailSubject;
        //        mailtxt.IsBodyHtml = true;
        //        mailtxt.Body = cm.MailText;

        //        System.Net.Mail.Attachment attachment;
        //        attachment = new System.Net.Mail.Attachment(filename);
        //        mailtxt.Attachments.Add(attachment);

        //        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(cm.MailSMTP);

        //        client.Port = int.Parse(cm.MailPort);
        //        client.EnableSsl = cm.MailSSL;
        //        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
        //        client.UseDefaultCredentials = true;
        //        NetworkCredential cred = new System.Net.NetworkCredential(cm.MailUser, cm.MailPass);

        //        client.Credentials = cred;
        //        client.Send(mailtxt);

        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al enviar el correo, favor contactar el administrador." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        public void SendMail()
        {
            using (var con = new SqlConnection(conect))
            {

                String Query2 = "insert into tbControlMail (cmreid, cmpruebaempresaid, cmmail, cmfecha, cmhora, cmenviado, cmerror) values ((select reid from tbResultados where rePruebaID = " + PruebaID + " and repacid = " + pacID + "), '0', (select case when LEN(pemail2) >= 1  then pemail+', '+pemail2 else pEmail END from tbPacientes  where pid in (" + pacID + ")), '" + cambiada1 + "', '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', 0, NULL) ";
                cmd = new SqlCommand(Query2, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
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
                String Sql = "delete from tbPruebasPendientes where ppID = '" + PruebaID + "'";

                SqlCommand cmd = new SqlCommand(Sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }



        public void DelPreResult()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    String Sql = "delete from tbpreResultados where rePruebaID = '" + PruebaID + "'";

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
       
            public void InsertpreResults()
            {
                using (var con = new SqlConnection(conect))
                {
                    if (Special == true)
                    {
                        SqlCommand AddResultados = new SqlCommand("Insert into tbpreResultados values (@rePacid, @rePaciente, @reDir, @reFechan, @reEdad, @reCed, @reTipop, @rePrueba, @reResultado, @reCT, @reFecha, @refecham, @reHora, @reHoram, @PDFDOC, @reResultado1, @reResultado2, @reCT2, @reEmpresa, @rePruebaID, @reFacturacionID)", con);
                        con.Open();
                        try
                        {

                            int rowcount = dataGridView2.RowCount;
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                cmd = new SqlCommand(Sql, con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "spInsertPreResultados";
                                cmd.Parameters.Add(new SqlParameter("@resultado", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Results"].Value);
                                cmd.Parameters.Add(new SqlParameter("@resultado2", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["n3"].Value);
                                cmd.Parameters.Add(new SqlParameter("@ct", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["n2"].Value);
                                cmd.Parameters.Add(new SqlParameter("@ct2", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["n4"].Value);
                                cmd.Parameters.Add(new SqlParameter("@prueba", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Pruebas"].Value);
                                cmd.Parameters.Add(new SqlParameter("@pruebaid", SqlDbType.Int)).Value = Convert.ToString(row.Cells["IDPrueba"].Value);
                                cmd.ExecuteNonQuery();

                                if (rowcount == 1)
                                {
                                    AddResultados.Parameters.Clear();
                                    AddResultados.Parameters.AddWithValue("@rePacid", Convert.ToString(row.Cells["ID"].Value));
                                    AddResultados.Parameters.AddWithValue("@rePaciente", Convert.ToString(row.Cells["Nombre"].Value));
                                    AddResultados.Parameters.AddWithValue("@reDir", Convert.ToString(row.Cells["Direc"].Value));
                                    if (Convert.ToString(row.Cells["Fechan"].Value) == "-")
                                    {
                                        AddResultados.Parameters.AddWithValue("@reFechan", "1900-01-01");
                                    }
                                    else
                                    {
                                        AddResultados.Parameters.AddWithValue("@reFechan", Convert.ToString(row.Cells["Fechan"].Value));
                                    }

                                    AddResultados.Parameters.AddWithValue("@reEdad", Convert.ToString(row.Cells["Edad"].Value));
                                    AddResultados.Parameters.AddWithValue("@reCed", Convert.ToString(row.Cells["Cedu"].Value));
                                    AddResultados.Parameters.AddWithValue("@reTipop", Convert.ToString(row.Cells["Tipo"].Value));
                                    AddResultados.Parameters.AddWithValue("@rePrueba", Pruebalab);
                                    AddResultados.Parameters.AddWithValue("@reResultado", "-");
                                    AddResultados.Parameters.AddWithValue("@reResultado1", "-");
                                    AddResultados.Parameters.AddWithValue("@reCT", "-");
                                    AddResultados.Parameters.AddWithValue("@reResultado2", "-");
                                    AddResultados.Parameters.AddWithValue("@reCT2", "-");
                                    AddResultados.Parameters.AddWithValue("@reFecha", Convert.ToString(row.Cells["fechae"].Value));
                                    AddResultados.Parameters.AddWithValue("@reFecham", Convert.ToString(row.Cells["fecham"].Value));
                                    AddResultados.Parameters.AddWithValue("@reHoram", Convert.ToString(row.Cells["horam"].Value));
                                    AddResultados.Parameters.AddWithValue("@reHora", Convert.ToString(row.Cells["horae"].Value));
                                    AddResultados.Parameters.AddWithValue("@PDFDOC", SqlDbType.VarBinary).Value = System.Data.SqlTypes.SqlBinary.Null;
                                    AddResultados.Parameters.AddWithValue("@reEmpresa", SqlDbType.VarChar).Value = DBNull.Value;
                                    AddResultados.Parameters.AddWithValue("@rePruebaID", Convert.ToString(row.Cells["IDPrueba"].Value));
                                    AddResultados.Parameters.AddWithValue("@reFacturacionID", Nofact.ToString());
                                    AddResultados.ExecuteNonQuery();
                                    PruebaID = (int)row.Cells["IDPrueba"].Value;
                                    GeneratePDF();
                                    //DelPrueba();
                                }
                                rowcount = rowcount - 1;
                            }

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        finally
                        {
                            con.Close();
                        }
                        SaveLog();
                    }
                    else
                    {
                        //string Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF) values ('" + pacID + "', '" + lblname.Text + "', '" + dir + "', '" + lblFecha.Text + "', '" + lblage.Text + "', '" + lblCed.Text + "','" + Tipop + "', '" + Prueba + "', '" + Resultado + "', '" + null + "', '" + null + "', '" + null + "', '" + null + "','" + cambiada1 + "' , '" + FechaMuestra + "',  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + HoraMuestra + "', '" + null + "')";
                        SqlCommand AddResultados = new SqlCommand("Insert into tbpreResultados values (@rePacid, @rePaciente, @reDir, @reFechan, @reEdad, @reCed, @reTipop, @rePrueba, @reResultado, @reCT, @reFecha, @refecham, @reHora, @reHoram, @PDFDOC, @reResultado1, @reResultado2, @reCT2, @reEmpresa, @rePruebaID, @reFacturacionID)", con);
                        con.Open();
                        try
                        {
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                AddResultados.Parameters.Clear();
                                AddResultados.Parameters.AddWithValue("@rePacid", Convert.ToString(row.Cells["ID"].Value));
                                AddResultados.Parameters.AddWithValue("@rePaciente", Convert.ToString(row.Cells["Nombre"].Value));
                                AddResultados.Parameters.AddWithValue("@reDir", Convert.ToString(row.Cells["Direc"].Value));
                                if (Convert.ToString(row.Cells["Fechan"].Value) == "-")
                                {
                                    AddResultados.Parameters.AddWithValue("@reFechan", "1900-01-01");
                                }
                                else
                                {
                                    AddResultados.Parameters.AddWithValue("@reFechan", Convert.ToString(row.Cells["Fechan"].Value));
                                }

                                AddResultados.Parameters.AddWithValue("@reEdad", Convert.ToString(row.Cells["Edad"].Value));
                                AddResultados.Parameters.AddWithValue("@reCed", Convert.ToString(row.Cells["Cedu"].Value));
                                AddResultados.Parameters.AddWithValue("@reTipop", Convert.ToString(row.Cells["Tipo"].Value));
                                AddResultados.Parameters.AddWithValue("@rePrueba", Convert.ToString(row.Cells["Pruebas"].Value));
                                AddResultados.Parameters.AddWithValue("@reResultado", Convert.ToString(row.Cells["Results"].Value));
                                AddResultados.Parameters.AddWithValue("@reResultado1", Convert.ToString(row.Cells["n1"].Value));
                                AddResultados.Parameters.AddWithValue("@reCT", Convert.ToString(row.Cells["n2"].Value));
                                AddResultados.Parameters.AddWithValue("@reResultado2", Convert.ToString(row.Cells["n3"].Value));
                                AddResultados.Parameters.AddWithValue("@reCT2", Convert.ToString(row.Cells["n4"].Value));
                                AddResultados.Parameters.AddWithValue("@reFecha", Convert.ToString(row.Cells["fechae"].Value));
                                AddResultados.Parameters.AddWithValue("@reFecham", Convert.ToString(row.Cells["fecham"].Value));
                                AddResultados.Parameters.AddWithValue("@reHoram", Convert.ToString(row.Cells["horam"].Value));
                                AddResultados.Parameters.AddWithValue("@reHora", Convert.ToString(row.Cells["horae"].Value));
                                AddResultados.Parameters.AddWithValue("@PDFDOC", SqlDbType.VarBinary).Value = System.Data.SqlTypes.SqlBinary.Null;
                                AddResultados.Parameters.AddWithValue("@reEmpresa", SqlDbType.VarChar).Value = DBNull.Value;
                                AddResultados.Parameters.AddWithValue("@rePruebaID", Convert.ToString(row.Cells["IDPrueba"].Value));
                                AddResultados.Parameters.AddWithValue("@reFacturacionID", Nofact.ToString());
                                AddResultados.ExecuteNonQuery();
                                PruebaID = (int)row.Cells["IDPrueba"].Value;
                                //DelPrueba();
                                GeneratePDF();
                            }

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        finally
                        {
                            con.Close();
                        }
                        SaveLog();
                    }
                }
            }
        
        public void InsertResults()
        {
            using (var con = new SqlConnection(conect))
            {
                if (Special == true)
                {
                    SqlCommand AddResultados = new SqlCommand("Insert into tbResultados values (@rePacid, @rePaciente, @reDir, @reFechan, @reEdad, @reCed, @reTipop, @rePrueba, @reResultado, @reCT, @reFecha, @refecham, @reHora, @reHoram, (select redocpdf from tbpreresultados where repruebaid = '" + PruebaID + "'), @reResultado1, @reResultado2, @reCT2, @reEmpresa, @rePruebaID, @reFacturacionID)", con);
                    con.Open();
                    try
                    {

                        int rowcount = dataGridView2.RowCount;
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            cmd = new SqlCommand(Sql, con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spInsertPreResultados";
                            cmd.Parameters.Add(new SqlParameter("@resultado", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Results"].Value);
                            cmd.Parameters.Add(new SqlParameter("@resultado2", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["n3"].Value);
                            cmd.Parameters.Add(new SqlParameter("@ct", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["n2"].Value);
                            cmd.Parameters.Add(new SqlParameter("@ct2", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["n4"].Value);
                            cmd.Parameters.Add(new SqlParameter("@prueba", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Pruebas"].Value);
                            cmd.Parameters.Add(new SqlParameter("@pruebaid", SqlDbType.Int)).Value = Convert.ToString(row.Cells["IDPrueba"].Value);
                            cmd.ExecuteNonQuery();

                            if (rowcount == 1)
                            {
                                AddResultados.Parameters.Clear();
                                AddResultados.Parameters.AddWithValue("@rePacid", Convert.ToString(row.Cells["ID"].Value));
                                AddResultados.Parameters.AddWithValue("@rePaciente", Convert.ToString(row.Cells["Nombre"].Value));
                                AddResultados.Parameters.AddWithValue("@reDir", Convert.ToString(row.Cells["Direc"].Value));
                                if (Convert.ToString(row.Cells["Fechan"].Value) == "-")
                                {
                                    AddResultados.Parameters.AddWithValue("@reFechan", "1900-01-01");
                                }
                                else
                                {
                                    AddResultados.Parameters.AddWithValue("@reFechan", Convert.ToString(row.Cells["Fechan"].Value));
                                }

                                AddResultados.Parameters.AddWithValue("@reEdad", Convert.ToString(row.Cells["Edad"].Value));
                                AddResultados.Parameters.AddWithValue("@reCed", Convert.ToString(row.Cells["Cedu"].Value));
                                AddResultados.Parameters.AddWithValue("@reTipop", Convert.ToString(row.Cells["Tipo"].Value));
                                AddResultados.Parameters.AddWithValue("@rePrueba", Pruebalab);
                                AddResultados.Parameters.AddWithValue("@reResultado", "-");
                                AddResultados.Parameters.AddWithValue("@reResultado1", "-");
                                AddResultados.Parameters.AddWithValue("@reCT", "-");
                                AddResultados.Parameters.AddWithValue("@reResultado2", "-");
                                AddResultados.Parameters.AddWithValue("@reCT2", "-");
                                AddResultados.Parameters.AddWithValue("@reFecha", Convert.ToString(row.Cells["fechae"].Value));
                                AddResultados.Parameters.AddWithValue("@reFecham", Convert.ToString(row.Cells["fecham"].Value));
                                AddResultados.Parameters.AddWithValue("@reHoram", Convert.ToString(row.Cells["horam"].Value));
                                AddResultados.Parameters.AddWithValue("@reHora", Convert.ToString(row.Cells["horae"].Value));
                                //AddResultados.Parameters.AddWithValue("@PDFDOC", SqlDbType.VarBinary).Value = PDFDOC;
                                AddResultados.Parameters.AddWithValue("@reEmpresa", SqlDbType.VarChar).Value = DBNull.Value;
                                AddResultados.Parameters.AddWithValue("@rePruebaID", Convert.ToString(row.Cells["IDPrueba"].Value));
                                AddResultados.Parameters.AddWithValue("@reFacturacionID", Nofact.ToString());
                                AddResultados.ExecuteNonQuery();
                                PruebaID = (int)row.Cells["IDPrueba"].Value;
                                DelPrueba();
                                DelPreResult();
                                SendMail();

                            }
                            rowcount = rowcount - 1;
                        }

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    finally
                    {
                        con.Close();
                    }
                    SaveLog();
                }
                else
                {
                    //string Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF) values ('" + pacID + "', '" + lblname.Text + "', '" + dir + "', '" + lblFecha.Text + "', '" + lblage.Text + "', '" + lblCed.Text + "','" + Tipop + "', '" + Prueba + "', '" + Resultado + "', '" + null + "', '" + null + "', '" + null + "', '" + null + "','" + cambiada1 + "' , '" + FechaMuestra + "',  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + HoraMuestra + "', '" + null + "')";
                    SqlCommand AddResultados = new SqlCommand("Insert into tbResultados values (@rePacid, @rePaciente, @reDir, @reFechan, @reEdad, @reCed, @reTipop, @rePrueba, @reResultado, @reCT, @reFecha, @refecham, @reHora, @reHoram, (select redocpdf from tbpreresultados where repruebaid = '" + PruebaID + "'), @reResultado1, @reResultado2, @reCT2, @reEmpresa, @rePruebaID, @reFacturacionID)", con);
                    con.Open();
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            AddResultados.Parameters.Clear();
                            AddResultados.Parameters.AddWithValue("@rePacid", Convert.ToString(row.Cells["ID"].Value));
                            AddResultados.Parameters.AddWithValue("@rePaciente", Convert.ToString(row.Cells["Nombre"].Value));
                            AddResultados.Parameters.AddWithValue("@reDir", Convert.ToString(row.Cells["Direc"].Value));
                            if (Convert.ToString(row.Cells["Fechan"].Value) == "-")
                            {
                                AddResultados.Parameters.AddWithValue("@reFechan", "1900-01-01");
                            }
                            else
                            {
                                AddResultados.Parameters.AddWithValue("@reFechan", Convert.ToString(row.Cells["Fechan"].Value));
                            }

                            AddResultados.Parameters.AddWithValue("@reEdad", Convert.ToString(row.Cells["Edad"].Value));
                            AddResultados.Parameters.AddWithValue("@reCed", Convert.ToString(row.Cells["Cedu"].Value));
                            AddResultados.Parameters.AddWithValue("@reTipop", Convert.ToString(row.Cells["Tipo"].Value));
                            AddResultados.Parameters.AddWithValue("@rePrueba", Convert.ToString(row.Cells["Pruebas"].Value));
                            AddResultados.Parameters.AddWithValue("@reResultado", Convert.ToString(row.Cells["Results"].Value));
                            AddResultados.Parameters.AddWithValue("@reResultado1", Convert.ToString(row.Cells["n1"].Value));
                            AddResultados.Parameters.AddWithValue("@reCT", Convert.ToString(row.Cells["n2"].Value));
                            AddResultados.Parameters.AddWithValue("@reResultado2", Convert.ToString(row.Cells["n3"].Value));
                            AddResultados.Parameters.AddWithValue("@reCT2", Convert.ToString(row.Cells["n4"].Value));
                            AddResultados.Parameters.AddWithValue("@reFecha", Convert.ToString(row.Cells["fechae"].Value));
                            AddResultados.Parameters.AddWithValue("@reFecham", Convert.ToString(row.Cells["fecham"].Value));
                            AddResultados.Parameters.AddWithValue("@reHoram", Convert.ToString(row.Cells["horam"].Value));
                            AddResultados.Parameters.AddWithValue("@reHora", Convert.ToString(row.Cells["horae"].Value));
                            AddResultados.Parameters.AddWithValue("@reEmpresa", SqlDbType.VarChar).Value = DBNull.Value;
                            AddResultados.Parameters.AddWithValue("@rePruebaID", Convert.ToString(row.Cells["IDPrueba"].Value));
                            AddResultados.Parameters.AddWithValue("@reFacturacionID", Nofact.ToString());
                            AddResultados.ExecuteNonQuery();
                            PruebaID = (int)row.Cells["IDPrueba"].Value;
                            DelPrueba();
                            DelPreResult();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    finally
                    {
                        con.Close();
                    }
                    SaveLog();
                }
            }
        }

        public void GeneratePDF()
        {
            using (var con = new SqlConnection(conect))
            {
                String Query = "insert into tbcontrolpdf (cpreid, cppacid, cpgenerate, cpfecha, cphora, cpuser, cpenglish) values ((select reid from tbpreResultados where rePruebaID = " + PruebaID + " and repacid = " + pacID + "), " + pacID + ", '0', '" + cambiada1 + "', '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + UserCache.Usuario + "', @English) ";
                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@English", 0);
                cmd.CommandType = CommandType.Text;

                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
        }


        public void UpdatePlantilla()
        {
            using (var con = new SqlConnection(conect))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    cmd.CommandText = @"update tbresultados set reDocPDF = @DOC where reID = (select max(reid) from tbResultados where repacid = "+pacID+")";
                    cmd.Parameters.AddWithValue("@DOC", SqlDbType.VarBinary).Value = PDFDOC;
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
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSdr_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void radGridView1_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
           
        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void radGridView1_RowFormatting(object sender, RowFormattingEventArgs e)
        {

        }

        private void radGridView1_CreateRow(object sender, GridViewCreateRowEventArgs e)
        {

        }

        private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bool Results = false;

                Rows = dataGridView1.Rows.Count;
                fileArray = new string[Rows];

                for (int counter = 0; counter < dataGridView1.RowCount; counter++)
                {
                    num = 0;
                    testvalue = dataGridView1.Rows[counter].Cells["Departamento"].Value.ToString();
                    foreach (GridViewRowInfo rowInfo in radGridView1.Rows) if (radGridView1.Rows[rowInfo.Index].Cells[0].Value == null && radGridView1.Rows[rowInfo.Index].Cells[2].Value.ToString() == testvalue || radGridView1.Rows[rowInfo.Index].Cells[0].Value == null && radGridView1.Rows[rowInfo.Index].Cells[2].Value.ToString() == "Hemograma")
                        {
                            
                            num++;
                        }
                    if (counter >= dataGridView1.RowCount - 1)
                    {
                        Merge = true;
                    }
                    num = num + 1;

                    EditPlantilla();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
