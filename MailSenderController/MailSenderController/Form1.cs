using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace MailSenderController
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {
        public Form1()
        {
            InitializeComponent();
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            btnStartStop.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"\\resourses\start.png");
            btnStartStop.ImageAlignment = ContentAlignment.TopCenter;

        }

        public static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        private static BackgroundWorker worker = new BackgroundWorker();
        bool Abort = false;
        int cmreid;
        int repacid;
        int cmpruebaempresaid;
        bool cmenviado;
        String repaciente;
        byte[] reDocPDF;
        String cmmail;
        String docname;
        String filename;
        String reprueba;
        string pemail;
        bool enviado;
        int cmintento;
        clsMail cm = new clsMail();
        clsRandomNo rd = new clsRandomNo();
        int cmid;
        bool generado = false;
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i >= 10)
                {
                    i = 0;
                }
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                
                validation();
                if (radGridView1.Rows.Count > 0)
                {
                    CargaPlantilla();
                }
                Thread.Sleep(5000);
                worker.ReportProgress(i * 10);
                if (Abort == false)
                {
                    Statuslabel("Buscando registros para envio..", Color.DarkSlateGray);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conect);
            Statuslabel("Proceso Dentenido", Color.DarkSlateGray);
            label2.Text = "Server: "+con.DataSource;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Iniciar")
            {
                btnStartStop.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"\\resourses\stop.png");
                btnStartStop.ImageAlignment = ContentAlignment.TopCenter;
                Abort = false;
                btnStartStop.Text = "Detener";
                if (worker.IsBusy != true)
                {
                    worker.RunWorkerAsync();
                    Statuslabel("Buscando registros para envio...", Color.DarkSlateGray);
                }
            }
            else if (btnStartStop.Text == "Detener")
            {
                //cancel();
                Abort = true;

                btnStartStop.Text = "Iniciar";
                Statuslabel("Proceso Dentenido", Color.DarkSlateGray);
                btnStartStop.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"\\resourses\start.png");
                btnStartStop.ImageAlignment = ContentAlignment.TopCenter;
            }
        }
        public void Statuslabel(string message, object color = null)
        {
            label1.Invoke(new MethodInvoker(() =>
            {
                label1.Text = message;
                if (color != null)
                    label1.ForeColor = (Color)color;
            }));
        }
        public void CargaPlantilla()
        {
        using (var con = new SqlConnection(conect))
        {
        foreach (GridViewRowInfo rowInfo in radGridView1.Rows) if (Abort == false)
        {
        try
        {
            cmid = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[0].Value);
            cmreid = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[1].Value);
            repacid = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[2].Value);
            cmpruebaempresaid = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[3].Value);
            cmenviado = Convert.ToBoolean(radGridView1.Rows[rowInfo.Index].Cells[4].Value);
            repaciente = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[5].Value);
            reprueba = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[6].Value);
            cmmail = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[7].Value);
                            cmmail = Regex.Replace(cmmail, @"[\u0000-\u001F]", string.Empty);
            cmintento = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[8].Value);
            if (cmmail == "RR\u001f_22@GMAIL.COM")
                            {
                                cmmail = "RR_22@GMAIL.COM";
                            }
                            con.Open();
                            using (SqlCommand cm = con.CreateCommand())
                            {
                                cm.CommandText = "Select redocpdf from tbresultados where reid = " + cmreid + "";
                                using (SqlDataReader dr = cm.ExecuteReader())
                                {
                                    while (dr.Read())
                                    {
                                        reDocPDF = (byte[])dr[0];
                                    }
                                }
                            }
                            con.Close();

                            rd.GetNo();
            Statuslabel("Procesando envio...", Color.DarkSlateGray);
            

         
                            if (reprueba != "HIV" && cmintento < 3)
                            {
                                docname = repaciente + "-" + rd.RandomNo + ".pdf";
                                filename = @"C:\SGP\" + repaciente + "-" + rd.RandomNo + ".pdf";
                                System.IO.File.WriteAllBytes(filename, reDocPDF);
                                if (cmpruebaempresaid != 0)
                                {
                                    sendmailgrupo(cmmail);
                                }
                                else
                                {
                                    sendmail(cmmail, docname);
                                }
                                
                            }
                        }
                  catch 
                  {                  
                  con.Close();
                  return;
                }
              }

            }
        }
        public void UpdateMail()
        {
            using (var con = new SqlConnection(conect))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    cmd.CommandText = @"update tbcontrolmail set cmenviado = 1 where cmid = " + cmid + " and  cmreID = " + cmreid + "";

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
        public void UpdateMailEmpresa()
        {
            using (var con = new SqlConnection(conect))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    cmd.CommandText = @"update tbcontrolmail set cmenviado = 1 where cmid = " + cmid + " and  cmpruebaempresaid = " + cmpruebaempresaid + "";

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
        public void UpdateIntento(string error)
        {
            using (var con = new SqlConnection(conect))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    cmd.CommandText = @"update tbControlMail set cmerror = '"+ Regex.Replace(error, @"'", "`") +"', cmIntento = case when cmintento is null then 1 else cmintento + 1 end where cmid = "+cmid+" and cmreID = " + cmreid + "";
                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();
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
        public void sendmail(string mailto, string doc)
        {
            if (enviado == false)
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
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = true;
                    NetworkCredential cred = new System.Net.NetworkCredential(cm.MailUser, cm.MailPass);
                    client.EnableSsl = cm.MailSSL;
                    
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };                    
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                

                    client.Credentials = cred;
                    client.Send(mailtxt);
                    enviado = true;

                    if (enviado == true && cmpruebaempresaid == 0)
                    {
                        //MessageBox.Show("Resultados enviados de manera satisfactoria al correo: " + pemail + ".", "Reenvio de correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateMail();
                        enviado = false;

                    }

                }

                catch (Exception ex)
                {
                    if (cmpruebaempresaid == 0)
                    { 
                    UpdateIntento(ex.Message);
                }
                    enviado = false;
                }
            }
        }
        public void sendmailgrupo(string mailto)
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
                    DataSet myDataSet = new DataSet();
                    System.Net.Mail.Attachment attachment;
                    using (var con = new SqlConnection(conect))
                    {
                        int Rows;
                        Rows = dataGridView1.RowCount - 1;
                        con.Open();
                        //cmd = new SqlCommand("select DISTINCt(a.pEmpresa) as [Empresa], a.pFechareg as [Fecha Registro] from tbPacientes a  where a.pEmpresa IS NOT NULL ", con);
                        //SqlCommand cmd = new SqlCommand("select repaciente, redocpdf, repacid from tbresultados where repruebaid = "+cmpruebaempresaid+"", con);
                        SqlCommand cmd = new SqlCommand("select repaciente, redocpdf, repacid, pemail from tbresultados inner join tbpacientes on rePacid = pid where repruebaid = " + cmpruebaempresaid + "", con);
                        SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                       
                        myDA.Fill(myDataSet, "Resultados");
                       
                        dataGridView1.Invoke(new MethodInvoker(() =>
                        {
                            dataGridView1.DataSource = myDataSet.Tables["Resultados"].DefaultView;
                            dataGridView1.Columns[1].Visible = false;
                            
                          
                        }));



                        con.Close();
                    }
                    //attachment = new System.Net.Mail.Attachment(filename);
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        rd.GetNo();
                        repaciente = (string)row.Cells["repaciente"].Value;
                        if (row.Cells["redocpdf"].Value != System.DBNull.Value)
                        {
                            reDocPDF = (byte[])row.Cells["redocpdf"].Value;
                        }
                        else
                        {
                            continue;
                        }
                        repacid = (int)row.Cells["repacid"].Value;
                        if (row.Cells["pemail"].Value == System.DBNull.Value)
                        {
                            pemail = "";
                        }
                        else
                        {
                            pemail = (string)row.Cells["pemail"].Value;
                        }

                        try
                        {
                            string filename = @"C:\SGP\" + repaciente + "-" + rd.RandomNo + ".pdf";
                            System.IO.File.WriteAllBytes(filename, reDocPDF);
                            attachment = new System.Net.Mail.Attachment(filename);
                            mailtxt.Attachments.Add(attachment);
                            enviado = false;
                            if (pemail != "")
                            {
                                sendmail(pemail, repaciente + "-" + rd.RandomNo + ".pdf");
                            }
                        }
                        catch
                        {

                        }
                    }

                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(cm.MailSMTP);

                    client.Port = int.Parse(cm.MailPort);
                    client.EnableSsl = cm.MailSSL;
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    client.UseDefaultCredentials = false;

                    NetworkCredential cred = new System.Net.NetworkCredential(cm.MailUser, cm.MailPass);

                    client.Credentials = cred;
                    client.SendAsync(mailtxt, null);
                    UpdateMailEmpresa();
                    enviado = true;
                    dataGridView1.Invoke(new MethodInvoker(() =>
                    {
                        myDataSet.Clear();
                        dataGridView1.Refresh();

                    }));
                   
                }
                catch (Exception ex)
                {
                    UpdateIntento(ex.Message);
                    enviado = false;
                }
            }
        }
        public void validation()
        {
            if (Abort == false)
            {
                try
                {
                    enviado = false;
                    radGridView1.Invoke(new MethodInvoker(() =>
                    {
                        radGridView1.Rows.Clear();
                    }));
                    SqlConnection cn = new SqlConnection(conect);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("spGetMailtoSend", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 60;
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adpt.Fill(ds);


                    cn.Close();
                    Statuslabel("Validando...", Color.DarkSlateGray);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        Statuslabel("Buscando registros para envio.", Color.DarkSlateGray);

                    }
                    else
                    {

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int rowcount = ds.Tables[0].Rows.Count;
                            cmintento = (int)dr["cmintento"];
                            cmid = (int)dr["cmid"];
                            cmreid = (int)dr["cmreid"];
                            repacid = (int)dr["repacid"];
                           
                            if (dr["cmpruebaempresaid"] != System.DBNull.Value)
                            {
                                cmpruebaempresaid = (int)dr["cmpruebaempresaid"];
                            }
                            else
                            {
                                cmpruebaempresaid = 0;
                            }
                            cmenviado = (bool)dr["cmenviado"];
                            repaciente = dr["repaciente"].ToString();
                            reprueba = dr["reprueba"].ToString();

                            cmmail = dr["cmmail"].ToString();

                            bool exist = false;
                            if (radGridView1.RowCount >= 1)
                            {
                                for (int i = 0; i < radGridView1.RowCount; i++)
                                {

                                    if (Convert.ToInt32(radGridView1.Rows[i].Cells["Id"].Value) == cmid)
                                    {
                                        exist = true;
                                    }


                                }
                            }
                            if (exist == false)
                            {
                                radGridView1.Invoke(new MethodInvoker(() =>
                                {
                                    CheckResult();
                                    if (generado == true)
                                    {
                                        radGridView1.Rows.Add(cmid, cmreid, repacid, cmpruebaempresaid, cmenviado, repaciente, reprueba, cmmail, cmintento);
                                    }
                                }));


                            }
                        }
                    }
                        }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }

        public void CheckResult()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "Select redocpdf from tbresultados where reid= "+cmreid+" and redocpdf is not null  ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    generado = true;
                }
                con.Close();

            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resulta = MessageBox.Show("Seguro desea cerrar la aplicacion?", "Cerrar Aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    Abort = true;

                    btnStartStop.Text = "Iniciar";
                    Statuslabel("Proceso Dentenido", Color.DarkSlateGray);
                    btnStartStop.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"\\resourses\start.png");
                    btnStartStop.ImageAlignment = ContentAlignment.TopCenter;
                    Application.Exit();
                }
                else if (resulta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
