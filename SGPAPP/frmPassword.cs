using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        bool isvalid = false;
        String User;
        byte[] Pass;
        byte[] Salt;
        String Status;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Porfavor, digite el nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
                return;
            }
            if (txtAnterior.Text == "")
            {
                MessageBox.Show("Porfavor, digite la contraseña anterior", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAnterior.Focus();
                return;
            }
            if (txtNueva.Text == "")
            {
                MessageBox.Show("Porfavor, digite la contraseña nueva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNueva.Focus();
                return;
            }
            if (txtConfirmacion.Text == "")
            {
                MessageBox.Show("Porfavor, digite la confirmacion de la contraseña nueva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmacion.Focus();
                return;
            }
            if (txtNueva.Text == txtConfirmacion.Text)
            {


                using (var con = new SqlConnection(conect))
                {
                    string sql = "SELECT  (uUser) as [User], (uPassword) as [Pass], (uStatus) as [Status], (uSalt) as [Salt] FROM tbUsuarios WHERE uUser = '" + txtUser.Text + "' ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        con.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            User = reader[0].ToString();
                            Pass = (byte[])reader[1];
                            Status = reader[2].ToString();
                            Salt = (byte[])reader[3];

                            byte[] hashedPassword = clsEncrypt.HashPasswordWithSalt(Encoding.UTF8.GetBytes(txtAnterior.Text), Salt);
                            if (hashedPassword.SequenceEqual(Pass) && Status == "Activo")
                            {
                                isvalid = true;
                                
                            }
                            if (isvalid == false && Status == "Activo")
                            {
                                MessageBox.Show("Contraseña Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtAnterior.Focus();
                                return;
                            }
                            if (Status != "Activo")
                            {
                                MessageBox.Show("Este usuario se encuentra deshabilitado. Contacte al administrador", "Usuario Deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario Incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUser.Focus();
                        }
                        if (con.State == ConnectionState.Open)
                        {
                            con.Dispose();

                        }

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
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
            }
            if (isvalid ==true)
            {
                UpdatePass();
            }
        }
        public void UpdatePass()
        {
            using (var con = new SqlConnection(conect))
            {
                try { 
                byte[] salt = clsEncrypt.GenerateSalt();
                var hashedPassword = clsEncrypt.HashPasswordWithSalt(Encoding.UTF8.GetBytes(txtNueva.Text), salt);
                string sql = "update tbUsuarios set uPassword= @pass,  uSalt= @salt where uuser = '" + txtUser.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                
                
                    cmd.Parameters.Add("@salt", SqlDbType.VarBinary).Value = salt;
                    cmd.Parameters.Add("@pass", SqlDbType.VarBinary).Value = hashedPassword;
                
                
                con.Open();
               
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Contraseña Actualizada Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                finally
                {
                    Logs log = new Logs();
                    log.Accion = "Contraseña actualizada del usuario: " + txtUser.Text + "";
                    log.Form = "Actualizacion de Contraseña";
                    log.SaveLog();
                    this.Close();
                }
            }
        }
    }
}
