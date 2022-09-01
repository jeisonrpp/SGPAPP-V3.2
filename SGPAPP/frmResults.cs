using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;
using System.Net.Sockets;
using System.Globalization;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using System.Runtime;
using System.Runtime.InteropServices;

namespace SGPAPP
{
    public partial class frmResults : Form
    {

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;
        public frmResults()
        {
            InitializeComponent();
        }

        public int pacID;
        public int PrID;
        public String Method;
        public String docname;
        DateTime Fecha = DateTime.Now;
        public String Age;
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        clsMail cm = new clsMail();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        public string cambiada1;
        String day;
        String mes;
        String year;
        public String mail;
        public string mail2;
        public String dir;
        bool Enviado = false;
        frmCPG pgb = new frmCPG();
        String PruebaID;
       public String HoraMuestra;
        public String FechaMuestra;
        public String FechaRegistro;
         public DateTime HoraRegistro = DateTime.Now;
        byte[] PDFDOC;
        bool Citas = false;
        bool Printed;
        String QrLink;
        String ResultID;
        public bool Merge = false;
        public String Fechar;
        public String Resultado;
        private void btnSav_Click(object sender, EventArgs e)
        {

            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {

                try
                {

                if (cbbResult.Text != "Seleccione el Resultado" || txtCt.Text != "")
                {
                
                    if (lblFecha.Text == "-")
                    {
                        Fechar = "1900-01-01";
                    }
                    else
                    {
                        Fechar = lblFecha.Text;
                    }
                    using (var con = new SqlConnection(conect))
                    {
                        conviertefecha();
                        GetResultID();
                        if (lbltest.Text == "Influenza" || lbltest.Text == "Anticuerpo-Covid")
                        {
                            EditPlantillaPlus();
                        }
                        else
                        {
                            EditPlantilla();
                        }



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
                    
                        if (cbbResult.Text == "Detectado" && lbltest.Text == "Influenza" || cbbResults1.Text == "Detectado" && lbltest.Text == "Influenza")
                        {
                            Resultado = "Detectado";
                        }
                        else if (cbbResult.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid" || cbbResults1.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid")
                        {
                            Resultado = "Positivo";
                        }
                        else
                        {
                            Resultado = cbbResult.Text;
                        }
                        //if (Merge == true)
                        //{
                        //    SaveLog();
                        //    this.DialogResult = DialogResult.OK;
                        //}
                        //else
                        //{
                            string Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF, rePruebaID) values ('" + pacID + "', '" + lblname.Text + "', '" + dir + "', '" + Fechar + "', '" + lblage.Text + "', '" + lblCed.Text + "','" + lblTipo.Text + "', '" + lbltest.Text + "', '" + Resultado + "', '" + cbbResult.Text + "', '" + txtCt.Text + "', '" + cbbResults1.Text + "', '" + txtCt1.Text + "','" + cambiada1 + "' , '" + FechaMuestra + "',  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + HoraMuestra + "', @PDFDOC, '"+PrID+"')";
                            cmd = new SqlCommand(Sql, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@PDFDOC", SqlDbType.VarBinary).Value = PDFDOC;
                            con.Open();
                            try
                            {
                                int i = cmd.ExecuteNonQuery();
                                
                                    String doc = lblname.Text + " - " + PruebaID + " - " + cambiada1 + ".pdf";
                                    if (mail2.Length > 0)
                                {
                                    mail = mail + ", " + mail2;
                                }
                                    sendmail(mail, doc);
                                                                
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
                                con.Close();
                            }
                            SaveLog();
                            this.DialogResult = DialogResult.OK;
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar los campos faltantes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        string realname;

        public void getPlantilla()
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                con.Open();
                using (SqlCommand cm = con.CreateCommand())
                {
                    if (lbltest.Text == "Sars Cov-2")
                    {
                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plid = @id  ";
                        if (cbbResult.Text == "Detectado" && lbltest.Text == "Sars Cov-2" && chkIng.Checked == false)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 1;
                        }
                        if (lbltest.Text == "Sars Cov-2" && cbbResult.Text == "No Detectado" && chkIng.Checked == false || lbltest.Text == "Sars Cov-2" && cbbResult.Text == "Indeterminado" && chkIng.Checked == false)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 2;
                        }
                        if (lbltest.Text == "Sars Cov-2" && chkIng.Checked == true)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 6;
                        }
                    }
                    else if(lbltest.Text == "Antigeno" && chkIng.Checked == true)
                    {
                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = 'Antigen Test'  ";
                    }
                    else
                    {
                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = '" + lbltest.Text+ "'  ";
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
        public void UpdateCitas()
        {
            using (var con = new SqlConnection(conect))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    cmd.CommandText = @"update tbCitas set cEstatus= @Status where pid = '" + pacID + "' and cestatus = 'Programada'";
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
        public void getQR()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT qrLink from tbQRinfo where qrID = 1";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
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
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void EditPlantilla()
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
            imagen.Save("qrimagen-" + pacID + ".png", ImageFormat.Png);
            getPlantilla();

            System.IO.Directory.CreateDirectory(@"C:\SGP");
            docname = lblname.Text + " - "+ PruebaID +" - " + cambiada1 + ".pdf";
            object ObjMiss = System.Reflection.Missing.Value;
            Word.Application ObjWord = new Word.Application();
            string ruta = Application.StartupPath + @"\\resourses\" + pacID + "-"+realname;
            string rutasave = @"C:\SGP\" + docname + "";
            object parametro = ruta;
            object save = rutasave;
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
            nom.Text = lblname.Text;
            Word.Range age = ObjDoc.Bookmarks.get_Item(ref edad).Range;
            age.Text = lblage.Text;
            Word.Range fech = ObjDoc.Bookmarks.get_Item(ref fechan).Range;
            fech.Text = lblFecha.Text;
            Word.Range cedu = ObjDoc.Bookmarks.get_Item(ref ced).Range;
            cedu.Text = lblCed.Text;
            Word.Range resu = ObjDoc.Bookmarks.get_Item(ref res).Range;
            if (chkIng.Checked == true)
            {
                if (cbbResult.Text == "Detectado")
                {
                    resu.Text = "Detected";
                }
                if (cbbResult.Text == "No Detectado")
                {
                    resu.Text = "Not Detected";
                }
                if (cbbResult.Text == "Indeterminado")
                {
                    resu.Text = "Undetermined";
                }
                if (cbbResult.Text == "Positivo")
                {
                    resu.Text = "Positive";
                }
                if (cbbResult.Text == "Negativo")
                {
                    resu.Text = "Negative";
                }

            }
            else
            {               
                resu.Text = cbbResult.Text;
            }           
            Word.Range cts = ObjDoc.Bookmarks.get_Item(ref ct).Range;
            cts.Text = txtCt.Text;
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
            var shape = ObjDoc.Bookmarks["image"].Range.InlineShapes.AddPicture(Application.StartupPath + @"\\qrimagen-" + pacID + ".png", false, true);
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
                File.Delete(Application.StartupPath + @"\\qrimagen-" + pacID + ".png");
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

        public void EditPlantillaPlus()
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
            imagen.Save("qrimagen-" + pacID + ".png", ImageFormat.Png);

            getPlantilla();
            System.IO.Directory.CreateDirectory(@"C:\SGP");
            docname = lblname.Text + " - "+ PruebaID +" - " + cambiada1 + ".pdf";
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
            object res = "resultado";
            object res2 = "Resultado2";
            object ct = "no";
            object ct2 = "no2";
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
            Word.Range resu = ObjDoc.Bookmarks.get_Item(ref res).Range;
            resu.Text = cbbResult.Text;
            Word.Range cts = ObjDoc.Bookmarks.get_Item(ref ct).Range;
            cts.Text = txtCt.Text;
            Word.Range resu2 = ObjDoc.Bookmarks.get_Item(ref res2).Range;
            resu2.Text = cbbResults1.Text;
            Word.Range cts2 = ObjDoc.Bookmarks.get_Item(ref ct2).Range;
            cts2.Text = txtCt1.Text;
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
            var shape = ObjDoc.Bookmarks["image"].Range.InlineShapes.AddPicture(Application.StartupPath + @"\\qrimagen-" + pacID + ".png", false, true);
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
                File.Delete(Application.StartupPath + @"\\qrimagen-" + pacID + ".png");
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
                MessageBox.Show("Error al enviar el correo, favor contactar el administrador." +ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enviado = false;
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
        public void GetPaciente()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT RTRIM(pNom) as [Paciente], RTRIM(pced) as [Cedula], RTRIM(pFecha) as [Edad] , RTRIM(pemail) as [Email] , RTRIM(pdir) as [Direccion], RTRIM(pemail2) as [Email2] from tbpacientes where pID = '" + pacID + "'";

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
                        mail2 = reader[5].ToString();

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
        public void getCitas()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "select RTRIM(cfecha) as [Fechamuestra] from tbcitas where cestatus = 'Programada' and pid = '" + pacID + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        DateTime Fnow = DateTime.Now;
                        FechaMuestra = reader[0].ToString();
                        Citas = true;
                        if (DateTime.Parse(FechaMuestra) > Fnow)
                        {
                            FechaMuestra = FechaRegistro;
                            Citas = false;
                        }

                    }
                    else
                    {
                        FechaMuestra = FechaRegistro;
                        Citas = false;
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

        public void GetPrueba()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT RTRIM(ppID) as [ID], RTRIM(ppTipo) as [Tipo], RTRIM(ppPrueba) as [Prueba] , RTRIM(ppFecha) as [Fecha de Muestra], RTRIM(ppHora) as [Hora de Muestra], RTRIM(ppHora) as [Hora de Muestra], RTRIM(ppmetodo) as [Metodo] from tbPruebasPendientes where ppID = '" + PrID + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        PruebaID = reader[0].ToString();
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
                }
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
        private void frmResults_Load(object sender, EventArgs e)
        {
            GetPaciente();
            GetPrueba();

            getCitas();
            cbbResult.Text = "Seleccione el Resultado";
            if (lbltest.Text == "Influenza")
            {
                lblTipo2.Text = lblTipo.Text;
                lbltest2.Text = lbltest.Text;
                cbbResult.Text = "Seleccione el Resultado";
                cbbResults1.Text = "Seleccione el Resultado";
                this.Height = 553;
                btnSav.Location = new Point(304, 462);
                groupBox3.Visible = true;
                groupBox2.Text = "Influenza A";
            }
            if (lbltest.Text == "Anticuerpo-Covid")
            {
                lblTipo2.Text = lblTipo.Text;
                lbltest2.Text = lbltest.Text;
                cbbResult.Items.Clear();
                cbbResults1.Items.Clear();
                cbbResult.Items.Add("Positivo");
                cbbResult.Items.Add("Negativo");
                cbbResults1.Items.Add("Positivo");
                cbbResults1.Items.Add("Negativo");
                cbbResults1.Text = "Seleccione el Resultado";
                cbbResult.Text = "Seleccione el Resultado";
                //txtCt.Enabled = false;
                //txtCt1.Enabled = false;

                this.Height = 553;
                btnSav.Location = new Point(304, 462);
                groupBox3.Visible = true;
                groupBox2.Text = "igG";
                groupBox3.Text = "igM";
            }
            if (lbltest.Text == "Antigeno")
            {
                cbbResult.Items.Clear();
                cbbResult.Items.Add("Positivo");
                cbbResult.Items.Add("Negativo");
                cbbResult.Text = "Seleccione el Resultado";
                chkIng.Visible = true;
            }
            if (lbltest.Text == "Sars Cov-2")
            {
                chkIng.Visible = true;
            }

            //this.Width = 703;
            //this.Height = 394; 703, 651

            //location 304, 303 / 304, 564

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtCt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void cbbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lbltest.Text == "Anticuerpo-Covid")
            //{
            //    
            //}
            if(cbbResult.Text == "No Detectado" || cbbResult.Text == "Indeterminado" ||  cbbResult.Text == "Negativo" || cbbResults1.Text == "Negativo")
            {
                txtCt.Text = "-";
                //txtCt.Enabled = false;
            }
            else if (cbbResult.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid" || cbbResults1.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid" || cbbResult.Text == "Detectado" && lbltest.Text != "Anticuerpo-Covid" || cbbResults1.Text == "Detectado" && lbltest.Text != "Anticuerpo-Covid")
            {
                txtCt.Text = "";
                //txtCt.Enabled = true;
            }
           

        }

        private void frmResults_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void cbbResult1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbbResult1.Text == "No Detectado" || cbbResult1.Text == "Indeterminado")
            //{
            //    txtCt1.Text = "-";
            //    txtCt1.Enabled = false;
            //}
            //else
            //{
            //    txtCt1.Text = "";
            //    txtCt1.Enabled = true;
            //}
           
        }

        private void cbbResult2_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    if (cbbResult2.Text == "No Detectado" || cbbResult2.Text == "Indeterminado")
        //    {
        //        txtCt2.Text = "-";
        //        txtCt2.Enabled = false;
        //    }
        //    else
        //    {
        //        txtCt2.Text = "";
        //        txtCt2.Enabled = true;
        //    }
        }

        private void cbbResults1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbResults1.Text == "No Detectado" || cbbResults1.Text == "Indeterminado" || cbbResults1.Text == "Negativo")
            {
                txtCt1.Text = "-";
                //txtCt1.Enabled = false;
            }
            else if (cbbResults1.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid" || cbbResults1.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid" || cbbResults1.Text == "Detectado" && lbltest.Text != "Anticuerpo-Covid" || cbbResults1.Text == "Detectado" && lbltest.Text != "Anticuerpo-Covid")
            {
                txtCt1.Text = "";
                //txtCt1.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbbResults1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtCt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtCt.Enabled == false)
            {
                txtCt.Enabled = true;
            }
        }

        private void txtCt1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtCt1.Enabled == false)
            {
                txtCt1.Enabled = true;
            }
        }
    }
}
