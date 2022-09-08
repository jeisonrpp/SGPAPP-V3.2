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
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmAddPruebas : Form
    {
        public frmAddPruebas()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        bool Special = false;
        SqlCommand cmd = null;
        String Sql;
        int Pruebaid;
        bool Valores;

        private void frmAddPruebas_Load(object sender, EventArgs e)
        {
            CargaPruebas();
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        public void CargaPruebas()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select distinct (prtipo) as tipos from tbPruebas order by prtipo", con);

                da.Fill(ds, "tipos");
                cbbTipo.DataSource = ds.Tables[0].DefaultView;
                cbbTipo.ValueMember = "tipos";
                cbbTipo.Text = "Seleccione el tipo";


                con.Close();
            }
        }

        private void chkbox_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chkbox.Checked == true)
            {
                txtResult.Enabled = true;
                txtUnd2.Enabled = true;
                txtMin1.Enabled = true;
                txtMax2.Enabled = true;
                btnAdd.Enabled = true;
                btnEliminar.Enabled = true;
                radGridView1.Enabled = true;
                Special = true;
            }
            else
            {
                txtResult.Enabled = false;
                txtUnd2.Enabled = false;
                txtMin1.Enabled = false;
                txtMax2.Enabled = false;
                btnAdd.Enabled = false;
                btnEliminar.Enabled = false;
                radGridView1.Enabled = false;
                Special = false;
            }
        }

        private void btnSav_Click(object sender, EventArgs e)
        {
            try
            {
                InsertPruebas();
                if (Special == true)
                {
                    InsertPruebasResults();
                    Special = false;
                }

                MessageBox.Show("Datos Guardados Correctamente!.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargaPruebas();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Limpiar()
        {
            chkbox.Checked = false;
            cbbTipo.SelectedIndex = 0;
            txtPrueba.Text = "";
            txtTiempo.Text = "";
            txtUnidad.Text = "";
            txtResult.Text = "";
            txtMin.Text = "";
            txtMax.Text = "";
            txtMax2.Text = "";
            txtMax2.Text = "";
            radGridView1.Rows.Clear();
            txtUnd2.Text = "";
        }

        public void InsertPruebas()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                cmd = new SqlCommand(Sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertPruebas";
                cmd.Parameters.Add(new SqlParameter("@prtipo", SqlDbType.VarChar)).Value = cbbTipo.Text;
                cmd.Parameters.Add(new SqlParameter("@prnombre", SqlDbType.VarChar)).Value = txtPrueba.Text;
                cmd.Parameters.Add(new SqlParameter("@prtiempo", SqlDbType.VarChar)).Value = txtTiempo.Text;
                cmd.Parameters.Add(new SqlParameter("@prunidad", SqlDbType.VarChar)).Value = txtUnidad.Text;
                cmd.Parameters.Add(new SqlParameter("@prvalores", SqlDbType.VarChar)).Value = txtMin.Text + " - " + txtMax.Text;
                cmd.Parameters.Add(new SqlParameter("@prvalmin", SqlDbType.NChar)).Value = txtMin.Text;
                cmd.Parameters.Add(new SqlParameter("@prvalmax", SqlDbType.NChar)).Value = txtMax.Text;
                cmd.Parameters.Add(new SqlParameter("@prespecial", SqlDbType.Bit)).Value = Special;
                cmd.Parameters.Add(new SqlParameter("@prid", SqlDbType.Int)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Pruebaid = (int)cmd.Parameters["@prid"].Value;
                con.Close();

            }
        }

        public void InsertPruebasResults()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
                {
                    cmd = new SqlCommand(Sql, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInsertPruebasResults";
                    cmd.Parameters.Add(new SqlParameter("@prnombre", SqlDbType.VarChar)).Value = radGridView1.Rows[rowInfo.Index].Cells[0].Value.ToString();
                    cmd.Parameters.Add(new SqlParameter("@prunidad", SqlDbType.VarChar)).Value = radGridView1.Rows[rowInfo.Index].Cells[3].Value.ToString();
                    cmd.Parameters.Add(new SqlParameter("@prvalores", SqlDbType.VarChar)).Value = radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString() + " - " + radGridView1.Rows[rowInfo.Index].Cells[2].Value.ToString();
                    cmd.Parameters.Add(new SqlParameter("@prvalmin", SqlDbType.NChar)).Value = radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString();
                    cmd.Parameters.Add(new SqlParameter("@prvalmax", SqlDbType.NChar)).Value = radGridView1.Rows[rowInfo.Index].Cells[2].Value.ToString();
                    cmd.Parameters.Add(new SqlParameter("@prid", SqlDbType.Int)).Value = Pruebaid;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        public void CalculaValores(double min, double max)
        {
            if (min != '-' & max != '-' & min > max)
            {
                MessageBox.Show("El valor minimo debe ser menor que el valor maximo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Valores = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool exist = false;
            if (txtResult.Text.Length > 0)
            {
                if (radGridView1.RowCount > 0)
                {
                    for (int i = 0; i < radGridView1.RowCount; i++)
                    {
                        if (Convert.ToString(radGridView1.Rows[i].Cells["Column1"].Value) == txtResult.Text)
                        {
                            exist = true;
                            MessageBox.Show("Este Resultado ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                    if (exist == false)
                    {
                        CalculaValores(Convert.ToDouble(txtMin1.Text), Convert.ToDouble(txtMax2.Text));
                        if (Valores == true)
                        {
                            radGridView1.Rows.Add(txtResult.Text, txtMin1.Text, txtMax2.Text, txtUnd2.Text);
                            txtResult.Text = "";
                            txtMin1.Text = "";
                            txtMax2.Text = "";
                            txtUnd2.Text = "";
                            Valores = false;
                        }
                    }
                }
                else
                {
                    CalculaValores(Convert.ToDouble(txtMin1.Text), Convert.ToDouble(txtMax2.Text));
                    if (Valores == true)
                    {
                        radGridView1.Rows.Add(txtResult.Text, txtMin1.Text, txtMax2.Text, txtUnd2.Text);
                        txtResult.Text = "";
                        txtMin1.Text = "";
                        txtMax2.Text = "";
                        txtUnd2.Text = "";
                        Valores = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe digitar el nombre del resultado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.radGridView1.Rows.Count > 0)
            {
                radGridView1.Rows.RemoveAt(this.radGridView1.SelectedRows[0].Index);
            }
        }

        private void radScrollablePanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
