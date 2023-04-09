using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Word = Microsoft.Office.Interop.Word;

namespace SGPPDFController
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {
        public Form1()
        {
            InitializeComponent();
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            btnStartStop.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"\\resourses\start.png");
            btnStartStop.ImageAlignment = ContentAlignment.TopCenter;
            radGridView1.Columns[4].IsVisible = false;
            radGridView1.Columns[5].IsVisible = false;
            radGridView1.Columns[6].IsVisible = false;
            radGridView1.Columns[7].IsVisible = false;
            radGridView1.Columns[8].IsVisible = false;
            radGridView1.Columns[9].IsVisible = false;
            radGridView1.Columns[10].IsVisible = false;
            radGridView1.Columns[11].IsVisible = false;
            radGridView1.Columns[12].IsVisible = false;
            radGridView1.Columns[13].IsVisible = false;
            radGridView1.Columns[14].IsVisible = false;
            radGridView1.Columns[15].IsVisible = false;
            radGridView1.Columns[16].IsVisible = false;
            radGridView1.Columns[17].IsVisible = false;
        }
        public static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        private static BackgroundWorker worker = new BackgroundWorker();
        int cpreid;
        byte cpgenerate;
        String repaciente;
        String redir;
        String refechan;
        String reedad;
        String reced;
        String retipop;
        String reprueba;
        String reresultado;
        String rect;
        String reresultado2;
        String rect2;
        String refecham;
        String rehoram;
        String refecha;
        String rehora;
        bool English;
        String QrLink;
        clsRandomNum rd = new clsRandomNum();
        String realname;
        int Pacid;
        String docname;
        String rutasave;
        byte[] PDFDOC;
        bool Abort = false;
        int cpid;
        int cpintento;
        string cperror;
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        bool validapr = false;
        bool especial = false;
        int plantillaid;
        bool Presult = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conect);
            Statuslabel("Proceso Dentenido", Color.DarkSlateGray);
            label2.Text = "Server: " + con.DataSource;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Iniciar")
            {
                btnStartStop.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"\\resourses\stop.png");
                btnStartStop.ImageAlignment = ContentAlignment.TopCenter;
                Abort = false;
                btnStartStop.Text = "Detener";
                if (worker.IsBusy != true)
                {
                    worker.RunWorkerAsync();
                    Statuslabel("Buscando PDF para generar...", Color.DarkSlateGray);
                }
            }
            else if (btnStartStop.Text == "Detener")
            {
                cancel();
                Abort = true;
                
                btnStartStop.Text = "Iniciar";
                Statuslabel("Proceso Dentenido", Color.DarkSlateGray);
                btnStartStop.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"\\resourses\start.png");
                btnStartStop.ImageAlignment = ContentAlignment.TopCenter;
            }

            }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //cancel();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            for (int i = 1; i <= 10; i++)
            {
                if (i >= 10)
                {
                    i = 0;
                }
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                validation();
                if (radGridView1.Rows.Count > 0)
                {
                    GeneratePDF();
                }
                Thread.Sleep(5000);
                worker.ReportProgress(i * 10);
                if (Abort == false)
                {
                    Statuslabel("Buscando PDF para generar..", Color.DarkSlateGray);
                }
            }

        }
        public void Statuslabel(string message, object color = null)
        {
            label1.Invoke(new MethodInvoker(() =>
            {
                label1.Text = message;
                if (color != null)
                    label1.ForeColor = (Color)color;
            }));
        }



        public void validation()
        {
            if (Abort == false)
            {
                try
                {
                   
                    radGridView1.Invoke(new MethodInvoker(() =>
                    {
                        radGridView1.Rows.Clear();
                    }));

                    SqlConnection cn = new SqlConnection(conect);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("spGetPDFtoGenerate", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adpt.Fill(ds);


                    cn.Close();
                    Statuslabel("Validando...", Color.DarkSlateGray);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        Statuslabel("Buscando PDF para generar.", Color.DarkSlateGray);

                    }
                    else
                    {

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            cpid = (int)dr["cpid"];
                            cpreid = (int)dr["cpreid"];
                            Pacid = (int)dr["cppacid"];
                            //cpgenerate = (byte)dr["cpgenerate"];
                            English = (bool)dr["cpenglish"];
                            repaciente = dr["repaciente"].ToString();
                            redir = dr["redir"].ToString();
                            refechan = dr["refechan"].ToString();
                            reedad = dr["reedad"].ToString();
                            reced = dr["reced"].ToString();
                            retipop = dr["retipop"].ToString();
                            reprueba = dr["reprueba"].ToString();
                            reresultado = dr["reresultado"].ToString();
                            rect = dr["rect"].ToString();
                            reresultado2 = dr["reresultado2"].ToString();
                            rect2 = dr["rect2"].ToString();
                            refecham = dr["refecham"].ToString();
                            refecha = dr["refecha"].ToString();
                            rehoram = dr["rehoram"].ToString();
                            rehora = dr["rehora"].ToString();                            
                            cpintento = (int)dr["cpintento"];
                            bool exist = false;
                            if (radGridView1.RowCount >= 1)
                            {
                                for (int i = 0; i < radGridView1.RowCount; i++)
                                {

                                    if (Convert.ToInt32(radGridView1.Rows[i].Cells["cpId"].Value) == cpid)
                                    {
                                        exist = true;
                                    }
                                   

                                }
                            }
                            if (exist == false)
                            {
                                radGridView1.Invoke(new MethodInvoker(() =>
                                 {
                                     radGridView1.Rows.Add(cpid, cpreid, Pacid, English, repaciente, redir, refechan, reedad, reced, retipop, reprueba, reresultado, rect, reresultado2, rect2, refecham, refecha, rehoram, rehora,cpintento);
                                 }));


                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {

        }
        public void cancel()
        {
            worker.CancelAsync();
            MessageBox.Show("Proceso Detenido Exitosamente.", "Detenido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        public void ValidaPrueba()
        {
            validapr = false;
            especial = false; 
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                //string ct2 = "select prlaboratorios, prespecial from tbpruebas where prNombre = '" + reprueba + "' and prLaboratorios = 1";
                string ct2 = "select prlaboratorios, prespecial, case when (select plid from tbplantilla where plprueba = '" + reprueba + "') is null then 0 else (select plid from tbplantilla where plprueba = '" + reprueba + "') end from tbpruebas where prNombre = '" + reprueba + "' and prLaboratorios = 1";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    validapr = bool.Parse(rdr[0].ToString());
                    especial = bool.Parse(rdr[1].ToString());
                    plantillaid = (int)rdr[2];

                }
                con.Close();

              
            }
        }

        public void ValidaPDF()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                Presult = false;
                string ct2 = "select reid, repaciente from tbpreresultados where reid = '" + cpreid + "' and repaciente = '"+repaciente+"'";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Presult = true;

                }
                con.Close();


            }
        }

        public void GeneratePDF()
        {                       
                using (var con = new SqlConnection(conect))
                {
                    foreach (GridViewRowInfo rowInfo in radGridView1.Rows) if (Abort == false)
                    {
                        try
                        {

                            Statuslabel("Generando PDF...", Color.DarkSlateGray);
                                cpid = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[0].Value);
                                cpreid = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[1].Value);
                                Pacid = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[2].Value);
                                English = Convert.ToBoolean(radGridView1.Rows[rowInfo.Index].Cells[3].Value);
                                repaciente = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[4].Value);
                                redir = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[5].Value);
                                refechan = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[6].Value);
                                if (refechan.ToString() == "01-01-1900")
                                {
                                    refechan = "-";
                                }
                                reedad = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[7].Value);
                                reced = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[8].Value);
                                retipop = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[9].Value);
                                reprueba = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[10].Value);
                                reresultado = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[11].Value);
                                rect = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[12].Value);
                                reresultado2 = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[13].Value);
                                rect2 = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[14].Value);
                                refecham = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[15].Value);
                                refecha = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[16].Value);
                                rehoram = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[17].Value);
                                rehora = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[18].Value);
                                cpintento = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[19].Value);
                                
                            if (cpintento < 3)
                            {
                                ValidaPrueba();
                                ValidaPDF();
                                if (validapr == true && especial == false)
                                {
                                    
                                    con.Open();
                                    SqlDataAdapter da = new SqlDataAdapter("spGeneratePruebasEspeciales", con);
                                    DataTable dt = new DataTable();
                                    
                                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                                    da.SelectCommand.Parameters.AddWithValue("@reid", cpreid);
                                    da.SelectCommand.Parameters.AddWithValue("@especial", 0);
                                    da.SelectCommand.Parameters.AddWithValue("@paciente", repaciente);
                                    da.SelectCommand.Parameters.AddWithValue("@result", Presult);
                                    da.Fill(dt);
                                    this.radGridView2.DataSource = dt;
                                    con.Close();

                                    EditPlantillaLab();
                                    dt.Rows.Clear();
                                }
                                else if (especial == true)
                                {
                                    con.Open();
                                    SqlDataAdapter da = new SqlDataAdapter("spGeneratePruebasEspeciales", con);
                                    DataTable dt = new DataTable();
                                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                                    da.SelectCommand.Parameters.AddWithValue("@reid", cpreid);
                                    da.SelectCommand.Parameters.AddWithValue("@especial", 1);
                                    da.SelectCommand.Parameters.AddWithValue("@paciente", repaciente);
                                    da.SelectCommand.Parameters.AddWithValue("@result", Presult);
                                    da.Fill(dt);
                                    this.radGridView2.DataSource = dt;
                                    con.Close();

                                    EditPlantillaLab();
                                    dt.Rows.Clear();
                                }
                                else if (validapr == false && especial == false)
                                {
                                    EditPlantilla();
                                }                                
                               
                            }
                    }
                        catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message + " Causa:" + ex.InnerException, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;
                }
            }
                
            }
        }
        public void UpdatePDF()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "update tbcontrolpdf set cpgenerate = 1 where cpreid = " + cpreid + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateIntento(string error)
        {
            using (var con = new SqlConnection(conect))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    cmd.CommandText = @"update tbControlPdf set cperror = '" + Regex.Replace(error, @"'", "`") + "', cpIntento = case when cpintento is null then 1 else cpintento + 1 end where cpid = " + cpid + " and cpreID = " + cpreid + "";

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

            }

        }
        public void getQR()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT qrLink from tbQRinfo where qrID = 1";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        QrLink = reader[0].ToString();

                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado link registrado!");
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
        public void getPlantilla()
        {
            using (SqlConnection con = new SqlConnection(conect))
            {


                con.Open();
                using (SqlCommand cm = con.CreateCommand())
                {

                    if (reprueba == "Sars Cov-2")
                    {
                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plid = @id  ";
                        if (reresultado == "Detectado" && reprueba == "Sars Cov-2" && English == false)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 1;
                        }
                        if (reprueba == "Sars Cov-2" && reresultado == "No Detectado" && English == false || reprueba == "Sars Cov-2" && reresultado == "Indeterminado" && English == false)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 2;
                        }
                        if (reprueba == "Sars Cov-2" && English == true)
                        {
                            cm.Parameters.Add("@id", SqlDbType.Int).Value = 6;
                        }
                    }
                    else if (validapr == true && plantillaid > 0 && reprueba != "Cultivo de Orina*")
                    {

                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plid = " + plantillaid + "";

                    }
                    else if (plantillaid == 0 && validapr == true && reprueba != "Cultivo de Orina*" && reprueba != "Colotect")
                    {

                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = 'ALT'";

                    }
                    else if (reprueba == "Colotect")
                    {
                        foreach (GridViewRowInfo rowInfo in radGridView2.Rows)
                        {
                            if (radGridView2.Rows[2].Cells[2].Value.ToString() == "Positivo" || radGridView2.Rows[2].Cells[2].Value.ToString() == "POSITIVO") { cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = 'Colotect pos'"; break; }
                            else if (radGridView2.Rows[2].Cells[2].Value.ToString() == "Negativo" || radGridView2.Rows[2].Cells[2].Value.ToString() == "NEGATIVO") { cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = 'Colotect neg'"; break; }
                        }
                    }
                    else
                    {
                        cm.CommandText = "Select pldoc, plrealname from tbplantilla where plPrueba = '" + reprueba + "'  ";
                    }

                    rd.GetNo();


                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            realname = dr[1].ToString();
                            int size = 1024 * 1024;
                            byte[] buffer = new byte[size];
                            int readBytes = 0;
                            int index = 0;
                            string fileName = Application.StartupPath + @"\\resourses\" + rd.RandomNo + "-" + realname;
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
        }
        public void EditPlantillaLab()
        {
            try
            {
                getPlantilla();
                System.IO.Directory.CreateDirectory(@"C:\SGP");
                docname = repaciente + "-" + rd.RandomNo + ".pdf";
                object ObjMiss = System.Reflection.Missing.Value;
                Word.Application ObjWord = new Word.Application();
                string ruta = Application.StartupPath + @"\\resourses\" + rd.RandomNo + "-" + realname;
                string rutasave = @"C:\SGP\" + docname + "";
                object parametro = ruta;
                object save = rutasave;
                object paciente = "paciente";
                object edad = "edad";
                object fechan = "fechan";
                object ced = "ced";
                object DEPTO = "DEPTO";
                object fechae = "fechae";
                object dire = "dir";
                object fechamu = "fecham";
                object DefaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
                object WdAutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
                Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss, ReadOnly: true);
                Word.Range nom = ObjDoc.Bookmarks.get_Item(ref paciente).Range;
                nom.Text = repaciente;
                Word.Range age = ObjDoc.Bookmarks.get_Item(ref edad).Range;
                age.Text = reedad;
                Word.Range fech = ObjDoc.Bookmarks.get_Item(ref fechan).Range;
                fech.Text = reedad;
                Word.Range cedu = ObjDoc.Bookmarks.get_Item(ref ced).Range;
                cedu.Text = reced;
                Word.Range deptos = ObjDoc.Bookmarks.get_Item(ref DEPTO).Range;
                deptos.Text = "";
                Word.Range fechaem = ObjDoc.Bookmarks.get_Item(ref fechae).Range;
                fechaem.Text = DateTime.Parse(refecha).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + " / " + DateTime.Parse(rehora).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                Word.Range direction = ObjDoc.Bookmarks.get_Item(ref dire).Range;
                direction.Text = redir;
                Word.Range fechamue = ObjDoc.Bookmarks.get_Item(ref fechamu).Range;
                fechamue.Text = DateTime.Parse(refecham).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + " " + DateTime.Parse(rehoram).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                Word.Table table = ObjDoc.Tables[2];
                table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                int i = 3;
                String valmin;
                String valmax;
                String subprueba;
                String unidad;
                String Valref;
                String result;
                
                int num = radGridView2.Rows.Count;
                num = num +1;
                foreach (GridViewRowInfo rowInfo in radGridView2.Rows) 
                    {
                    deptos.Text = radGridView2.Rows[rowInfo.Index].Cells[7].Value.ToString();
                   // int rowcount = radGridView2.Rows.Count;

                    subprueba = radGridView2.Rows[rowInfo.Index].Cells[1].Value.ToString();
                    if (radGridView2.Rows[rowInfo.Index].Cells[2].Value != null)
                    {
                        reresultado = radGridView2.Rows[rowInfo.Index].Cells[2].Value.ToString();
                    }
                    else { reresultado = "-"; }
                    unidad = radGridView2.Rows[rowInfo.Index].Cells[3].Value.ToString();
                    Valref = radGridView2.Rows[rowInfo.Index].Cells[4].Value.ToString();   
                    if (radGridView2.Rows[rowInfo.Index].Cells[5].Value.ToString() != "-" && radGridView2.Rows[rowInfo.Index].Cells[6].Value.ToString() != "-")
                    {
                        valmin = radGridView2.Rows[rowInfo.Index].Cells[5].Value.ToString();
                        valmax = radGridView2.Rows[rowInfo.Index].Cells[6].Value.ToString();
                        decimal value;
                        if (reresultado != "-" && Decimal.TryParse(reresultado, out value) && Double.Parse(reresultado) < Double.Parse(valmin))
                        {
                            result = " ↓ " + reresultado;
                        }
                        else if (reresultado != "-" && Decimal.TryParse(reresultado, out value) && Double.Parse(reresultado) > Double.Parse(valmax))
                        {
                            result = " ↑ " + reresultado;
                        }
                        else
                        {
                            result = reresultado;
                        }
                    }
                    else
                    {
                        result = reresultado;
                    }
                    table.Cell(i, 1).Range.Text = subprueba;
                    table.Cell(i, 2).Range.Text = result;
                    table.Cell(i, 3).Range.Text = unidad;
                    table.Cell(i, 4).Range.Text = Valref;

                    if (i <= num)
                    {
                        i++;
                        table.Rows.Add(ref ObjMiss);
                    }
                }
                object rango1 = nom;
                object rango2 = age;
                object rango3 = fech;
                object rango4 = cedu;
                object rango5 = fechaem;
                object rango6 = direction;
                object rango7 = fechamue;
                object rango8 = deptos;
                ObjDoc.Bookmarks.Add("paciente", ref rango1);
                ObjDoc.Bookmarks.Add("edad", ref rango2);
                ObjDoc.Bookmarks.Add("fechan", ref rango3);
                ObjDoc.Bookmarks.Add("ced", ref rango4);
                ObjDoc.Bookmarks.Add("fechae", ref rango5);
                ObjDoc.Bookmarks.Add("dir", ref rango6);
                ObjDoc.Bookmarks.Add("fecham", ref rango7);
                ObjDoc.Bookmarks.Add("DEPTO", ref rango8);
                ObjWord.Visible = false;
                if (File.Exists(rutasave))
                {
                    File.Delete(rutasave);

                }

                ObjDoc.ExportAsFixedFormat(rutasave, Word.WdExportFormat.wdExportFormatPDF);

                object DoNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;

                ObjDoc.Close(ref DoNotSaveChanges);

                ObjWord.Quit();
                PDFDOC = System.IO.File.ReadAllBytes(rutasave);


                UpdatePDF();
           
                if (Presult == true)
                {
                    UpdateprePlantilla();
                }
                else
                {
                    UpdatePlantilla();
                }
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }
        }
            catch (Exception ex)
            {
                UpdateIntento(ex.Message);
            }
            }
        public void EditPlantilla()
        {
            try
            {

                getQR();

                QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                QrCode qrCode = new QrCode();
                String Value = QrLink + cpreid;
                qrEncoder.TryEncode(Value, out qrCode);
                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.SteelBlue, Brushes.White);
                MemoryStream ms = new MemoryStream();
                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                var imageTemporal = new Bitmap(ms);
                var imagen = new Bitmap(imageTemporal, new Size(new Point(120, 120)));
                imagen.Save("qrimagen-" + Pacid + ".png", ImageFormat.Png);



                getPlantilla();

                System.IO.Directory.CreateDirectory(@"C:\SGP");

                docname = repaciente + "-" + rd.RandomNo + ".pdf";

                object ObjMiss = System.Reflection.Missing.Value;
                Word.Application ObjWord = new Word.Application();
                string ruta = Application.StartupPath + @"\\resourses\" + rd.RandomNo + "-" + realname;
                rutasave = @"C:\SGP\" + docname + "";
                object parametro = ruta;
                object save = rutasave;
                if (reprueba == "Influenza" || reprueba == "Anticuerpo-Covid")
                {
                    object paciente = "paciente";
                    object edad = "edad";
                    object fechan = "fechan";
                    object ced = "ced";
                    object res = "resultado";
                    object res2 = "Resultado2";
                    object ct = "no";
                    object ct2 = "no2";
                    object fechae = "fechae";
                    object dire = "dir";
                    object fechamu = "fecham";
                    Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss, ReadOnly: true);
                    Word.Range nom = ObjDoc.Bookmarks.get_Item(ref paciente).Range;
                    nom.Text = repaciente;
                    Word.Range age = ObjDoc.Bookmarks.get_Item(ref edad).Range;
                    Word.Range fech = ObjDoc.Bookmarks.get_Item(ref fechan).Range;
                    if (DateTime.Parse(refechan).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) == "01-01-1900")
                    {
                        fech.Text = "-";
                        age.Text = "-";
                    }
                    else
                    {
                        age.Text = reedad;
                        fech.Text = DateTime.Parse(refechan).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                    }
                    Word.Range cedu = ObjDoc.Bookmarks.get_Item(ref ced).Range;
                    cedu.Text = reced;
                    Word.Range resu = ObjDoc.Bookmarks.get_Item(ref res).Range;
                    resu.Text = reresultado;
                    Word.Range cts = ObjDoc.Bookmarks.get_Item(ref ct).Range;
                    cts.Text = rect;
                    Word.Range resu2 = ObjDoc.Bookmarks.get_Item(ref res2).Range;
                    resu2.Text = reresultado2;
                    Word.Range cts2 = ObjDoc.Bookmarks.get_Item(ref ct2).Range;
                    cts2.Text = rect2;
                    Word.Range fechaem = ObjDoc.Bookmarks.get_Item(ref fechae).Range;
                    if (rehora != "")
                    {
                        fechaem.Text = DateTime.Parse(refecha).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + " / " + DateTime.Parse(rehora).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        fechaem.Text = refecha;
                    }
                    Word.Range direction = ObjDoc.Bookmarks.get_Item(ref dire).Range;
                    direction.Text = redir;
                    Word.Range fechamue = ObjDoc.Bookmarks.get_Item(ref fechamu).Range;
                    if (refecham == "-")
                    {
                        fechamue.Text = refecham;
                    }
                    else if (refecham != "-" && rehoram != "")
                    {
                        fechamue.Text = DateTime.Parse(refecham).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + " " + DateTime.Parse(rehoram).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        fechamue.Text = DateTime.Parse(refecham).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                    }
                    object rango1 = nom;
                    object rango2 = age;
                    object rango3 = fech;
                    object rango4 = cedu;
                    object rango5 = resu;
                    object rango6 = cts;
                    object rango7 = resu2;
                    object rango8 = cts2;
                    object rango9 = fechaem;
                    object rango10 = direction;
                    object rango11 = fechamue;
                    ObjDoc.Bookmarks.Add("paciente", ref rango1);
                    ObjDoc.Bookmarks.Add("edad", ref rango2);
                    ObjDoc.Bookmarks.Add("fechan", ref rango3);
                    ObjDoc.Bookmarks.Add("ced", ref rango4);
                    ObjDoc.Bookmarks.Add("resultado", ref rango5);
                    ObjDoc.Bookmarks.Add("no", ref rango6);
                    ObjDoc.Bookmarks.Add("Resultado2", ref rango7);
                    ObjDoc.Bookmarks.Add("no2", ref rango8);
                    ObjDoc.Bookmarks.Add("fechae", ref rango9);
                    ObjDoc.Bookmarks.Add("dir", ref rango10);
                    ObjDoc.Bookmarks.Add("fecham", ref rango11);
                    var shape = ObjDoc.Bookmarks["image"].Range.InlineShapes.AddPicture(Application.StartupPath + @"\\qrimagen-" + Pacid + ".png", false, true);
                    ObjWord.Visible = false;



                    if (File.Exists(rutasave))
                    {
                        File.Delete(rutasave);
                    }
                    ObjDoc.ExportAsFixedFormat(rutasave, Word.WdExportFormat.wdExportFormatPDF);
                    object DoNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                    ObjDoc.Close(ref DoNotSaveChanges);
                    ObjWord.Quit();
                    PDFDOC = System.IO.File.ReadAllBytes(rutasave);
                }
                if (reprueba == "Sars Cov-2" || reprueba == "Antigeno")
                {
                    object paciente = "paciente";
                    object edad = "edad";
                    object fechan = "fechan";
                    object ced = "ced";
                    object res = "resultado";
                    object ct = "no";
                    object fechae = "fechae";
                    object dire = "dir";
                    object fechamu = "fecham";
                    Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss);
                    Word.Range nom = ObjDoc.Bookmarks.get_Item(ref paciente).Range;
                    nom.Text = repaciente;
                    Word.Range age = ObjDoc.Bookmarks.get_Item(ref edad).Range;

                    Word.Range fech = ObjDoc.Bookmarks.get_Item(ref fechan).Range;
                    if (DateTime.Parse(refechan).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) == "01-01-1900")
                    {
                        fech.Text = "-";
                        age.Text = "-";
                    }
                    else
                    {
                        age.Text = reedad;
                        fech.Text = DateTime.Parse(refechan).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                    }
                    Word.Range cedu = ObjDoc.Bookmarks.get_Item(ref ced).Range;
                    cedu.Text = reced;
                    Word.Range resu = ObjDoc.Bookmarks.get_Item(ref res).Range;
                    if (English == true)
                    {
                        if (reresultado == "Detectado")
                        {
                            resu.Text = "Detected";
                        }
                        if (reresultado == "No Detectado")
                        {
                            resu.Text = "Not Detected";
                        }
                        if (reresultado == "Indeterminado")
                        {
                            resu.Text = "Undetermined";
                        }
                        if (reresultado == "Positivo")
                        {
                            resu.Text = "Positive";
                        }
                        if (reresultado == "Negativo")
                        {
                            resu.Text = "Negative";
                        }
                    }

                    else
                    {
                        resu.Text = reresultado;
                    }
                    Word.Range cts = ObjDoc.Bookmarks.get_Item(ref ct).Range;
                    cts.Text = rect;
                    Word.Range fechaem = ObjDoc.Bookmarks.get_Item(ref fechae).Range;
                    if (rehora != "")
                    {
                        fechaem.Text = DateTime.Parse(refecha).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + " / " + DateTime.Parse(rehora).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        fechaem.Text = refecha;
                    }
                    Word.Range direction = ObjDoc.Bookmarks.get_Item(ref dire).Range;
                    direction.Text = redir;
                    Word.Range fechamue = ObjDoc.Bookmarks.get_Item(ref fechamu).Range;
                    if (refecham == "-")
                    {
                        fechamue.Text = refecham;
                    }
                    else if (refecham != "-" && rehoram != "")
                    {
                        fechamue.Text = DateTime.Parse(refecham).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + " " + DateTime.Parse(rehoram).ToString("hh:mm tt", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        fechamue.Text = DateTime.Parse(refecham).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                    }

                    object rango1 = nom;
                    object rango2 = age;
                    object rango3 = fech;
                    object rango4 = cedu;
                    object rango5 = resu;
                    object rango6 = cts;
                    object rango7 = fechaem;
                    object rango8 = direction;
                    object rango9 = fechamue;
                    ObjDoc.Bookmarks.Add("paciente", ref rango1);
                    ObjDoc.Bookmarks.Add("edad", ref rango2);
                    ObjDoc.Bookmarks.Add("fechan", ref rango3);
                    ObjDoc.Bookmarks.Add("ced", ref rango4);
                    ObjDoc.Bookmarks.Add("resultado", ref rango5);
                    ObjDoc.Bookmarks.Add("no", ref rango6);
                    ObjDoc.Bookmarks.Add("fechae", ref rango7);
                    ObjDoc.Bookmarks.Add("dir", ref rango8);
                    ObjDoc.Bookmarks.Add("fecham", ref rango9);
                    var shape = ObjDoc.Bookmarks["image"].Range.InlineShapes.AddPicture(Application.StartupPath + @"\\qrimagen-" + Pacid + ".png", false, true);
                    File.Delete(Application.StartupPath + @"\\qrimagen-" + Pacid + ".png");
                    ObjWord.Visible = false;

                    if (File.Exists(rutasave))
                    {
                        File.Delete(rutasave);

                    }

                    ObjDoc.ExportAsFixedFormat(rutasave, Word.WdExportFormat.wdExportFormatPDF);

                    object DoNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;

                    ObjDoc.Close(ref DoNotSaveChanges);

                    ObjWord.Quit();
                    PDFDOC = System.IO.File.ReadAllBytes(rutasave);
                   
                }
                UpdatePDF();
                UpdatePlantilla();
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                }

            }          
            catch (Exception ex)
            {
                UpdateIntento(ex.Message);                               
            }
        }
        public void UpdateprePlantilla()
        {
            using (var con = new SqlConnection(conect))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    cmd.CommandText = @"update tbpreresultados set reDocPDF = @DOC where reID = " + cpreid + "";
                    cmd.Parameters.AddWithValue("@DOC", SqlDbType.VarBinary).Value = PDFDOC;
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

            }

        }
        public void UpdatePlantilla()
        {
            using (var con = new SqlConnection(conect))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    cmd.CommandText = @"update tbresultados set reDocPDF = @DOC where reID = " + cpreid + "";
                    cmd.Parameters.AddWithValue("@DOC", SqlDbType.VarBinary).Value = PDFDOC;
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

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resulta = MessageBox.Show("Seguro desea cerrar la aplicacion?", "Cerrar Aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    Abort = true;

                    btnStartStop.Text = "Iniciar";
                    Statuslabel("Proceso Dentenido", Color.DarkSlateGray);
                    btnStartStop.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"\\resourses\start.png");
                    btnStartStop.ImageAlignment = ContentAlignment.TopCenter;
                    Application.Exit();
                }
                else if (resulta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
