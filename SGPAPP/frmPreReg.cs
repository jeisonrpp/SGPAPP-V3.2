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
using Word = Microsoft.Office.Interop.Word;

namespace SGPAPP
{
    public partial class frmPreReg : Form
    {
        public frmPreReg()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        String PreID;
        int Max;
        int Cantidad;
        String LastID;
        String FirstID="CGE";
        DateTime Fecha = DateTime.Now;
        String cambiada2;
        String EmptyID;
        int ReportID;
        String Mail;
        clsMail cm = new clsMail();
        string docname;
        string rutasave;

        public void GetPreID()
        {

            using (var con = new SqlConnection(conect))
            {
                string sql = "Select count (preid) from tbprepacientes";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();


                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    PreID = reader[0].ToString();
                    con.Close();
                   
                }
                }
            }
        public void GetEmptyID()
        {
            using (var con = new SqlConnection(conect))
            {
                int Rows;
                String ID;
                Rows = dataGridView2.RowCount - 1;
                con.Open();
                if (txtID.Text.Length < 1)
                {
                    cmd = new SqlCommand("select preid from tbprepacientes where preFechareg < DATEADD(HH,-24,getdate()) and prenom is null and preidentity is null ", con);
                }
                else
                {
                    cmd = new SqlCommand("select preid from tbprepacientes where preFechareg < DATEADD(HH,-24,getdate()) and prenom is null and preidentity = '" + txtID.Text + "'", con);
                }
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "preid");
                dataGridView2.DataSource = myDataSet.Tables["preid"].DefaultView;
                dataGridView2.Columns["preid"].DisplayIndex = 0;
                con.Close();

                if (dataGridView2.Rows.Count > 0)
                {
                    int Emptyidcount = dataGridView2.Rows.Count;
                    Cantidad = Cantidad - Emptyidcount;
                }
                foreach(DataGridViewRow row in dataGridView2.Rows)
                {
                    EmptyID = Convert.ToString(row.Cells["preID"].Value);
                    dataGridView1.Rows.Add(EmptyID);
                    updatepreid();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

        }
        String realname;
        public void getPlantilla()
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                con.Open();
                using (SqlCommand cm = con.CreateCommand())
                {
                    //string fileName = Application.StartupPath + @"\\resourses\" + PacID+"-plantillaresults";


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
             docname = rd.RandomNo + ".pdf";
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
            User.Text = UserCache.Usuario;
            Word.Table table = ObjDoc.Tables[1];
            table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            int i = 2;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int rowcount = dataGridView1.Rows.Count;

                PreID = (string)row.Cells["IDPre"].Value;

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
        public void GeneratePreID()
        {
            using (var con = new SqlConnection(conect))
            {
                Fechadehoy();
                string Sql = "insert into tbprepacientes(preid, prefechareg, preUser, preIdentity, prereport) values ('" + PreID+ "', '"+cambiada2+"', '"+UserCache.Usuario+"', '"+txtID.Text+"', "+ReportID+")";
                // con = new SqlConnection(cs.ConnectionString);
                cmd = new SqlCommand(Sql, con);
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

        private void frmPreReg_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnGenera_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Length > 0)
            {
                if (txtID.Text.Length > 5)
                {
                    MessageBox.Show("Debe colocar un identificador mas corto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {


                    if (int.Parse(txtCantidad.Text) < 50)
                    {
                        DialogResult resulta = MessageBox.Show("Seguro desea generar '" + txtCantidad.Text + "' IDs?", "Generar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resulta == DialogResult.Yes)
                        {

                            Cantidad = int.Parse(txtCantidad.Text);
                            GetEmptyID();
                            GetReporteID();
                            
                            for (int i = 0; i < Cantidad; i++)
                            {
                                

                                GetPreID();
                                
                                //PreID = PreID.Substring(4);
                                Max = int.Parse(PreID);
                                Max = Max + 1;
                                if (txtID.Text.Length > 0)
                                {
                                    PreID = "PRE-0" + Max.ToString() + "-"+txtID.Text;
                                }
                                else
                                {
                                    PreID = "PRE-0" + Max.ToString();
                                }
                           
                                if (FirstID == "CGE")
                                {
                                    FirstID = PreID;
                                }
                                GeneratePreID();
                                dataGridView1.Rows.Add(PreID);
                             
                            }
                            LastID = PreID;
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
                            dataGridView1.Rows.Clear();

                            txtCantidad.Text = "";
                            txtID.Text = "";
                            Logs log = new Logs();
                            log.Accion = "IDs generados desde el: " + FirstID + " hasta el " + LastID + "";
                            log.Form = "Generacion Pre-ID";
                            log.SaveLog();

                            using (var con = new SqlConnection(conect))
                            {
                                try
                                {
                                    string sql = "update tbcontador set preregistroID =" + ReportID + "";

                                    SqlCommand cmd = new SqlCommand(sql, con);
                                    cmd.CommandType = CommandType.Text;
                                    con.Open();
                                    int i = cmd.ExecuteNonQuery();
                                    if (i > 0) ;
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
                    else
                    {
                        MessageBox.Show("La cantidad máxima es de 50 IDs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Debe digitar una cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void GetReporteID()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "Select preregistroid from tbcontador";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();


                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ReportID = Convert.ToInt32(reader[0]);
                        ReportID = ReportID + 1;
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado registro!");
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
        public void updatepreid()
        {
            using (var con = new SqlConnection(conect))
            {
                Fechadehoy();
                string sql = "update tbprepacientes set prefechareg = '"+cambiada2+"' where preid = '"+EmptyID+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                int i = cmd.ExecuteNonQuery();
            }
            }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void Fechadehoy()
        {
            try
            {
                DateTime fecha2;


                fecha2 = Fecha;

                String day = fecha2.Day.ToString();
                String mes = fecha2.Month.ToString();
                String year = fecha2.Year.ToString();

                cambiada2 = year + "-" + mes + "-" + day;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            GetEmptyID();
        }
    }
}
