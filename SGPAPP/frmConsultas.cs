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
using System.IO;
using System.Configuration;
using System.Drawing.Printing;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SGPAPP.Properties;
using Telerik.WinControls.Export;
using System.Diagnostics;

namespace SGPAPP
{
    public partial class frmConsultas : Form
    {
        public frmConsultas()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn2 = new GridViewCommandColumn();           
            commandColumn2.Name = "CommandColumn2";
            commandColumn2.UseDefaultText = true;
            commandColumn2.Image = Properties.Resources.icons8_search_16;
            commandColumn2.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn2.FieldName = "select";
            commandColumn2.HeaderText = "Modificar";
            radGridView1.MasterTemplate.Columns.Add(commandColumn2);
            radGridView1.CommandCellClick += new CommandCellClickEventHandler(radGridView1_CommandCellClick);
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        String cambiada1;
        String cambiada2;
        int PacienteID;
        String Documentid;
        String Paciente;
        String contraseniaAleatoria;
        String Fechan;

        public void GetData()
        {
            try
            {
               
                using (var con = new SqlConnection(conect))
                {
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
                        radGridView1.Columns.Move(0, 14);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmConsultas_Load(object sender, EventArgs e)
        {            
            GetData();

        }
       

            private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnExporta_Click(object sender, EventArgs e)
        {
           


        }

        private void ExportaExcl(RadGridView dgb)
        {
            //try
            //{
            //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
            //    excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
            //    int IndiceColumna = 0;
            //    foreach (DataGridViewColumn columna in dgb.Columns) //Aquí empezamos a leer las columnas del listado a exportar
            //    {
            //        IndiceColumna++;
            //        excel.Cells[1, IndiceColumna] = columna.Name;
            //    }
            //    int IndiceFila = 0;
            //    foreach (DataGridViewRow fila in dgb.Rows) //Aquí leemos las filas de las columnas leídas
            //    {
            //        IndiceFila++;
            //        IndiceColumna = 0;
            //        foreach (DataGridViewColumn columna in dgb.Columns)
            //        {
            //            IndiceColumna++;
            //            excel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
            //        }
            //    }
            //    excel.Visible = true;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("No hay Registros a Exportar.");
            //}
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void advancedDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
          
        }

        private void advancedDataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
        }

        private void dataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {

        }

        private void dataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
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

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;
                DateTime fecha2;
                DateTime fecha3;

                fecha1 = dtp1.Value;

                string day2 = fecha1.Day.ToString();
                string mes2 = fecha1.Month.ToString();
                string year2 = fecha1.Year.ToString();

                cambiada1 = year2 + "-" + mes2 + "-" + day2;

                fecha2 = dtp2.Value;

                String day1 = fecha2.Day.ToString();
                String mes1 = fecha2.Month.ToString();
                String year1 = fecha2.Year.ToString();

                cambiada2 = year1 + "-" + mes1 + "-" + day1;

               
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
           
        }
        bool Cred= false;
        public void CargaCred()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                { 
                con.Open();
                string ct = "select cPacid from tbCredenciales where cPacid = '" + PacienteID + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    Cred = false;
                }
                else
                {
                    Cred = true;
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }
            private void button1_Click(object sender, EventArgs e)
        {
           
        }
        public void Imprimir(object sender, PrintPageEventArgs e)
        {
            String imagen = Environment.CurrentDirectory + @"\\resourses\logocge.png";
            System.Drawing.Image img = System.Drawing.Image.FromFile(imagen);
            e.Graphics.DrawImage(img, new System.Drawing.Rectangle(20, 20, 206, 103));
            System.Drawing.Font font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString("CREDENCIALES CONSULTA", font, Brushes.Black, new RectangleF(40, 130, 200, 80));
            e.Graphics.DrawString("RESULTADOS", font, Brushes.Black, new RectangleF(85, 150, 200, 80));
            System.Drawing.Font font1 = new System.Drawing.Font("Calibri", 12, FontStyle.Regular, GraphicsUnit.Point);
            System.Drawing.Font font2 = new System.Drawing.Font("Calibri", 12, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString("Paciente: " +Paciente, font1, Brushes.Black, new RectangleF(30, 190, 300, 80));
            e.Graphics.DrawString("Usuario: " + Documentid, font2, Brushes.Black, new RectangleF(40, 250, 200, 80));
            e.Graphics.DrawString("Contraseña: " + contraseniaAleatoria, font2, Brushes.Black, new RectangleF(40, 280, 200, 80));
            e.Graphics.DrawString("www.cgegrupomedico.com", font1, Brushes.Black, new RectangleF(40, 350, 200, 80));

        }
        public void GeneraCed()
        {
            if (Documentid == "No Aplica")
            {
                int CED = PacienteID;
                Random rced = new Random();
                string nums = "000000000000000000000000000000";
                int Longitud = nums.Length;
                int longi = CED.ToString().Length;
                char caracter;
                int longitudCed = 11 - longi;
                Documentid = string.Empty;
                for (int i = 0; i < longitudCed; i++)
                {
                    caracter = nums[rced.Next(Longitud)];
                    Documentid += caracter.ToString();

                }
                Documentid = Documentid + CED;
                string result = string.Format("{0:000-0000000-0}", int.Parse(Documentid));
                Documentid = result;

                //using (var con = new SqlConnection(conect))
                //{
                //    string sql = "update tbpacientes set pCed = '" + Documentid + "' where pid = " + PacienteID + "";
                //    SqlCommand cmd = new SqlCommand(sql, con);
                //    cmd.CommandType = CommandType.Text;
                //    con.Open();
                //    try
                //    {
                //        int i = cmd.ExecuteNonQuery();
                        
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("Error:" + ex.ToString());
                //    }
                //    finally
                //    {
                //        con.Close();
                //    }
                //}
            }

        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {

                if (txtConsulta.Text.Length == 0)
                {
                    GetData();
                }
                else
                {
                    try
                    {
                        using (var con = new SqlConnection(conect))
                        {
                            SqlDataAdapter da = new SqlDataAdapter("spgetPacientes", con);
                            DataTable dt = new DataTable();
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@Nombre", txtConsulta.Text);
                            da.SelectCommand.Parameters.AddWithValue("@Fechadesde", (object)DBNull.Value);
                            da.SelectCommand.Parameters.AddWithValue("@fechahasta", (object)DBNull.Value);
                            da.Fill(dt);
                            this.radGridView1.DataSource = dt;
                            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                            //radGridView1.Columns.Move(0, 9);

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

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }
     

        private void radGridView1_CreateCell(object sender, GridViewCreateCellEventArgs e)
        {
            
        }

        private void radGridView1_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {

        }

        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            //var senderGrid = (RadGridView)sender;

            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            //{
               
            //        PacienteID = (int)this.dgb1.Rows[e.RowIndex].Cells["ID"].Value;

            //        frmPacEdit ed = new frmPacEdit();
            //        ed.PacID = PacienteID.ToString();
            //        ed.ShowDialog();
            //        if (ed.DialogResult == DialogResult.OK)
            //        {
            //            GetData();
            //        }
            //    }
            
            //MessageBox.Show("VainaBien");
        }
        void btnImagenclick_Click(object sender, EventArgs e)
        {
            try
            {
                GridImageCellElement imgCell = (GridImageCellElement)sender;

                if (imgCell == null)
                    return;
                PacienteID = (int)imgCell.RowInfo.Cells["ID"].Value;
                frmPacEdit ed = new frmPacEdit();
                ed.PacID = PacienteID.ToString();
                ed.ShowDialog();
                if (ed.DialogResult == DialogResult.OK)
                {
                    GetData();
                }


            }
            catch
            {

            }
        }



        private void radGridView1_CellPaint(object sender, GridViewCellPaintEventArgs e)
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

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            object cellValue = e.Row.Cells[0].Value;

        }

        private void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
           
            //if (e.Column.Name == "CommandColumn2")
            //{
            //    e.CellElement.DrawFill = true;
            //    e.CellElement.NumberOfColors = 1;
            //    e.CellElement.BackColor = System.Drawing.Color.Red;
            //GridImageCellElement imgCell = e.CellElement as GridImageCellElement;

            //if (imgCell != null)
            //{
            //    imgCell.Image = Properties.Resources.icons8_search_16;

            //    try
            //    {
            //        imgCell.Click -= btnImagenclick_Click;
            //    }
            //    catch
            //    {

            //    }

            //    imgCell.Click += btnImagenclick_Click;
            //}
        //}
        }
        void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            GridViewRowInfo row = radGridView1.CurrentRow;
            PacienteID = int.Parse(e.Row.Cells[0].Value.ToString());
            frmPacEdit ed = new frmPacEdit();
            ed.PacID = PacienteID.ToString();
            ed.ShowDialog();
            if (ed.DialogResult == DialogResult.OK)
            {
                GetData();
            }
        }

        private void radGridView1_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        {

        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Asignar Pruebas") || UserCache.Nivel == "Admin")
            {
                try
                {
                    int rowIndex = radGridView1.CurrentCell.RowIndex;

                    PacienteID = (int)this.radGridView1.Rows[rowIndex].Cells[0].Value;
                    Documentid = (String)this.radGridView1.Rows[rowIndex].Cells["Cedula"].Value;
                    Paciente = (string)this.radGridView1.Rows[rowIndex].Cells["Paciente"].Value;


                    DialogResult resulta = MessageBox.Show("Seguro quiere generar nuevos credenciales al Paciente: " + Paciente + " ?", "Actualizar Credenciales?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resulta == DialogResult.Yes)
                    {
                        using (var con = new SqlConnection(conect))
                        {
                            Random rdn = new Random();
                            string caracteres = "1234567890";
                            int longitud = caracteres.Length;
                            char letra;
                            int longitudContrasenia = 8;
                            contraseniaAleatoria = string.Empty;
                            for (int i = 0; i < longitudContrasenia; i++)
                            {
                                letra = caracteres[rdn.Next(longitud)];
                                contraseniaAleatoria += letra.ToString();
                            }
                            String pass = clsEncrypt.GetSHA256(contraseniaAleatoria);
                            GeneraCed();
                            CargaCred();

                            con.Open();
                            cmd = new SqlCommand("", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetCredenciales";
                            cmd.Parameters.Add(new SqlParameter("@pid", SqlDbType.VarChar)).Value = PacienteID;
                            cmd.Parameters.Add(new SqlParameter("@Ced", SqlDbType.VarChar)).Value = Documentid;
                            cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar)).Value = pass;

                            cmd.ExecuteNonQuery();

                            con.Close();
                        }


                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();
                        printDocument1.PrinterSettings = ps;
                        printDocument1.PrintPage += Imprimir;
                        ps.PrinterName = "LR2000";
                        printDocument1.Print();

                        string GS = Convert.ToString((char)29);
                        string ESC = Convert.ToString((char)27);

                        string COMMAND = "";
                        COMMAND = ESC + "@";
                        COMMAND += GS + "V" + (char)1;
                        RawPrinterHelper.SendStringToPrinter(ps.PrinterName = "LR2000", COMMAND);

                        Logs log = new Logs();
                        log.Accion = "Credenciales actualizados al usuario: " + Paciente + "";
                        log.Form = "Consulta de Pacientes";
                        log.SaveLog();
                        MessageBox.Show("Nuevos credenciales: '" + contraseniaAleatoria + "' del Paciente:" + Paciente + " Generados exitosamente!.", "Credenciales Generados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(conect))
                {
                    conviertefecha();
                    try
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("spgetPacientes", con);
                        DataTable dt = new DataTable();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@Fechadesde", cambiada1);
                        da.SelectCommand.Parameters.AddWithValue("@fechahasta", cambiada2);
                        da.Fill(dt);
                        this.radGridView1.DataSource = dt;
                        this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                        //radGridView1.Columns.Move(0, 9);
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

        private void radButton1_Click_1(object sender, EventArgs e)
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
