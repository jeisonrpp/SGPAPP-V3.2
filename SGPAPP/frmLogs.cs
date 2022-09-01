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
    public partial class frmLogs : Form
    {
        public frmLogs()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        public void GetLogs()
        {
          
                DateTime Fecha = DateTime.Now.AddDays(-7);
                string day1 = Fecha.Day.ToString();
                string mes1 = Fecha.Month.ToString();
                string year1 = Fecha.Year.ToString();

                string cambiada1 = year1 + "-" + mes1 + "-" + day1;
                using (var con = new SqlConnection(conect))
                {
                try
                { 

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetLogs", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Fechadesde", cambiada1);
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
               
          
        }
        private void ExportaExcl(DataGridView dgb)
        {
            //try
            //{
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
            excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
            int IndiceColumna = 0;
            foreach (DataGridViewColumn columna in dgb.Columns) //Aquí empezamos a leer las columnas del listado a exportar
            {
                IndiceColumna++;
                excel.Cells[1, IndiceColumna] = columna.Name;
            }
            int IndiceFila = 0;
            foreach (DataGridViewRow fila in dgb.Rows) //Aquí leemos las filas de las columnas leídas
            {
                IndiceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn columna in dgb.Columns)
                {
                    IndiceColumna++;
                    excel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                }
            }
            excel.Visible = true;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("No hay Registros a Exportar.");
            //}
        }
        private void btnExporta_Click(object sender, EventArgs e)
        {
            

        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
           
            GetLogs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
        }

        private void dataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
           
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            DateTime fecha1;
            DateTime fecha2;


            fecha1 = dtp1.Value;

            string day2 = fecha1.Day.ToString();
            string mes2 = fecha1.Month.ToString();
            string year2 = fecha1.Year.ToString();

            string cambiada2 = year2 + "-" + mes2 + "-" + day2;

            fecha2 = dtp2.Value;

            String day3 = fecha2.Day.ToString();
            String mes3 = fecha2.Month.ToString();
            String year3 = fecha2.Year.ToString();

            string cambiada3 = year3 + "-" + mes3 + "-" + day3;

            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetlogs", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Fechadesde", cambiada2);
                    da.SelectCommand.Parameters.AddWithValue("@fechahasta", cambiada3);

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

        private void radButton1_Click(object sender, EventArgs e)
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
