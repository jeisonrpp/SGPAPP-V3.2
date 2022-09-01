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
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;
using Word = Microsoft.Office.Interop.Word;

namespace SGPAPP
{
    public partial class frmResultse : Telerik.WinControls.UI.RadForm
    {
        public frmResultse()
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
        public void CheckPDF()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT redocPDF as [PDF] from tbresultados where reid = " + IDre + " and redocpdf is not null";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        checkPDF = true;

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
            private void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {

            GridViewRowInfo row = radGridView1.CurrentRow;
            IDre = Convert.ToString((int)e.Row.Cells["ID de Resultado"].Value);
            CheckPDF();
            if (checkPDF == false)
            {
                MessageBox.Show("Este Resultado aun no ha sido generado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PDFDOC = (byte[])e.Row.Cells["PDF"].Value;
                PacID = (int)e.Row.Cells["ID de Paciente"].Value;
                getPaciente();
                
                name = (string)e.Row.Cells["Paciente"].Value;
                edad1 = (string)e.Row.Cells["Edad"].Value;
                fechana = (string)e.Row.Cells["Fecha de Nacimiento"].Value;
                if (fechana == "1900-01-01")
                {
                    fechana = "-";
                }
                cedul = (string)e.Row.Cells["Cedula"].Value;
                Prueba = (string)e.Row.Cells["Prueba"].Value;
                resultado = (string)e.Row.Cells["Resultado"].Value;
                if (e.Row.Cells["No. CT"].Value != System.DBNull.Value)
                {
                    noct = (string)e.Row.Cells["No. CT"].Value;
                }
                else
                {
                    noct = "-";
                }
                if (e.Row.Cells["Resultado2"].Value != System.DBNull.Value)
                {
                    Resultado2 = (string)e.Row.Cells["Resultado2"].Value;
                }
                else
                {
                    Resultado2 = "-";
                }
                if (e.Row.Cells["No. CT2"].Value != System.DBNull.Value)
                {
                    CT2 = (string)e.Row.Cells["No. CT2"].Value;
                }
                else
                {
                    CT2 = "-";
                }

                Fecha = (string)e.Row.Cells["Fecha de Emision"].Value;
                if (e.Row.Cells["Hora de Muestra"].Value != System.DBNull.Value)
                {
                    HoraMuestra = (string)e.Row.Cells["Hora de Muestra"].Value;
                }
                else
                {
                    HoraMuestra = "";
                }
                if (e.Row.Cells["Hora de Emision"].Value != System.DBNull.Value)
                {
                    HoraEmision = (string)e.Row.Cells["Hora de Emision"].Value;
                }
                else
                {
                    HoraEmision = "";
                }
                if (e.Row.Cells["Fecha de Muestra"].Value == DBNull.Value)
                {
                    FechaMuestra = Fechareg;
                }
                else
                {
                    FechaMuestra = (string)e.Row.Cells["Fecha de Muestra"].Value;
                }

                if (e.Row.Cells["Direccion"].Value != System.DBNull.Value)
                {
                    dir = (string)e.Row.Cells["Direccion"].Value;

                }
                else
                {
                    dir = "-";
                }
                conviertefecha();


                CargaPlantilla();


                MessageBox.Show("Resultados generados satisfactoriamente.", "Operacion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);



                // }
            }    
        }
        bool checkPDF;
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        string cambiada1;
        string cambiada2;
        string cambiada3;
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
       public String Mail;
        bool enviado;
        clsMail cm = new clsMail();
        String IDre;
        String FechaMuestra;
        bool validate;
        public String Fechareg;
        String HoraMuestra;
        public String HoraEmision;
        byte[] PDFDOC;
        String QrLink;
        String ResultID;
        String Resultado2;
        String CT2;
        public String Empresa;
        bool English = false;
        string fileName;
        public int PruebaID;
        DateTime HoraRegistro;
        private void frmResultse_Load(object sender, EventArgs e)
        {

            GetData();
        }
        public void GetData()
        {
            try
            {


                using (var con = new SqlConnection(conect))
                {
                    con.Open();
                    cmd = new SqlCommand("SELECT  A.reID as [ID de Resultado], A.rePacid as [ID de Paciente], RTRIM(A.rePaciente) as [Paciente], RTRIM(A.reCed) as [Cedula], RTRIM(A.reFechan) as [Fecha de Nacimiento], RTRIM(A.reEdad) as [Edad], RTRIM(A.redir) as [Direccion], B.pemail as [Email], RTRIM(A.reTipop) as [Tipo de Prueba], RTRIM(A.rePrueba) as [Prueba], RTRIM(A.reResultado1) as [Resultado], RTRIM(A.reCT) as [No. CT], RTRIM(A.reResultado2) as [Resultado2], RTRIM(A.reCT2) as [No. CT2], RTRIM(A.reFecham) as [Fecha de Muestra], RTRIM(A.reFecha) as [Fecha de Emision], CONVERT(varchar(15),CAST(rehora AS TIME),100) as [Hora de Emision], CONVERT(varchar(15),CAST(rehoram AS TIME),100) as [Hora de Muestra], (A.reDocPDF) as [PDF]  from tbresultados A Inner join tbPacientes B on A.rePacid = b.pId where reEmpresa = '" + Empresa+"' and repruebaid = '"+PruebaID+ "' order by reid desc", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();

                    myDA.Fill(myDataSet, "Paciente");
                    radGridView1.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    if (radGridView1.Columns[0].Name == "CommandColumn2")
                    {
                        radGridView1.Columns.Move(0, 19);
                    }

                    radGridView1.Columns["PDF"].IsVisible = false;

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExporta_Click(object sender, EventArgs e)
        {

        }

        private void ExportaExcl(DataGridView dgb)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
                excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
                int IndiceColumna = 0;
                foreach (DataGridViewColumn columna in dgb.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                {
                    IndiceColumna++;
                    excel.Cells[1, IndiceColumna] = columna.Name;
                }
                int IndiceFila = 0;
                foreach (DataGridViewRow fila in dgb.Rows) //Aquí leemos las filas de las columnas leídas
                {
                    IndiceFila++;
                    IndiceColumna = 0;
                    foreach (DataGridViewColumn columna in dgb.Columns)
                    {
                        IndiceColumna++;
                        excel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                    }
                }
                excel.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("No hay Registros a Exportar.");
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
                    client.EnableSsl = cm.MailSSL;
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    client.UseDefaultCredentials = true;
                    NetworkCredential cred = new System.Net.NetworkCredential(cm.MailUser, cm.MailPass);

                    client.Credentials = cred;
                    client.Send(mailtxt);
                    enviado = true;


                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al enviar resultados al correo: " + Mail + ", Contacte al Administrador." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    enviado = false;
                }
            }
        }



        public void conviertefecha()
        {
            try
            {

                DateTime fecha3;

              

                if (Fecha != null)
                {
                    fecha3 = DateTime.Parse(Fecha);

                    day = fecha3.Day.ToString();
                    mes = fecha3.Month.ToString();
                    year = fecha3.Year.ToString();

                    cambiada3 = year + "-" + mes + "-" + day;
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

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
                    //string fileName = Application.StartupPath + @"\\resourses\" + PacID+"-plantillaresults";
                    if (Prueba == "Sars Cov-2")
                    {
                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plid = @id  ";
                        if (resultado == "Detectado" && Prueba == "Sars Cov-2" && English == false)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 1;
                        }
                        if (Prueba == "Sars Cov-2" && resultado == "No Detectado" && English == false || Prueba == "Sars Cov-2" && resultado == "Indeterminado" && English == false)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 2;
                        }
                        if (Prueba == "Sars Cov-2" && English == true)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 6;
                        }
                    }
                    else
                    {
                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = '" + Prueba + "'  ";
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
                            string fileName = Application.StartupPath + @"\\resourses\" + PacID + "-" + realname;
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
        public void getPaciente()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "select RTRIM(pemail) as [Email], RTRIM(pfechareg) as [Fecha Registro] from tbpacientes where pID = '" + PacID + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Mail = reader[0].ToString();
                        Fechareg = reader[1].ToString();
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
        String Prueba;
       
        public void CargaPlantilla()
        {
            clsRandomNo rd = new clsRandomNo();
            rd.GetNo();

            docname = name + "-" + rd.RandomNo + ".pdf";
            fileName = @"C:\SGP\" + name + "-" + rd.RandomNo + ".pdf";
            System.IO.File.WriteAllBytes(fileName, PDFDOC);
            Process prc = new Process();
                    prc.StartInfo.FileName = fileName;
                    prc.Start();




        }

        public void UpdatePlantilla()
        {
            using (var con = new SqlConnection(conect))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    cmd.CommandText = @"update tbresultados set reDocPDF = @DOC where reID = " + IDre + "";
                    cmd.Parameters.AddWithValue("@DOC", SqlDbType.VarBinary).Value = PDFDOC;
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
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                GetData();
            }
        }

        private void txtConsulta_Enter(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "Digite nombre o cedula")
            {
                txtConsulta.Text = "";
                txtConsulta.ForeColor = Color.Silver;
                GetData();
            }
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public void ValidaSendMail()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                string ct = "select * from tbcontrolmail where cmpruebaempresaid = '"+PruebaID+"' and cmenviado = 0";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Estos resultados ya se encuentran pendientes de ser enviados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    validate = true;
                    con.Close();
                }

                else if ((rdr != null))
                {
                    validate = false;
                    con.Close();
                }
            }
        }
        public void SendMail()
        {
            using (var con = new SqlConnection(conect))
            {
                ValidaSendMail();
                if (validate == false)
                {
                    HoraRegistro = DateTime.Now;
                    String Query2 = "insert into tbControlMail (cmreid, cmpruebaempresaid, cmmail, cmfecha, cmhora, cmenviado, cmerror) values ((select top 1 reid from tbResultados where rePruebaID = " + PruebaID + " and reEmpresa = '" + Empresa + "'), '" + PruebaID + "', '" + Mail + "', '" + cambiada1 + "', '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', 0, NULL) ";
                    cmd = new SqlCommand(Query2, con);
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
                        Logs log = new Logs();
                        log.Accion = "Resultados reenviados de Empresa: " + Empresa + " ID: " + PruebaID + "";
                        log.Form = "Consulta Resultado de Empresas";
                        log.SaveLog();
                    }
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            String FileExp = "C:\\SGP\\exportedFile" + DateTime.Now.ToString("yyyy-mm-dd") + ".xlsx";
            GridViewSpreadExport spreadExporter = new GridViewSpreadExport(this.radGridView1);
            SpreadExportRenderer exportRenderer = new SpreadExportRenderer();
            spreadExporter.RunExport(FileExp, exportRenderer);
            Process prc = new Process();
            prc.StartInfo.FileName = FileExp;
            prc.Start();
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            SendMail();
        }
    }
}
