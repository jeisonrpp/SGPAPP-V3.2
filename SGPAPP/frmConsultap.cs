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
using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace SGPAPP
{
    public partial class frmConsultap : Form
    {
        int ID;
        String Cedula;
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;


        public frmConsultap()
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

        public void GetData()
        {
           
                using (var con = new SqlConnection(conect))
                {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spgetPacientes", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@Fechadesde", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@fechahasta", (object)DBNull.Value);
                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    radGridView1.Columns.Move(0, 14);

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
            
        }

      

        private void frmProcedimientos_Load(object sender, EventArgs e)
        {
            GetData();
            
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {

        }

       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
           


        }

        private void advancedDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
 
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            
        }

        private void dataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtConsulta_Enter(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "Digite nombre o cedula")
            {
                txtConsulta.Text = "";
                txtConsulta.ForeColor = Color.MidnightBlue;
            }
        }

        private void txtConsulta_Leave(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "")
            {
                txtConsulta.Text = "Digite nombre o cedula";
                txtConsulta.ForeColor = Color.Silver;
               
            }
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {              

                    try
                    {
                        if (txtConsulta.Text != "Digite nombre o cedula")
                        {
                        using (var con = new SqlConnection(conect))
                        {
                            try {
                                con.Open();
                                SqlDataAdapter da = new SqlDataAdapter("spgetPacientes", con);
                                DataTable dt = new DataTable();
                                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                                da.SelectCommand.Parameters.AddWithValue("@Nombre", txtConsulta.Text);
                                da.SelectCommand.Parameters.AddWithValue("@Fechadesde", (object)DBNull.Value);
                                da.SelectCommand.Parameters.AddWithValue("@fechahasta", (object)DBNull.Value);
                                da.Fill(dt);
                                this.radGridView1.DataSource = dt;
                                this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }            
        }
        void btnImagenclick_Click(object sender, EventArgs e)
        {
            
        }

        private void radGridView1_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.IsSelected)
            {
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = System.Drawing.Color.LightBlue;
                e.RowElement.DrawFill = true;
            }
            else
            {
                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
            }
        }

        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            object cellValue = e.Row.Cells[0].Value;
        }

        private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.Name == "Column1")
            {
                e.CellElement.DrawFill = true;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = System.Drawing.Color.WhiteSmoke;

                GridImageCellElement imgCell = e.CellElement as GridImageCellElement;

                if (imgCell != null)
                {
                    imgCell.Image = Properties.Resources.icons8_checkmark_16;
                    

                    try
                    {
                        imgCell.Click -= btnImagenclick_Click;
                    }
                    catch
                    {

                    }

                    imgCell.Click += btnImagenclick_Click;
                }
            }
        }
        void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {

            if (UserCache.RoleList.Any(item => item.RoleName == "Asignar Pruebas") || UserCache.Nivel == "Admin")
            { 
                try
            {

                ID = (int)e.Row.Cells["ID"].Value;
                Cedula = (string)e.Row.Cells["Cedula"].Value;
                //frmPacEdit ed = new frmPacEdit();
                //ed.PacID = PacienteID;
                //ed.ShowDialog();
                frmPruebas hi = new frmPruebas();
                hi.pacID = ID;
                hi.Cedula = Cedula;
                hi.ShowDialog();


            }
            catch
            {

            }
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Asignar Pruebas") || UserCache.Nivel == "Admin")
            {
                frmTipoMax max = new frmTipoMax();
                max.Show();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
    }
}
