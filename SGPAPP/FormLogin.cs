using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.InteropServices;

namespace SGPAPP
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();   
        SqlCommand cmd = null;
        bool isvalid= false;
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.FromArgb(33, 53, 73);
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.FromArgb(33, 53, 73);
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUser.Select();
            UserCache.RoleList.Clear();
            UserCache.EmpresaRoles.Clear();
        }
        public void ChangeLog()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spChangeLog";

                    cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = txtUser.Text;

                    cmd.ExecuteReader();
                    con.Close();  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void GetRoles()
        {
            using (var con = new SqlConnection(conect))
            {

                try
                {
                    con.Open();
                    cmd = new SqlCommand("", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetUserRoles";
                    SqlDataReader rdr;
                    cmd.Parameters.Add("@userid", SqlDbType.Int).Value = UserCache.UserID;

                    rdr = cmd.ExecuteReader();
                    
                    while  (rdr.Read())
                    {
                        UserRoles item = new UserRoles();
                        item.RoleName = rdr.GetString(0);
                        item.RolID = rdr.GetInt32(1);
                        UserCache.RoleList.Add(item);
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
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {
                if (txtUser.Text == "")
                {
                    MessageBox.Show("Porfavor, digite el nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Focus();
                    return;
                }
                if (txtPass.Text == "")
                {
                    MessageBox.Show("Porfavor, digite la contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Focus();
                    return;
                }
                using (var con = new SqlConnection(conect))
                {

                    try
                    {
                        con.Open();
                        cmd = new SqlCommand("", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spGetUserLogin";
                        SqlDataReader reader;
                        cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = txtUser.Text;

                        reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            UserCache.Usuario = reader[0].ToString();
                            UserCache.Cedula = reader[1].ToString();
                            UserCache.LoginName = reader[2].ToString();
                            UserCache.Password = (byte[])reader[3];
                            UserCache.Nivel = reader[4].ToString();
                            UserCache.Status = reader[5].ToString();
                            UserCache.Salt = (byte[])reader[6];
                            UserCache.UserID = (int)reader[7];
                            GetRoles();
                            int i;
                            pgb1.Visible = true;
                            pgb1.Maximum = 2000;
                            pgb1.Minimum = 0;
                            pgb1.Value = 4;
                            pgb1.Step = 1;

                            for (i = 0; i <= 2000; i++)
                            {
                                pgb1.PerformStep();
                            }
                            byte[] hashedPassword = clsEncrypt.HashPasswordWithSalt(Encoding.UTF8.GetBytes(txtPass.Text), UserCache.Salt);
                            if (hashedPassword.SequenceEqual(UserCache.Password))
                            {
                                isvalid = true;
                            }
                            else
                            {
                                MessageBox.Show("Contraseña Incorrecta", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPass.Focus();
                                return;
                            }

                            if (UserCache.Status == "Activo")
                            {
                                this.Hide();

                                frmMain frm = new frmMain();

                                frm.Show();
                                //ChangeLog();
                            }
                            else
                            {
                                MessageBox.Show("Este usuario se encuentra deshabilitado. Contacte al administrador", "Usuario Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario Incorrecto", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUser.Focus();
                        }

                        if (con.State == ConnectionState.Open)
                        {
                            con.Dispose();

                        }
                        Logs log = new Logs();
                        log.Accion = "Inicio de Sesion Usuario: " + UserCache.Usuario + " v3.6";
                        log.Form = "Login";
                        log.SaveLog();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (txtUser.Text == "")
                {
                    MessageBox.Show("Porfavor, digite el nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Focus();
                    return;
                }
                if (txtPass.Text == "")
                {
                    MessageBox.Show("Porfavor, digite la contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Focus();
                    return;
                }
                using (var con = new SqlConnection(conect))
                {
                    
                    try
                        {
                            con.Open();
                            cmd = new SqlCommand("", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetUserLogin";
                            SqlDataReader reader;
                            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = txtUser.Text;

                            reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                UserCache.Usuario = reader[0].ToString();
                                UserCache.Cedula = reader[1].ToString();
                                UserCache.LoginName = reader[2].ToString();
                                UserCache.Password = (byte[])reader[3];
                                UserCache.Nivel = reader[4].ToString();
                                UserCache.Status = reader[5].ToString();
                                UserCache.Salt = (byte[])reader[6];
                                UserCache.UserID = (int)reader[7];
                                GetRoles();
                                int i;
                                pgb1.Visible = true;
                                pgb1.Maximum = 2000;
                                pgb1.Minimum = 0;
                                pgb1.Value = 4;
                                pgb1.Step = 1;

                                for (i = 0; i <= 2000; i++)
                                {
                                    pgb1.PerformStep();
                                }
                                byte[] hashedPassword = clsEncrypt.HashPasswordWithSalt(Encoding.UTF8.GetBytes(txtPass.Text), UserCache.Salt);
                                if (hashedPassword.SequenceEqual(UserCache.Password))
                                {
                                    isvalid = true;
                                }
                                else
                                {
                                    MessageBox.Show("Contraseña Incorrecta", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtPass.Focus();
                                    return;
                                }

                                if (UserCache.Status == "Activo")
                                {
                                    this.Hide();

                                    frmMain frm = new frmMain();

                                    frm.Show();
                                    //ChangeLog();
                                }
                                else
                                {
                                    MessageBox.Show("Este usuario se encuentra deshabilitado. Contacte al administrador", "Usuario Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuario Incorrecto", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtUser.Focus();
                            }

                            if (con.State == ConnectionState.Open)
                            {
                                con.Dispose();

                            }
                            Logs log = new Logs();
                            log.Accion = "Inicio de Sesion Usuario: " + UserCache.Usuario + " v3.6";
                            log.Form = "Login";
                            log.SaveLog();
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
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void txtPass_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPassword pass = new frmPassword();
            pass.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
