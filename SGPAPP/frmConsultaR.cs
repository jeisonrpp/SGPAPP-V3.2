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
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Diagnostics;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace SGPAPP
{
    public partial class frmConsultaR : Form
    {
        public frmConsultaR()
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
        Int32 PruebaID;
        String Metodo;
        String Paciente;
        String Dir;
        String Fechar;
        String Age;
        String Ced;
        String Tipo;
        String Test;
        String Result;
        String Result1;
        String CT;
        String CT2;
        String Results2;
        String Fechaemision;
        String FechaMuestra;
        String HoraMuestra;
        String HoraRegistro;
        clsMail cm = new clsMail();
        String Mail;
        String Prueba;
        bool validapr = false;
        bool validaEmpresa = false;
        int counter;
        bool especial = false;

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
                    da.SelectCommand.Parameters.AddWithValue("@Pruebas", DBNull.Value);
                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    if (radGridView1.Columns[0].Name == "CommandColumn2")
                    {
                        radGridView1.Columns.Move(0, 10);

                    }

                    radGridView1.Columns[8].IsVisible = false;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmConsultaR_Load(object sender, EventArgs e)
        {
          
            GetData();
        }

       

     
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void SaveLog()
        {
            Logs log = new Logs();
            log.Accion = "Prueba ID: "+PruebaID+", del Paciente: " + Paciente + ", Eliminada";
            log.Form = "Eliminacion de Pruebas";
            log.SaveLog();

        }
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
      
        //public void MergePDF()
        //{
        //    int RowCount = dataGridView3.Rows.Count;
        //    RowCount = RowCount + 1;
        //    string[] fileArray = new string[RowCount];
        //    int e = 0;
        //    foreach (DataGridViewRow row in dataGridView3.Rows)
        //    {               
        //        String Filename = (string)row.Cells["Column1"].Value;
       
                
        //        fileArray[e] = "C:\\SGP\\"+Filename;
        //        e++;
        //    }

        //    DateTime Fecha = DateTime.Now;
        //    PdfReader reader = null;
        //    Document sourceDocument = null;
        //    PdfCopy pdfCopyProvider = null;
        //    PdfImportedPage importedPage;
        //    string outputPdfPath = @"C:/SGP/"+PacienteNom+" - "+Fecha.ToString("yyyy-MM-dd")+".pdf";

        //    sourceDocument = new Document();
        //    pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
       
        //    //output file Open  
        //    sourceDocument.Open();


        //    //files list wise Loop  
        //    for (int f = 0; f < fileArray.Length - 1; f++)
        //    {
        //        int pages = TotalPageCount(fileArray[f]);

        //        reader = new PdfReader(fileArray[f]);
        //        //Add pages in new file  
        //        for (int i = 1; i <= pages; i++)
        //        {
        //            importedPage = pdfCopyProvider.GetImportedPage(reader, i);
        //            pdfCopyProvider.AddPage(importedPage);
        //        }

        //        reader.Close();
        //    }
        //    //save the output file  
        //    sourceDocument.Close();
        //    String doc ="";
        //    //byte[] PDFDOC = System.IO.File.ReadAllBytes(outputPdfPath);
        //    //foreach (DataGridViewRow rows in dataGridView4.Rows)
        //    //{
        //    //    Dir = (string)rows.Cells["cldir"].Value;
        //    //    Fechar = (string)rows.Cells["clfechar"].Value;
        //    //    Age = (string)rows.Cells["clage"].Value;
        //    //    Ced = (string)rows.Cells["clced"].Value;
        //    //    Tipo = (string)rows.Cells["cltipo"].Value;
        //    //    Test = (string)rows.Cells["cltest"].Value;
        //    //    Result = (string)rows.Cells["clresult"].Value;
        //    //    Result1 = (string)rows.Cells["clResult1"].Value;
        //    //    CT = (string)rows.Cells["clct"].Value;
        //    //    Results2 = (string)rows.Cells["clResults2"].Value;
        //    //    CT2 = (string)rows.Cells["clCT2"].Value;
        //    //    Fechaemision = (string)rows.Cells["clFechae"].Value;
        //    //    FechaMuestra = (string)rows.Cells["clFecham"].Value;
        //    //    HoraMuestra = (string)rows.Cells["clHoram"].Value;
        //    //    HoraRegistro = (string)rows.Cells["clHorare"].Value;

        //    //    using (var con = new SqlConnection(conect))
        //    //    {
        //    //        string Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF) values ('" + PacienteID + "', '" + PacienteNom + "', '" + Dir + "', '" + Fechar + "', '" + Age + "', '" + Ced + "','" + Tipo + "', '" + Test + "', '" + Result + "', '" + Result1 + "', '" + CT + "', '" + Results2 + "', '" + CT2 + "','" + Fechaemision + "' , '" + FechaMuestra + "', '" + HoraMuestra + "', '" + HoraRegistro + "', @PDFDOC)";
        //    //        cmd = new SqlCommand(Sql, con);
        //    //        cmd.CommandType = CommandType.Text;
        //    //        cmd.Parameters.Add("@PDFDOC", SqlDbType.VarBinary).Value = PDFDOC;
        //    //        con.Open();
        //    //        try
        //    //        {
        //    //            int i = cmd.ExecuteNonQuery();




        //    //        }
        //    //        catch (Exception ex)
        //    //        {
        //    //            MessageBox.Show("Error:" + ex.ToString());
        //    //        }
        //    //        finally
        //    //        {
        //    //            con.Close();
        //    //        }
        //    //    }
        //    //}
        //    Process prc = new Process();
        //    prc.StartInfo.FileName = outputPdfPath;
        //    prc.Start();
        //    doc = PacienteNom + " - " + Fecha.ToString("yyyy-MM-dd") + ".pdf";
        //    sendmail(Mail, doc);
        //}
        //private int TotalPageCount(string file)
        //{
        //    using (StreamReader sr = new StreamReader(System.IO.File.OpenRead(file)))
        //    {
        //        Regex regex = new Regex(@"/Type\s*/Page[^s]");
        //        MatchCollection matches = regex.Matches(sr.ReadToEnd());

        //        return matches.Count;
        //    }
        //}
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
                //Enviado = true;
            }

            catch (Exception ex)
            {
               // Enviado = false;
            }
        }
        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void advancedDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

       

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtConsulta_Leave(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "")
            {
                txtConsulta.Text = "Digite nombre o cedula";
                txtConsulta.ForeColor = Color.Silver;
               
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

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                
                    if (txtConsulta.Text != "Digite nombre o cedula")
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
                            da.SelectCommand.Parameters.AddWithValue("@Pruebas", DBNull.Value);
                            da.Fill(dt);
                            this.radGridView1.DataSource = dt;
                            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;



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
            }
        public void ValidaPruebas()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spValidaPruebasParaReportar";
                SqlDataReader reader;
                cmd.Parameters.Add("@prueba", SqlDbType.VarChar).Value = Prueba;
                cmd.Parameters.Add("@pid", SqlDbType.VarChar).Value = PacienteID;
                try
                {
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        validapr = (bool)reader[2];
                        especial = (bool)reader[1];
                        counter = (int)reader[3];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }
        void btnImagenclick_Click(object sender, EventArgs e)
        {
            
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

        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            object cellValue = e.Row.Cells[0].Value;
        }

        private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.Name == "Column1")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = System.Drawing.Color.WhiteSmoke;

                GridImageCellElement imgCell = e.CellElement as GridImageCellElement;

                if (imgCell != null)
                {
                    imgCell.Image = Properties.Resources.icons8_checkmark_16;


                    try
                    {
                        imgCell.Click -= btnImagenclick_Click;
                    }
                    catch
                    {

                    }

                    imgCell.Click += btnImagenclick_Click;
                }
            }
        }
      
        void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Asignar Resultados") || UserCache.Nivel == "Admin")
            {

                PacienteNom = (string)e.Row.Cells["Paciente"].Value;
                PacienteID = (string)e.Row.Cells["ID del Paciente"].Value;
                PruebaID = (int)e.Row.Cells["ID de Prueba"].Value;
                Metodo = (string)e.Row.Cells["Metodo"].Value;
                FechaMuestra = (string)e.Row.Cells["Fecha de Muestra"].Value;
                Prueba = (string)e.Row.Cells["Prueba"].Value;
                Tipo = (string)e.Row.Cells["Tipo de Prueba"].Value;
                DialogResult resulta;
                using (var con = new SqlConnection(conect))
                {
                    especial = false;
                    ValidaPruebas();


                    if (validapr == true)
                    {
                      
                        validapr = false;
                        frmPruebasEs resu = new frmPruebasEs();
                        resu.pacID = Convert.ToInt32(PacienteID);
                        resu.PruebaID = PruebaID;
                        resu.Method = Metodo;
                        resu.FechaMuestra = FechaMuestra;
                        resu.Tipop = Tipo;
                        resu.Special = especial;
                        resu.Pruebalab = Prueba;
                        if (Prueba == "COLOTECT")
                        {
                            resu.Colotect = true;
                        }
                        resu.ShowDialog();
                        if (resu.DialogResult == DialogResult.OK)
                        {

                            GetData();
                        }
                    }
                    else
                    {
                        //ValidaEmpresa();
                        if (Metodo == "Por Correo")
                        {
                            MessageBox.Show("Esta prueba pertenece a una empresa, los resultados no pueden ser reportados por esta via.", "Pruebas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    validaEmpresa = false;
                        }
                        else
                        {
                            try
                            {

                                frmReporte resu = new frmReporte();
                                resu.pacID = Convert.ToInt32(PacienteID);
                                resu.PrID = PruebaID;
                                resu.Method = Metodo;
                                resu.ShowDialog();
                                if (resu.DialogResult == DialogResult.OK)
                                {
                                    GetData();
                                }
                                //}
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                con.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Su usuario no posee privilegios para realizar esta accion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSav_Click(object sender, EventArgs e)
        {
            if (radGridView1.Rows.Count >= 1)
            {
                if (UserCache.RoleList.Any(item => item.RoleName == "Eliminar Pruebas") || UserCache.Nivel == "Admin")
                {


                    int rowIndex = radGridView1.CurrentCell.RowIndex;
                    PruebaID = (int)this.radGridView1.Rows[rowIndex].Cells["ID de Prueba"].Value;
                    Paciente = (string)this.radGridView1.Rows[rowIndex].Cells["Paciente"].Value;
                    DialogResult resulta = MessageBox.Show("Desea eliminar prueba del paciente: " + Paciente + " ?", "Eliminar Prueba?", MessageBoxButtons.YesNo);
                    if (resulta == DialogResult.Yes)
                    {

                        using (var con = new SqlConnection(conect))
                        {
                            try
                            {
                               
                                con.Open();
                                SqlCommand cmd = new SqlCommand("", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "spEliminarPruebasPendientes";
                                cmd.Parameters.Add(new SqlParameter("@pruebaid", SqlDbType.Int)).Value = PruebaID;
                                cmd.ExecuteNonQuery();

                                SaveLog();
                                Paciente = "";
                                PruebaID = 0;
                                GetData();

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
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        
    }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Resultados Pendientes") || UserCache.Nivel == "Admin")
            {
                frmPreResultados re = new frmPreResultados();
                re.ShowDialog();

                if (re.DialogResult == DialogResult.OK)
                {
                    GetData();
                }

            }
            else
            {
    
                MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
