using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using Word = Microsoft.Office.Interop.Word;

namespace SGPAPP
{
    public partial class frmResultsNew : Telerik.WinControls.UI.RadForm
    {
        public frmResultsNew()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        int PruebaID;
        int Prueba = 10;
        int CantidadRes;
        public int pacID;
        public int PrID;
        public String Method;
        String docname;
        DateTime Fecha = DateTime.Now;
        public String Age;
        String HoraMuestra;
        String FechaMuestra;
        String FechaRegistro;
        public String mail;
        public String dir;
        string cambiada1;
        String day;
        String mes;
        String year;
        byte[] PDFDOC;
        String QrLink;
        String ResultID;
        string realname;
        bool Printed;
        bool Enviado = false;
        DateTime HoraRegistro = DateTime.Now;
        clsMail cm = new clsMail();
        public void GetComportamiento()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    int Rows;
                    Rows = dataGridView2.RowCount - 1;
                    con.Open();
                    cmd = new SqlCommand("select  cpResultados as [Campo] from tbComportamiento where cpPruebaID = " + Prueba + "", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    dataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                    dataGridView2.RowHeadersVisible = false;
                    myDA.Fill(myDataSet, "Usuario");
                    dataGridView2.DataSource = myDataSet.Tables["Usuario"].DefaultView;

                    dataGridView2.Columns["Campo"].DisplayIndex = 0;
                    con.Close();
                    panel1.Controls.Clear();
                    int pointX = 180;
                    int pointY = 40;
                    int lpointX = 10;
                    int lpointY = 43;

                    int pointX2 = 490;
                    int pointY2 = 40;
                    int lpointX2 = 320;
                    int lpointY2 = 43;

                    int Rowscount = 0;
                 
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            Rowscount++;
                            if (Rowscount <= 5)
                            {
                                TextBox a = new TextBox();
                                //a.Name = "txt" + Rowscount.ToString();
                                a.Location = new Point(pointX, pointY);
                                a.Size = new Size(150, 20);
                                panel1.Controls.Add(a);
                                panel1.Show();
                                pointY += 30;
                                Label sea = new Label();
                                //sea.Name = "lbl" + Rowscount.ToString();
                                sea.TextAlign = ContentAlignment.MiddleRight;
                                sea.Text = (string)row.Cells["Campo"].Value;
                                sea.Size = new Size(150, 13);
                                sea.Location = new Point(lpointX, lpointY);
                                panel1.Controls.Add(sea);
                                panel1.Show();
                                lpointY += 30;
                            }
                            else
                            {
                                TextBox a = new TextBox();
                                a.Location = new Point(pointX2, pointY2);
                                a.Size = new Size(150, 20);
                                panel1.Controls.Add(a);
                                panel1.Show();
                                pointY2 += 30;
                                Label sea = new Label();
                                sea.TextAlign = ContentAlignment.MiddleRight;
                                sea.Text = (string)row.Cells["Campo"].Value;
                                sea.Size = new Size(150, 13);
                                sea.Location = new Point(lpointX2, lpointY2);
                                panel1.Controls.Add(sea);
                                panel1.Show();
                                lpointY2 += 30;
                            }
                            //if(dataGridView2.Rows.Count > 5)
                            //{
                            //    MessageBox.Show("Funciona");
                            //}
                            //int ID = (int)row.Cells["ID de Comportamiento"].Value;
                            //String Campo = (string)row.Cells["Campo"].Value;

                            //dataGridView2.Rows.Add(Campo);
                        }                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int txtno1 = 5;
                int labelno1 = 5;
                int pointX = 30;
                int pointY = 40;
                int lpointX = 10;
                int lpointY = 43;

                int txtno2 = 10;
                int labelno2 = 5;
                int pointX2 = 290;
                int pointY2 = 40;
                int lpointX2 = 250;
                int lpointY2 = 43;
                panel1.Controls.Clear();
                for (int i = 0; i < txtno1; i++)
                {
                    TextBox a = new TextBox();
                    a.Text = (i + 1).ToString();
                    a.Location = new Point(pointX, pointY);
                    panel1.Controls.Add(a);
                    panel1.Show();
                    pointY += 30;

                    Label sea = new Label();
                    sea.Text = (i + 1).ToString();
                    sea.Location = new Point(lpointX, lpointY);
                    panel1.Controls.Add(sea);
                    panel1.Show();
                    lpointY += 30;

                }
                for (int i = 5; i < txtno2; i++)
                {
                    TextBox a2 = new TextBox();
                    a2.Text = (i + 1).ToString();
                    a2.Location = new Point(pointX2, pointY2);
                    panel1.Controls.Add(a2);
                    panel1.Show();
                    pointY2 += 30;

                    Label sea2 = new Label();
                    sea2.Text = (i + 1).ToString();
                    sea2.Location = new Point(lpointX2, lpointY2);
                    panel1.Controls.Add(sea2);
                    panel1.Show();
                    lpointY2 += 30;
                }


                int se = 0;
                foreach (Control cComprobar in panel1.Controls)
                {
                    if (cComprobar is TextBox)
                    {
                        se++;
                        //label8.Text = se.ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            String Label = "";
            String Txt = "";
            bool tx = false;
            bool lb = false;
            foreach (Control cComprobar in panel1.Controls)
            {

                if (cComprobar is Label)
                {
                    Label = cComprobar.Text;
                    lb = true;
                }
                if (cComprobar is TextBox)
                {
                    Txt = cComprobar.Text;
                    tx = true;
                }

                if (lb == true && tx == true)
                {
                    dataGridView1.Rows.Add(Label, Txt);
                    lb = false;
                    tx = false;
                }
            }

            //int see = 0;

            //foreach (Control cComprobar in panel1.Controls)
            //{
            //    if (cComprobar is TextBox)
            //    {
            //        see++;
            //        if (see ==6)
            //        {
            //            MessageBox.Show("Prueba");
            //        }
            //        //label8.Text = cComprobar.Text;
            //    }

            //}
        }

        private void frmResultsNew_Load(object sender, EventArgs e)
        {
            GetPaciente();
            GetPrueba();
        }
        public void GetPrueba()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT RTRIM(ppID) as [ID], RTRIM(ppTipo) as [Tipo], RTRIM(ppPrueba) as [Prueba] , RTRIM(ppFecha) as [Fecha de Muestra], RTRIM(ppHora) as [Hora de Muestra], RTRIM(ppHora) as [Hora de Muestra], RTRIM(ppmetodo) as [Metodo] from tbPruebasPendientes where ppID = '13586'"/*'" + PrID + "'*/;

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        PruebaID = int.Parse(reader[0].ToString());
                        lblTipo.Text = reader[1].ToString();
                        lbltest.Text = reader[2].ToString();
                        FechaRegistro = reader[3].ToString();
                        HoraMuestra = reader[4].ToString();
                        Method = reader[6].ToString();
                        if (HoraMuestra != "")
                        {
                            HoraMuestra = DateTime.Parse(HoraMuestra).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            HoraMuestra = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado registro de pruebas!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                    GetComportamiento();
                }
            }
        }
        public void GetPaciente()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT RTRIM(pNom) as [Paciente], RTRIM(pced) as [Cedula], RTRIM(pFecha) as [Edad] , RTRIM(pemail) as [Email] , RTRIM(pdir) as [Direccion] from tbpacientes where pID = '10608'"/* '"+ pacID +"' */;

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

        private void button3_Click(object sender, EventArgs e)
        {
            GetComportamiento();
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
        public void GetResultID()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT Max(reiD) as [ID] from tbresultados";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
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
        public void DelPrueba()
        {
            using (var con = new SqlConnection(conect))
            {
                String Sql = "delete from tbPruebasPendientes where ppID = '" + PrID + "'";

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
        private void btnSav_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Esta seguro que desea procesar", "Procesar Resultados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                String Fechar;
                if (lblFecha.Text == "-")
                {
                    Fechar = "1900-01-01";
                }
                else
                {
                    Fechar = lblFecha.Text;
                }
                FechaMuestra = FechaRegistro;
                //using (var con = new SqlConnection(conect))
                //{
                    conviertefecha();
                    GetResultID();
 
                    EditPlantilla();

                    if (Printed == true && Method == "Impreso")
                    {
                        MessageBox.Show("Resultados generados satisfactoriamente.", "Operacion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DelPrueba();
                    }
                    else if (Printed == false && Method == "Impreso")
                    {
                        MessageBox.Show("Ha ocurrido un error al general los resultados, Contacte al Administrador.", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Method == "Consulta Web")
                    {
                        MessageBox.Show("Resultados generados satisfactoriamente.", "Operacion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DelPrueba();
                    }
                    //String Resultado;
                    //if (cbbResult.Text == "Detectado" && lbltest.Text == "Influenza" || cbbResults1.Text == "Detectado" && lbltest.Text == "Influenza")
                    //{
                    //    Resultado = "Detectado";
                    //}
                    //else if (cbbResult.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid" || cbbResults1.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid")
                    //{
                    //    Resultado = "Positivo";
                    //}
                    //else
                    //{
                    //    Resultado = cbbResult.Text;
                    //}
                    //string Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF) values ('" + pacID + "', '" + lblname.Text + "', '" + dir + "', '" + Fechar + "', '" + lblage.Text + "', '" + lblCed.Text + "','" + lblTipo.Text + "', '" + lbltest.Text + "', '" + Resultado + "', '" + cbbResult.Text + "', '" + txtCt.Text + "', '" + cbbResults1.Text + "', '" + txtCt1.Text + "','" + cambiada1 + "' , '" + FechaMuestra + "', '" + HoraMuestra + "', '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', @PDFDOC)";
                    //cmd = new SqlCommand(Sql, con);
                    //cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.Add("@PDFDOC", SqlDbType.VarBinary).Value = PDFDOC;
                    //con.Open();
                    try
                    {
                        //int i = cmd.ExecuteNonQuery();
                        if (Method == "Consulta Web")
                        {
                            String doc = lblname.Text + " - " + cambiada1 + ".pdf";
                            sendmail(mail, doc);
                        }
                        //if (Citas == true)
                        //{
                        //    UpdateCitas();
                        //}

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.ToString());
                    }
                    finally
                    {
                        //con.Close();
                    }
                    SaveLog();

                //}
            }

        }
        public void sendmail(string mailto, string doc)
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
                client.Send(mailtxt);
                Enviado = true;
            }

            catch (Exception ex)
            {
                Enviado = false;
            }
        }
        public void getPlantilla()
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                con.Open();
                using (SqlCommand cm = con.CreateCommand())
                {
                   
                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = '" + lbltest.Text + "'  ";               

                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            realname = dr[1].ToString();
                            int size = 1024 * 1024;
                            byte[] buffer = new byte[size];
                            int readBytes = 0;
                            int index = 0;
                            string fileName = Application.StartupPath + @"\\resourses\" + pacID + "-" + realname;
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
        public void EditPlantilla()
        {
            getPlantilla();
            System.IO.Directory.CreateDirectory(@"C:\SGP");
            docname = lblname.Text + " - " + cambiada1 + ".pdf";
            object ObjMiss = System.Reflection.Missing.Value;
            Word.Application ObjWord = new Word.Application();
            string ruta = Application.StartupPath + @"\\resourses\" + pacID + "-" + realname;
            string rutasave = @"C:\SGP\" + docname + "";
            object parametro = ruta;
            object save = rutasave;        
                object paciente = "paciente";
                object edad = "edad";
                object fechan = "fechan";
                object ced = "ced";
                object fechae = "fechae";
                object dire = "dir";
                object fechamu = "fecham";
               
                Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss, ReadOnly: true);
                Word.Range nom = ObjDoc.Bookmarks.get_Item(ref paciente).Range;
                nom.Text = lblname.Text;
                Word.Range age = ObjDoc.Bookmarks.get_Item(ref edad).Range;
                age.Text = lblage.Text;
                Word.Range fech = ObjDoc.Bookmarks.get_Item(ref fechan).Range;
                fech.Text = lblFecha.Text;
                Word.Range cedu = ObjDoc.Bookmarks.get_Item(ref ced).Range;
                cedu.Text = lblCed.Text;
                Word.Range fechaem = ObjDoc.Bookmarks.get_Item(ref fechae).Range;
                fechaem.Text = cambiada1 + " / " + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                Word.Range direction = ObjDoc.Bookmarks.get_Item(ref dire).Range;
                direction.Text = dir;
                Word.Range fechamue = ObjDoc.Bookmarks.get_Item(ref fechamu).Range;
                fechamue.Text = DateTime.Parse(FechaMuestra).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + " " + HoraMuestra;
                object rango1 = nom;
                object rango2 = age;
                object rango3 = fech;
                object rango4 = cedu;
                object rango5 = fechaem;
                object rango6 = direction;
                object rango7 = fechamue;
                ObjDoc.Bookmarks.Add("paciente", ref rango1);
                ObjDoc.Bookmarks.Add("edad", ref rango2);
                ObjDoc.Bookmarks.Add("fechan", ref rango3);
                ObjDoc.Bookmarks.Add("ced", ref rango4);
                ObjDoc.Bookmarks.Add("fechae", ref rango5);
                ObjDoc.Bookmarks.Add("dir", ref rango6);
                ObjDoc.Bookmarks.Add("fecham", ref rango7);
          
            if (lbltest.Text == "Antimicrosomal")
            {
                object resultado = "resultado";
                object resultado1 = "resultado2";
                Word.Range result1 = ObjDoc.Bookmarks.get_Item(ref resultado).Range;
                Word.Range result2 = ObjDoc.Bookmarks.get_Item(ref resultado1).Range;
                String Txt = "";                
                bool tx = false;
                int cont = 0;
                foreach (Control cComprobar in panel1.Controls)
                {
                
                    if (cComprobar is TextBox)
                    {
                        Txt = cComprobar.Text;
                        tx = true;
                    }

                    if (tx == true)
                    {
                        cont++;
                        tx = false;
                    }
                    if (cont == 1)
                    {

                        result1.Text = Txt;
                    }
                    if (cont == 2) 
                    {

                        result2.Text = Txt;
                    }
                }
                object rango8 = result1;
                object rango9 = result2;
                ObjDoc.Bookmarks.Add("resultado", ref rango8);
                ObjDoc.Bookmarks.Add("resultado2", ref rango9);
            }
            if (lbltest.Text == "Liquido Ascitico")
            {
                object resultado = "resultado";
                object resultado1 = "resultado1";
                object resultado2 = "resultado2";
                object resultado3 = "resultado3";
                object resultado4 = "resultado4";
                object resultado5 = "resultado5";
                Word.Range result1 = ObjDoc.Bookmarks.get_Item(ref resultado).Range;
                Word.Range result2 = ObjDoc.Bookmarks.get_Item(ref resultado1).Range;
                Word.Range result3 = ObjDoc.Bookmarks.get_Item(ref resultado2).Range;
                Word.Range result4 = ObjDoc.Bookmarks.get_Item(ref resultado3).Range;
                Word.Range result5 = ObjDoc.Bookmarks.get_Item(ref resultado4).Range;
                Word.Range result6 = ObjDoc.Bookmarks.get_Item(ref resultado5).Range;
                String Txt = "";
                bool tx = false;
                int cont = 0;
                foreach (Control cComprobar in panel1.Controls)
                {

                    if (cComprobar is TextBox)
                    {
                        Txt = cComprobar.Text;
                        tx = true;
                    }

                    if (tx == true)
                    {
                        cont++;
                        tx = false;
                    }
                    if (cont == 1)
                    {

                        result1.Text = Txt;
                    }
                    if (cont == 2)
                    {

                        result2.Text = Txt;
                    }
                    if (cont == 3)
                    {

                        result3.Text = Txt;
                    }
                    if (cont == 4)
                    {

                        result4.Text = Txt;
                    }
                     if (cont == 5)
                    {

                        result5.Text = Txt;
                    }
                    if (cont == 6)
                    {

                        result6.Text = Txt;
                    }                   
                }
                object rango8 = result1;
                object rango9 = result2;
                object rango10 = result3;
                object rango11= result4;
                object rango12 = result5;
                object rango13 = result6;
                ObjDoc.Bookmarks.Add("resultado", ref rango8);
                ObjDoc.Bookmarks.Add("resultado1", ref rango9);
                ObjDoc.Bookmarks.Add("resultado2", ref rango10);
                ObjDoc.Bookmarks.Add("resultado3", ref rango11);
                ObjDoc.Bookmarks.Add("resultado4", ref rango12);
                ObjDoc.Bookmarks.Add("resultado5", ref rango13);


            }
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
           
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                }

            try
            {
                if (Method == "Impreso")
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(rutasave);
                    Process.Start(startInfo);
                    Printed = true;
                }

            }
            catch (Exception ex)
            {
                Printed = false;
                Enviado = false;
            }

        }
        
    
    }
}
