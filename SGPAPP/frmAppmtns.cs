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
using System.Collections;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace SGPAPP
{
    public partial class frmAppmtns : Form
    {

        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        DateTime Fecha = DateTime.Now;
        DateTime FechaSelected;
        string cambiada1;
        string cambiada2;
        DataTable dt = new DataTable();
        public String CitaID;

        public frmAppmtns()
        {
            InitializeComponent();
        }
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;


                fecha1 = Convert.ToDateTime(FechaActual.Text);

                String day = fecha1.Day.ToString();
                String mes = fecha1.Month.ToString();
                String year = fecha1.Year.ToString();

                cambiada1 = year + "-" + mes + "-" + day;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }

        public void GetData()
        {
            
                using (var con = new SqlConnection(conect))
                {
                try
                {
                    dgb1.ColumnHeadersDefaultCellStyle.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold);
                    conviertefecha();
                    //con = new SqlConnection(cs.ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("select CONVERT(varchar(15),CAST(chora AS TIME),100) as [Hora de Cita], RTRIM(pNom) as [Paciente], RTRIM(pComment) as [Comentario], RTRIM(cEstatus) as [Estado de Cita], RTRIM(cId) as [Id de Cita] , RTRIM(cFecha) as [Fecha] from tbCitas where cFecha = '" + cambiada1 + "' and cTipo = 'Presencial' order by cHora", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "Hora de Cita");
                    dgb1.DataSource = myDataSet.Tables["Hora de Cita"].DefaultView;
                    dgb1.Columns["Hora de Cita"].DisplayIndex = 0;
                    dgb1.Columns["Paciente"].DisplayIndex = 1;
                    dgb1.Columns["Comentario"].DisplayIndex = 2;
                    dgb1.Columns["Estado de Cita"].DisplayIndex = 3;
                    dgb1.Columns["Hora de Cita"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgb1.Columns["Paciente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgb1.Columns["Comentario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgb1.Columns["Estado de Cita"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgb1.Columns[5].Visible = false;
                    dgb1.Columns[6].Visible = false;
                    foreach (DataGridViewColumn c in dgb1.Columns)
                    {
                        c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        c.DefaultCellStyle.Font = new Font("Yu Gothic UI Semibold,", 16F, GraphicsUnit.Pixel);

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
          
        public void Fechas()
        {           
            FechaActual.Text = Fecha.ToString("dddd d, MMMMM, yyyy");
            FechaSiguiente.Text = DateTime.Parse(FechaActual.Text).AddDays(1).ToString("dddd d, MMMMM, yyyy");
            FechaAnterior.Text = DateTime.Parse(FechaActual.Text).AddDays(-1).ToString("dddd d, MMMMM, yyyy");
        }
        public void UpdateCitas()
        {

            using (var con = new SqlConnection(conect))
            {
                try
                {
                    cambiaFecha();
                string sqls = "update tbcitas set cEstatus= 'Vencida' where cEstatus = 'Programada' and cFecha < '" + cambiada2 + "'";
                SqlCommand cmds = new SqlCommand(sqls, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
              
                    int i = cmds.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void frmAppmtns_Load(object sender, EventArgs e)
        {
            this.dgb1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            Fechas();
            GetData();
            UpdateCitas();
            //ArrayList row = new ArrayList();
            //DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            //combo.HeaderText = "Estado de Cita";
            //combo.Name = "combo";
            //row = new ArrayList();
            //row.Add("Programada");
            //row.Add("Cancelada");
            //row.Add("Completada");
            //row.Add("No Completada");
            //combo.Items.AddRange(row.ToArray());
            //dgb1.Columns.Add(combo);
            //dgb1.Columns["combo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
        }

        private void FechaSiguiente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Fecha = Fecha.AddDays(1);
            Fechas();
            GetData();
        }

        private void FechaAnterior_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Fecha = Fecha.AddDays(-1);
            Fechas();
            GetData();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            btnNewDate.Enabled = true;
        }

        private void btnNewDate_Click(object sender, EventArgs e)
        {
            Fecha = DateTime.Now;
            FechaSelected = monthCalendar1.SelectionEnd;
            if (FechaSelected >= Fecha)
            {
                if (FechaSelected.DayOfWeek == DayOfWeek.Sunday)
                {
                    DialogResult resulta = MessageBox.Show("Esta seguro que desea programar una cita un domingo?", "Programar Citas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(resulta == DialogResult.Yes)
                    {
                        frmDates Date = new frmDates();
                        Date.FechaActual.Text = FechaSelected.ToString("dddd d, MMMM, yyyy");
                        if (Date.ShowDialog() == DialogResult.OK)
                        {
                            GetData();
                        }
                    }
                    

                }
                else
                {
                    frmDates Date = new frmDates();
                    Date.FechaActual.Text = FechaSelected.ToString("dddd d, MMMM, yyyy");
                    if (Date.ShowDialog() == DialogResult.OK)
                    {
                        Fechas();
                        GetData();
                        
                    }
                }


            }
            else
            {
                MessageBox.Show("La fecha seleccionada no es valida, debe elegir una fecha mayor a la actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void FechaActual_Click(object sender, EventArgs e)
        {

        }

        private void FechaActual_DoubleClick(object sender, EventArgs e)
        {
            dtp1.Visible = true;
            dtp1.Value = Convert.ToDateTime(FechaActual.Text);
            tableLayoutPanel2.Visible = false;
            FechaSiguiente.Enabled = false;
            FechaAnterior.Enabled = false;
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            
          
        }

        private void dtp1_CloseUp(object sender, EventArgs e)
        {
            Fecha = dtp1.Value;
            Fechas();
            GetData();

            dtp1.Visible = false;
            tableLayoutPanel2.Visible = true;
            FechaSiguiente.Enabled = true;
            FechaAnterior.Enabled = true;
        }

        private void frmAppmtns_DoubleClick(object sender, EventArgs e)
        {
            if (dtp1.Visible == true)
            {
                dtp1.Visible = false;
                tableLayoutPanel2.Visible = true;
                FechaSiguiente.Enabled = true;
                FechaAnterior.Enabled = true;
            }
        }

        private void dgb1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgb1.Columns[e.ColumnIndex].Name == "Editar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dgb1.Rows[e.RowIndex].Cells["Editar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\resourses\calendar.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 8, e.CellBounds.Top + 3);              
                this.dgb1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dgb1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 20;

                e.Handled = true;
            }

 
            }

        private void dgb1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (this.dgb1.Columns[e.ColumnIndex].Name == "Editar")
                {
                    cambiaFecha();
                    if (this.dgb1.Rows[e.RowIndex].Cells["Estado de Cita"].Value.ToString() == "Vencida")
                    {
                        MessageBox.Show("Esta cita no puede ser modificada debido a que ya esta Vencida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (this.dgb1.Rows[e.RowIndex].Cells["Estado de Cita"].Value.ToString() == "Cancelada")
                    {
                        MessageBox.Show("Esta cita no puede ser modificada debido a que ya fue cancelada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (this.dgb1.Rows[e.RowIndex].Cells["Estado de Cita"].Value.ToString() == "Completada")
                    {
                        MessageBox.Show("Esta cita no puede ser modificada debido a que ya fue completada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (this.dgb1.Rows[e.RowIndex].Cells["Estado de Cita"].Value.ToString() == "Programada" || this.dgb1.Rows[e.RowIndex].Cells["Estado de Cita"].Value.ToString() == "Pendiente de Aprobacion")
                    {
                        CitaID = (string)this.dgb1.Rows[e.RowIndex].Cells["Id de Cita"].Value;

                        frmEditDates edate = new frmEditDates();
                        edate.DatesID = CitaID;
                        edate.ShowDialog();

                        if (edate.DialogResult == DialogResult.OK)
                        {

                            GetData();
                        }
                    }
                }
            }
        }
        public void cambiaFecha()
        {
            try
            {
                DateTime fecha1;

                Fecha = DateTime.Now;
                fecha1 = Fecha.AddDays(-1);

                String day = fecha1.Day.ToString();
                String mes = fecha1.Month.ToString();
                String year = fecha1.Year.ToString();

                cambiada2 = year + "-" + mes + "-" + day;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frmConsultaC rptcita = new frmConsultaC();
            rptcita.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDomi_Click(object sender, EventArgs e)
        {
            frmCitasd cd = new frmCitasd();
            cd.ShowDialog();
        }
    }
}
//que sea por fecha!