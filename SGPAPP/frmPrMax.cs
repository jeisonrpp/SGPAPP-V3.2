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
                 
                        con.Open();
                        cmd = new SqlCommand("SELECT pId as [ID], RTRIM(pNom) as [Paciente], RTRIM(pCed) as [Cedula], RTRIM(pFecha) as [Fecha Nacimiento] from tbpacientes", con);
                        SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                        DataSet myDataSet = new DataSet();
                        myDA.Fill(myDataSet, "Paciente");
                    radGridView5.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                        //dataGridView1.Columns["ID"].DisplayIndex = 0;
                        //dataGridView1.Columns["Paciente"].DisplayIndex = 1;
                        //dataGridView1.Columns["Cedula"].DisplayIndex = 2;
                        //dataGridView1.Columns["Fecha Nacimiento"].DisplayIndex = 3;


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
                    string sql = "Select reid, repacid from tbresultados where repacid = '" + ID + "' and reprueba = '" + Prueba + "' and refecha = '" + cambiada1 + "' ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();


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
            
           
                try
                {
                    using (var con = new SqlConnection(conect))
                    {
                     
                        con.Open();
                        cmd = new SqlCommand("SELECT pId as [ID], RTRIM(pNom) as [Paciente], RTRIM(pCed) as [Cedula], RTRIM(pFecha) as [Fecha Nacimiento] from tbpacientes where pnom like '%"+ txtConsulta.Text+ "%'  or pCed like '%" + txtConsulta.Text + "%' ", con);
                        SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                        DataSet myDataSet = new DataSet();
                        myDA.Fill(myDataSet, "Paciente");
                    radGridView5.DataSource = myDataSet.Tables["Paciente"].DefaultView;
        


                        con.Close();
                    
                    con.Close();
                }
                }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
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

           try
                {
                    using (var con = new SqlConnection(conect))
                    {
                     
                        con.Open();
                        cmd = new SqlCommand("SELECT pId as [ID], RTRIM(pNom) as [Paciente], RTRIM(pCed) as [Cedula], RTRIM(pFecha) as [Fecha Nacimiento] from tbpacientes where pnom like '%" + txtConsulta.Text + "%'  or pCed like '%" + txtConsulta.Text + "%' ", con);
                        SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                        DataSet myDataSet = new DataSet();
                        myDA.Fill(myDataSet, "Paciente");
                    radGridView5.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                        

                        con.Close();


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           

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

                    SqlCommand AddPruebas = new SqlCommand("Insert into tbPruebasPendientes values (@Pacid, @Paciente, @Cedula, @Tipo, @Prueba, @Fecha, @Tiempo, @Metodo, @ppHora, @ppempresaid)", con);
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
                                AddPruebas.Parameters.Clear();
                                AddPruebas.Parameters.AddWithValue("@Pacid", Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[0].Value));
                                AddPruebas.Parameters.AddWithValue("@Paciente", Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[1].Value));
                                AddPruebas.Parameters.AddWithValue("@Cedula", Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[2].Value));
                                AddPruebas.Parameters.AddWithValue("@Tipo", Tipop);
                                AddPruebas.Parameters.AddWithValue("@Prueba", Prueba);
                                AddPruebas.Parameters.AddWithValue("@Fecha", cambiada1);
                                AddPruebas.Parameters.AddWithValue("@Tiempo", Time);
                                AddPruebas.Parameters.AddWithValue("@Metodo", Metodo);
                                AddPruebas.Parameters.AddWithValue("@ppHora", Fecha.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                                AddPruebas.Parameters.AddWithValue("@ppempresaid", DBNull.Value);
                                AddPruebas.ExecuteNonQuery();
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
    }
}
