using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmPruebasO : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;
        public frmPruebasO()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn4 = new GridViewCommandColumn();
            commandColumn4.Name = "commandColumn4";
            commandColumn4.UseDefaultText = true;
            commandColumn4.Image = Properties.Resources.icons8_checkmark_16;
            commandColumn4.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn4.FieldName = "select";
            commandColumn4.HeaderText = "Seleccionar";
            radGridView3.MasterTemplate.Columns.Add(commandColumn4);
            radGridView3.CommandCellClick += new CommandCellClickEventHandler(radGridView3_CommandCellClick);
        }

       
        private void radGridView3_CommandCellClick(object sender, GridViewCellEventArgs e)
        {

            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {
                frmPruebaE pe = new frmPruebaE();


                if (UserCache.EmpresaRoles.Any(item => item.EmpresaRol == e.Row.Cells[0].Value.ToString()) || UserCache.EmpresaRoles.Any(item => item.EmpresaRol == "Todas*"))
                     {
                    pe.Empresa = e.Row.Cells[0].Value.ToString();
                    pe.LotID = (int)e.Row.Cells[5].Value;
                    pe.ShowDialog();
                    if (pe.DialogResult == DialogResult.OK)
                    {

                        GetData();
                    }
                }


                else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        string Empresa;
        string Fechareg;
        SqlCommand cmd = null;
        String ID;
        String Pac;
        String Ced = "";
        String Fechan;
        bool existe = false;
        public String Tipop;
        public String Prueba;
        public String Metodo;
        public String Time;
        String cambiada1;
        DateTime Fecha = DateTime.Now;


        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(conect))
                {
                    SqlDataAdapter da = new SqlDataAdapter("spGetEmpresas", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", txtConsulta.Text);
                    da.SelectCommand.Parameters.AddWithValue("@Prueba", "Si");
                    da.SelectCommand.Parameters.AddWithValue("@Resultados", (object)DBNull.Value);
                    da.Fill(dt);
                    this.radGridView3.DataSource = dt;
                    this.radGridView3.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    radGridView3.Columns[5].IsVisible = false;
                    con.Close();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetData()
        {
            
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter("spGetEmpresas", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@Prueba", "Si");
                    da.SelectCommand.Parameters.AddWithValue("@Resultados", (object)DBNull.Value);
                    da.Fill(dt);
                    this.radGridView3.DataSource = dt;
                    this.radGridView3.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    if (radGridView3.Columns[0].Name == "commandColumn5")
                    {
                        radGridView3.Columns[5].IsVisible = false;
                    }
                    if (radGridView3.Columns[0].Name == "commandColumn4")
                    {
                        radGridView3.Columns.Move(0, 6);
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

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }
        public void PruebaEmpresa()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "update tbEmpresas set emPruebas = 1 where emnom = '" + Empresa + "'";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0);
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
     

        private void btnSav_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPruebasO_Load(object sender, EventArgs e)
        {
            GetData();
           
        }

        private void txtConsulta_Enter(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "Digite Nombre de la Empresa")
            {
                txtConsulta.Text = "";
                txtConsulta.ForeColor = Color.MidnightBlue;
            }
        }

        private void txtConsulta_Leave(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "")
            {
                txtConsulta.Text = "Digite Nombre de la Empresa";
                txtConsulta.ForeColor = Color.Silver;
                GetData();

            }
        }
    }
}
