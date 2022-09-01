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
    public partial class frmTipoMax : Form
    {
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        String Time;
        public frmTipoMax()
        {
            InitializeComponent();
        }

        private void frmTipoMax_Load(object sender, EventArgs e)
        {
            CargacbbTipo();
        }
        public void CargacbbTipo()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select distinct(prTipo) as Tipos from tbPruebas where prlaboratorios = 0 order by prTipo", con);

                da.Fill(ds, "Tipos");
                cbbTipo.DataSource = ds.Tables[0].DefaultView;
                cbbTipo.ValueMember = "Tipos";
                cbbTipo.Text = "Seleccione el Tipo";
                cbbPrueba.Text = "Seleccione la Prueba";
                con.Close();
            }
        }

        public void CargacbbPrueba()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (prNombre) as Pruebas from tbPruebas where prTipo = '" + cbbTipo.Text + "' order by prNombre", con);

                da.Fill(ds, "Pruebas");
                cbbPrueba.DataSource = ds.Tables[0].DefaultView;
                cbbPrueba.ValueMember = "Pruebas";
                cbbPrueba.Text = "Seleccione la Prueba";
                con.Close();
            }
        }

        private void cbbPrueba_DropDown(object sender, EventArgs e)
        {
            CargacbbPrueba();
            cbbMetodo.Enabled = true;
            cbbMetodo.Text = "Seleccione el Metodo";

        }

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbPrueba_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbPrueba_DropDown_1(object sender, EventArgs e)
        {
            CargacbbPrueba();
            cbbMetodo.Enabled = true;
            cbbMetodo.Text = "Seleccione el Metodo";
        }

        private void cbbTipo_DropDown(object sender, EventArgs e)
        {
            cbbPrueba.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSav_Click(object sender, EventArgs e)
        {
            if (cbbTipo.Text == "Seleccione el Tipo" || cbbPrueba.Text == "Seleccione la Prueba" || cbbMetodo.Text == "Seleccione el Metodo")
            {
                    MessageBox.Show("Debe completar los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                {
                    using (var con = new SqlConnection(conect))
                {
                    string sql = "SELECT RTRIM(prTiempo) as [Tiempo] from tbPruebas where prTipo = '" + cbbTipo.Text + "' and prNombre = '" + cbbPrueba.Text + "'";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    try
                    {
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Time = reader[0].ToString();


                        }
                        else
                        {
                            MessageBox.Show("No se ha encontrado registro!");
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
                frmPrMax mx = new frmPrMax();
                mx.Tipop = cbbTipo.Text;
                mx.Prueba = cbbPrueba.Text;
                mx.Metodo = cbbMetodo.Text;
                mx.Time = Time;
                this.Hide();
                mx.Show();
            }
        }
    }
}
