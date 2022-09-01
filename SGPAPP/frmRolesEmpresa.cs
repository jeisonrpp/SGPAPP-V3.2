using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmRolesEmpresa : Form
    {
        public frmRolesEmpresa()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        String cambiada1;
        String Empresa;
        int EmpresaID;
        public int UserID;
        public String User;
        bool Exist;
        Logs log = new Logs();
        public void GetEmpresa()
        {
            using (var con = new SqlConnection(conect))
            {
                int Rows;
                Rows = radGridView5.RowCount - 1;
                con.Open();
                //cmd = new SqlCommand("select DISTINCt(a.pEmpresa) as [Empresa], a.pFechareg as [Fecha Registro] from tbPacientes a  where a.pEmpresa IS NOT NULL ", con);
                cmd = new SqlCommand("select distinct emid as [ID], emNom as [Empresas] from tbEmpresas order by emnom", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Paciente");
                radGridView5.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                this.radGridView5.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                radGridView5.Columns[0].IsVisible = false;
                con.Close();
            }
        }
        public void GetUserEmpresa()
        {
            using (var con = new SqlConnection(conect))
            {
                int Rows;
                Rows = radGridView1.RowCount - 1;
                con.Open();
                //cmd = new SqlCommand("select DISTINCt(a.pEmpresa) as [Empresa], a.pFechareg as [Fecha Registro] from tbPacientes a  where a.pEmpresa IS NOT NULL ", con);
                cmd = new SqlCommand("select  erol_emid as [ID], emNom as [Empresas] from tbEmpresas inner join tbrolesempresa on emid = erol_emid where erol_uid = "+UserID+" order by emnom", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Paciente");
                radGridView1.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                radGridView1.Columns[0].IsVisible = false;
                con.Close();
            }
        }
        private void frmRolesEmpresa_Load(object sender, EventArgs e)
        {
            GetEmpresa();
            GetUserEmpresa();
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
       
                conviertefecha();
                foreach (var item in radGridView5.SelectedRows)
                {
                    Empresa = item.Cells["Empresas"].Value.ToString();
                    EmpresaID = (int)item.Cells["ID"].Value;
              
                }
            if (Empresa != null)
            {
                if (radGridView1.RowCount >= 1)
                {
                    for (int i = 0; i < radGridView1.RowCount; i++)
                    {
                        if (Convert.ToString(radGridView1.Rows[i].Cells["Empresas"].Value) == Empresa)

                        {
                            MessageBox.Show("Esta Empresa ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Exist = true;
                            break;
                        }
                        else

                        {
                            Exist = false;
                        }
                    }
                }

                if (Exist == false)
                {

                    dgbAdd.Rows.Add(UserID, EmpresaID, cambiada1);
                    radGridView1.Rows.Add(EmpresaID, Empresa);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            conviertefecha();
            foreach (var item in radGridView1.SelectedRows)
            {
                EmpresaID = (int)item.Cells["ID"].Value;
                Empresa = item.Cells["Empresas"].Value.ToString();

            }
            if (Empresa != null)
            {
                for (int v = 0; v < radGridView1.Rows.Count; v++)
                {
                    if ((string)radGridView1.Rows[v].Cells["Empresas"].Value == Empresa)
                    {
                        radGridView1.Rows.RemoveAt(v);
                        v--;
                    }
                }
                if (dgbAdd.RowCount < 1)
                {
                    dgbRemove.Rows.Add(UserID, EmpresaID, cambiada1, UserCache.Usuario);
                }
                else
                {
                    for (int i = 0; i < dgbAdd.RowCount; i++)
                    {
                        if ((int)dgbAdd.Rows[i].Cells["emid"].Value == EmpresaID/* && (string)dataGridView1.Rows[i].Cells["Action"].Value == "Add"*/)
                        {
                            dgbAdd.Rows.RemoveAt(i);
                            break;
                        }
                        else
                        {

                            dgbRemove.Rows.Add(UserID, EmpresaID, cambiada1, UserCache.Usuario);
                            break;
                        }

                    }
                }
            }
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            dgbAdd.Rows.Clear();
            dgbRemove.Rows.Clear();
            GetUserEmpresa();
            GetEmpresa();
        }

        private void btnSav_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Esta de seguro que desea aplicar estos cambios al usuario: " + User + "?", "Configuracion Roles Empresas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                try
                {
                    using (var con = new SqlConnection(conect))
                    {
                        if (dgbAdd.RowCount >= 1)
                        {
                            SqlCommand AddRoles = new SqlCommand("Insert into tbrolesempresa values (@Userid, @emid, @Fecha, @User)", con);
                            con.Open();

                            foreach (DataGridViewRow row in dgbAdd.Rows)
                            {
                                AddRoles.Parameters.Clear();
                                AddRoles.Parameters.AddWithValue("@Userid", Convert.ToString(row.Cells["uid3"].Value));
                                AddRoles.Parameters.AddWithValue("@emid", Convert.ToString(row.Cells["emid"].Value));
                                AddRoles.Parameters.AddWithValue("@Fecha", Convert.ToString(row.Cells["fecha3"].Value));
                                AddRoles.Parameters.AddWithValue("@User", UserCache.Usuario);
                                AddRoles.ExecuteNonQuery();
                                con.Close();

                               
                                log.Accion = "Rol de Empresa: "+ Convert.ToString(row.Cells["emid"].Value) + " Agregados al Usuario: " + UserCache.Usuario + "";
                                log.Form = "Login";
                                log.SaveLog();
                            }
                        }
                        if (dgbRemove.RowCount >= 1)
                        {
                            foreach (DataGridViewRow row in dgbRemove.Rows)
                            {
                                string sql = "delete from tbrolesempresa where erol_uid = " + Convert.ToString(row.Cells["uid2"].Value) + " and erol_emid= " + Convert.ToString(row.Cells["idempresa2"].Value) + "";
                                SqlCommand cmd = new SqlCommand(sql, con);
                                cmd.CommandType = CommandType.Text;
                                con.Open();

                                int i = cmd.ExecuteNonQuery();
                                con.Close();
                                log.Accion = "Rol de Empresa: " + Convert.ToString(row.Cells["emid"].Value) + " Eliminados al Usuario: " + UserCache.Usuario + "";
                                log.Form = "Login";
                                log.SaveLog();
                            }
                        }
                    }
                    MessageBox.Show("Cambios Aplicados de manera satisfactoria", "Configuracion Roles Empresas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgbAdd.Rows.Clear();
                    dgbRemove.Rows.Clear();
                    GetUserEmpresa();
                    GetEmpresa();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void radGridView5_SelectionChanged(object sender, EventArgs e)
        {
           
        }
    }
}
