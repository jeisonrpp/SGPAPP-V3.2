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
using System.Runtime;
using System.Runtime.InteropServices;

namespace SGPAPP
{
    public partial class Resultsm : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;
        public Resultsm()
        {
            InitializeComponent();
        }
        public int pacID;
        public int PrID;
        String docname;
        DateTime Fecha = DateTime.Now;
        String Age;
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        clsMail cm = new clsMail();
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string cambiada1;
        public String day;
        public String mes;
        public String year;
        public String mail;
        public string mail2;
        public String dir;
        public bool Ingles = false;
        bool Enviado = false;
        frmCPG pgb = new frmCPG();
        String PruebaID;
        public String FechaMuestra;
        public String FechaRegistro;
        public bool Citas = false;
        public String HoraMuestra;
        public String Metodo;
        private void Resultsm_Load(object sender, EventArgs e)
        {
            GetPaciente();
            GetPrueba();
            getCitas();
            cbbResult.Text = "Seleccione el Resultado";
            if (lbltest.Text == "Influenza")
            {
                lblTipo2.Text = lblTipo.Text;
                lbltest2.Text = lbltest.Text;
                cbbResults1.Text = "Seleccione el Resultado";
                cbbResult.Text = "Seleccione el Resultado";

                this.Height = 553;
                btnSav.Location = new Point(304, 462);
                groupBox3.Visible = true;
                groupBox2.Text = "Influenza A";
            }
            if (lbltest.Text == "Anticuerpo-Covid")
            {
                lblTipo2.Text = lblTipo.Text;
                lbltest2.Text = lbltest.Text;
                cbbResult.Items.Clear();
                cbbResults1.Items.Clear();
                cbbResult.Items.Add("Positivo");
                cbbResult.Items.Add("Negativo");
                cbbResults1.Items.Add("Positivo");
                cbbResults1.Items.Add("Negativo");
                cbbResults1.Text = "Seleccione el Resultado";
                cbbResult.Text = "Seleccione el Resultado";
            
                    //txtCt.Enabled = false;
                    //txtCt1.Enabled = false;
         
                this.Height = 553;
                btnSav.Location = new Point(304, 462);
                groupBox3.Visible = true;
                groupBox2.Text = "igG";
                groupBox3.Text = "igM";
            }
            if (lbltest.Text == "Antigeno")
            {             
                cbbResult.Items.Clear();               
                cbbResult.Items.Add("Positivo");
                cbbResult.Items.Add("Negativo");
                cbbResult.Text = "Seleccione el Resultado";
                chkIng.Visible = true;
            }
            if (lbltest.Text == "Sars Cov-2")
            {
                chkIng.Visible = true;
            }
        }
        public void GetPaciente()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT RTRIM(pNom) as [Paciente], RTRIM(pced) as [Cedula], RTRIM(pFecha) as [Edad] , RTRIM(pemail) as [Email] , RTRIM(pdir) as [Direccion], RTRIM(pemail2) as [Email2] from tbpacientes where pID = '" + pacID + "'";
                chkIng.Checked = false;
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
                        lblCed.Text = reader[1].ToString();
                        Age = reader[2].ToString();
                        if (Age == "1900-01-01")
                        {
                            lblage.Text = "-";
                            lblFecha.Text = "-";
                        }
                        else
                        {
                            Age = Convert.ToString(DateTime.Today.AddTicks(-DateTime.Parse(Age).Ticks).Year - 1);
                            lblage.Text = Age.ToString() + " años";
                            lblFecha.Text = reader[2].ToString();
                        }
                        mail = reader[3].ToString();
                        lblmail.Text = mail;
                        dir = reader[4].ToString();
                        mail2 = reader[5].ToString();
                        if (mail2.Length >0)
                        {
                            mail = mail + ", " + mail2;
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
        public void GetPrueba()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT RTRIM(ppID) as [ID], RTRIM(ppTipo) as [Tipo], RTRIM(ppPrueba) as [Prueba] , RTRIM(ppFecha) as [Fecha de Muestra], RTRIM(ppHora) as [Hora de Muestra], RTRIM(ppMetodo) as [Metodo] from tbPruebasPendientes inner join tbpruebas on ppPrueba = prnombre where ppID = '" + PrID + "' and prlaboratorios = 0";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        PruebaID = reader[0].ToString();
                        lblTipo.Text = reader[1].ToString();
                        lbltest.Text = reader[2].ToString();
                        FechaRegistro = reader[3].ToString();
                        HoraMuestra = reader[4].ToString();
                        Metodo = reader[5].ToString();
                    }
                    else
                    {
                        this.Close();
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
        public void getCitas()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "select RTRIM(cfecha) as [Fechamuestra] from tbcitas where cestatus = 'Programada' and pid = '" + pacID + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        DateTime Fnow = DateTime.Now;
                        FechaMuestra = reader[0].ToString();
                        Citas = true;
                        if (DateTime.Parse(FechaMuestra) > Fnow)
                        {
                            FechaMuestra = FechaRegistro;
                            Citas = false;
                        }

                    }
                    else
                    {
                        FechaMuestra = FechaRegistro;
                        Citas = false;
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
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {

                if (chkIng.Checked == true)
            {
                Ingles = true;

            }
            else
            {
                Ingles = false;
            }
            this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbResult.Text == "No Detectado" || cbbResult.Text == "Indeterminado" || cbbResult.Text == "Negativo" || cbbResults1.Text == "Negativo")
            {
                txtCt.Text = "-";
                //txtCt.Enabled = false;
            }
            else if (cbbResult.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid" || cbbResults1.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid" || cbbResult.Text == "Detectado" && lbltest.Text != "Anticuerpo-Covid" || cbbResults1.Text == "Detectado" && lbltest.Text != "Anticuerpo-Covid")
            {
                txtCt.Text = "";
                //txtCt.Enabled = true;
            }
        }

        private void cbbResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbResults1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbResults1.Text == "No Detectado" || cbbResults1.Text == "Indeterminado" || cbbResults1.Text == "Negativo")
            {
                txtCt1.Text = "-";
                //txtCt1.Enabled = false;
            }
            else if (cbbResults1.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid" || cbbResults1.Text == "Positivo" && lbltest.Text == "Anticuerpo-Covid" || cbbResults1.Text == "Detectado" && lbltest.Text != "Anticuerpo-Covid" || cbbResults1.Text == "Detectado" && lbltest.Text != "Anticuerpo-Covid")
            {
                txtCt1.Text = "";
                //txtCt1.Enabled = true;
            }
        }

        private void chkIng_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIng.Checked == true)
            {
                Ingles = true;
            }

        }

        private void cbbResults1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
