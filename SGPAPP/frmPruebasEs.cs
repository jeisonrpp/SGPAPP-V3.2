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
       public String HoraMuestra;
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
        int Nofact;
        bool HIV = false;
        public bool Colotect = false;
        public bool Special = false;
        int reid;
        List<int> ResultsList = new List<int> ();

        private void frmPruebasEs_Load(object sender, EventArgs e)
        {
            frmNoFact nf = new frmNoFact();
            nf.ShowDialog();
            if (nf.DialogResult == DialogResult.OK)
            {
                Nofact = Convert.ToInt32(nf.txtNoFact.Text);
                GetPaciente();
                GetPrueba();
            }
        }
      
        public void GetPaciente()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetPacientes";
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar)).Value = pacID;
                cmd.Parameters.Add(new SqlParameter("@Fechadesde", SqlDbType.VarChar)).Value = "edit";
                cmd.Parameters.Add(new SqlParameter("@Fechahasta", SqlDbType.VarChar)).Value = (object)DBNull.Value;
                SqlDataReader reader;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblname.Text = reader[1].ToString();
                        lblCed.Text = reader[2].ToString();
                        Age = reader[3].ToString();
                        if (Age == "1900-01-01")
                        {
                            lblage.Text = "-";
                            lblFecha.Text = "-";
                        }
                        else
                        {
                            Age = Convert.ToString(DateTime.Today.AddTicks(-DateTime.Parse(Age).Ticks).Year - 1);
                            lblage.Text = Age.ToString() + " años";
                            lblFecha.Text = reader[3].ToString();
                        }
                        mail = reader[6].ToString();
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
                using (var con = new SqlConnection(conect))
                {
                 con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spValidatePreResult";
                cmd.Parameters.Add(new SqlParameter("@pruebaid", SqlDbType.Int)).Value = PruebaID;
             
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Esta prueba ya fue reportada y se encuentra pendiente de aprobacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    this.Close();
                }
                
                else
                {
                    //con.Close();
                    //con.Open();
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
                foreach (GridViewRowInfo rowInfo in radGridView1.Rows) if (radGridView1.Rows[rowInfo.Index].Cells[0].Value == null)
                    {

                        int rowcount = radGridView1.Rows.Count;
                    
                        PruebaID = int.Parse(radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString());
                        Prueba = radGridView1.Rows[rowInfo.Index].Cells[3].Value.ToString();                      
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

                        dataGridView2.Rows.Add(PruebaID, pacID, lblname.Text, dir, lblFecha.Text, lblage.Text, lblCed.Text, Tipop, Prueba, Resultado, "null", "null", "null", "null", cambiada1, FechaMuestra, HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture), HoraMuestra, "null");
                        
                    }
              
                    InsertpreResults();
                frmLoadPDF lpdf = new frmLoadPDF();
                lpdf.Factid = Nofact.ToString();
                lpdf.ShowDialog();
             
                if (lpdf.DialogResult == DialogResult.Yes)
                {
                    DialogResult resulta = MessageBox.Show("Desea procesar estos resultados?", "Procesar Resultados", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (resulta == DialogResult.Yes)
                    {
                        try
                        {
                            InsertResults();
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
                                    //String Sql = "delete from tbpreResultados where rePruebaID = '" + PruebaID + "'";

                                    //SqlCommand cmd = new SqlCommand(Sql, con);
                                    //cmd.CommandType = CommandType.Text;
                                    //con.Open();


                                    //int e = cmd.ExecuteNonQuery();
                                    con.Open();
                                    cmd = new SqlCommand("", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "spDeletePreResult";
                                    cmd.Parameters.Add(new SqlParameter("@refactid", SqlDbType.Int)).Value = Nofact;

                                    cmd.ExecuteNonQuery();


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
        public void SendMail(int id)
        {
            using (var con = new SqlConnection(conect))
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertSendMailControl";
                cmd.Parameters.Add(new SqlParameter("@refactid", id));

                cmd.ExecuteNonQuery();
                con.Close();
                //String Query2 = "insert into tbControlMail (cmreid, cmpruebaempresaid, cmmail, cmfecha, cmhora, cmenviado, cmerror) values ((select reid from tbResultados where rePruebaID = " + PruebaID + " and repacid = " + pacID + "), '0', (select case when LEN(pemail2) >= 1  then pemail+', '+pemail2 else pEmail END from tbPacientes  where pid in (" + pacID + ")), '" + cambiada1 + "', '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', 0, NULL) ";
                //cmd = new SqlCommand(Query2, con);
                //cmd.CommandType = CommandType.Text;
                //con.Open();
                //try
                //{
                //    int i = cmd.ExecuteNonQuery();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error:" + ex.ToString());
                //}
                //finally
                //{
                //    con.Close();
                //}
            }
        }
      
       
            public void InsertpreResults()
            {
                using (var con = new SqlConnection(conect))
                {
                    if (Special == true)
                    {
                        
                        con.Open();
                        try
                        {

                            int rowcount = dataGridView2.RowCount;
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                cmd = new SqlCommand(Sql, con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "spUpdateResultData";
                                cmd.Parameters.Add(new SqlParameter("@resultado", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Results"].Value);
                                cmd.Parameters.Add(new SqlParameter("@resultado2", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["n3"].Value);
                                cmd.Parameters.Add(new SqlParameter("@ct", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["n2"].Value);
                                cmd.Parameters.Add(new SqlParameter("@ct2", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["n4"].Value);
                                cmd.Parameters.Add(new SqlParameter("@prueba", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Pruebas"].Value);
                                cmd.Parameters.Add(new SqlParameter("@pruebaid", SqlDbType.Int)).Value = Convert.ToString(row.Cells["IDPrueba"].Value);
                                cmd.ExecuteNonQuery();

                                if (rowcount == 1)
                                {

                                cmd = new SqlCommand(Sql, con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "spInsertPreResultadosLab";
                                cmd.Parameters.Add(new SqlParameter("@pacid", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["ID"].Value);
                                cmd.Parameters.Add(new SqlParameter("@resultado", SqlDbType.VarChar)).Value = "-";
                                cmd.Parameters.Add(new SqlParameter("@factid", SqlDbType.VarChar)).Value = Nofact;
                                cmd.Parameters.Add(new SqlParameter("@pruebaid", SqlDbType.Int)).Value = Convert.ToString(row.Cells["IDPrueba"].Value);
                                cmd.Parameters.Add(new SqlParameter("@preid", SqlDbType.Int)).Direction = ParameterDirection.Output;
                                cmd.ExecuteNonQuery();
                                reid = (int)cmd.Parameters["@preid"].Value;
                                ResultsList.Add(reid);

                                PruebaID = (int)row.Cells["IDPrueba"].Value;
                                    
                           
                                }
                                rowcount = rowcount - 1;
                            }
                        GeneratePDF();

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
                        con.Open();
                        try
                        {
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {

                            cmd = new SqlCommand(Sql, con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spInsertPreResultadosLab";
                            cmd.Parameters.Add(new SqlParameter("@pacid", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["ID"].Value);
                            cmd.Parameters.Add(new SqlParameter("@resultado", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Results"].Value);
                            cmd.Parameters.Add(new SqlParameter("@factid", SqlDbType.VarChar)).Value = Nofact;
                            cmd.Parameters.Add(new SqlParameter("@pruebaid", SqlDbType.Int)).Value = Convert.ToString(row.Cells["IDPrueba"].Value);
                            cmd.Parameters.Add(new SqlParameter("@preid", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            reid = (int)cmd.Parameters["@preid"].Value;
                            ResultsList.Add(reid);

                            PruebaID = (int)row.Cells["IDPrueba"].Value;
                 
                            

                            }
                        GeneratePDF();
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
              
                   con.Open();
                    try
                    {

                    foreach (var id in ResultsList)
                    {
                      
                            cmd = new SqlCommand("", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spInsertResultadosLab";
                            cmd.Parameters.Add(new SqlParameter("@reid", SqlDbType.VarChar)).Value = id;
                            cmd.Parameters.Add(new SqlParameter("@insertedfactid", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            Nofact = (int)cmd.Parameters["@insertedfactid"].Value;
                            
                        }
                    SendMail(Nofact);
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

        public void GeneratePDF()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertGeneratePDFControl";
                cmd.Parameters.Add(new SqlParameter("@refactid", Nofact));
                cmd.Parameters.Add(new SqlParameter("@user", UserCache.Usuario));

                cmd.ExecuteNonQuery();
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
                testvalue = Tipop;
                EditPlantilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
