using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class frmPlantilla : Form
    {
        public frmPlantilla()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        String cambiada1;
        int PlantillaID;
        bool Modify = false;
        private void frmPlantilla_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cargacbbPruebas();
            GetData();
        }
        public void GetData()
        {

            using (var con = new SqlConnection(conect))
            {
                try
                {
                    int Rows;
                    Rows = dataGridView1.RowCount - 1;
                    con.Open();
                    cmd = new SqlCommand("select  plID as [ID de Plantilla], plPrueba as [Prueba], plrealname as [Plantilla] from tbPlantilla", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                    dataGridView1.RowHeadersVisible = false;
                    myDA.Fill(myDataSet, "Usuario");
                    dataGridView1.DataSource = myDataSet.Tables["Usuario"].DefaultView;
                    dataGridView1.Columns["ID de Plantilla"].Visible = false;
                    dataGridView1.Columns["Prueba"].DisplayIndex = 0;
                    dataGridView1.Columns["Plantilla"].DisplayIndex = 1;
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
            }
        public void cargacbbPruebas()
        {
            using (var con = new SqlConnection(conect))
            {
                try { 
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (prNombre) as Pruebas from tbPruebas order by prNombre", con);

                da.Fill(ds, "Pruebas");
                cbbPrueba.DataSource = ds.Tables[0].DefaultView;
                cbbPrueba.ValueMember = "Pruebas";
                cbbPrueba.Text = "Seleccione la Prueba";


                con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }
        public void cargarcbbPlantillas()
        {
            using (var con = new SqlConnection(conect))
            {
                try { 
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (prNombre) as Pruebas from tbPruebas order by prNombre", con);

                da.Fill(ds, "Pruebas");
                cbbPrueba.DataSource = ds.Tables[0].DefaultView;
                cbbPrueba.ValueMember = "Pruebas";
                cbbPrueba.Text = "Seleccione la Prueba";


                con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }
        private void btnDialog_Click(object sender, EventArgs e)
        {
            oFD1.InitialDirectory = "c:\\";
            oFD1.Filter = "Word Documents|*.docx";
            oFD1.FilterIndex = 1;
            oFD1.RestoreDirectory = true;

            if (oFD1.ShowDialog() == DialogResult.OK)
            {
                txtPlantilla.Text = oFD1.FileName;
                btnSavep.Enabled = true;
            }
        }

       

        private void btnSavep_Click(object sender, EventArgs e)
        {
            
                byte[] file = null;
                Stream myStream = oFD1.OpenFile();
                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);
                    file = ms.ToArray();
                }
                byte[] realname = file;
                string oDocument = oFD1.SafeFileName;

               
                    conviertefecha();

            if (Modify == true)
            {
                DialogResult resulta = MessageBox.Show("Seguro quiere actualizar la plantilla de resultado?", "Actualizar Plantilla?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    using (var con = new SqlConnection(conect))
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        try { 
                        cmd.CommandText = @"update tbplantilla set plrealname = @realname, pldoc = @doc, plFecha = @fecha where plid = " + PlantillaID + "";

                        cmd.Parameters.AddWithValue("@realname", oDocument);
                        cmd.Parameters.AddWithValue("doc", realname);
                        cmd.Parameters.AddWithValue("fecha", cambiada1);
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();
                        string[] files = Directory.GetFiles(@"C:\SGP\");

                        foreach (string fileh in files)
                        {
                            FileInfo fi = new FileInfo(fileh);
                            if (fi.LastWriteTime < DateTime.Now.AddDays(1))
                                fi.Delete();
                        }
                        GetData();
                        btnSavep.Enabled = false;
                        cbbPrueba.Text = "Seleccione la Prueba";
                        txtPlantilla.Text = "";
                        Modify = false;
                        Logs log = new Logs();
                        log.Accion = "Plantilla: " + cbbPrueba + " Actualizada";
                        log.Form = "Configuracion de Plantilla";
                        log.SaveLog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                        }
                    }

                }
            }

            else
            {
                DialogResult resulta = MessageBox.Show("Seguro quiere agregar la plantilla de resultado?", "Agregar Plantilla?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    using (var con = new SqlConnection(conect))
                    {
                        try { 
                        string Sql = "insert into tbPlantilla(plrealname, plDoc, plFecha, plPrueba) values (@realname, @doc, @fecha, @Prueba)";
                        cmd = new SqlCommand(Sql, con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("realname", oDocument);
                        cmd.Parameters.AddWithValue("doc", realname);
                        cmd.Parameters.AddWithValue("fecha", cambiada1);
                        cmd.Parameters.AddWithValue("Prueba", cbbPrueba.Text);

                        con.Open();
                       
                            int i = cmd.ExecuteNonQuery();
                            MessageBox.Show("Prueba Creada Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                        }
                        finally
                        {
                            btnSavep.Enabled = false;
                            Logs log = new Logs();
                            log.Accion = "Plantilla: " + cbbPrueba + " Agregada";
                            log.Form = "Configuracion de Plantilla";
                            log.SaveLog();
                            Modify = false;
                            GetData();
                        }
                    }
                }
            }        
        }
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1 = DateTime.Now;




                string day2 = fecha1.Day.ToString();
                string mes2 = fecha1.Month.ToString();
                string year2 = fecha1.Year.ToString();

                cambiada1 = year2 + "-" + mes2 + "-" + day2;


            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }

        private void cbbPlantilla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbPlantilla_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = true;
        }

        private void cbbPrueba_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        string fileName;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Consult")
                {
                    PlantillaID = (int)this.dataGridView1.Rows[e.RowIndex].Cells["ID de Plantilla"].Value;
                    txtPlantilla.Text = (string)this.dataGridView1.Rows[e.RowIndex].Cells["Plantilla"].Value;
                    cbbPrueba.Text = (string)this.dataGridView1.Rows[e.RowIndex].Cells["Prueba"].Value;

                    using (SqlConnection con = new SqlConnection(conect))
                    {
                        try { 
                        con.Open();
                        using (SqlCommand cm = con.CreateCommand())
                        {
                             fileName = Application.StartupPath + @"\\resourses\" + txtPlantilla.Text;
                            cm.CommandText = "Select pldoc, plrealname from tbplantilla where plid = "+PlantillaID+"  ";

                            using (SqlDataReader dr = cm.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    string realname = dr[1].ToString();
                                    int size = 1024 * 1024;
                                    byte[] buffer = new byte[size];
                                    int readBytes = 0;
                                    int index = 0;
                                    fileName = Application.StartupPath + @"\\resourses\" + realname;
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
                            btnOpen.Enabled = true;
                            Modify = true;
                            con.Close();
                        }
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
        private void btnOpen_Click(object sender, EventArgs e)
        {           
                    Process prc = new Process();
                    prc.StartInfo.FileName = fileName;
                    prc.Start();               
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "Consult" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridView1.Rows[e.RowIndex].Cells["Consult"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\resourses\search.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dataGridView1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dataGridView1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }
        }
    }
}
