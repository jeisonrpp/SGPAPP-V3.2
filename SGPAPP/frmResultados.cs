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
                string sql = "SELECT RTRIM(pNom) as [Paciente], RTRIM(pSex) as [Sexo], RTRIM(pFecha) as [Edad] from tbpacientes where pID = '" + pacID + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblname.Text = reader[0].ToString();
                        lblSex.Text = reader[1].ToString();
                        Age = reader[2].ToString();
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
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
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

                string sql = "SELECT RTRIM(prTiempo) as [Tiempo], prEspecial as [Especial], RTRIM(prid) as [ID] from tbPruebas where prTipo = '" + cbbTipo.Text + "' and prNombre = '" + cbbPrueba.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

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
                        //if (Especial == "1")
                        //{
                            
                        //        con.Open();
                        //        cmd = new SqlCommand("select RTRIM(prTipo) as [Tipo], RTRIM(presnom) as [Prueba], RTRIM(prTiempo) as [Tiempo] from tbpruebas A inner join tbPruebasresults B on A.prid = B.prid where B.prid =" + ID + "", con);
                        //        SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                        //        DataSet myDataSet = new DataSet();
                        //        myDA.Fill(myDataSet, "Pruebas");
                        //        dataGridView2.DataSource = myDataSet.Tables["Pruebas"].DefaultView;
                        //        dataGridView2.Columns["Tipo"].DisplayIndex = 0;
                        //        dataGridView2.Columns["Prueba"].DisplayIndex = 1;
                        //        dataGridView2.Columns["Tiempo"].DisplayIndex = 2;
                        //        con.Close();
                        //        for (int i = 0; i < dataGridView2.RowCount; i++)
                        //        {
                        //            int Rows;
                        //            Rows = dataGridView1.RowCount - 1;
                        //            dt.Rows.Add(dataGridView2.Rows[i].Cells["Tipo"].Value.ToString(), dataGridView2.Rows[i].Cells["Prueba"].Value.ToString(), dataGridView2.Rows[i].Cells["Tiempo"].Value.ToString(), cambiada1, "Consulta Web");
                        //            dataGridView1.DataSource = dt;
                        //            btnSave.Enabled = true;
                        //        }
                        //    }
                                                   
                        //else

                        //{
                            int Rows;
                            Rows = dataGridView1.RowCount - 1;
                            dt.Rows.Add(cbbTipo.Text, cbbPrueba.Text, Time, cambiada1, cbbMetodo.Text, Especial);
                            dataGridView1.DataSource = dt;
                     //   }
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
                    //if (Especial == true)
                    //{

                    //if (dataGridView2.Rows.Count < 1 && dataGridView1.Rows.Count < 1)
                    //    {
                    //    con.Open();
                    //    cmd = new SqlCommand("select RTRIM(prTipo) as [Tipo], RTRIM(presnom) as [Prueba], RTRIM(prTiempo) as [Tiempo] from tbpruebas A inner join tbPruebasresults B on A.prid = B.prid where B.prid =" + ID + "", con);
                    //    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    //    DataSet myDataSet = new DataSet();
                    //    myDA.Fill(myDataSet, "Pruebas");
                    //    dataGridView2.DataSource = myDataSet.Tables["Pruebas"].DefaultView;
                    //    dataGridView2.Columns["Tipo"].DisplayIndex = 0;
                    //    dataGridView2.Columns["Prueba"].DisplayIndex = 1;
                    //    dataGridView2.Columns["Tiempo"].DisplayIndex = 2;
                    //    con.Close();
                    //    for (int i = 0; i < dataGridView2.RowCount; i++)
                    //    {
                    //        int Rows;
                    //        Rows = dataGridView1.RowCount - 1;
                    //        dt.Rows.Add(dataGridView2.Rows[i].Cells["Tipo"].Value.ToString(), dataGridView2.Rows[i].Cells["Prueba"].Value.ToString(), dataGridView2.Rows[i].Cells["Tiempo"].Value.ToString(), cambiada1, "Consulta Web");
                    //        dataGridView1.DataSource = dt;
                    //        btnSave.Enabled = true;
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Esta prueba solo puede agregarse de manera individual, elimine o guarde las pruebas agregadas e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                    //}
                    //else

                    //{
                    //    if (dataGridView2.Rows.Count < 1 )
                    //    {
                            int Rows;
                            Rows = dataGridView1.RowCount - 1;
                            dt.Rows.Add(cbbTipo.Text, cbbPrueba.Text, Time, cambiada1, cbbMetodo.Text, Especial);
                            dataGridView1.DataSource = dt;
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Para agregar otra prueba elimine o guarde las pruebas agregadas e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    //}
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
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select distinct(prTipo) as Tipos from tbPruebas order by prTipo", con);

                da.Fill(ds, "Tipos");
                cbbTipo.DataSource = ds.Tables[0].DefaultView;
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
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (prNombre) as Pruebas from tbPruebas where prTipo = '" + cbbTipo.Text + "' order by prNombre", con);

                da.Fill(ds, "Pruebas");
                cbbPrueba.DataSource = ds.Tables[0].DefaultView;
                cbbPrueba.ValueMember = "Pruebas";
                cbbPrueba.Text = "Seleccione la Prueba";
                con.Close();
            }
        }
        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargacbbPrueba();
            cbbMetodo.SelectedIndex = 0;
           
            // if (cbbTipo.Text == "Seleccione el Tipo" || cbbTipo.Text == "")
           // {
               
           // }
           //else
           // {
           //    CargacbbPrueba();
           //     cbbPrueba.Enabled = true;
           // }
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
           // cbbMetodo.Enabled = true;
            //string sql = "SELECT RTRIM(prTiempo) as [Tiempo] from tbPruebas where prTipo = '" + cbbTipo.Text + "' and prPrueba = '" + cbbPrueba.Text + "'";
            //con = new SqlConnection(cs.ConnectionString);
            //SqlCommand cmd = new SqlCommand(sql, con);
            //SqlDataReader reader;
            //cmd.CommandType = CommandType.Text;
            //con.Open();

            //try
            //{
            //    reader = cmd.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        Time = reader[0].ToString();
                    

            //    }
            //    else
            //    {
            //        MessageBox.Show("No se ha encontrado registro!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.ToString());
            //}
            //finally
            //{
            //    con.Close();
            //}
        }
        public void getResultados()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "Select reid, repacid from tbresultados where repacid = '" + pacID + "' and reprueba = '" + cbbPrueba.Text + "' and refecha = '"+cambiada1+"' ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();


                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Este paciente ya tiene una prueba de este tipo reportada el dia de hoy, esta prueba no se le puede asignar nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        Insertadgv();
                        btnSave.Enabled = true;
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
                string sql = "SELECT * from tbPruebasPendientes where pppacid = '" + pacID + "' and ppPrueba = '"+cbbPrueba.Text+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

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
                string sql = "select * from tbresultados where refecha  >= DATEADD(day, -1, GETDATE()) and repacid = '" + pacID + "' and rePrueba = '" + cbbPrueba.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

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
                    //else
                    //{
                    //    getResultados();

                    //CargacbbTipo();
                    //cbbMetodo.Enabled = false;
                    //cbbPrueba.Enabled = false;
                    //}
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
        public void UpdateCitas()
        {
            
            using (var con = new SqlConnection(conect))
            {
                string sqls = "update tbcitas set cEstatus= 'Completada' where pID = '" + pacID + "' and cFecha = '" + cambiada1 + "'";
                SqlCommand cmds = new SqlCommand(sqls, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmds.ExecuteNonQuery();
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
                    //int rowdgb1 = dataGridView1.Rows.Count;
                    //for (int i = 0; i < rowdgb1; i++)
                    //{
                    //    dataGridView1.Rows.RemoveAt(i);
                    //}
                   
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
                   // SqlCommand AddPruebas = new SqlCommand("Insert into tbPruebasPendientes values (@Pacid, @Paciente, @Cedula, @Tipo, @Prueba, @Fecha, @Tiempo, @Metodo, @Hora, @EmpresaID)", con);
                    con.Open();
                    Hora = DateTime.Now;
                    try
                    {
                        bool espc = false;
                        //if (Especial == true)
                        //{
                        //    espc = true;


                        //    if (dataGridView1.RowCount >= 1)
                        //    {
                        //        cmd = new SqlCommand(Sql, con);
                        //        cmd.CommandType = CommandType.StoredProcedure;
                        //        cmd.CommandText = "spInsertPruebasPendientes";
                        //        cmd.Parameters.Add(new SqlParameter("@pacid", SqlDbType.Int)).Value = pacID;
                        //        cmd.Parameters.Add(new SqlParameter("@pnombre", SqlDbType.VarChar)).Value = lblname.Text;
                        //        cmd.Parameters.Add(new SqlParameter("@pcedula", SqlDbType.VarChar)).Value = Cedula;
                        //        cmd.Parameters.Add(new SqlParameter("@tipoprueba", SqlDbType.VarChar)).Value = cbbTipo.Text;
                        //        cmd.Parameters.Add(new SqlParameter("@prueba", SqlDbType.NChar)).Value = cbbPrueba.Text;
                        //        cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date)).Value = cambiada1;
                        //        cmd.Parameters.Add(new SqlParameter("@hora", SqlDbType.Time)).Value = Hora.ToString("HH:mm");
                        //        cmd.Parameters.Add(new SqlParameter("@empresaid", SqlDbType.Int)).Value = DBNull.Value;
                        //        cmd.Parameters.Add(new SqlParameter("@especial", SqlDbType.Bit)).Value = espc;
                        //        cmd.Parameters.Add(new SqlParameter("@prid", SqlDbType.Int)).Value = ID;
                        //        cmd.ExecuteNonQuery();
                        //    }
                        //}
                        //else
                        //{
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {

                                string sql = "SELECT RTRIM(prid) as [ID] from tbPruebas where prTipo = '" + Convert.ToString(row.Cells["Tipo"].Value) + "' and prNombre = '" + Convert.ToString(row.Cells["Prueba"].Value) + "'";
                                SqlCommand cm = new SqlCommand(sql, con);
                                SqlDataReader reader;
                                cm.CommandType = CommandType.Text;
                             
                                    reader = cm.ExecuteReader();
                                    if (reader.Read())
                                    {                                       
                                        ID = int.Parse(reader[0].ToString());
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se ha encontrado registro!");
                                    }
                                reader.Close();
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
                                cmd.Parameters.Add(new SqlParameter("@prid", SqlDbType.Int)).Value = ID;
                                cmd.ExecuteNonQuery();
                           // }
                        }

                        //foreach (DataGridViewRow row in dataGridView1.Rows)
                        //{
                        //    AddPruebas.Parameters.Clear();
                        //    AddPruebas.Parameters.AddWithValue("@Pacid", Convert.ToString(pacID));
                        //    AddPruebas.Parameters.AddWithValue("@Paciente", lblname.Text);
                        //    AddPruebas.Parameters.AddWithValue("@Cedula", Cedula);
                        //    AddPruebas.Parameters.AddWithValue("@Tipo", Convert.ToString(row.Cells["Tipo"].Value));
                        //    AddPruebas.Parameters.AddWithValue("@Prueba", Convert.ToString(row.Cells["Prueba"].Value));
                        //    AddPruebas.Parameters.AddWithValue("@Fecha", Convert.ToString(row.Cells["Fecha de Muestra"].Value));
                        //    AddPruebas.Parameters.AddWithValue("@Tiempo", Convert.ToString(row.Cells["Tiempo"].Value));
                        //    AddPruebas.Parameters.AddWithValue("@Metodo", "Consulta Web");
                        //    AddPruebas.Parameters.AddWithValue("@Hora", Hora.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                        //    AddPruebas.Parameters.AddWithValue("@EmpresaID", DBNull.Value);
                        //    AddPruebas.ExecuteNonQuery();

                        //}
                        MessageBox.Show("Datos guardados exitosamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ////UpdateCitas();
                        //dt.Rows.Clear();
                        ////CargacbbTipo();
                        ////cbbPrueba.Enabled = false;
                        ////cbbMetodo.Enabled = false;
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
