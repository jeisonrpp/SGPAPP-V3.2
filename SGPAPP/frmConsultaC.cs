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
using System.Diagnostics;
using System.IO;

namespace SGPAPP
{
    public partial class frmConsultaC : Form
    {
        public frmConsultaC()
        {
            InitializeComponent();
        }


        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();       
        SqlCommand cmd = null;
        string cambiada1;
        string cambiada2;
        String ID;
        public void GetData()
        {
           
                using (var con = new SqlConnection(conect))
                {
                try
                { 
                    int Rows;
                    Rows = dataGridView1.RowCount - 1;
                    //con = new SqlConnection(cs.ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("SELECT RTRIM(cId) as [ID], RTRIM(pNom) as [Paciente], RTRIM(cFecha) as [Fecha de Cita], CONVERT(varchar(15),CAST(chora AS TIME),100) as [Hora], RTRIM(ctipo) as [Tipo de Cita], RTRIM(pComment) as [Comentario], RTRIM(cEstatus) as [Estado] from tbCitas", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "Paciente");
                    dataGridView1.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["Paciente"].DisplayIndex = 0;
                    dataGridView1.Columns["Fecha de Cita"].DisplayIndex = 1;
                    dataGridView1.Columns["Hora"].DisplayIndex = 2;
                    dataGridView1.Columns["Tipo de Cita"].DisplayIndex = 3;
                    dataGridView1.Columns["Comentario"].DisplayIndex = 4;
                    dataGridView1.Columns["Estado"].DisplayIndex = 5;
                    dataGridView1.SelectedCells[0].Style = new DataGridViewCellStyle { ForeColor = Color.Black };

                    con.Close();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }

        private void frmConsultaC_Load(object sender, EventArgs e)
        {

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;          
            GetData();
        }

        private void btnExporta_Click(object sender, EventArgs e)
        {
            ExportaExcl(dataGridView1);
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
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;
                DateTime fecha2;

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
           using (var con = new SqlConnection(conect))
                {
                try { 
                    conviertefecha();
                    int Rows;
                    Rows = dataGridView1.RowCount - 1;
                    con.Open();
                    cmd = new SqlCommand("SELECT  RTRIM(cId) as [ID], RTRIM(pNom) as [Paciente], RTRIM(cFecha) as [Fecha de Cita], CONVERT(varchar(15),CAST(chora AS TIME),100) as [Hora], RTRIM(ctipo) as [Tipo de Cita], RTRIM(pComment) as [Comentario], RTRIM(cEstatus) as [Estado] from tbCitas where cfecha between '" + cambiada1 + "' and  '" + cambiada2 + "'", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "Paciente");
                    dataGridView1.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["Paciente"].DisplayIndex = 0;
                    dataGridView1.Columns["Fecha de Cita"].DisplayIndex = 1;
                    dataGridView1.Columns["Hora"].DisplayIndex = 2;
                    dataGridView1.Columns["Tipo de Cita"].DisplayIndex = 3;
                    dataGridView1.Columns["Comentario"].DisplayIndex = 4;
                    dataGridView1.Columns["Estado"].DisplayIndex = 5;
                    dataGridView1.SelectedCells[0].Style = new DataGridViewCellStyle { ForeColor = Color.Black };
                    con.Close();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }


            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "Seg" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridView1.Rows[e.RowIndex].Cells["Seg"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\resourses\search.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 6, e.CellBounds.Top + 6);

                this.dataGridView1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dataGridView1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 20;
                this.dataGridView1.Columns[e.ColumnIndex].DisplayIndex = 7;
                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "Indic" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridView1.Rows[e.RowIndex].Cells["Indic"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\resourses\search.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 6, e.CellBounds.Top + 6);

                this.dataGridView1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dataGridView1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 20;
                this.dataGridView1.Columns[e.ColumnIndex].DisplayIndex = 8;
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Seg")
                {
                    ID = (string)this.dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
                    using (SqlConnection con = new SqlConnection(conect))
                    {
                        try
                        {
                            con.Open();
                            using (SqlCommand cm = con.CreateCommand())
                            {

                                ID = (string)this.dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
                                cm.CommandText = "Select cSegname, cSeguro from tbCitas where cId = @id  ";
                                cm.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                                using (SqlDataReader dr = cm.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        string realname = dr[0].ToString();
                                        if (realname.Length >= 1)
                                        {
                                            int size = 1024 * 1024;
                                            byte[] buffer = new byte[size];
                                            int readBytes = 0;
                                            int index = 0;
                                            string fileName = Application.StartupPath + @"\\resourses\" + realname;

                                            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                                            {
                                                while ((readBytes = (int)dr.GetBytes(1, index, buffer, 0, size)) > 0)
                                                {
                                                    fs.Write(buffer, 0, readBytes);
                                                    index += readBytes;
                                                }
                                            }
                                            Process prc = new Process();
                                            prc.StartInfo.FileName = fileName;
                                            prc.Start();
                                            con.Close();
                                        }

                                    }

                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                        }
                    }
                }
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Indic")
                {
                    ID = (string)this.dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
                    using (SqlConnection con = new SqlConnection(conect))
                    {
                        try
                        {
                            con.Open();
                            using (SqlCommand cm = con.CreateCommand())
                            {

                                ID = (string)this.dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
                                cm.CommandText = "Select cindicname, cIndic from tbCitas where cId = @id  ";
                                cm.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                                using (SqlDataReader dr = cm.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        string realname = dr[0].ToString();
                                        if (realname.Length >= 1)
                                        {
                                            int size = 1024 * 1024;
                                            byte[] buffer = new byte[size];
                                            int readBytes = 0;
                                            int index = 0;
                                            string fileName = Application.StartupPath + @"\\resourses\" + realname;

                                            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                                            {
                                                while ((readBytes = (int)dr.GetBytes(1, index, buffer, 0, size)) > 0)
                                                {
                                                    fs.Write(buffer, 0, readBytes);
                                                    index += readBytes;
                                                }
                                            }
                                            Process prc = new Process();
                                            prc.StartInfo.FileName = fileName;
                                            prc.Start();
                                            con.Close();
                                        }

                                    }

                                }

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

        private void dataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
         
        }

        private void dataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
         
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void advancedDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Seg")
                {
                    ID = (string)this.dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
                    using (SqlConnection con = new SqlConnection(conect))
                    {
                        try
                        {
                            con.Open();
                            using (SqlCommand cm = con.CreateCommand())
                            {

                                ID = (string)this.dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
                                cm.CommandText = "Select cSegname, cSeguro from tbCitas where cId = @id  ";
                                cm.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                                using (SqlDataReader dr = cm.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        string realname = dr[0].ToString();
                                        if (realname.Length >= 1)
                                        {
                                            int size = 1024 * 1024;
                                            byte[] buffer = new byte[size];
                                            int readBytes = 0;
                                            int index = 0;
                                            string fileName = Application.StartupPath + @"\\resourses\" + realname;

                                            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                                            {
                                                while ((readBytes = (int)dr.GetBytes(1, index, buffer, 0, size)) > 0)
                                                {
                                                    fs.Write(buffer, 0, readBytes);
                                                    index += readBytes;
                                                }
                                            }
                                            Process prc = new Process();
                                            prc.StartInfo.FileName = fileName;
                                            prc.Start();
                                            con.Close();
                                        }

                                    }

                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                        }
                    }
                }
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Indic")
                {
                    ID = (string)this.dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
                    using (SqlConnection con = new SqlConnection(conect))
                    {
                        try
                        {
                            con.Open();
                            using (SqlCommand cm = con.CreateCommand())
                            {

                                ID = (string)this.dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
                                cm.CommandText = "Select cindicname, cIndic from tbCitas where cId = @id  ";
                                cm.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                                using (SqlDataReader dr = cm.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        string realname = dr[0].ToString();
                                        if (realname.Length >= 1)
                                        {
                                            int size = 1024 * 1024;
                                            byte[] buffer = new byte[size];
                                            int readBytes = 0;
                                            int index = 0;
                                            string fileName = Application.StartupPath + @"\\resourses\" + realname;

                                            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                                            {
                                                while ((readBytes = (int)dr.GetBytes(1, index, buffer, 0, size)) > 0)
                                                {
                                                    fs.Write(buffer, 0, readBytes);
                                                    index += readBytes;
                                                }
                                            }
                                            Process prc = new Process();
                                            prc.StartInfo.FileName = fileName;
                                            prc.Start();
                                            con.Close();
                                        }

                                    }

                                }

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

        private void dataGridView1_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "Seg" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridView1.Rows[e.RowIndex].Cells["Seg"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\resourses\search.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 6, e.CellBounds.Top + 6);

                this.dataGridView1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dataGridView1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 20;
                this.dataGridView1.Columns[e.ColumnIndex].DisplayIndex = 7;
                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "Indic" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridView1.Rows[e.RowIndex].Cells["Indic"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\resourses\search.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 6, e.CellBounds.Top + 6);

                this.dataGridView1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dataGridView1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 20;
                this.dataGridView1.Columns[e.ColumnIndex].DisplayIndex = 8;
                e.Handled = true;
            }
        }

        private void txtConsulta_KeyUp(object sender, KeyEventArgs e)
        {

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
                    
                        using (var con = new SqlConnection(conect))
                        {
                            try
                            {
                                int Rows;
                                Rows = dataGridView1.RowCount - 1;
                                //con = new SqlConnection(cs.ConnectionString);
                                con.Open();
                                cmd = new SqlCommand("SELECT  RTRIM(cId) as [ID], RTRIM(pNom) as [Paciente], RTRIM(cFecha) as [Fecha de Cita], CONVERT(varchar(15),CAST(chora AS TIME),100) as [Hora], RTRIM(ctipo) as [Tipo de Cita], RTRIM(pComment) as [Comentario], RTRIM(cEstatus) as [Estado] from tbCitas where pnom like '%" + txtConsulta.Text + "%'", con);
                                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                                DataSet myDataSet = new DataSet();
                                myDA.Fill(myDataSet, "Paciente");
                                dataGridView1.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                                dataGridView1.Columns["ID"].Visible = false;
                                dataGridView1.Columns["Paciente"].DisplayIndex = 0;
                                dataGridView1.Columns["Fecha de Cita"].DisplayIndex = 1;
                                dataGridView1.Columns["Hora"].DisplayIndex = 2;
                                dataGridView1.Columns["Tipo de Cita"].DisplayIndex = 3;
                                dataGridView1.Columns["Comentario"].DisplayIndex = 4;
                                dataGridView1.Columns["Estado"].DisplayIndex = 5;
                                dataGridView1.SelectedCells[0].Style = new DataGridViewCellStyle { ForeColor = Color.Black };
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
    }
}
