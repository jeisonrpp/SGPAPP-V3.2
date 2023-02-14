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
using System.Net.Mail;
using System.Net;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net.Sockets;
using System.Globalization;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Text.RegularExpressions;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.Export;

namespace SGPAPP
{
    public partial class frmResultsc : Form
    {
        public frmResultsc()
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

        string outputPdfPath;
        ToolTip t1 = new ToolTip();
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        string cambiada1;
        string cambiada2;
        string cambiada3;
        String day;
        String mes;
        String year;
        String Fecha;
        String docname;
        String name;
        String edad1;
        String fechana;
        String cedul;
        String resultado;
        String noct;
        String dir;
        string rutasave;
        int PacID;
        String Mail;
        String Mail2;
        bool enviado;
        clsMail cm = new clsMail();
        String IDre;
        String FechaMuestra;
        bool Printed;
        String FechaReg;
        String HoraMuestra;
        String HoraEmision;
        byte[] PDFDOC;
        String QrLink;
        String ResultID;
        String Resultado2;
        String CT2;
        bool English = false;
        string fileName;
        bool validapr = false;
        int PruebaID;
        clsRandomNo rd = new clsRandomNo();
        bool checkPDF;

        SqlDataReader rdr = null;
        bool validate;
        public void GetData()
        {
            try
            {
 
                using (var con = new SqlConnection(conect))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetResultados", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@Fechadesde", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@fechahasta", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@Prueba", (object)DBNull.Value);

                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    if (radGridView1.Columns[0].Name == "CommandColumn2")
                    {
                        radGridView1.Columns.Move(0, 20);
                        radGridView1.Columns[1].IsVisible = false;
 
                        radGridView1.Columns[6].IsVisible = false;
                        radGridView1.Columns[14].IsVisible = false;
                        radGridView1.Columns[12].IsVisible = false;
                        radGridView1.Columns[13].IsVisible = false;
                        radGridView1.Columns[18].IsVisible = false;
                        //radGridView1.Columns[20].IsVisible = false;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmResultsc_Load(object sender, EventArgs e)
        {
            GetData();
            CargaPruebas();
        }
        public void CargaPruebas()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("spGetPruebas", con);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                sqlData.Fill(table);
                cbbPrueba.DataSource = table;
                cbbPrueba.ValueMember = "Pruebas";
                cbbPrueba.Text = "Seleccione la Prueba";
                con.Close();


                con.Close();
            }
        }
        private void btnExporta_Click(object sender, EventArgs e)
        {
        
        }

        private void ExportaExcl(DataGridView dgb)
        {
            try
            {
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
            }
            catch (Exception)
            {
                MessageBox.Show("No hay Registros a Exportar.");
            }
        }

        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        public void SaveLog()
        {
            Logs log = new Logs();
            log.Accion = "Resultados ID: "+IDre+" Reimpresos al Paciente: " + name + "";
            log.Form = "Reimpresion de Resultados";
            log.SaveLog();
        }
        string realname;
       
        public void CargaPDF()
        {
            using (SqlConnection con = new SqlConnection(conect))
            {


                
                    cmd = new SqlCommand("", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spCargaPDFResultados";                    
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = IDre;
                    con.Open();

                    rd.GetNo();


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            realname = dr[0].ToString();
                            int size = 1024 * 1024;
                            byte[] buffer = new byte[size];
                            int readBytes = 0;
                            int index = 0;
                            docname = name + "-" + rd.RandomNo + ".pdf";
                            fileName = @"C:\SGP\" + name + "-" + rd.RandomNo + ".pdf";
                            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                while ((readBytes = (int)dr.GetBytes(0, index, buffer, 0, size)) > 0)
                                {
                                    fs.Write(buffer, 0, readBytes);
                                    index += readBytes;
                                }
                            }

                        
                    }
                }
            }

                }
    
      
        public void CheckPDF()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT redocPDF as [PDF] from tbresultados where reid = "+IDre+" and redocpdf is not null";

               
                SqlDataReader reader;
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCargaPDFResultados";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = IDre;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        checkPDF = true;

                    }
                    else
                    {
                        checkPDF = false;
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

                
                    fecha3 = DateTime.Now;

                    day = fecha3.Day.ToString();
                    mes = fecha3.Month.ToString();
                    year = fecha3.Year.ToString();

                    cambiada3 = year + "-" + mes + "-" + day;
                
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

       
       
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        public void getPaciente()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetPacientes";
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar)).Value = PacID;
                cmd.Parameters.Add(new SqlParameter("@Fechadesde", SqlDbType.VarChar)).Value = "edit";
                cmd.Parameters.Add(new SqlParameter("@Fechahasta", SqlDbType.VarChar)).Value = (object)DBNull.Value;
                SqlDataReader reader;
                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Mail = reader[0].ToString();
                        FechaReg = reader[1].ToString();
                        Mail2 = reader[2].ToString();
                        if (Mail2.Length >0)
                        {
                            Mail = Mail + ", " + Mail2;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado registro de paciente!");
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
        }
        String Prueba;
        String Tipo;
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

       

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtConsulta_Enter(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "Digite nombre, cedula o email")
            {
                txtConsulta.Text = "";
                txtConsulta.ForeColor = Color.MidnightBlue;
            }
        }

        private void txtConsulta_Leave(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "")
            {
                txtConsulta.Text = "Digite nombre, cedula o email";
                txtConsulta.ForeColor = Color.Silver;
                GetData();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

        }

        private void btnFolder_MouseHover(object sender, EventArgs e)
        {
           
            t1.Show("Abrir carpeta de resultados", btnFolder);
            
        }

        private void btnExporta_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Importar datos a excel", btnExcel);
        }

        private void btnFiltrar_MouseHover(object sender, EventArgs e)
        {
            //t1.Show("Filtar por rango de fecha", btnFiltrar);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
   
        }


        private void comboBox1_Leave(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           
        }

        private void cbbConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        public void ValidaPruebas()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                string ct2 = "select * from tbpruebas where prNombre = '" + Prueba + "' and prLaboratorios = 1";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    validapr = true;

                }
                con.Close();
            }
        }
        public void getPruebasEspeciales()
        {
            try
            {
                using (var con = new SqlConnection(conect))
                {
                    
                    con.Open();
                    if (Prueba != "HIV")
                    {
                        cmd = new SqlCommand("select rePrueba as pruebas, reresultado as resultados, prUnidad as unidad, prValores as valores, prvalmin as valormin, prvalmax as valormax, prDpto as Departamento from tbResultados inner join tbpruebas on rePrueba = prnombre where rePacid = " + PacID + " and reFecham = '" + FechaMuestra + "' and prlaboratorios = 1 and retipop = '" + Tipo + "' and rePrueba <> 'HIV'", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("select rePrueba as pruebas, reresultado as resultados, prUnidad as unidad, prValores as valores, prvalmin as valormin, prvalmax as valormax, prDpto as Departamento from tbResultados inner join tbpruebas on rePrueba = prnombre where rePacid = " + PacID + " and reFecham = '" + FechaMuestra + "' and prlaboratorios = 1 and rePrueba = 'HIV'", con);
                    }    
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                    myDA.Fill(myDataSet, "Usuario");
                    dataGridView1.DataSource = myDataSet.Tables["Usuario"].DefaultView;
                    dataGridView1.Columns["pruebas"].DisplayIndex = 0;
                    dataGridView1.Columns["resultados"].DisplayIndex = 1;
                    dataGridView1.Columns["unidad"].DisplayIndex = 2;
                    dataGridView1.Columns["valores"].DisplayIndex = 3;
                    dataGridView1.Columns["valormin"].DisplayIndex = 4;
                    dataGridView1.Columns["valormax"].DisplayIndex = 5;
                    dataGridView1.Columns["Departamento"].DisplayIndex = 6;
                    con.Close();

                    //con.Open();
                    //cmd = new SqlCommand("SELECT Distinct(prDpto) as [Departamento] from tbpruebas inner join tbResultados on reprueba = prNombre where prLaboratorios = 1 and repacid = '" + PacID + "' and reFecham = '" + FechaMuestra + "'", con);
                    //SqlDataAdapter myDA2 = new SqlDataAdapter(cmd);
                    //DataSet myDataSet2 = new DataSet();
                    //myDA2.Fill(myDataSet2, "Paciente");
                    //dataGridView3.DataSource = myDataSet2.Tables["Paciente"].DefaultView;
                    //dataGridView3.Columns["Departamento"].DisplayIndex = 0;

                    //con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        String testvalue;

        private void btnPlantilla_Click(object sender, EventArgs e)
        {
            

        }
        public void ValidaPDF()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                string ct = "select * from tbcontrolPDF where cpreid = '" + IDre + "' and cpgenerate = 0";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Estos resultados ya se encuentran pendientes de ser generados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    validate = true;
                    con.Close();
                }

                else if ((rdr != null))
                {
                    validate = false;
                    con.Close();
                }
            }
        }
        public void GeneratePDF()
        {
            ValidaPDF();
            if (validate == false)
            {

                using (var con = new SqlConnection(conect))
                {
                    DateTime HoraRegistro = DateTime.Now;
                    String Query = "insert into tbcontrolpdf (cpreid, cppacid, cpgenerate, cpfecha, cphora, cpuser, cpenglish) values ('" + IDre + "', " + PacID + ", '0', '" + cambiada3 + "', '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + UserCache.Usuario + "', @English) ";
                    cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@English", English);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        MessageBox.Show("Actualizacion de Resultados Ejecutada Correctamente!.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        private void btnPlantilla_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Actualizar resultados", btnact);
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

                            con.Open();
                            SqlDataAdapter da = new SqlDataAdapter("spGetResultados", con);
                            DataTable dt = new DataTable();
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@Nombre", txtConsulta.Text);
                            da.SelectCommand.Parameters.AddWithValue("@Fechadesde", (object)DBNull.Value);
                            da.SelectCommand.Parameters.AddWithValue("@fechahasta", (object)DBNull.Value);
                            da.SelectCommand.Parameters.AddWithValue("@Prueba", (object)DBNull.Value);

                            da.Fill(dt);
                            this.radGridView1.DataSource = dt;
                            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
  



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

      
        public void MergePDF()
        {
            int Rows = dataGridView2.Rows.Count;
            Rows = Rows + 1;
            string[] fileArray = new string[Rows];
            int es = 0;
            String Filename;

            foreach (DataGridViewRow Row in dataGridView2.Rows)
            {
                using (var con = new SqlConnection(conect))
                {
                    con.Open();
                    using (SqlCommand cm = con.CreateCommand())
                    {
                        int ResultID = (int)Row.Cells["ID Resultado"].Value;
                        fileName = @"C:\SGP\" + name + "-" + ResultID + "-" + cambiada3 + ".pdf";
                        cm.CommandText = "Select reDocPDF from tbresultados where reid = @id and redocpdf is not null ";

                        cm.Parameters.Add("@id", SqlDbType.Int).Value = (int)Row.Cells["ID Resultado"].Value;

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {

                            if (dr.Read())
                            {

                                int size = 1024 * 1024;
                                byte[] buffer = new byte[size];
                                int readBytes = 0;
                                int index = 0;
                                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                                {

                                    while ((readBytes = (int)dr.GetBytes(0, index, buffer, 0, size)) > 0)
                                    {
                                        fs.Write(buffer, 0, readBytes);
                                        index += readBytes;
                                    }
                                }
                            }
                        }
                    }
                    Filename = fileName;

                    fileArray[es] = Filename;
                    es++;
                    con.Close();
                }
            }
            DateTime Fecha = DateTime.Now;
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            outputPdfPath = @"C:\SGP\" + name + " - 1" + Fecha.ToString("yyyy-MM-dd") + ".pdf";

            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //output file Open  
            sourceDocument.Open();


            //files list wise Loop  
            for (int f = 0; f < fileArray.Length - 1; f++)
            {
                int pages = TotalPageCount(fileArray[f]);

                reader = new PdfReader(fileArray[f]);
                //Add pages in new file  
                for (int i = 1; i <= pages; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }

                reader.Close();
            }
            //save the output file  
            sourceDocument.Close();
            PDFDOC = System.IO.File.ReadAllBytes(outputPdfPath);
            Process prc = new Process();
            prc.StartInfo.FileName = outputPdfPath;
            prc.Start();
            //UpdateResults();

        }
        public void UpdateResults()
        {
            int cont = 0;
            using (var con = new SqlConnection(conect))
            using (SqlCommand cmd = con.CreateCommand())
            {
                foreach (DataGridViewRow ro in dataGridView2.Rows)
                {
                    String Var = "DOC"+cont.ToString();
                    
                    try
                    {
                        cmd.CommandText = @"update tbresultados set reDocPDF = @"+Var+" where reID = " + (int)ro.Cells["ID Resultado"].Value + "";
                        cmd.Parameters.AddWithValue("@"+Var+"", SqlDbType.VarBinary).Value = PDFDOC;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }

                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();
                    cont++;
                }
            }
        }
    
        private int TotalPageCount(string file)
        {
            using (StreamReader sr = new StreamReader(System.IO.File.OpenRead(file)))
            {
                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());

                return matches.Count;
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void cbbPrueba_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        void btnImagenclick_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    GridImageCellElement imgCell = (GridImageCellElement)sender;

            //    if (imgCell == null)
            //        return;

                //ID = (int)imgCell.RowInfo.Cells["ID"].Value;
                //Cedula = (string)imgCell.RowInfo.Cells["Cedula"].Value;

               
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


        private void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
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
            if (UserCache.RoleList.Any(item => item.RoleName == "Reimpresion/Envio Resultados") || UserCache.Nivel == "Admin")
            {
   

                PacID = (int)e.Row.Cells["ID de Paciente"].Value;
                getPaciente();
                IDre = Convert.ToString((int)e.Row.Cells["ID de Resultado"].Value);
                name = (string)e.Row.Cells["Paciente"].Value;
                //PruebaID = (int)radGridView1.Rows[row.Index].Cells["ID Prueba Empresa"].Value;
                CheckPDF();
                if (checkPDF == false)
                {
                    MessageBox.Show("Este Resultado aun no ha sido generado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    conviertefecha();
                    frmMsg msg = new frmMsg();
                    msg.ShowDialog();
                    if (msg.DialogResult == DialogResult.OK)
                    {
                        enviado = false;


                        if (Prueba != "HIV")
                        {

                            SendMail();

                            MessageBox.Show("Resultados enviados de manera satisfactoria al correo: " + Mail + ".", "Reenvio de correo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Este tipo de prueba no puede ser enviada por correo.", "Reenvio de correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    if (msg.DialogResult == DialogResult.Yes)
                    {


                        CargaPDF();
                        Process prc = new Process();
                        prc.StartInfo.FileName = fileName;
                        prc.Start();
                        try
                        {

                            Printed = true;
                        }
                        catch (Exception ex)
                        {

                            Printed = false;
                        }

                        if (Printed == true)
                        {
                            MessageBox.Show("Resultados generados satisfactoriamente.", "Operacion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }

                    SaveLog();
                }
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }
        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void radGridView1_RowMouseMove(object sender, EventArgs e)
        {
            
        }
        public void SendMail()
        {
            conviertefecha();
            using (var con = new SqlConnection(conect))
            {
                if (Mail2.Length > 0)
                {
                    Mail = Mail + ", " + Mail2;
                }
                DateTime HoraRegistro = DateTime.Now;
                String Query2 = "insert into tbControlMail (cmreid, cmpruebaempresaid, cmmail, cmfecha, cmhora, cmenviado, cmerror) values ("+IDre+", '0', '" + Mail + "', '" + cambiada3 + "', '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', 0, NULL) ";
                cmd = new SqlCommand(Query2, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void cbbPrueba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnact_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Actualizacion Resultados") || UserCache.Nivel == "Admin")
            {
                try
                {

                    int rowIndex = radGridView1.CurrentCell.RowIndex;

                    IDre = this.radGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                    PacID = int.Parse(this.radGridView1.Rows[rowIndex].Cells[1].Value.ToString());
                    getPaciente();
                    name = this.radGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                    cedul = this.radGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                    fechana = this.radGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                    if (fechana == "1900-01-01")
                    {
                        fechana = "-";
                    }
                    edad1 = this.radGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                    Tipo = this.radGridView1.Rows[rowIndex].Cells[9].Value.ToString();
                    Prueba = this.radGridView1.Rows[rowIndex].Cells[10].Value.ToString();
                    resultado = this.radGridView1.Rows[rowIndex].Cells[11].Value.ToString();
                    noct = this.radGridView1.Rows[rowIndex].Cells[12].Value.ToString();
                    Resultado2 = this.radGridView1.Rows[rowIndex].Cells[13].Value.ToString();
                    CT2 = this.radGridView1.Rows[rowIndex].Cells[14].Value.ToString();
                    Fecha = this.radGridView1.Rows[rowIndex].Cells[16].Value.ToString();
                    if ((this.radGridView1.Rows[rowIndex].Cells[20].Value != null))
                    {
                        PruebaID = int.Parse(this.radGridView1.Rows[rowIndex].Cells[20].Value.ToString());
                    }
                    if (this.radGridView1.Rows[rowIndex].Cells[18].Value != System.DBNull.Value)
                    {
                        HoraMuestra = this.radGridView1.Rows[rowIndex].Cells[18].Value.ToString();
                    }
                    else
                    {
                        HoraMuestra = "";
                    }
                    if (this.radGridView1.Rows[rowIndex].Cells[17].Value != System.DBNull.Value)
                    {
                        HoraEmision = this.radGridView1.Rows[rowIndex].Cells[17].Value.ToString();
                    }
                    else
                    {
                        HoraEmision = "";
                    }
                    if (this.radGridView1.Rows[rowIndex].Cells[15].Value == DBNull.Value)
                    {
                        FechaMuestra = FechaReg;
                    }
                    else
                    {
                        FechaMuestra = this.radGridView1.Rows[rowIndex].Cells[15].Value.ToString();
                    }

                    if (this.radGridView1.Rows[rowIndex].Cells[6].Value != System.DBNull.Value)
                    {
                        dir = this.radGridView1.Rows[rowIndex].Cells[6].Value.ToString();

                    }
                    else
                    {
                        dir = "-";
                    }
                    //ValidaPruebas();
                    //if (validapr == true)
                    //{
                    //    conviertefecha();
                    //    DialogResult result = MessageBox.Show("Esta seguro que desea actualizar los resultados " + IDre + " de: " + name + "?", "Generar Resultados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //    if (result == DialogResult.Yes)
                    //    {
                    //        bool Results = false;

                    //        getPruebasEspeciales();


                    //        testvalue = dataGridView1.Rows[0].Cells["Departamento"].Value.ToString();


                    //        EditPlantillalab();

                    //        UpdatePlantilla();
                    //        MessageBox.Show("Resultados Actualizados Correctamente!.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //}
                    //else
                    //{
                        conviertefecha();
                        DialogResult result = MessageBox.Show("Esta seguro que desea actualizar los resultados " + IDre + " de: " + name + "?", "Generar Resultados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (Prueba == "Sars Cov-2" || Prueba == "Antigeno")
                            {
                                DialogResult resulta = MessageBox.Show("DESEA GENERAR LOS RESULTADOS EN INGLES?", "Idioma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (resulta == DialogResult.Yes)
                                {
                                    English = true;
                                }

                                else
                                {
                                    English = false;
                                }
                            }

                            GeneratePDF();
                            Logs log = new Logs();
                            log.Accion = "Resultados regenerados: " + name + "";
                            log.Form = "Consulta de Resultados";
                            log.SaveLog();
                        }
                    //}

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void radButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\SGP\");
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(conect))
                {

                    conviertefecha();
                    SqlDataAdapter da = new SqlDataAdapter("spGetResultados", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@Fechadesde", cambiada1);
                    da.SelectCommand.Parameters.AddWithValue("@fechahasta", cambiada2);
                    da.SelectCommand.Parameters.AddWithValue("@Prueba", (object)DBNull.Value);

                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    //radGridView1.Columns.Move(0, 18);
                    //radGridView1.Columns[1].IsVisible = false;
                    //radGridView1.Columns[8].IsVisible = false;
                    //radGridView1.Columns[11].IsVisible = false;
                    //radGridView1.Columns[12].IsVisible = false;
                    //radGridView1.Columns[13].IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cbbPrueba.Text != "Seleccione la prueba")
                {
                    using (var con = new SqlConnection(conect))
                    {

                        SqlDataAdapter da = new SqlDataAdapter("spGetResultados", con);
                        DataTable dt = new DataTable();
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@Fechadesde", (object)DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@fechahasta", (object)DBNull.Value);
                        da.SelectCommand.Parameters.AddWithValue("@Prueba", cbbPrueba.Text);

                        da.Fill(dt);
                        this.radGridView1.DataSource = dt;
                        this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                        //radGridView1.Columns.Move(0, 18);
                        //radGridView1.Columns[1].IsVisible = false;
                        //radGridView1.Columns[8].IsVisible = false;
                        //radGridView1.Columns[11].IsVisible = false;
                        //radGridView1.Columns[12].IsVisible = false;
                        //radGridView1.Columns[13].IsVisible = false;

                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "ReportEmpresa") || UserCache.Nivel == "Admin")
            {
                frmReportesEmpresas prt = new frmReportesEmpresas();
                prt.ShowDialog();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
    }
    }

