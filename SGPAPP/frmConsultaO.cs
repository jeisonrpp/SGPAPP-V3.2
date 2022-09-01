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
    public partial class frmConsultaO : Telerik.WinControls.UI.RadForm
    {
        public frmConsultaO()
        {
            InitializeComponent();

            GridViewCommandColumn commandColumn5 = new GridViewCommandColumn();
            commandColumn5.Name = "commandColumn5";
            commandColumn5.UseDefaultText = true;
            commandColumn5.Image = Properties.Resources.icons8_checkmark_16;
            commandColumn5.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn5.FieldName = "select";
            commandColumn5.HeaderText = "Seleccionar";
            radGridView6.MasterTemplate.Columns.Add(commandColumn5);
            radGridView6.CommandCellClick += new CommandCellClickEventHandler(radGridView6_CommandCellClick);
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        string Empresa;
        string Fechareg;
        int PruebaEmpresaID;
        private void frmConsultaO_Load(object sender, EventArgs e)
        {
            getResultados();
     
            this.radGridView6.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }
        
        public void getResultados()
        {

            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetResultados", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", "Empresa");
                    da.SelectCommand.Parameters.AddWithValue("@Fechadesde", "Empresa");
                    da.SelectCommand.Parameters.AddWithValue("@fechahasta", "Empresa");
                    da.SelectCommand.Parameters.AddWithValue("@Prueba", "Empresa");

                    da.Fill(dt);
                    this.radGridView6.DataSource = dt;
                    this.radGridView6.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

                    if (radGridView6.Columns[0].Name == "commandColumn5")
                    {
                        radGridView6.Columns[4].DataType = typeof(DateTime);
                        radGridView6.Columns[4].FormatString = "{0: d/M/yyyy}";

                        //radGridView6.Columns[5].DataType = typeof(DateTime);
                        //radGridView6.Columns[5].FormatString = "HH:mm";

                        //radGridView6.Columns[4].IsVisible = false;
                        radGridView6.Columns.Move(0,4);

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

        private void radGridView6_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
          

        }

        private void radGridView6_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
          
        }
        void radGridView6_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                GridViewRowInfo row = radGridView6.CurrentRow;
                if (UserCache.EmpresaRoles.Any(item => item.EmpresaRol == (string)e.Row.Cells["Empresa"].Value) || UserCache.EmpresaRoles.Any(item => item.EmpresaRol == "Todas*"))
                {
                    Empresa = (string)e.Row.Cells["Empresa"].Value;
                    Fechareg = (string)e.Row.Cells["Fecha"].Value.ToString();
                    PruebaEmpresaID = (int)e.Row.Cells["ID de Prueba"].Value;
                    frmResultse re = new frmResultse();
                    re.Fechareg = Fechareg;
                    re.Empresa = Empresa;
                    re.Mail = (string)e.Row.Cells["Email"].Value.ToString();
                    re.PruebaID = PruebaEmpresaID;
                    re.ShowDialog();
                }
                else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetResultados", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", textBox2.Text);
                    da.SelectCommand.Parameters.AddWithValue("@Fechadesde", "Empresa");
                    da.SelectCommand.Parameters.AddWithValue("@fechahasta", "Empresa");
                    da.SelectCommand.Parameters.AddWithValue("@Prueba", "Empresa");

                    da.Fill(dt);
                    this.radGridView6.DataSource = dt;
                    //this.radGridView6.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;




                    con.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Digite Nombre de la Empresa")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.MidnightBlue;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Digite Nombre de la Empresa";
                textBox2.ForeColor = Color.Silver;
                getResultados();

            }
        }
    }
}
