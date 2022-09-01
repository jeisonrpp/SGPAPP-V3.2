using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Word = Microsoft.Office.Interop.Word;

namespace SGPAPP
{
    public partial class frmConsultaPI : Form
    {
        public frmConsultaPI()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn2 = new GridViewCommandColumn();
            commandColumn2.Name = "CommandColumn2";
            commandColumn2.UseDefaultText = true;
            commandColumn2.Image = Properties.Resources.icons8_search_16;
            commandColumn2.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn2.FieldName = "select";
            commandColumn2.HeaderText = "Seleccionar";
            radGridView1.MasterTemplate.Columns.Add(commandColumn2);
            radGridView1.CommandCellClick += new CommandCellClickEventHandler(radGridView1_CommandCellClick);
        }
        String PreID;
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        int ReportID;
        String Usuario;
        String realname;
        clsMail cm = new clsMail();
        string docname;
        String Mail;
        string rutasave;
        private void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            GridViewRowInfo row = radGridView1.CurrentRow;
            ReportID = (int)radGridView1.Rows[row.Index].Cells["ID Reporte"].Value;
            Usuario = (string)radGridView1.Rows[row.Index].Cells["Usuario"].Value;
            GetIDs();
            generatePDF();
            frmMsg msj = new frmMsg();
            msj.Text = "Reportes";
            msj.label1.Text = "De que forma desea gestionar este reporte?";
            msj.ShowDialog();

            if (msj.DialogResult == DialogResult.OK)
            {
                frmCPG mail = new frmCPG();
                mail.ShowDialog();
                Mail = mail.txtMail.Text;
                if (mail.DialogResult == DialogResult.OK)
                {
                    sendmail(Mail, docname);
                } 
            }
            if (msj.DialogResult == DialogResult.Yes)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(rutasave);
                Process.Start(startInfo);     
            }
            dataGridView1.DataSource = null;
        }
        public void GetIDs()
        {
            using (var con = new SqlConnection(conect))
            {
                int Rows;
              
                Rows = dataGridView1.RowCount - 1;
                con.Open();
              
                cmd = new SqlCommand("select PREID from tbprepacientes where prereport = " + ReportID + "", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "PREID");
                dataGridView1.DataSource = myDataSet.Tables["PREID"].DefaultView;
                dataGridView1.Columns["PREID"].DisplayIndex = 0;
                con.Close();
              
            }
        }
        public void getPlantilla()
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                con.Open();
                using (SqlCommand cm = con.CreateCommand())
                {

                cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = 'PreID'  ";
              
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            realname = dr[1].ToString();
                            int size = 1024 * 1024;
                            byte[] buffer = new byte[size];
                            int readBytes = 0;
                            int index = 0;
                            string fileName = Application.StartupPath + @"\\resourses\" + ReportID + "-" + realname;
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
        public void generatePDF()
        {
            clsRandomNo rd = new clsRandomNo();
            rd.GetNo();
            getPlantilla();
            docname =   rd.RandomNo + ".pdf";
            object ObjMiss = System.Reflection.Missing.Value;
            Word.Application ObjWord = new Word.Application();
            string ruta = Application.StartupPath + @"\\resourses\" + ReportID + "-" + realname;
             rutasave = @"C:\SGP\" + docname + "";
            object parametro = ruta;
            object save = rutasave;
            object DefaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            object WdAutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
            object fecha = "Fecha";
            object user = "Usuario";
            Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss);
            Word.Range fechas = ObjDoc.Bookmarks.get_Item(ref fecha).Range;
            fechas.Text = DateTime.Now.ToString("dd-MM-yyyy");
            Word.Range User = ObjDoc.Bookmarks.get_Item(ref user).Range;
            User.Text = Usuario;
            Word.Table table = ObjDoc.Tables[1];
            table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            int i = 2;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int rowcount = dataGridView1.Rows.Count;

                PreID = (string)row.Cells["PREID"].Value;

                table.Cell(i, 1).Range.Text = PreID;
                if (i <= rowcount)
                {
                    i++;
                    table.Rows.Add(ref ObjMiss);
                }
            }
            object rango1 = fechas;
            object rango2 = User;
            ObjDoc.Bookmarks.Add("Fecha", ref rango1);
            ObjDoc.Bookmarks.Add("Usuario", ref rango2);
            ObjWord.Visible = false;
            ObjDoc.ExportAsFixedFormat(rutasave, Word.WdExportFormat.wdExportFormatPDF);

            object DoNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;

            ObjDoc.Close(ref DoNotSaveChanges);

            ObjWord.Quit();
         

        }
     

        private void frmConsultaPI_Load(object sender, EventArgs e)
        {
            GetData();
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
                mailtxt.Subject = "Reporte PRE-ID CGE Laboratorio";
                mailtxt.IsBodyHtml = true;
                mailtxt.Body = "Saludos, adjunto se encuentra el reporte de pre-id generados.";

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
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al enviar resultados al correo: " + Mail + ", Contacte al Administrador." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            }
        
        public void GetData()
        {
            try
            {

                using (var con = new SqlConnection(conect))
                {
                    SqlDataAdapter da = new SqlDataAdapter("spgetPreid", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Report", "ID");
                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    radGridView1.Columns[0].IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetReportes()
        {
            try
            {

                using (var con = new SqlConnection(conect))
                {
                    SqlDataAdapter da = new SqlDataAdapter("spgetPreid", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Report", "Rep");
                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    radGridView1.Columns[0].IsVisible = true;
                    radGridView1.Columns.Move(0, 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnact_Click(object sender, EventArgs e)
        {
            GetReportes();
            groupBox1.Text = "Consulta de Reportes";
        }
    }
}
