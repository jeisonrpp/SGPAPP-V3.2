using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Export;

namespace SGPAPP
{
    public partial class frmReportesEmpresas : Form
    {
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();

        public frmReportesEmpresas()
        {
            InitializeComponent();
        }

        private void frmReportesEmpresas_Load(object sender, EventArgs e)
        {
            CargaEmpresas();
            CargaPruebas();
        }

        public void CargaPruebas()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (prNombre) as Pruebas from tbPruebas order by prNombre", con);

                da.Fill(ds, "Pruebas");
                cbbPrueba.DataSource = ds.Tables[0].DefaultView;
                cbbPrueba.ValueMember = "Pruebas";
                cbbPrueba.Text = "Seleccione la prueba";


                con.Close();
            }
        }
        public void CargaEmpresas()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (emnom) as Empresas from tbEmpresas order by emnom", con);

                da.Fill(ds, "Empresas");
                cbbEmpresa.DataSource = ds.Tables[0].DefaultView;
                cbbEmpresa.ValueMember = "Empresas";
                cbbEmpresa.Text = "Seleccione la Empresa";


                con.Close();
            }
        }

        public void GetData()
        {
            try
            {

                using (var con = new SqlConnection(conect))
                {
                    radGridView1.DataSource = null;
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spEmpresasReport", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@fechainicio", dtp1.Text);
                    da.SelectCommand.Parameters.AddWithValue("@fechafin", dtp2.Text);
                    da.SelectCommand.Parameters.AddWithValue("@prueba", cbbPrueba.Text);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", cbbEmpresa.Text);

                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    if (radGridView1.Columns[0].Name == "CommandColumn2")
                       
                        con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            String FileExp = "C:\\SGP\\exportedFile" + DateTime.Now.ToString("yyyy-mm-dd") + ".xlsx";
            GridViewSpreadExport spreadExporter = new GridViewSpreadExport(this.radGridView1);
            SpreadExportRenderer exportRenderer = new SpreadExportRenderer();
            spreadExporter.RunExport(FileExp, exportRenderer);

            Process prc = new Process();
            prc.StartInfo.FileName = FileExp;
            prc.Start();
        }
    }
}
