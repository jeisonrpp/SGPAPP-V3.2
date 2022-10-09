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
                SqlDataAdapter sqlData = new SqlDataAdapter("spGetTiposPruebas", con);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("@Empresas", true);
                DataTable table = new DataTable();
                sqlData.Fill(table);
                cbbTipo.DataSource = table;
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
                SqlDataAdapter sqlData = new SqlDataAdapter("spGetPruebasPorTipo", con);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = cbbTipo.Text;
                DataTable table = new DataTable();
                sqlData.Fill(table);
                cbbPrueba.DataSource = table;
                cbbPrueba.ValueMember = "Pruebas";
                cbbPrueba.Text = "Seleccione la Prueba";
                con.Close();
            }
        }

        private void cbbPrueba_DropDown(object sender, EventArgs e)
        {
            CargacbbPrueba();
            //cbbMetodo.Enabled = true;
            //cbbMetodo.Text = "Seleccione el Metodo";

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
            //cbbMetodo.Enabled = true;
            cbbMetodo.Text = "Consulta Web";
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
            if (cbbTipo.Text == "Seleccione el Tipo" || cbbPrueba.Text == "Seleccione la Prueba" )
            {
                    MessageBox.Show("Debe completar los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                {
                    using (var con = new SqlConnection(conect))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spValidaPruebasParaAsignar";
                    SqlDataReader reader;
                    cmd.Parameters.Add("@pid", SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters.Add("@prueba", SqlDbType.VarChar).Value = cbbPrueba.Text;
                    cmd.Parameters.Add("@tipop", SqlDbType.VarChar).Value = cbbTipo.Text;
                    cmd.Parameters.Add("@paso", SqlDbType.VarChar).Value = 3;

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
