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
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using System.Runtime;
using System.Runtime.InteropServices;

namespace SGPAPP
{
    public partial class frmPruebas : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;

        public frmPruebas()
        {
            InitializeComponent();
        }

        public int pacID;
        public String Cedula;
        DateTime Fecha = DateTime.Now;
        String Age;
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        String Time;
        DataTable dt = new DataTable();
        bool Existe;
        string cambiada1;
        DateTime Hora;
        bool Especial;
        int ID;
        String Sql;

        public void GetPaciente()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetPacientes";
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar)).Value = pacID;
                cmd.Parameters.Add(new SqlParameter("@Fechadesde", SqlDbType.VarChar)).Value = "edit";
                cmd.Parameters.Add(new SqlParameter("@Fechahasta", SqlDbType.VarChar)).Value = (object)DBNull.Value;
                SqlDataReader reader;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        lblname.Text = reader[1].ToString();
                        lblSex.Text = reader[10].ToString();
                        Age = reader[3].ToString();
                        if (Age == "1900-01-01")
                        {
                            lblage.Text = "-";
                        }
                        else
                        {

                            Age = Convert.ToString(DateTime.Today.AddTicks(-DateTime.Parse(Age).Ticks).Year - 1);
                            lblage.Text = Age.ToString() + " años";
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado registro!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                    con.Close();

                }
                con.Close();
            }
        }

        private void frmPruebas_Load(object sender, EventArgs e)
        {
            GetPaciente();
            AgregaColumnas();
            CargacbbTipo();
            conviertefecha();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void Insertadgv()
        {
    
            using (var con = new SqlConnection(conect))
            {

                 con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spValidaPruebasParaAsignar";
                SqlDataReader reader;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = pacID;
                cmd.Parameters.Add("@prueba", SqlDbType.VarChar).Value = cbbPrueba.Text;
                cmd.Parameters.Add("@tipop", SqlDbType.VarChar).Value = cbbTipo.Text;
                cmd.Parameters.Add("@paso", SqlDbType.VarChar).Value = 3;


                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Time = reader[0].ToString();
                        Especial = Convert.ToBoolean(reader[1].ToString());
                        ID = int.Parse(reader[2].ToString());
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado registro!");
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

                Existe = false;
                if (dataGridView1.RowCount > 0)
                {
                    CheckifExist();
                }

                else
                {
                    {
           
                            int Rows;
                            Rows = dataGridView1.RowCount - 1;
                            dt.Rows.Add(cbbTipo.Text, cbbPrueba.Text, Time, cambiada1, cbbMetodo.Text, Especial);
                            dataGridView1.DataSource = dt;
                 
                    }
                }
            }
        }
      
        public void CheckifExist()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells["Prueba"].Value) == cbbPrueba.Text && Convert.ToString(dataGridView1.Rows[i].Cells["Tipo"].Value) == cbbTipo.Text)
                {
                    MessageBox.Show("Esta prueba ya ha sido asignada a este paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Existe = true;
                    break;
                }
               
            }
            if (Existe == false)
            {
                using (var con = new SqlConnection(conect))
                {
                   
                            int Rows;
                            Rows = dataGridView1.RowCount - 1;
                            dt.Rows.Add(cbbTipo.Text, cbbPrueba.Text, Time, cambiada1, cbbMetodo.Text, Especial);
                            dataGridView1.DataSource = dt;
                     
                }
            }
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
        public void AgregaColumnas()
        {

            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Prueba", typeof(string));      
            dt.Columns.Add("Tiempo", typeof(string));
            dt.Columns.Add("Fecha de Muestra", typeof(string));
            dt.Columns.Add("Metodo", typeof(string));
            dt.Columns.Add("Especial", typeof(bool));

            

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Especial"].Visible = false;
        }
        public void CargacbbTipo()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("spGetTiposPruebas", con);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("@Empresas", false);
                DataTable table = new DataTable();
                sqlData.Fill(table);
                cbbTipo.DataSource = table;
                cbbTipo.ValueMember = "Tipos";
                cbbTipo.Text = "Seleccione el Tipo";
                cbbPrueba.Text = "Seleccione la Prueba";
                con.Close();
            }
        }

        public void CargacbbPrueba()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("spGetPruebasPorTipo", con);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = cbbTipo.Text;
                DataTable table = new DataTable();
                sqlData.Fill(table);
                cbbPrueba.DataSource = table;
                cbbPrueba.ValueMember = "Pruebas";
                cbbPrueba.Text = "Seleccione la Prueba";
                con.Close();
            }
        }
        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargacbbPrueba();
            cbbMetodo.SelectedIndex = 0;
                    
        }

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbPrueba_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbPrueba_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void cbbMetodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbPrueba_DropDown(object sender, EventArgs e)
        {
            CargacbbPrueba();
            cbbMetodo.Enabled = true;
            cbbMetodo.SelectedIndex = 0;

        }

        private void cbbTipo_DropDown(object sender, EventArgs e)
        {
            //CargacbbPrueba();
            cbbPrueba.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        public void GetPruebasPendientes()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spValidaPruebasParaAsignar";
                SqlDataReader reader;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = pacID;
                cmd.Parameters.Add("@prueba", SqlDbType.VarChar).Value = cbbPrueba.Text;
                cmd.Parameters.Add("@tipop", SqlDbType.VarChar).Value = cbbTipo.Text;
                cmd.Parameters.Add("@paso", SqlDbType.VarChar).Value = 1;


                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Este paciente ya tiene una prueba del mismo tipo registrada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                    else
                    {
                        GetResultadosRecientes();
                       
                        //CargacbbTipo();
                        //cbbMetodo.Enabled = false;
                        //cbbPrueba.Enabled = false;
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
        public void GetResultadosRecientes()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spValidaPruebasParaAsignar";
                SqlDataReader reader;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = pacID;
                cmd.Parameters.Add("@prueba", SqlDbType.VarChar).Value = cbbPrueba.Text;
                cmd.Parameters.Add("@tipop", SqlDbType.VarChar).Value = cbbTipo.Text;
                cmd.Parameters.Add("@paso", SqlDbType.VarChar).Value = 2;

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (UserCache.RoleList.Any(item => item.RoleName == "Pruebas-24") || UserCache.Nivel == "Admin")
                        {
                            DialogResult resulta = MessageBox.Show("Este paciente ya tiene una prueba reportada del mismo tipo de menos de 24 horas!, desea asignarle otra?", "Asignar Pruebas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resulta == DialogResult.Yes)
                            {
                                Insertadgv();

                            }

                        }
                        else
                        {
                            MessageBox.Show("Este paciente ya tiene una prueba reportada del mismo tipo de menos de 24 horas!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Insertadgv();
                        btnSave.Enabled = true;
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
        private void btnSav_Click(object sender, EventArgs e)
        {
           
        }       
        
        public void SaveLog()
        {
            Logs log = new Logs();
            log.Accion = "Prueba asignada al Paciente: " + lblname.Text + "";
            log.Form = "Asignacion de Pruebas";
            log.SaveLog();
        }
        private void btnCanc_Click(object sender, EventArgs e)
        {

        }

        private void cbbMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (cbbTipo.Text == "Seleccione el Tipo" || cbbPrueba.Text == "Seleccione la Prueba")
            {
                MessageBox.Show("Debe elegir la prueba a agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                GetPruebasPendientes();

            }
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count >= 1)
                {
                    dataGridView1.DataSource = null;
   
                   
                    dataGridView2.DataSource = null;
                    dt.Rows.Clear();
                    

                }
               else if (dataGridView1.Rows.Count >= 1)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {

                using (var con = new SqlConnection(conect))
                {
                   
                    con.Open();
                    Hora = DateTime.Now;
                    try
                    {
                        bool espc = false;
                    
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {

                               
                                cmd = new SqlCommand(Sql, con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "spInsertPruebasPendientes";
                                cmd.Parameters.Add(new SqlParameter("@pacid", SqlDbType.Int)).Value = pacID;
                                cmd.Parameters.Add(new SqlParameter("@pnombre", SqlDbType.VarChar)).Value = lblname.Text;
                                cmd.Parameters.Add(new SqlParameter("@pcedula", SqlDbType.VarChar)).Value = Cedula;
                                cmd.Parameters.Add(new SqlParameter("@tipoprueba", SqlDbType.VarChar)).Value = Convert.ToString(row.Cells["Tipo"].Value);
                                cmd.Parameters.Add(new SqlParameter("@prueba", SqlDbType.NChar)).Value = Convert.ToString(row.Cells["Prueba"].Value);
                                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date)).Value = cambiada1;
                                cmd.Parameters.Add(new SqlParameter("@hora", SqlDbType.Time)).Value = Hora.ToString("HH:mm");
                                cmd.Parameters.Add(new SqlParameter("@empresaid", SqlDbType.Int)).Value = DBNull.Value;
                                cmd.Parameters.Add(new SqlParameter("@especial", SqlDbType.Bit)).Value = row.Cells["Especial"].Value;
                                cmd.Parameters.Add(new SqlParameter("@prid", SqlDbType.Int)).Value = DBNull.Value;
                                cmd.ExecuteNonQuery();
                           // }
                        }

                    
                        MessageBox.Show("Datos guardados exitosamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    finally
                    {
                        con.Close();
                        SaveLog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
