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
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Threading;
using System.Globalization;

namespace SGPAPP
{
    public partial class frmDates : Form
    {
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        public String PacienteID;
        public String Nombre;
        String cambiada1;
        String Status = "Programada";
        String ID;
        String Mail;
        bool Seguro = false;
        bool Indicacion = false;
        DateTime Hora1;
        DateTime Hora2;
        DateTime WeekMax;
        DateTime WeekMin;
        DateTime WeekendMax;
        DateTime WeekendMin;
        CitasTime ctime = new CitasTime();
   
        public frmDates()
        {
            InitializeComponent();
            ctime.GetTimeSetp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (cbbTipo.Text != "Seleccione el Tipo")
            {
                conviertefecha();
                CheckCitas();
                SaveLog();
            }
           else
            {
                MessageBox.Show("Seleccione el tipo de cita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }
        public void SendMail()
        {
            clsMail cm = new clsMail();
            cm.GetMailSetup();
            var mailtxt = new MailMessage();
            mailtxt.To.Add(Mail);
            mailtxt.From = new MailAddress(cm.MailFrom, cm.MailName, System.Text.Encoding.UTF8);
            mailtxt.Subject = "Citas CGE Laboratorio";
            mailtxt.IsBodyHtml = true;
            mailtxt.Body = "Su cita ha sido programada para el dia: "+FechaActual.Text+" a las: "+txtHora.Text+", en caso que requiera reprogramarla favor contactarnos. ";
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
            log.Accion = "Cita Creada al Paciente: " + txtPac.Text + ", el " + FechaActual.Text + ", a las " + txtHora.Text + "";
            log.Form = "Gestion de Citas";
            log.SaveLog();

            
               
        }
        private void btnSav_Click(object sender, EventArgs e)
        {
            frmConsultad d = new frmConsultad();
            if (cbbTipo.SelectedIndex != 0 )
            {
                d.Empresa = false;
                if (d.ShowDialog() == DialogResult.Yes)
                {
                    //PacienteID = d.PacienteID;
                    Nombre = d.PacienteNom;
                    txtPac.Text = Nombre;
                    getID();
                }               

                }
            else
            {
                MessageBox.Show("Debe seleccionar el tipo de Cita", "Citas",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        public void getID()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "Select pID, pemail from tbpacientes where pCed = '" + PacienteID + "' and pnom = '"+Nombre+"'  ";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ID = reader[0].ToString();
                        Mail = reader[1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar el ID, Intente nuevamente!");
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
        public void CheckCitas()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "Select cHora, cFecha, ctipo from tbcitas where cHora = '" + txtHora.Text + "' and cFecha = '" + cambiada1 + "' and ctipo = '" + cbbTipo.Text + "'";

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
                        GuardaCitas();
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
        public void GuardaCitas()
        {
           

            DialogResult guardar = MessageBox.Show("Deseas programar esta cita a " + txtPac.Text + " el " + FechaActual.Text + " a las " + txtHora.Text + "?", "Programar Cita", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (guardar == DialogResult.Yes)
            {
                byte[] file = null;
                byte[] file2 = null;
                if (Seguro == true)
                {                   
                    Stream myStream = openFileDialog1.OpenFile();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        myStream.CopyTo(ms);
                        file = ms.ToArray();
                    }
                }
                if (Indicacion == true)
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
                        if (Seguro == true && Indicacion == false)
                        {
                            string oDocument = openFileDialog1.SafeFileName;
                            string oDocument2 = openFileDialog2.SafeFileName;

                            cmd.CommandText = @"insert into tbCitas(cTipo, cFecha, cHora, pId, pNom, csegname, cSeguro, pComment, cEstatus) values (@tipo, @fecha, @hora, @ID, @Pac, @Seg, @Seguro, @Comment, @Status)";
                            cmd.Parameters.AddWithValue("@tipo", cbbTipo.Text);
                            cmd.Parameters.AddWithValue("@fecha", cambiada1);
                            cmd.Parameters.AddWithValue("@hora", txtHora.Text);
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@Pac", txtPac.Text);
                            cmd.Parameters.AddWithValue("@Seg", oDocument);
                            cmd.Parameters.AddWithValue("@Seguro", file);
                            cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                            cmd.Parameters.AddWithValue("@Status", Status);
                            con.Open();
                            cmd.ExecuteScalar();
                            con.Close();
                        }
                        if (Seguro == false && Indicacion == true)
                        {
                            string oDocument = openFileDialog1.SafeFileName;
                            string oDocument2 = openFileDialog2.SafeFileName;

                            cmd.CommandText = @"insert into tbCitas(cTipo, cFecha, cHora, pId, pNom, cIndicname, cIndic, pComment, cEstatus) values (@tipo, @fecha, @hora, @ID, @Pac, @Indic, @Indicacion, @Comment, @Status)";
                            cmd.Parameters.AddWithValue("@tipo", cbbTipo.Text);
                            cmd.Parameters.AddWithValue("@fecha", cambiada1);
                            cmd.Parameters.AddWithValue("@hora", txtHora.Text);
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@Pac", txtPac.Text);
                            cmd.Parameters.AddWithValue("@Indic", oDocument2);
                            cmd.Parameters.AddWithValue("@Indicacion", file2);
                            cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                            cmd.Parameters.AddWithValue("@Status", Status);
                            con.Open();
                            cmd.ExecuteScalar();
                            con.Close();
                        }
                        if (Seguro == true && Indicacion == true)
                        {
                            string oDocument = openFileDialog1.SafeFileName;
                            string oDocument2 = openFileDialog2.SafeFileName;

                            cmd.CommandText = @"insert into tbCitas(cTipo, cFecha, cHora, pId, pNom, csegname, cSeguro, cIndicname, cIndic, pComment, cEstatus) values (@tipo, @fecha, @hora, @ID, @Pac, @Seg, @Seguro, @Indic, @Indicacion, @Comment, @Status)";
                            cmd.Parameters.AddWithValue("@tipo", cbbTipo.Text);
                            cmd.Parameters.AddWithValue("@fecha", cambiada1);
                            cmd.Parameters.AddWithValue("@hora", txtHora.Text);
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@Pac", txtPac.Text);
                            cmd.Parameters.AddWithValue("@Seg", oDocument);
                            cmd.Parameters.AddWithValue("@Seguro", file);
                            cmd.Parameters.AddWithValue("@Indic", oDocument2);
                            cmd.Parameters.AddWithValue("@Indicacion", file2);
                            cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                            cmd.Parameters.AddWithValue("@Status", Status);
                            con.Open();
                            cmd.ExecuteScalar();
                            con.Close();
                        }
                        if (Seguro == false && Indicacion == false)
                        {


                            cmd.CommandText = @"insert into tbCitas(cTipo, cFecha, cHora, pId, pNom, pComment, cEstatus) values (@tipo, @fecha, @hora, @ID, @Pac, @Comment, @Status)";
                            cmd.Parameters.AddWithValue("@tipo", cbbTipo.Text);
                            cmd.Parameters.AddWithValue("@fecha", cambiada1);
                            cmd.Parameters.AddWithValue("@hora", txtHora.Text);
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@Pac", txtPac.Text);
                            cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                            cmd.Parameters.AddWithValue("@Status", Status);
                            con.Open();
                            cmd.ExecuteScalar();
                            con.Close();
                        }
                        MessageBox.Show("Cita creada Correctamente!", "Agendar Cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
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
        }

        private void frmDates_Load(object sender, EventArgs e)
        {
            btnSearch.Select();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            cbbTipo.SelectedIndex = 0;
            txtHora.Text = "8:00 AM";

        }

        private void btnSeguro_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Todos los archivos (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSeguro.Text = openFileDialog1.FileName;
                Seguro = true;
            }
        }

        private void btnIndicacion_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = "c:\\";
            openFileDialog2.Filter = "Todos los archivos (*.*)|*.*";
            openFileDialog2.FilterIndex = 1;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                txtIndic.Text = openFileDialog2.FileName;
                Indicacion = true;
            }
        }

        private void dtpHora_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpHora_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void dtpHora_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
                }
            }
            if (dia == DayOfWeek.Saturday)
            {
                if (Hora1 < DateTime.Parse(WeekendMax.ToString("hh:mm tt", CultureInfo.InvariantCulture)))
                {
                    Hora2 = Hora1.AddMinutes(15);
                }
            }

            txtHora.Text = Hora2.ToString("hh:mm tt", CultureInfo.InvariantCulture);

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
