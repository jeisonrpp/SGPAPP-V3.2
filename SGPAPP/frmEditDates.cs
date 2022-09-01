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
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Globalization;
using System.Threading;

namespace SGPAPP
{
    public partial class frmEditDates : Form
    {
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        String Fecha;
        String cambiada1;
        DateTime Fechacambiada;
        String Mail;
        String PacienteID;
        bool Seg = false;
        bool indi = false;
        String Fechactual;
        DateTime Hora;
        String Estado;
        DateTime Hora1;
        DateTime Hora2;
        DateTime WeekMax;
        DateTime WeekMin;
        DateTime WeekendMax;
        DateTime WeekendMin;
        CitasTime ctime = new CitasTime();

        public frmEditDates()
        {
            InitializeComponent();
            ctime.GetTimeSetp();
        }
        public String DatesID;

        private void frmEditDates_Load(object sender, EventArgs e)
        {
            CargaDatos();
            getMail();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

        }
        public void getMail()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "Select pID, pemail from tbpacientes where pID = '" + PacienteID + "'  ";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Mail = reader[1].ToString();
                    }
                    else
                    {

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
        public void CargaDatos()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "Select cFecha, cHora, pId, pNom, csegname, cindicname, pComment, cEstatus, ctipo from tbcitas where cId = '" + DatesID + "'  ";
                //SqlConnection con = new SqlConnection(cs.ConnectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                       
                        Fecha = reader[0].ToString();
                        Hora = DateTime.Parse(reader[1].ToString());
                        txtHora.Text = Hora.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                        PacienteID = reader[2].ToString();
                        txtPac.Text = reader[3].ToString();
                        txtSeguro.Text = reader[4].ToString();
                        txtIndic.Text = reader[5].ToString();
                        txtComment.Text = reader[6].ToString();
                        Estado = reader[7].ToString();
                        cbbStatus.Text = Estado;
                        cbbTipo.Text = reader[8].ToString();
                        Fechactual = DateTime.Parse(Fecha).ToString("dddd d, MMMMM, yyyy");
                        FechaActual.Text = Fechactual;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult guardar = MessageBox.Show("Deseas modificar esta cita a " + txtPac.Text + " el " + FechaActual.Text + " a las " + txtHora.Text + " estatus: " +cbbStatus.Text+" ?", "Modificar Cita", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (guardar == DialogResult.Yes)
            {
                conviertefecha();
                CheckCitas();
                SaveLog();
            }
        }
        public void CheckCitas()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "Select cHora, cFecha, ctipo from tbcitas where cHora = '" + txtHora.Text + "' and cFecha = '" + cambiada1 + "' and ctipo = '"+cbbTipo.Text+ "' and cestatus = 'Programada' and pid <> '"+PacienteID+"'";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Ya existe una Cita programada en este horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        return;
                    }
                    else
                    {
                        con.Close();
                        ModificaCita();
                        this.DialogResult = DialogResult.OK;
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
        public void SendMailp()
        {
            clsMail cm = new clsMail();
            cm.GetMailSetup();
            var mailtxt = new MailMessage();
            mailtxt.To.Add(Mail);
            mailtxt.From = new MailAddress(cm.MailFrom, cm.MailName, System.Text.Encoding.UTF8);
            mailtxt.Subject = "Citas CGE Laboratorio";
            mailtxt.IsBodyHtml = true;
            mailtxt.Body = "Su cita para Prueba PCR Sars Cov-2 ha sido programada para el dia: " + FechaActual.Text + " a las: " + txtHora.Text + ", en caso que requiera reprogramarla favor contactarnos. ";
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(cm.MailSMTP);
            client.Port = int.Parse(cm.MailPort);
            client.EnableSsl = cm.MailSSL;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            client.UseDefaultCredentials = true;
            NetworkCredential cred = new System.Net.NetworkCredential(cm.MailUser, cm.MailPass);

            client.Credentials = cred;
            client.Send(mailtxt);
        }
        public void SendMailr()
        {
            clsMail cm = new clsMail();
            cm.GetMailSetup();
            var mailtxt = new MailMessage();
            mailtxt.To.Add(Mail);
            mailtxt.From = new MailAddress(cm.MailFrom, cm.MailName, System.Text.Encoding.UTF8);
            mailtxt.Subject = "Citas CGE Laboratorio";
            mailtxt.IsBodyHtml = true;
            mailtxt.Body = "Su cita para Prueba PCR Sars Cov-2 ha sido reprogramada para el dia: " + FechaActual.Text + " a las: " + txtHora.Text + ", en caso que requiera reprogramarla favor contactarnos. ";
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(cm.MailSMTP);
            client.Port = int.Parse(cm.MailPort);
            client.EnableSsl = cm.MailSSL;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            client.UseDefaultCredentials = true;
            NetworkCredential cred = new System.Net.NetworkCredential(cm.MailUser, cm.MailPass);

            client.Credentials = cred;
            client.Send(mailtxt);
        }
        public void SaveLog()
        {
           
            Logs log = new Logs();
            log.Accion = "Cita: "+ DatesID + ", Editada al Paciente " + txtPac.Text + ", el " + FechaActual.Text + " a las " + txtHora.Text + "";
            log.Form = "Gestion de Citas";
            log.SaveLog();

        }
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;


                fecha1 = Convert.ToDateTime(FechaActual.Text);

                String day = fecha1.Day.ToString();
                String mes = fecha1.Month.ToString();
                String year = fecha1.Year.ToString();

                cambiada1 = year + "-" + mes + "-" + day;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
        public void ModificaCita()
        {
            byte[] file = null;
            byte[] file2 = null;
            if (Seg == true)
            {
                
                Stream myStream = openFileDialog1.OpenFile();
                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);
                    file = ms.ToArray();
                }
            }
            if (indi == true)
            {
                
                Stream myStream2 = openFileDialog2.OpenFile();
                using (MemoryStream ms2 = new MemoryStream())
                {
                    myStream2.CopyTo(ms2);
                    file2 = ms2.ToArray();
                }
            }
                using (var con = new SqlConnection(conect))
                using (SqlCommand cmd = con.CreateCommand())
                {
                try
                {
                    byte[] segname = file;
                    byte[] indicname = file2;
                    string oDocument = openFileDialog1.SafeFileName;
                    string oDocument2 = openFileDialog2.SafeFileName;
                    //        string sql = "update tbcitas set cFecha = '" + cambiada1 + "',cHora = '" + dtpHora.Value + "', cEstatus= '" + cbbStatus.Text + "', pComment = '" + txtComment.Text + "' where cid = '" + DatesID + "'";
                    if (Seg == true && indi == false)
                    {
                        cmd.CommandText = @"update tbCitas set ctipo = @tipo, cFecha = @fecha, cHora = @hora, csegname= @Seg, cSeguro= @Seguro, pComment=@Comment, cEstatus= @Status where cid = '" + DatesID + "'";
                        cmd.Parameters.AddWithValue("@tipo", cbbTipo.Text);
                        cmd.Parameters.AddWithValue("@fecha", cambiada1);
                        cmd.Parameters.AddWithValue("@hora", txtHora.Text);
                        cmd.Parameters.AddWithValue("@Seg", oDocument);
                        cmd.Parameters.AddWithValue("@Seguro", file);
                        cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                        cmd.Parameters.AddWithValue("@Status", cbbStatus.Text);
                    }
                    if (indi == true && Seg == false)
                    {
                        cmd.CommandText = @"update tbCitas set ctipo = @tipo, cFecha = @fecha, cHora = @hora, cIndicname=@Indic, cIndic=@Indicacion, pComment=@Comment, cEstatus= @Status where cid = '" + DatesID + "'";
                        cmd.Parameters.AddWithValue("@tipo", cbbTipo.Text);
                        cmd.Parameters.AddWithValue("@fecha", cambiada1);
                        cmd.Parameters.AddWithValue("@hora", txtHora.Text);
                        cmd.Parameters.AddWithValue("@Indic", oDocument2);
                        cmd.Parameters.AddWithValue("@Indicacion", file2);
                        cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                        cmd.Parameters.AddWithValue("@Status", cbbStatus.Text);
                    }
                    if (indi == true && Seg == true)
                    {
                        cmd.CommandText = @"update tbCitas set ctipo = @tipo, cFecha = @fecha, cHora = @hora, csegname= @Seg, cSeguro= @Seguro, cIndicname=@Indic, cIndic=@Indicacion, pComment=@Comment, cEstatus= @Status where cid = '" + DatesID + "'";
                        cmd.Parameters.AddWithValue("@tipo", cbbTipo.Text);
                        cmd.Parameters.AddWithValue("@fecha", cambiada1);
                        cmd.Parameters.AddWithValue("@hora", txtHora.Text);
                        cmd.Parameters.AddWithValue("@Seg", oDocument);
                        cmd.Parameters.AddWithValue("@Seguro", file);
                        cmd.Parameters.AddWithValue("@Indic", oDocument2);
                        cmd.Parameters.AddWithValue("@Indicacion", file2);
                        cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                        cmd.Parameters.AddWithValue("@Status", cbbStatus.Text);
                    }
                    if (indi == false && Seg == false)
                    {
                        cmd.CommandText = @"update tbCitas set ctipo = @tipo, cFecha = @fecha, cHora = @hora, pComment=@Comment, cEstatus= @Status where cid = '" + DatesID + "'";
                        cmd.Parameters.AddWithValue("@tipo", cbbTipo.Text);
                        cmd.Parameters.AddWithValue("@fecha", cambiada1);
                        cmd.Parameters.AddWithValue("@hora", txtHora.Text);
                        cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                        cmd.Parameters.AddWithValue("@Status", cbbStatus.Text);
                    }
                 
                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();
                    MessageBox.Show("Cita Actualizada Correctamente!", "Modificar Cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                    if(Fechactual != FechaActual.Text && Estado == cbbStatus.Text && Estado == "Programada")
                    {
                        SendMailr();
                    }
                   
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
            }

        }

        private void FechaActual_DoubleClick(object sender, EventArgs e)
        {
            dtp1.Visible = true;
            dtp1.Value = Convert.ToDateTime(FechaActual.Text);
            tableLayoutPanel2.Visible = false;
        }

        private void dtp1_CloseUp(object sender, EventArgs e)
        {
            Fechacambiada = dtp1.Value;


            dtp1.Visible = false;
            tableLayoutPanel2.Visible = true;
            FechaActual.Text = Fechacambiada.ToString("dddd d, MMMMM, yyyy");
        }

        private void frmEditDates_DoubleClick(object sender, EventArgs e)
        {
            if (dtp1.Visible == true)
            {
                dtp1.Visible = false;
                tableLayoutPanel2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Todos los archivos (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSeguro.Text = openFileDialog1.FileName;
                Seg = true;
            }
        }

        private void btnIndic_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = "c:\\";
            openFileDialog2.Filter = "Todos los archivos (*.*)|*.*";
            openFileDialog2.FilterIndex = 1;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                txtIndic.Text = openFileDialog2.FileName;
                indi = true;
            }
        }

        private void txtmore_Click(object sender, EventArgs e)
        {
            WeekMax = DateTime.Parse(ctime.WeekMax);
            WeekendMax = DateTime.Parse(ctime.WeekendMax);
            DateTime fact = DateTime.Parse(FechaActual.Text);
            DayOfWeek dia = fact.DayOfWeek;
            Hora1 = DateTime.Parse(txtHora.Text);
            if (dia != DayOfWeek.Saturday)
            {
                if (Hora1 < DateTime.Parse(WeekMax.ToString("hh:mm tt", CultureInfo.InvariantCulture)))
                {
                    Hora2 = Hora1.AddMinutes(15);
                    txtHora.Text = Hora2.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                }
            }
            if (dia == DayOfWeek.Saturday)
            {
                if (Hora1 < DateTime.Parse(WeekendMax.ToString("hh:mm tt", CultureInfo.InvariantCulture)))
                {
                    Hora2 = Hora1.AddMinutes(15);
                    txtHora.Text = Hora2.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                }
            }

           
        }

        private void txtLess_Click(object sender, EventArgs e)
        {
            WeekMin = DateTime.Parse(ctime.WeekMin);
            WeekendMin = DateTime.Parse(ctime.WeekendMin);
            DateTime fact = DateTime.Parse(FechaActual.Text);
            DayOfWeek dia = fact.DayOfWeek;
            Hora1 = DateTime.Parse(txtHora.Text);
            if (dia != DayOfWeek.Saturday)
            {
                if (Hora1 > DateTime.Parse(WeekMin.ToString("hh:mm tt", CultureInfo.InvariantCulture)))
                {
                    Hora2 = Hora1.AddMinutes(-15);
                    txtHora.Text = Hora2.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                }
            }
            if (dia == DayOfWeek.Saturday)
            {
                if (Hora1 > DateTime.Parse(WeekendMin.ToString("hh:mm tt", CultureInfo.InvariantCulture)))
                {
                    Hora2 = Hora1.AddMinutes(-15);
                    txtHora.Text = Hora2.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                }
            }
     
        }
    }
}