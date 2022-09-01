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
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmEditO : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;
        public frmEditO()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn4 = new GridViewCommandColumn();
            commandColumn4.Name = "commandColumn4";
            commandColumn4.UseDefaultText = true;
            commandColumn4.Image = Properties.Resources.icons8_checkmark_16;
            commandColumn4.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn4.FieldName = "select";
            commandColumn4.HeaderText = "Seleccionar";
            radGridView2.MasterTemplate.Columns.Add(commandColumn4);
            radGridView2.CommandCellClick += new CommandCellClickEventHandler(radGridView2_CommandCellClick);
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        string Empresa;
        string Fechareg;

        private void frmEditO_Load(object sender, EventArgs e)
        {
            EditEmpresa();
            EmpresaRoles();
        }
        public void EmpresaRoles()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "select emnom, erol_uid, erol_emid from tbrolesempresa inner join tbEmpresas on erol_emid = emid  where erol_uid = " + UserCache.UserID + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rdr;
                cmd.CommandType = CommandType.Text;
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RolesEmpresa item = new RolesEmpresa();
                    item.EmpresaRol = rdr.GetString(0);
                    UserCache.EmpresaRoles.Add(item);
                }
                con.Close();
            }
        }

        public void EditEmpresa()
        {


            using (var con = new SqlConnection(conect))
            {
                try
                {

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetlotesinfo", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);
                    //da.SelectCommand.Parameters.AddWithValue("@Prueba", (object)DBNull.Value);
                    //da.SelectCommand.Parameters.AddWithValue("@Resultados", (object)DBNull.Value);
                    da.Fill(dt);
                    this.radGridView2.DataSource = dt;
                    this.radGridView2.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    if (radGridView2.Columns[0].Name == "commandColumn4")
                    {
                        radGridView2.Columns.Move(0, 5);
                    }
                    //radGridView2.Columns[6].IsVisible = false;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }





        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        void radGridView2_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {

                frmResE Re = new frmResE();


                if (UserCache.EmpresaRoles.Any(item => item.EmpresaRol == (string)e.Row.Cells["Empresa"].Value) || UserCache.EmpresaRoles.Any(item => item.EmpresaRol == "Todas*"))
                {
                    Re.txtEmpresa.Text = (string)e.Row.Cells["Empresa"].Value;
                    Re.LotID = (int)e.Row.Cells["Id de lote"].Value;
                    if ((string)e.Row.Cells["Estado"].Value == "Pendiente de pruebas")
                    {
                        Re.esLote = true;
                        Re.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Este lote no puede ser modificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //frmModificaEmpresa md = new frmModificaEmpresa();

                    //md.Empresa = (string)this.radGridView2.Rows[rowIndex].Cells["Empresa"].Value;
                    //md.Fechareg = (string)this.radGridView2.Rows[rowIndex].Cells["Fecha Registro"].Value.ToString();
                    //md.txteEmp.Text = (string)this.radGridView2.Rows[rowIndex].Cells["Empresa"].Value;
                    //md.txtEdir.Text = (string)this.radGridView2.Rows[rowIndex].Cells["Direccion"].Value;
                    //md.txtEEmail.Text = (string)this.radGridView2.Rows[rowIndex].Cells["Email"].Value;
                    //md.txtEcont.Text = (string)this.radGridView2.Rows[rowIndex].Cells["Contacto"].Value;
                    //md.ShowDialog();
                    if (Re.DialogResult == DialogResult.OK)
                    {
                        EditEmpresa();
                    }

                }
            else 
                { 
                    MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {
                frmResE Re = new frmResE();
                //if ((Application.OpenForms["frmResE"] as frmResE) != null)
                //{
                //    Re.BringToFront();
                //    //MessageBox.Show("Esta ventana ya se encuentra abierta");
                //}
                //else
                //{
                Re.ShowDialog();
                //}
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {
                frmResE Re = new frmResE();
                //if ((Application.OpenForms["frmResE"] as frmResE) != null)
                //{
                //    Re.BringToFront();
                //    //MessageBox.Show("Esta ventana ya se encuentra abierta");
                //}
                //else
                //{
                Re.ShowDialog();
                //}
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Digite Nombre de la Empresa")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.MidnightBlue;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Digite Nombre de la Empresa";
                textBox1.ForeColor = Color.Silver;
                EditEmpresa();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                try
                {
                    using (var con = new SqlConnection(conect))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("spGetlotesinfo", con);
                        DataTable dt = new DataTable();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.AddWithValue("@Nombre", textBox1.Text);
                        //da.SelectCommand.Parameters.AddWithValue("@Prueba", (object)DBNull.Value);
                        //da.SelectCommand.Parameters.AddWithValue("@Resultados", (object)DBNull.Value);
                        da.Fill(dt);
                        this.radGridView2.DataSource = dt;
                        //this.radGridView2.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                        //if (radGridView2.Columns[0].Name == "commandColumn4")
                        //{
                        //    radGridView2.Columns.Move(0, 5);
                        //}
                        //radGridView2.Columns[6].IsVisible = false;
                        con.Close();


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
