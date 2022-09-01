using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmPruebaE : Telerik.WinControls.UI.RadForm
    {
        public frmPruebaE()
        {
            InitializeComponent();
        }
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;
        static string conect = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        public String Empresa;
        public int LotID;
        public String Fechareg;
        public String Time;
        String Pacid;
        String Prueba;
        bool results = false;
        String Pac;
       int pEMpresaid;
        string cambiada1;
        private void frmPruebaE_Load(object sender, EventArgs e)
        {
            CargacbbTipo();
            GetPacientes();
        }

        public void GetPacientes()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter("spGetPacientesEmpresas", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Empresa", Empresa);
                    da.SelectCommand.Parameters.AddWithValue("@tipo", "Prueba");
                    da.SelectCommand.Parameters.AddWithValue("@PruebaEmpresa", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@LotID", LotID);
                    da.Fill(dt);
                    if (dt.Rows.Count < 1)
                    {
                        MessageBox.Show("Esta empresa no tiene pacientes agregados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    else
                    {
                        this.radGridView4.DataSource = dt;
                    }
                    this.radGridView4.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;                   
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }
        public void CargacbbTipo()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select distinct(prTipo) as Tipos from tbPruebas where prlaboratorios = 0 order by prTipo", con);

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

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbPrueba_DropDown(object sender, EventArgs e)
        {
            CargacbbPrueba();
            cbbMetodo.Enabled = true;
            cbbMetodo.Text = "Seleccione el Metodo";
        }

        private void cbbTipo_DropDown(object sender, EventArgs e)
        {
            cbbPrueba.Enabled = true;
        }

        public void CargaDatos()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "Select prtiempo from tbpruebas where prnombre = '" + cbbPrueba.Text + "'  ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();


                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                       Time = reader[0].ToString();                       
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado registro!");
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
        public void CargaEmpresaID()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "Select empresaid from tbcontador";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();


                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pEMpresaid = Convert.ToInt32(reader[0]);
                        pEMpresaid = pEMpresaid + 1;
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado registro!");
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
        private void btnStart_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
           
        }
        public void getResultados()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "select * from tbresultados where refecha  >= DATEADD(day, -1, GETDATE()) and repacid = '" + Pacid + "' and rePrueba = '" + cbbPrueba.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();


                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("El paciente " + Pac + ", ya tiene una prueba de este tipo reportada el dia de hoy, esta prueba no se le puede asignar nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void radButton1_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {

                DataTable dt = new DataTable();

               
                if (cbbTipo.Text == "Seleccione el Tipo" || cbbPrueba.Text == "Seleccione la Prueba" || cbbMetodo.Text == "Seleccione el Metodo")
                {
                    MessageBox.Show("Debe completar los datos de la prueba", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else {
                    CargaDatos();
                    CargaEmpresaID();
                    using (var con = new SqlConnection(conect))
                {

                    try
                    {
                        SqlCommand AddPruebas = new SqlCommand("Insert into tbPruebasPendientes values (@Pacid, @Paciente, @Cedula, @Tipo, @Prueba, @Fecha, @Tiempo, @Metodo, @ppHora, @ppempresaid)", con);
                        con.Open();

                        DateTime fecha1;
                        DateTime Fecha = DateTime.Now;

                        fecha1 = DateTime.Now;

                        String day = fecha1.Day.ToString();
                        String mes = fecha1.Month.ToString();
                        String year = fecha1.Year.ToString();

                         cambiada1 = year + "-" + mes + "-" + day;

                        foreach (GridViewRowInfo rowInfo in radGridView4.Rows)
                        {
                                Pacid = Convert.ToString(radGridView4.Rows[rowInfo.Index].Cells[0].Value);
                                Pac = Convert.ToString(radGridView4.Rows[rowInfo.Index].Cells[1].Value);
                                getResultados();
                                

                                if (results == false)
                                {
                                    AddPruebas.Parameters.Clear();
                                    AddPruebas.Parameters.AddWithValue("@Pacid", Convert.ToString(radGridView4.Rows[rowInfo.Index].Cells[0].Value));
                                    AddPruebas.Parameters.AddWithValue("@Paciente", Convert.ToString(radGridView4.Rows[rowInfo.Index].Cells[1].Value));
                                    AddPruebas.Parameters.AddWithValue("@Cedula", Convert.ToString(radGridView4.Rows[rowInfo.Index].Cells[2].Value));
                                    AddPruebas.Parameters.AddWithValue("@Tipo", cbbTipo.Text);
                                    AddPruebas.Parameters.AddWithValue("@Prueba", cbbPrueba.Text);
                                    AddPruebas.Parameters.AddWithValue("@Fecha", cambiada1);
                                    AddPruebas.Parameters.AddWithValue("@Tiempo", Time);
                                    AddPruebas.Parameters.AddWithValue("@Metodo", cbbMetodo.Text);
                                    AddPruebas.Parameters.AddWithValue("@ppHora", Fecha.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                                    AddPruebas.Parameters.AddWithValue("@ppempresaid", pEMpresaid);
                                    AddPruebas.ExecuteNonQuery();

                                    Logs log = new Logs();
                                    log.Accion = "Prueba asignada a Paciente: " + Convert.ToString(radGridView4.Rows[rowInfo.Index].Cells[1].Value) + " del Lote: "+LotID+", Empresa: " + Empresa + "";
                                    log.Form = "Asignacion de Pruebas: Empresas";
                                    log.SaveLog();
                                    
                                    dt.Rows.Clear();
                                    PruebaEmpresa();
                                    this.DialogResult = DialogResult.OK;
                                }
                        }
                                     MessageBox.Show("Datos guardados exitosamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    catch (Exception ex)
                    {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                    }

                    finally
                    {
                        con.Close();
                        Logs log = new Logs();
                        log.Accion = "Prueba Empresa: " + Empresa + " Asignada";
                        log.Form = "Asignacion de Pruebas: Empresas";
                        log.SaveLog();

                    }
                }
            }
         }


            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PruebaEmpresa()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "update tblotesempresa set lotPruebas = 1, lotPruebaid = '"+pEMpresaid+"' where lotid = '" + LotID + "'";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0) ;
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

                try
                {
                    string sql = "update tbcontador set empresaid =" + pEMpresaid + "";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0) ;
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
    }
}
