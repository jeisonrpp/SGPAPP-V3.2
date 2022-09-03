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
using System.Text.RegularExpressions;
using System.Configuration;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using System.Security.Cryptography;
using System.Drawing.Printing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace SGPAPP
{
    public partial class frmRegPac : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        String Sex;
        String PacienteId;
        String cambiada1;
        String cambiada2;
        DateTime Fecha = DateTime.Now;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        SqlDataReader rdr = null;
        String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        String pass;
        string contraseniaAleatoria;
        String Cedula;
        clsMail cm = new clsMail();
        public frmRegPac()
        {
            InitializeComponent();
        }

        private void txtNom_Enter(object sender, EventArgs e)
        {
      
        }

        private void txtNom_Leave(object sender, EventArgs e)
        {
     
        }

        private void txtCed_Enter(object sender, EventArgs e)
        {

        }

        private void txtCed_Leave(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {

        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {

        }

        private void txtEmailC_Enter(object sender, EventArgs e)
        {

        }

        private void txtEmailC_Leave(object sender, EventArgs e)
        {

        }

        private void txtTel_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtDir_Enter(object sender, EventArgs e)
        {

        }

        private void txtDir_Leave(object sender, EventArgs e)
        {

        }

        private void txtCel_Enter(object sender, EventArgs e)
        {

        }

        private void txtCel_Leave(object sender, EventArgs e)
        {

        }

        private void cbbSeguro_Enter(object sender, EventArgs e)
        {

        }

        private void cbbSeguro_Leave(object sender, EventArgs e)
        {

        }

        private void txtSeg_Enter(object sender, EventArgs e)
        {

        }

        private void txtSeg_Leave(object sender, EventArgs e)
        {

        }

        private void txtFecha_Enter(object sender, EventArgs e)
        {


        }

        private void txtFecha_Leave(object sender, EventArgs e)
        {

        }

        private void txtNom_MouseClick(object sender, MouseEventArgs e)
        {
            //this.txtNom.Select(0, 0);
        }

        private void txtFecha_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtFecha.Select(0, 0);
        }

        private void txtSeg_MouseClick(object sender, MouseEventArgs e)
        {
            //this.txtCel.Select(0, 0);
            //this.txtCed.Select(0, 0);
            //this.txtDir.Select(0, 0);
            //this.txtEmail.Select(0, 0);
            //this.txtEmailC.Select(0, 0);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void cargacbbSeg()
        {
            using (var con = new SqlConnection(conect))
            {

                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("spGetSeguros", con);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                sqlData.Fill(table);
                cbbSeguro.DataSource = table;
                cbbSeguro.ValueMember = "Seguros";
                cbbSeguro.Text = "Seleccione el Seguro";
                con.Close();
             
   
            }
        }
        public void cargacbbRef()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("spGetReferidos", con);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                sqlData.Fill(table);
                cbbRef.DataSource = table;
                cbbRef.ValueMember = "Referidos";
                cbbRef.Text = "";
                con.Close();
              
            }
        }
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;
                if (txtFecha.Text == "No Aplica")
                {
                    cambiada1 = "1900-01-01";
                }
                else
                {
                    fecha1 = DateTime.ParseExact(txtFecha.Text, "dd-MM-yyyy", null);


                    String day = fecha1.Day.ToString();
                    String mes = fecha1.Month.ToString();
                    String year = fecha1.Year.ToString();

                    if(int.Parse(day) <= 9)
                    {
                        day = "0" + day;
                    }
                    if (int.Parse(mes) <= 9)
                    {
                        mes = "0" + mes;
                    }

                    cambiada1 = year + "-" + mes + "-" + day;
                    contraseniaAleatoria = day + mes + year;
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

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

         
        public void limpiar()
        {
            txtNom.Text = "";
            txtFecha.Text = "";
            txtCed.Text = "";
            txtCel.Text = "";
            cbbRef.Text = "";
            txtEmail.Text = "";
            txtEmailC.Text = "";
            label6.Visible = false;
            txtDir.Text = "";
            cbbSeguro.Text = "";
            rbF.Checked = false;
            rbM.Checked = false;
            chkFecha.Checked = false;
            chkCed.Checked = false;
            cbbDoc.SelectedIndex = 0;
        }

        public void GuardaPacientes()
        {
            string Email = txtEmail.Text;
         
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertPacientes";
                cmd.Parameters.Add(new SqlParameter("@pNom", SqlDbType.VarChar)).Value = txtNom.Text;
                cmd.Parameters.Add(new SqlParameter("@pCed", SqlDbType.VarChar)).Value = txtCed.Text;
                cmd.Parameters.Add(new SqlParameter("@pSex", SqlDbType.VarChar)).Value = Sex;
                cmd.Parameters.Add(new SqlParameter("@pFecha", SqlDbType.VarChar)).Value = cambiada1;
                cmd.Parameters.Add(new SqlParameter("@pDir", SqlDbType.VarChar)).Value = txtDir.Text;
                cmd.Parameters.Add(new SqlParameter("@pCel", SqlDbType.VarChar)).Value = txtCel.Text;
                cmd.Parameters.Add(new SqlParameter("@pEmail", SqlDbType.VarChar)).Value = txtEmail.Text;
                cmd.Parameters.Add(new SqlParameter("@pemail2", SqlDbType.VarChar)).Value = txtEmailC.Text;
                cmd.Parameters.Add(new SqlParameter("@pSeguro", SqlDbType.VarChar)).Value = cbbSeguro.Text;
                cmd.Parameters.Add(new SqlParameter("@pFechareg", SqlDbType.Date)).Value = cambiada2;
                cmd.Parameters.Add(new SqlParameter("@pReferidor", SqlDbType.VarChar)).Value = cbbRef.Text;
 
                cmd.Parameters.Add(new SqlParameter("@pid", SqlDbType.Int)).Direction = ParameterDirection.Output;
                try
                {
                 cmd.ExecuteNonQuery();
                PacienteId = cmd.Parameters["@pid"].Value.ToString();
           
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                    con.Close();
                    return;
                }
                finally
                {
                    con.Close();
                    MessageBox.Show("Paciente Guardado Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logs log = new Logs();
                    log.Accion = "Paciente: " + txtNom.Text + " Guardado";
                    log.Form = "Registro de Pacientes";
                    log.SaveLog();
                    GeneraCred();
                    sendmail(txtEmail.Text);
                   
            
                }
            }

        }


        private void txtFecha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cbbSeguro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void cbbSeguro_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void rbF_CheckedChanged(object sender, EventArgs e)
        {
            if (rbF.Checked == true)
            {
                rbM.Checked = false;
                Sex = "Femenino";
            }
        }

        private void rbM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbM.Checked == true)
            {
                rbF.Checked = false;
                Sex = "Masculino";
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void txtEmailC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

           

        }
        public void GeneraCed()
        {
            //using (var con = new SqlConnection(conect))
            //{
            //    string sql = "Select MAX(pid) from tbpacientes";
            //    SqlCommand cmd = new SqlCommand(sql, con);
            //    SqlDataReader reader;
            //    cmd.CommandType = CommandType.Text;
            //    con.Open();

            //    reader = cmd.ExecuteReader();
            //    if (reader.Read())
            //    {
                    String CED = PacienteId;
                    CED = Convert.ToString(int.Parse(CED));
                    Random rced = new Random();
                    string nums = "000000000000000000000000000000";
                    int Longitud = nums.Length;
                    int longi = CED.Length;
                    char caracter;
                    int longitudCed = 11 - longi;
                    Cedula = string.Empty;
                    for (int i = 0; i < longitudCed; i++)
                    {
                        caracter = nums[rced.Next(Longitud)];
                        Cedula += caracter.ToString();
                        
                    }
                    Cedula = Cedula + CED;
                    string result = string.Format("{0:000-0000000-0}", int.Parse(Cedula));
                    Cedula = result;
                //}
                //con.Close();

            //}
        }
        public void Imprimir(object sender, PrintPageEventArgs e)
        {
            String imagen = Environment.CurrentDirectory + @"\\resourses\logocge.png";
            System.Drawing.Image img = System.Drawing.Image.FromFile(imagen);
            e.Graphics.DrawImage(img, new System.Drawing.Rectangle(20, 20, 206, 103));
            System.Drawing.Font font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString("CREDENCIALES CONSULTA", font, Brushes.Black, new RectangleF(40, 130, 200, 80));
            e.Graphics.DrawString("RESULTADOS", font, Brushes.Black, new RectangleF(85, 150, 200, 80));
            System.Drawing.Font font1 = new System.Drawing.Font("Calibri", 12, FontStyle.Regular, GraphicsUnit.Point);
            System.Drawing.Font font2 = new System.Drawing.Font("Calibri", 12, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString("Paciente: "+txtNom.Text, font1, Brushes.Black, new RectangleF(30, 190, 300, 80));
            e.Graphics.DrawString("Usuario: "+Cedula, font2, Brushes.Black, new RectangleF(40, 250, 200, 80));
            e.Graphics.DrawString("Contraseña: "+contraseniaAleatoria, font2, Brushes.Black, new RectangleF(40, 280, 200, 80));
            e.Graphics.DrawString("www.cgelaboratorio.com", font1, Brushes.Black, new RectangleF(40, 350, 200, 80));           

        }
        public void GeneraCred()
        {
            if (txtCed.Text == "No Aplica")
            {
                GeneraCed();
            }
            else
            {
                Cedula = txtCed.Text;
            }

            if (contraseniaAleatoria == "")
            {
                Random rdn = new Random();
                string caracteres = "1234567890";
                int longitud = caracteres.Length;
                char letra;
                int longitudContrasenia = 8;
                contraseniaAleatoria = string.Empty;
                for (int i = 0; i < longitudContrasenia; i++)
                {
                    letra = caracteres[rdn.Next(longitud)];
                    contraseniaAleatoria += letra.ToString();
                }
            }
            pass = clsEncrypt.GetSHA256(contraseniaAleatoria);


            using (var con = new SqlConnection(conect))
            {
                con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGeneraCredenciales";
                cmd.Parameters.Add(new SqlParameter("@pid", SqlDbType.VarChar)).Value = PacienteId;
                cmd.Parameters.Add(new SqlParameter("@Ced", SqlDbType.VarChar)).Value = Cedula;
                cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar)).Value = pass;
             
                cmd.ExecuteNonQuery();

                con.Close();

                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                printDocument1.PrinterSettings = ps;
                printDocument1.PrintPage += Imprimir;
                ps.PrinterName = "LR2000";
                printDocument1.Print();


                string GS = Convert.ToString((char)29);
                string ESC = Convert.ToString((char)27);

                string COMMAND = "";
                COMMAND = ESC + "@";
                COMMAND += GS + "V" + (char)1;
                RawPrinterHelper.SendStringToPrinter(ps.PrinterName = "LR2000", COMMAND);
            }

        }
        public void sendmail(string mailto)
        {
           
                try
                {

                    cm.GetMailSetup();

                    var mailtxt = new MailMessage();
                if (txtEmailC.Text.Length > 0)
                {
                    mailtxt.To.Add(mailto + ", " + txtEmailC.Text);
                }
                else
                {
                    mailtxt.To.Add(mailto);
                }
                    mailtxt.From = new MailAddress(cm.MailFrom, cm.MailName, System.Text.Encoding.UTF8);
                    mailtxt.Subject = "Credenciales Consulta de Resultados CGE Laboratorio";
                    mailtxt.IsBodyHtml = true;
                    mailtxt.Body = "Saludos "+txtNom.Text+", a continuacion le mostramos los credenciales para poder iniciar sesion en nuestra plataforma, su Usuario es: "+Cedula+", y su Contraseña: "+contraseniaAleatoria+", (su fecha de nacimiento en el siguiente orden dia mes año) una vez sus resultados sean cargados a la plataforma, podra visualizarlos ingresando al portal: www.cgelaboratorio.com";

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
                    MessageBox.Show("Ha ocurrido un error al enviar credenciales al correo: " + txtEmail.Text + ", Contacte al Administrador." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        

        private void txtEmailC_TextChanged(object sender, EventArgs e)
        {
            //if (txtEmailC.Text != txtEmail.Text)
            //{
            //    label6.Visible = true;
            //    label6.Text = "El email ingresado no coincide.";
            //    btnSave.Enabled = false;
            //}
            //else
            //{
            //    label6.Visible = false;
            //    btnSave.Enabled = true;
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
           
        }

        private void frmRegPac_Load(object sender, EventArgs e)
        {
            rbF.Select();
            cbbDoc.SelectedIndex = 0;
            Fechadehoy();
            cargacbbSeg();
            cargacbbRef();
        }

        private void rbF_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                rbM.Focus();
            }
        }

        private void rbM_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtNom.Focus();
            }
        }

        private void txtNom_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtFecha.Focus();
            }
        }

        private void txtCed_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtEmail.Focus();
            }
        }

        private void txtFecha_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                cbbDoc.Focus();
            }
        }

        private void txtEmail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtEmailC.Focus();
            }
        }

        private void txtEmailC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCel.Focus();
            }
        }

        private void txtCel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtDir.Focus();
            }
        }

        private void txtDir_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                cbbSeguro.Focus();
            }
        }

        private void cbbSeguro_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnGuardar.Focus();
            }
        }

        private void txtSeg_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnGuardar.Focus();
            }
        }

        private void btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnCancelar.Focus();
            }
        }

        private void btnCancel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnCerrar.Focus();
            }
        }

        private void chkCed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCed.Checked == true)
            {
                txtCed.Mask = "";
                txtCed.Text = "No Aplica";
                txtCed.Enabled = false;
            }
            else
            {
                txtCed.Text = "";
                txtCed.Enabled = true;
            }
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecha.Checked == true)
            {
                txtFecha.Mask = "";
                txtFecha.Text = "No Aplica";
                txtFecha.Enabled = false;
            }
            else
            {
                txtFecha.Mask = "00-00-0000";
                txtFecha.Text = "";
                txtFecha.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void cbbDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDoc.Text == "Cedula")
            {
                txtCed.Mask = "000-0000000-0";
            }
            else
            {
                txtCed.Mask = "";
            }
        }

        private void cbbDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
             e.Handled = true;
        }

        private void cbbDoc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCed.Focus();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Agregar Seguros") || UserCache.Nivel == "Admin")
            {
                frmSeguros seg = new frmSeguros();
                seg.ShowDialog();
                if (seg.DialogResult == DialogResult.OK)
                {
                    cargacbbSeg();
                }
            }
            else
            {
                MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {
                try
                {
                    contraseniaAleatoria = "";
                    if (txtNom.Text == "" || txtCed.Text == "" || txtEmail.Text == "" || txtFecha.MaskCompleted == false)
                    {
                        MessageBox.Show("Debe completar los campos faltantes");
                    }
                    else
                    {
                        String email = txtEmail.Text;
                        String email2 = txtEmailC.Text;


                        if (Regex.IsMatch(email, expresion))
                        {

                            if (txtEmailC.Text.Length > 0)
                            {
                                if (Regex.IsMatch(email2, expresion))
                                {

                                }
                                else
                                {
                                    MessageBox.Show("El email opcional ingresado no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtEmailC.Focus();
                                    return;
                                }


                            }
                            using (var con = new SqlConnection(conect))
                            {
                                con.Open();
                                cmd = new SqlCommand("", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "spValidaCedula";
                                SqlDataReader rdr;
                                cmd.Parameters.Add("@ced", SqlDbType.VarChar).Value = txtCed.Text;
                                rdr = cmd.ExecuteReader();

                                if (rdr.Read() && txtCed.Text != "No Aplica")
                                {
                                    MessageBox.Show("Este Paciente ya se encuentra esta registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //con.Close();
                                    return;
                                }

                                else if ((rdr != null))
                                {
                                    con.Close();
                                    conviertefecha();
                                    GuardaPacientes();
                                }

                                DialogResult resulta = MessageBox.Show("Desea asignar una prueba al paciente: " + txtNom.Text + " ?", "Asignar Prueba?", MessageBoxButtons.YesNo);

                                if (resulta == DialogResult.Yes)
                                {
                                    frmPruebas re = new frmPruebas();
                                    re.pacID = int.Parse(PacienteId);
                                    re.Cedula = txtCed.Text;
                                    re.ShowDialog();
                                }
                                limpiar();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El email ingresado no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEmail.Focus();
                            return;
                        }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Agregar Referidor") || UserCache.Nivel == "Admin")
            {
            frmReferidos refe = new frmReferidos();
            refe.ShowDialog();
            if (refe.DialogResult == DialogResult.OK)
            {
                cargacbbRef();
            }
             
            }
            else
            {
                MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            conviertefecha();
        }
    }
}
