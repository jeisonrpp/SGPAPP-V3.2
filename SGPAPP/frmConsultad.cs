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
    public partial class frmConsultad : Telerik.WinControls.UI.RadForm
    {
        public frmConsultad()
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

        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        public int PacienteID;
        public String PacienteNom;
        public bool Empresa = false;
        public String Empresap;
        public String Fechareg;
        public String Cedula;
        public String Fechan;
        public String Seguro;
        public String Sexo;
        public String Email;
        bool validalotes = false;
        public void GetData()
        {
            try
            {
                //cmd = new SqlCommand("SELECT pId as [ID], RTRIM(pNom) as [Paciente], RTRIM(pCed) as [Cedula], RTRIM(pSex) as [Sexo], RTRIM(pFecha) as [Fecha Nacimiento], RTRIM(pdir) as [Direccion], RTRIM(pCel) as [No. de Contacto], RTRIM(pEmail) as [Email], RTRIM(pseguro) as [Seguro], RTRIM(pFechareg) as [Fecha Regsitro], RTRIM(pEmpresa) as [Empresa]  from tbpacientes where pnom like '%" + txtConsulta.Text + "%' or pced like '%" + txtConsulta.Text + "%'", con);

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
                        if (radGridView1.Columns[0].Name == "CommandColumn2")
                        {
                            radGridView1.Columns.Move(0, 13);
                            radGridView1.Columns[14].IsVisible = false;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {

        }

        private void frmConsultad_Load(object sender, EventArgs e)
        {
          
            GetData();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void advancedDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                txtConsulta.ForeColor = Color.MidnightBlue;
            }
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                try
                {

                    using (var con = new SqlConnection(conect))
                    {
                        try
                        {
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
        void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                GridViewRowInfo row = radGridView1.CurrentRow;

                if (Empresa == false)
                {
                    PacienteID = (int)radGridView1.Rows[row.Index].Cells["ID"].Value;
                    PacienteNom = (string)radGridView1.Rows[row.Index].Cells["Paciente"].Value;
                    Cedula = (string)radGridView1.Rows[row.Index].Cells["Cedula"].Value;
                    Fechan = (string)radGridView1.Rows[row.Index].Cells["Fecha Nacimiento"].Value;
                    Seguro = (string)radGridView1.Rows[row.Index].Cells["Seguro"].Value;
                    Sexo = (string)radGridView1.Rows[row.Index].Cells["Sexo"].Value;
                    if (radGridView1.Rows[row.Index].Cells["Email"].Value == System.DBNull.Value)
                    {
                        Email = "";
                    }
                    else
                    {
                        Email = (string)radGridView1.Rows[row.Index].Cells["Email"].Value;
                    }
                    if (radGridView1.Rows[row.Index].Cells["Empresa"].Value == System.DBNull.Value)
                    {
                        Empresap = "null";
                    }
                    else
                    {
                        Empresap = (string)radGridView1.Rows[row.Index].Cells["Empresa"].Value;
                    }
                }
                else
                {
                    Empresap = (string)radGridView1.Rows[row.Index].Cells["Empresa"].Value;
                    Fechareg = (string)radGridView1.Rows[row.Index].Cells["Fecha Registro"].Value;
                }
                ValidaLotes();
                if (validalotes == false)
                {
                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show("Este paciente se encuentra pendiente de ser reportado en otro lote.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                validalotes = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ValidaLotes()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    SqlDataReader rdr;
                    string ct2 = "select plotid from tbpacientes inner join tblotesempresa on plotid = lotid where pid = "+PacienteID+ " and lotid = plotid and lotpruebas =1 and lotResultados = 0";
                    cmd = new SqlCommand(ct2);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        validalotes = true;

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
    }
}
