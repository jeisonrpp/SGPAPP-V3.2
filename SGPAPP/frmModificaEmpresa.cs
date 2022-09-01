using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class frmModificaEmpresa : Telerik.WinControls.UI.RadForm
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;
        public frmModificaEmpresa()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
       public string Empresa;
        public string Fechareg;
        private void btnEdit_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMD_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {
                DialogResult resulta = MessageBox.Show("Esta Seguro que desea aplicar estos cambios a la empresa: " + Empresa + "?", "Actualizar Empresa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    using (var con = new SqlConnection(conect))
                    {
                        try
                        {
                            string sql = "update tbEmpresas set emNom = '" + txteEmp.Text + "', emDir = '" + txtEdir.Text + "', emEmail = '" + txtEEmail.Text + "', emContacto = '" + txtEcont.Text + "' where emnom = '" + Empresa + "'";

                            SqlCommand cmd = new SqlCommand(sql, con);
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
                            Logs log2 = new Logs();
                            log2.Accion = "Modificacion de Empresa: " + txteEmp.Text + " Guardada";
                            log2.Form = "Modificacion de Empresas";
                            log2.SaveLog();
                        }
                    }

                    using (var con = new SqlConnection(conect))
                    {
                        try
                        {
                            string sql = "update tbPacientes set pEmpresa = '" + txteEmp.Text + "'  where pempresa = '" + Empresa + "' ";

                            SqlCommand cmd = new SqlCommand(sql, con);
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

                    txteEmp.Text = "";
                    txtEEmail.Text = "";
                    txtEcont.Text = "";
                    txtEdir.Text = "";
                   
                }
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
