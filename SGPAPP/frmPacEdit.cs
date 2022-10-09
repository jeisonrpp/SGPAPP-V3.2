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
using System.Net.Sockets;
using System.Net;
using System.Runtime;
using System.Runtime.InteropServices;

namespace SGPAPP
{
    
    public partial class frmPacEdit : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;

        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        String ID;
        String Sex;
        String cambiada1;
        public String PacID;

        public frmPacEdit()
        {
            InitializeComponent();
        }

        private void frmPacEdit_Load(object sender, EventArgs e)
        {
            limpiar();
            CargaDatos();
            rbF.Focus();
           
                   }

        public void cargacbbSeg()
        {
            using (var con = new SqlConnection(conect))
            {

                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("spGetSeguros", con);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                sqlData.Fill(table);
                cbbSeguro.DataSource = table;
                cbbSeguro.ValueMember = "Seguros";
                cbbSeguro.Text = "Seleccione el Seguro";
                con.Close();


            }
        }
        public void CargaDatos()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                          con.Open();
                    cmd = new SqlCommand("", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetPacientes";
                    SqlDataReader reader;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = PacID;
                    cmd.Parameters.Add("@Fechadesde", SqlDbType.VarChar).Value = "edit";
                    cmd.Parameters.Add("@fechahasta", SqlDbType.VarChar).Value = DBNull.Value;

                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ID = reader[0].ToString();
                        txtNom.Text = reader[1].ToString();
                        txtCed.Text = reader[2].ToString();
                        dtp.Text = reader[3].ToString();
                        Sex = reader[10].ToString();
                        cbbSeguro.Text = reader[9].ToString();
                        txtDir.Text = reader[4].ToString();
                        txtCel.Text = reader[5].ToString();
                        txtEmail.Text = reader[6].ToString();
                        txtEmail2.Text = reader[7].ToString();
                        cbbRef.Text = reader[13].ToString();

                        if (Sex == "Masculino")
                        {
                            rbM.Checked = true;
                        }
                        else if (Sex == "Femenino")
                        {
                            rbF.Checked = true;
                        }


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

      
        private void txtNom_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCed.Focus();
            }
        }

        private void txtAp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCed.Focus();
            }
        }

        private void txtCed_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                rbF.Focus();
            }
        }

        private void rbF_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                rbM.Focus();
            }
        }

        private void rbM_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtDir.Focus();
            }
        }

        private void txtNac_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
          
        }

        private void dtp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;

            }
        }

        private void txtDir_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
       
        }

        private void cbbEC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;

            }
        }

        private void txtTel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCel.Focus();
            }
        }

        private void txtCel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtEmail.Focus();
            }
        }

        private void txtEmail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void txtFam_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void txtPar_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
          
        }

        private void txtTelf_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
   
            }
        }

        private void txtRazon_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
       
            }
        }

       

        private void txtObs1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
     
            }
        }

      

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Edicion de Pacientes") || UserCache.Nivel == "Admin")
            { 
                if (linkLabel1.Text == "Deshabilitar Edicion")
            {
                linkLabel1.Text = "Editar Paciente";
               
               
                txtNom.Enabled = false;
                txtCed.Enabled = false;
            
                txtDir.Enabled = false;
                txtCel.Enabled = false;
                txtEmail.Enabled = false;
                txtEmail2.Enabled = false;
                cbbSeguro.Enabled = false;
                cbbRef.Enabled = false;


                dtp.Enabled = false;
                rbF.Enabled = false;
                rbM.Enabled = false;
                btnSav.Visible = false;
            }
            else
            {
                linkLabel1.Text = "Deshabilitar Edicion";
                if (UserCache.Nivel == "Admin")
                {
                    txtCed.Enabled = true;
                }
                txtNom.Enabled = true;
                txtDir.Enabled = true;
                txtCel.Enabled = true;
                txtEmail.Enabled = true;
                txtEmail2.Enabled = true;
                cbbRef.Enabled = true;
                cbbSeguro.Enabled = true;

                dtp.Enabled = true;


                rbF.Enabled = true;
                rbM.Enabled = true;
                btnSav.Visible = true;
            }
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void ModificaPaciente()
        {
            using (var con = new SqlConnection(conect))
            {
                String Age = cambiada1;
                Age = Convert.ToString(DateTime.Today.AddTicks(-DateTime.Parse(Age).Ticks).Year - 1);
                Age = Age + " años";

                con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdatePacientes";
                cmd.Parameters.Add(new SqlParameter("@pNom", SqlDbType.VarChar)).Value = txtNom.Text;
                cmd.Parameters.Add(new SqlParameter("@pCed", SqlDbType.VarChar)).Value = txtCed.Text;
                cmd.Parameters.Add(new SqlParameter("@pSex", SqlDbType.VarChar)).Value = Sex;
                cmd.Parameters.Add(new SqlParameter("@pFecha", SqlDbType.VarChar)).Value = cambiada1;
                cmd.Parameters.Add(new SqlParameter("@pDir", SqlDbType.VarChar)).Value = txtDir.Text;
                cmd.Parameters.Add(new SqlParameter("@pCel", SqlDbType.VarChar)).Value = txtCel.Text;
                cmd.Parameters.Add(new SqlParameter("@pEmail", SqlDbType.VarChar)).Value = txtEmail.Text;
                cmd.Parameters.Add(new SqlParameter("@pemail2", SqlDbType.VarChar)).Value = txtEmail2.Text;
                cmd.Parameters.Add(new SqlParameter("@pSeguro", SqlDbType.VarChar)).Value = cbbSeguro.Text;
                cmd.Parameters.Add(new SqlParameter("@pReferidor", SqlDbType.VarChar)).Value = cbbRef.Text;
                cmd.Parameters.Add(new SqlParameter("@pid", SqlDbType.Int)).Value = PacID;
                cmd.Parameters.Add(new SqlParameter("@edad", SqlDbType.VarChar)).Value = Age;

                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                    con.Close();
                    return;
                }
                finally
                {
                    con.Close();
                    MessageBox.Show("Paciente Actualizado Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SaveLog();
                }
            }

         
            limpiar();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Esta seguro que desea modificar el paciente: " + txtNom.Text + " ?", "Modificar Datos", MessageBoxButtons.YesNo);
            if (resulta == DialogResult.Yes)
            {
                conviertefecha();
                ModificaPaciente();
            }
        }
        public void limpiar()
        {
            txtNom.Text = "";
            txtCed.Text = "";
            txtCel.Text = "";
            dtp.Text = "";
            txtEmail.Text = "";
            txtDir.Text = "";

            cbbSeguro.Text = "";
            rbF.Checked = false;
            rbM.Checked = false;
            linkLabel1.Text = "Editar Paciente";
            dtp.Enabled = false;
            txtNom.Enabled = false;
            txtCed.Enabled = false;
            txtDir.Enabled = false;
            txtCel.Enabled = false;
            txtEmail.Enabled = false;
            txtEmail2.Enabled = false;
            cbbSeguro.Enabled = false;
            rbF.Enabled = false;
            rbM.Enabled = false;
            btnSav.Visible = false;

        }
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;


                fecha1 = dtp.Value;

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

        private void rbF_CheckedChanged(object sender, EventArgs e)
        {
            if (rbF.Checked == true)
            {
                rbM.Checked = false;
                Sex = "Femenino";
            }
        }

        private void rbM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbM.Checked == true)
            {
                rbF.Checked = false;
                Sex = "Masculino";
            }
        }

        public void UpdateAfecciones()
        {
            using (var con = new SqlConnection(conect))
            {
                try { 
                string sql = "update afecciones set afAfecc = ";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Registro Actualizado!");
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

        private void txtObs2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void txtAfecciones_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;

            }
        }

        private void txtMedicamentos_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;

            }
        }

        private void txtAlergias_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;

            }
        }

        private void txtCirugias_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;

            }
        }

        private void txtCirugiaPlas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;

            }
        }

        private void txtMesoHidro_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;

            }
        }

        private void txtToxiBot_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
 
            }
        }

        private void txtRellenos_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
    
            }
        }

        private void btnCanc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtNom.Focus();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void rbF_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                rbM.Focus();
            }
        }

        private void rbM_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtNom.Focus();
            }
        }

        private void txtNom_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCed.Focus();
            }
        }

        private void txtAp_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCed.Focus();
            }
        }

        private void txtCed_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                dtp.Focus();
            }
        }

        private void dtp_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtDir.Focus();
            }
        }

        private void txtNac_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                cbbSeguro.Focus();
            }
        }

        private void cbbEC_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
         
        }

        private void txtCel_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtDir.Focus();
            }
        }

        private void txtEmail_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCel.Focus();
            }
        }

        private void cbbSeguro_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnSav.Focus();
            }
        }

        private void txtTel_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCel.Focus();
            }
        }

        private void txtSeg_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void txtFam_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void txtPar_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
         
           
        }

        private void txtTelf_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnSav.Focus();
            }

        }

        private void btnUp_ParentChanged(object sender, EventArgs e)
        {

        }

        private void btnUp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
            }

        }

        private void cbbSeguro_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbbSeguro_DropDown(object sender, EventArgs e)
        {

            using (var con = new SqlConnection(conect))
            {
                try { 
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (segSeguro) as Seguros from tbSeguros order by segseguro", con);

                da.Fill(ds, "Seguros");
                cbbSeguro.DataSource = ds.Tables[0].DefaultView;
                cbbSeguro.ValueMember = "Seguros";
                cbbSeguro.Text = "Seleccione el Seguro";

                con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }

        private void cbbSeguro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbEC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void rbF_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbF.Checked == true)
            {
                rbM.Checked = false;
                Sex = "Femenino";
            }
        }

        private void rbM_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbM.Checked == true)
            {
                rbF.Checked = false;
                Sex = "Masculino";
            }
        }

        private void txtNac_PreviewKeyDown_2(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtEmail.Focus();
            }
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            conviertefecha();
        }

        private void txtCed_PreviewKeyDown_2(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                dtp.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           
        }

        public void SaveLog()
        {
            Logs log = new Logs();
            log.Accion = "Modificacion al Paciente ID: "+PacID+", Nombre:" + txtNom.Text + "";
            log.Form = "Gestion de Citas";
            log.SaveLog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void dtp_PreviewKeyDown_2(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtEmail.Focus();
            }
        }

        private void cbbRef_DropDown(object sender, EventArgs e)
        {
           using (var con = new SqlConnection(conect))
                {
                    con.Open();
                    DataSet ds = new DataSet();

                    SqlDataAdapter da = new SqlDataAdapter("Select (refNom) as Referidos from tbReferidos order by refNom", con);

                    da.Fill(ds, "Referidos");
                    cbbRef.DataSource = ds.Tables[0].DefaultView;
                    cbbRef.ValueMember = "Referidos";



                    con.Close();
               
            }
        }

        private void btnSav_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {

                DialogResult resulta = MessageBox.Show("Esta seguro que desea modificar el paciente: " + txtNom.Text + " ?", "Modificar Datos", MessageBoxButtons.YesNo);
                if (resulta == DialogResult.Yes)
                {
                    conviertefecha();
                    ModificaPaciente();

                }
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }


