using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmPrMax : Form
    {
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        String ID;
        String Pac;
        String Ced;
        String Fechan;
        public String Tipop;
        public String Prueba;
        public String Metodo;
        public String Time;
        string cambiada1;
        bool results = false;

        bool existe = false;
        public frmPrMax()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                }

        public void GetData()
        {
            try
            {
                
                    using (var con = new SqlConnection(conect))
                    {

                    SqlDataAdapter da = new SqlDataAdapter("spgetPacientes", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@Fechadesde", "prmax");
                    da.SelectCommand.Parameters.AddWithValue("@fechahasta", DBNull.Value);
                    da.Fill(dt);
                    this.radGridView5.DataSource = dt;
                    this.radGridView5.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    con.Close();
                    }

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmPrMax_Load(object sender, EventArgs e)
        {
            GetData();
            this.radGridView5.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }
       
    

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        public void getResultados()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spValidaPruebasParaAsignar";
                    SqlDataReader reader;
                    cmd.Parameters.Add("@pid", SqlDbType.Int).Value = ID;
                    cmd.Parameters.Add("@prueba", SqlDbType.VarChar).Value = Prueba;
                    cmd.Parameters.Add("@tipop", SqlDbType.VarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("@paso", SqlDbType.VarChar).Value = 2;


                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("El paciente "+Pac + ", ya tiene una prueba de este tipo reportada el dia de hoy, esta prueba no se le puede asignar nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        results = true;
                    }
                    else
                    {
                        results = false;
                    }

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

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            
        }

        private void dataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
          
          
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;


                fecha1 = DateTime.Now;

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

        private void btnSav_Click(object sender, EventArgs e)
        {
            
        }
        public void SaveLog()
        {
            Logs log = new Logs();
            log.Accion = "Prueba asignada al Paciente: " + Pac+ "";
            log.Form = "Asignacion Masiva de Pruebas";
            log.SaveLog();
        
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "")
            {
                txtConsulta.Text = "Digite nombre o cedula";
                txtConsulta.ForeColor = Color.Silver;
                GetData();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "Digite nombre o cedula")
            {
                txtConsulta.Text = "";
                txtConsulta.ForeColor = Color.MidnightBlue;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                                  
        
    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
            
        }

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (var item in radGridView5.SelectedRows)
            {
                ID = item.Cells["ID"].Value.ToString();
                Pac = item.Cells["Paciente"].Value.ToString();
                Ced = item.Cells["Cedula"].Value.ToString();
                Fechan = item.Cells["Fecha Nacimiento"].Value.ToString();
            }
            if (ID != null)
            {
                if (radGridView1.RowCount >= 1)
                {
                    for (int i = 0; i < radGridView1.RowCount; i++)
                    {
                        if (Convert.ToString(radGridView1.Rows[i].Cells["ID"].Value) == ID)

                        {
                            MessageBox.Show("Este Paciente ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            existe = true;
                            break;
                        }
                        else

                        {
                            existe = false;
                        }
                    }
                }

                if (existe == false)
                {
                    radGridView1.Rows.Add(ID, Pac, Ced, Fechan);
                    //int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    //dataGridView1.Rows.RemoveAt(rowIndex);
                }

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (radGridView1.RowCount >= 1)
            {
                int rowIndex = radGridView1.CurrentCell.RowIndex;
                radGridView1.Rows.RemoveAt(rowIndex);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount >= 1)
            {
                using (var con = new SqlConnection(conect))
                {
                    DateTime Fecha = DateTime.Now;

                   
                    con.Open();
                    try
                    {
                        conviertefecha();
                        foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
                        {
                            ID = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[0].Value);
                            Pac = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[1].Value);

                            getResultados();
                            if (results == false)
                            {
                                SqlCommand cmd = new SqlCommand("", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "spInsertPruebasPendientes";
                                cmd.Parameters.Add(new SqlParameter("@pacid", SqlDbType.Int)).Value = ID;
                                cmd.Parameters.Add(new SqlParameter("@pnombre", SqlDbType.VarChar)).Value = Pac;
                                cmd.Parameters.Add(new SqlParameter("@pcedula", SqlDbType.VarChar)).Value = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[2].Value);
                                cmd.Parameters.Add(new SqlParameter("@tipoprueba", SqlDbType.VarChar)).Value = Tipop;
                                cmd.Parameters.Add(new SqlParameter("@prueba", SqlDbType.NChar)).Value = Prueba;
                                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date)).Value = cambiada1;
                                cmd.Parameters.Add(new SqlParameter("@hora", SqlDbType.Time)).Value = DBNull.Value;
                                cmd.Parameters.Add(new SqlParameter("@empresaid", SqlDbType.Int)).Value = DBNull.Value;
                                cmd.Parameters.Add(new SqlParameter("@especial", SqlDbType.Bit)).Value = false;
                                cmd.Parameters.Add(new SqlParameter("@prid", SqlDbType.Int)).Value = DBNull.Value;
                                cmd.ExecuteNonQuery();
                                SaveLog();
                            }


                        }
                        MessageBox.Show("Datos guardados exitosamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dt.Rows.Clear();
                        //CargacbbTipo();
                        //cbbPrueba.Enabled = false;
                        //cbbMetodo.Enabled = false;
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    finally
                    {
                        con.Close();
                        //SaveLog();
                    }
                }
            }
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (txtConsulta.Text != "Digite nombre o cedula")
                {
                    try
                    {
                        using (var con = new SqlConnection(conect))
                        {

                            con.Open();
                            SqlDataAdapter da = new SqlDataAdapter("spgetPacientes", con);
                            DataTable dt = new DataTable();
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@Nombre", txtConsulta.Text);
                            da.SelectCommand.Parameters.AddWithValue("@Fechadesde", "prmaxsearch");
                            da.SelectCommand.Parameters.AddWithValue("@fechahasta", "prmaxsearch");
                            da.Fill(dt);
                            this.radGridView5.DataSource = dt;
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
}
