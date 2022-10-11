using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.IO;

namespace SGPAPP
{
    public partial class frmPreResultados : Telerik.WinControls.UI.RadForm
    {
        public frmPreResultados()
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

        public void CargaPDF()
        {
            using (SqlConnection con = new SqlConnection(conect))
            {


                con.Open();
                using (SqlCommand cm = con.CreateCommand())
                {

                    cmd = new SqlCommand("", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spCargaPDFPreResultados";
                    SqlDataReader reader;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = IDre;

                    reader = cmd.ExecuteReader();
                    rd.GetNo();
                 
                        while (reader.Read())
                        {
                            string realname = reader[0].ToString();
                            int size = 1024 * 1024;
                            byte[] buffer = new byte[size];
                            int readBytes = 0;
                            int index = 0;
                            docname = name + "-" + rd.RandomNo + ".pdf";
                            fileName = @"C:\SGP\" + name + "-" + rd.RandomNo + ".pdf";
                            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                while ((readBytes = (int)reader.GetBytes(0, index, buffer, 0, size)) > 0)
                                {
                                    fs.Write(buffer, 0, readBytes);
                                    index += readBytes;
                                }
                            }

                        
                    }
                }
            }

        }

        private void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {

            IDre = Convert.ToString((int)e.Row.Cells["ID de Resultado"].Value);
            name = (string)e.Row.Cells["Paciente"].Value;
            CheckPDF();
            if (checkPDF == true)
            {
                //CargaPDF();
                Process prc = new Process();
                prc.StartInfo.FileName = fileName;
                prc.Start();
                //PDFDOC = (byte[])e.Row.Cells["PDF"].Value;
                //PacID = (int)e.Row.Cells["ID de Paciente"].Value;


                //name = (string)e.Row.Cells["Paciente"].Value;
                //edad1 = (string)e.Row.Cells["Edad"].Value;
                //fechana = (string)e.Row.Cells["Fecha de Nacimiento"].Value;
                //if (fechana == "1900-01-01")
                //{
                //    fechana = "-";
                //}
                //cedul = (string)e.Row.Cells["Cedula"].Value;
                //Prueba = (string)e.Row.Cells["Prueba"].Value;
                //resultado = (string)e.Row.Cells["Resultado"].Value;
                //if (e.Row.Cells["No. CT"].Value != System.DBNull.Value)
                //{
                //    noct = (string)e.Row.Cells["No. CT"].Value;
                //}
                //else
                //{
                //    noct = "-";
                //}
                //if (e.Row.Cells["Resultado2"].Value != System.DBNull.Value)
                //{
                //    Resultado2 = (string)e.Row.Cells["Resultado2"].Value;
                //}
                //else
                //{
                //    Resultado2 = "-";
                //}
                //if (e.Row.Cells["No. CT2"].Value != System.DBNull.Value)
                //{
                //    CT2 = (string)e.Row.Cells["No. CT2"].Value;
                //}
                //else
                //{
                //    CT2 = "-";
                //}

                //Fecha = (string)e.Row.Cells["Fecha de Emision"].Value;
                //if (e.Row.Cells["Hora de Muestra"].Value != System.DBNull.Value)
                //{
                //    HoraMuestra = (string)e.Row.Cells["Hora de Muestra"].Value;
                //}
                //else
                //{
                //    HoraMuestra = "";
                //}
                //if (e.Row.Cells["Hora de Emision"].Value != System.DBNull.Value)
                //{
                //    HoraEmision = (string)e.Row.Cells["Hora de Emision"].Value;
                //}
                //else
                //{
                //    HoraEmision = "";
                //}
                //if (e.Row.Cells["Fecha de Muestra"].Value == DBNull.Value)
                //{
                //    FechaMuestra = FechaReg;
                //}
                //else
                //{
                //    FechaMuestra = (string)e.Row.Cells["Fecha de Muestra"].Value;
                //}

                //if (e.Row.Cells["Direccion"].Value != System.DBNull.Value)
                //{
                //    dir = (string)e.Row.Cells["Direccion"].Value;

                //}
                //else
                //{
                //    dir = "-";
                //}
                //clsRandomNo rd = new clsRandomNo();
                //rd.GetNo();

                //docname = name + "-" + rd.RandomNo + ".pdf";
                //fileName = @"C:\SGP\" + name + "-" + rd.RandomNo + ".pdf";
                //System.IO.File.WriteAllBytes(fileName, PDFDOC);

                checkPDF = false;
            }
            else
            {
                MessageBox.Show("Este Resultado aun no ha sido generado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CheckPDF()
        {


            int rowIndex = radGridView1.CurrentCell.RowIndex;
            IDre = this.radGridView1.Rows[rowIndex].Cells["ID de Resultado"].Value.ToString();
            name = (string)this.radGridView1.Rows[rowIndex].Cells["Paciente"].Value;

            using (var con = new SqlConnection(conect))
            {
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCargaPDFPreResultados";
                SqlDataReader reader;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = IDre;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        checkPDF = true;
                        string realname = reader[0].ToString();
                        int size = 1024 * 1024;
                        byte[] buffer = new byte[size];
                        int readBytes = 0;
                        int index = 0;
                        docname = name + "-" + rd.RandomNo + ".pdf";
                        fileName = @"C:\SGP\" + name + "-" + rd.RandomNo + ".pdf";
                        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            while ((readBytes = (int)reader.GetBytes(0, index, buffer, 0, size)) > 0)
                            {
                                fs.Write(buffer, 0, readBytes);
                                index += readBytes;
                            }
                        }
                    }
                    else
                    {
                        checkPDF = false;
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
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        String day;
        String mes;
        String year;
        String Fecha;
        String docname;
        String name;
        String edad1;
        String fechana;
        String cedul;
        String resultado;
        String noct;
        String dir;
        string rutasave;
        int PacID;
        int PruebaID;
        String Mail;
        String Mail2;
        bool enviado;
        clsMail cm = new clsMail();
        String IDre;
        String FechaMuestra;
        bool Printed;
        String FechaReg;
        String HoraMuestra;
        String HoraEmision;
        byte[] PDFDOC;
        String QrLink;
        String ResultID;
        String Resultado2;
        String CT2;
        bool English = false;
        string fileName;
        bool validapr = false;
        clsRandomNo rd = new clsRandomNo();
        int Rows;
        int es = 0;
        string[] fileArray;
        SqlDataReader rdr = null;
        String Prueba;
        String Tipo;
        bool checkPDF;

        private void frmPreResultados_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {


            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetpreResults", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);


                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    if (radGridView1.Columns[0].Name == "CommandColumn2")
                    {
                        radGridView1.Columns.Move(0, 18);
                        radGridView1.Columns[1].IsVisible = false;
                        radGridView1.Columns[8].IsVisible = false;
                        radGridView1.Columns[11].IsVisible = false;
                        radGridView1.Columns[12].IsVisible = false;
                        radGridView1.Columns[13].IsVisible = false;
                        radGridView1.Columns[19].IsVisible = false;
                        radGridView1.Columns[20].IsVisible = false;
                        
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
            }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (txtConsulta.Text.Length == 0)
                {
                    GetData();
                }
                else
                {

                    using (var con = new SqlConnection(conect))
                    {
                        try
                        {
                            //con = new SqlConnection(cs.ConnectionString);
                            con.Open();
                            SqlDataAdapter da = new SqlDataAdapter("spGetpreResults", con);
                            DataTable dt = new DataTable();
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@Nombre", txtConsulta.Text);


                            da.Fill(dt);
                            this.radGridView1.DataSource = dt;
                            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                            //radGridView1.Columns.Move(0, 18);
                            //radGridView1.Columns[1].IsVisible = false;
                            //radGridView1.Columns[8].IsVisible = false;
                            //radGridView1.Columns[11].IsVisible = false;
                            //radGridView1.Columns[12].IsVisible = false;
                            //radGridView1.Columns[13].IsVisible = false;




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

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
           
            }

        private void btnSav_Click(object sender, EventArgs e)
        {
            int rowIndex = radGridView1.CurrentCell.RowIndex;
            Tipo = radGridView1.Rows[rowIndex].Cells[8].Value.ToString();
            PacID = int.Parse(radGridView1.Rows[rowIndex].Cells[1].Value.ToString());
            name = radGridView1.Rows[rowIndex].Cells[2].Value.ToString();


            foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
            {

                using (var con = new SqlConnection(conect))
                {
                    try
                    {
                        String Sql = "delete from tbpreresultados where reTipop = '" + Tipo + "' and rePacid = " + PacID + "";

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
            MessageBox.Show("Pruebas devueltas a Gestion de Resultados con Exito!", "Pruebas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetData();
        }
        public void getPaciente()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "select RTRIM(pemail) as [Email], RTRIM(pfechareg) as [Fecha Registro], RTRIM(pemail2) as [Email2] from tbpacientes where pID = '" + PacID + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Mail = reader[0].ToString();
                        FechaReg = reader[1].ToString();
                        Mail2 = reader[2].ToString();
                        if (Mail2.Length > 0)
                        {
                            Mail = Mail + ", " + Mail2;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado registro de paciente!");
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
        private void radButton1_Click(object sender, EventArgs e)
        {
            CheckPDF();
            if (checkPDF == true)
            {

                int rowIndex = radGridView1.CurrentCell.RowIndex;
                DialogResult resulta = MessageBox.Show("Esta seguro que desea aprobar los resultados de: " + radGridView1.Rows[rowIndex].Cells[2].Value.ToString() + "?", "Aprobar Resultados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Tipo = radGridView1.Rows[rowIndex].Cells[8].Value.ToString();
                PacID = int.Parse(radGridView1.Rows[rowIndex].Cells[1].Value.ToString());
                
                if (resulta == DialogResult.Yes)
                {
                    foreach (GridViewRowInfo rowInfo in radGridView1.Rows) if ((int)radGridView1.Rows[rowInfo.Index].Cells[1].Value == PacID && (string)radGridView1.Rows[rowInfo.Index].Cells[8].Value == Tipo)
                        {
                            using (var con = new SqlConnection(conect))
                            {
                                try
                                {
                                    //string Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF) values ('" + pacID + "', '" + lblname.Text + "', '" + dir + "', '" + lblFecha.Text + "', '" + lblage.Text + "', '" + lblCed.Text + "','" + Tipop + "', '" + Prueba + "', '" + Resultado + "', '" + null + "', '" + null + "', '" + null + "', '" + null + "','" + cambiada1 + "' , '" + FechaMuestra + "',  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + HoraMuestra + "', '" + null + "')";
                                    SqlCommand AddResultados = new SqlCommand("Insert into tbResultados values (@rePacid, @rePaciente, @reDir, @reFechan, @reEdad, @reCed, @reTipop, @rePrueba, @reResultado, @reCT, @reFecha, @refecham, @reHora, @reHoram, (select redocpdf from tbpreresultados where reid = " + int.Parse(radGridView1.Rows[rowIndex].Cells[0].Value.ToString()) + "), @reResultado1, @reResultado2, @reCT2, @reEmpresa, @rePruebaID, @reFacturacionID)", con);
                                    con.Open();

                                    PruebaID = (int)radGridView1.Rows[rowInfo.Index].Cells[19].Value;
                                    AddResultados.Parameters.Clear();
                                    AddResultados.Parameters.AddWithValue("@rePacid", PacID);
                                    AddResultados.Parameters.AddWithValue("@rePaciente", radGridView1.Rows[rowInfo.Index].Cells[2].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reDir", radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reEdad", radGridView1.Rows[rowInfo.Index].Cells[5].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reFechan", radGridView1.Rows[rowInfo.Index].Cells[4].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reCed", radGridView1.Rows[rowInfo.Index].Cells[3].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reTipop", radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@rePrueba", radGridView1.Rows[rowInfo.Index].Cells[9].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reResultado", radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reResultado1", radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reCT", radGridView1.Rows[rowInfo.Index].Cells[11].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reResultado2", radGridView1.Rows[rowInfo.Index].Cells[12].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reCT2", radGridView1.Rows[rowInfo.Index].Cells[13].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reFecha", radGridView1.Rows[rowInfo.Index].Cells[15].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reFecham", radGridView1.Rows[rowInfo.Index].Cells[14].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reHoram", radGridView1.Rows[rowInfo.Index].Cells[17].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reHora", radGridView1.Rows[rowInfo.Index].Cells[16].Value.ToString());
                                    //AddResultados.Parameters.AddWithValue("@PDFDOC", (byte[])radGridView1.Rows[rowInfo.Index].Cells[19].Value);
                                    AddResultados.Parameters.AddWithValue("@reEmpresa", SqlDbType.VarChar).Value = DBNull.Value;
                                    AddResultados.Parameters.AddWithValue("@rePruebaID", radGridView1.Rows[rowInfo.Index].Cells[19].Value.ToString());
                                    AddResultados.Parameters.AddWithValue("@reFacturacionID", radGridView1.Rows[rowInfo.Index].Cells[20].Value.ToString());
                                    AddResultados.ExecuteNonQuery();
                                    DelPrueba();
                                    DelPreResult();
                                   
                                    clsRandomNo rd = new clsRandomNo();
                                    rd.GetNo();

                                    if (radGridView1.Rows[rowInfo.Index].Cells[9].Value.ToString() != "HIV" && enviado == false)
                                    {
                                        getPaciente();
                                        SendMail();
                                       
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
                                Logs log = new Logs();
                                log.Accion = "Resultados Aprobados a Prueba ID: " + PruebaID + " del Paciente: " + name + "";
                                log.Form = "Aprobar Resultados";
                                log.SaveLog();

                            }
                        }

                    MessageBox.Show("Resultados Aprobados Correctamente!", "Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    enviado = false;
                    GetData();
                }
            }
            else
            {
                MessageBox.Show("Este Resultado aun no ha sido generado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void sendmailold(string mailto, string doc)
        {
            try
            {
                cm.GetMailSetup();

                string filename = doc;
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

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo, favor contactar el administrador." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void DelPrueba()
    {
        using (var con = new SqlConnection(conect))
        {
                try { 
            String Sql = "delete from tbPruebasPendientes where ppID = '" + PruebaID + "'";

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
        public void DelPreResult()
        {
            using (var con = new SqlConnection(conect))
            {
                try { 
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

        public void SendMail()
        {
            using (var con = new SqlConnection(conect))
            {
                if (Mail2.Length > 0)
                {
                    Mail = Mail + ", " + Mail2;
                }
                String Query2 = "insert into tbControlMail (cmreid, cmpruebaempresaid, cmmail, cmfecha, cmhora, cmenviado, cmerror) values ((select reid from tbResultados where rePruebaID = " + PruebaID + " and repacid = " + PacID + "), '0', '" + Mail + "',  convert(date, getdate()), convert(time, getdate()), 0, NULL) ";
                cmd = new SqlCommand(Query2, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    enviado = true;

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

        private void frmPreResultados_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
