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
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        public int Userid= 1;
        public String User;
        int roleid;
        String Role;
        String cambiada1;
        String Accion;
        String RoleType;
        int selectedIndex;
        String Desc;
        bool Exist = false;
        Logs log = new Logs();
        public void GetRoles()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetRoles", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@parametro", "roles");
                    da.SelectCommand.Parameters.AddWithValue("@userid", Userid);       
                    da.Fill(dt);
                    this.radGridView5.DataSource = dt;
                    this.radGridView5.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    radGridView5.MasterTemplate.AutoExpandGroups = true;
                    radGridView5.Columns[0].IsVisible = false;
                    //if (radGridView5.Columns[0].Name == "commandColumn3")
                    //{
                    //    radGridView5.Columns.Move(0, 4);
                    //}
                    //radGridView5.Columns[5].IsVisible = false;
                    //radGridView5.Columns[6].IsVisible = false;
                    con.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }

        }
        public void GetRolesUsuarios()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter das = new SqlDataAdapter("spGetRoles", con);
                    DataTable dts = new DataTable();
                    das.SelectCommand.CommandType = CommandType.StoredProcedure;
                    das.SelectCommand.Parameters.AddWithValue("@parametro", 'j');
                    das.SelectCommand.Parameters.AddWithValue("@userid", Userid);
                    das.Fill(dts);
                    this.radGridView1.DataSource = dts;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    //if (radGridView5.Columns[0].Name == "commandColumn3")
                    //{
                    //    radGridView5.Columns.Move(0, 4);
                    //}
                    radGridView1.Columns[0].IsVisible = false;
                    //radGridView5.Columns[6].IsVisible = false;
                    con.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }

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
        private void frmRoles_Load(object sender, EventArgs e)
        {
            GetRoles();
            GetRolesUsuarios();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
         
                conviertefecha();
                foreach (var item in radGridView5.SelectedRows)
                {
                    Role = item.Cells["Rol"].Value.ToString();
                    roleid = (int)item.Cells["ID"].Value;
                    RoleType = (string)item.Cells["Tipo de Rol"].Value;
                }
            if (Role != null)
            {
                //for (int v = 0; v < radGridView5.Rows.Count; v++)
                //{
                //    if ((int)radGridView5.Rows[v].Cells["ID"].Value == roleid)
                //    {
                //        radGridView5.Rows.RemoveAt(v);
                //        v--; 
                //    }
                //}
                if (radGridView1.RowCount >= 1)
                {
                    for (int i = 0; i < radGridView1.RowCount; i++)
                    {
                        if (Convert.ToString(radGridView1.Rows[i].Cells["rol"].Value) == Role)

                        {
                            MessageBox.Show("Este rol ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    dgbAdd.Rows.Add(Userid, roleid, cambiada1, UserCache.Usuario);
                    radGridView1.Rows.Add(roleid, Role, RoleType);
                }

            }
        }

        private void radGridView5_SelectionChanged(object sender, EventArgs e)
        {

            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            conviertefecha();
            foreach (var item in radGridView1.SelectedRows)
            {
                roleid = (int)item.Cells["ID"].Value;
                Role = item.Cells["Rol"].Value.ToString();
                RoleType = (string)item.Cells["Tipo de Rol"].Value;
            }
            if (Role != null)
            {
                for (int v = 0; v < radGridView1.Rows.Count; v++)
                {
                    if ((string)radGridView1.Rows[v].Cells["rol"].Value == Role)
                    {
                        radGridView1.Rows.RemoveAt(v);
                        v--;
                    }
                }
                if (dgbAdd.RowCount < 1)
                {
                    dgbRemove.Rows.Add(Userid, roleid, cambiada1, UserCache.Usuario);
                }
                else
                {
                    for (int i = 0; i < dgbAdd.RowCount; i++)
                    {
                        if ((int)dgbAdd.Rows[i].Cells["rolid"].Value == roleid/* && (string)dataGridView1.Rows[i].Cells["Action"].Value == "Add"*/)
                        {
                            dgbAdd.Rows.RemoveAt(i);
                            break;
                        }
                        else
                        {

                            dgbRemove.Rows.Add(Userid, roleid, cambiada1, UserCache.Usuario);
                            break;
                        }

                    }
                }

            }
        }
        private void btnCanc_Click(object sender, EventArgs e)
        {
            GetRoles();
            GetRolesUsuarios();
            dgbAdd.Rows.Clear();
            dgbRemove.Rows.Clear();
        }

        private void btnSav_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Esta de seguro que desea aplicar estos cambios al usuario: " + User + "?", "Configuracion Roles", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                try
                {
                    using (var con = new SqlConnection(conect))
                    {
                        if (dgbAdd.RowCount >= 1)
                        {
                            SqlCommand AddRoles = new SqlCommand("Insert into tbuserroles values (@Userid, @Rolid, @Fecha, @User)", con);
                            con.Open();

                            foreach (DataGridViewRow row in dgbAdd.Rows)
                            {
                                AddRoles.Parameters.Clear();
                                AddRoles.Parameters.AddWithValue("@Userid", Convert.ToString(row.Cells["uid"].Value));
                                AddRoles.Parameters.AddWithValue("@Rolid", Convert.ToString(row.Cells["rolid"].Value));
                                AddRoles.Parameters.AddWithValue("@Fecha", Convert.ToString(row.Cells["fecha"].Value));
                                AddRoles.Parameters.AddWithValue("@User", Convert.ToString(row.Cells["user"].Value));
                                AddRoles.ExecuteNonQuery();
                             
                                log.Accion = "Rol: " + Convert.ToString(row.Cells["rolid"].Value) + " Agregado al Usuario: " + UserCache.Usuario + "";
                                log.Form = "Login";
                                log.SaveLog();
                            }
                            con.Close();

                        }
                        if (dgbRemove.RowCount >= 1)
                        {
                            foreach (DataGridViewRow row in dgbRemove.Rows)
                            {
                                string sql = "delete from tbuserroles where usr_rolid = " + Convert.ToString(row.Cells["rolid2"].Value) + " and usr_uid= " + Convert.ToString(row.Cells["uid2"].Value) + "";
                                SqlCommand cmd = new SqlCommand(sql, con);
                                cmd.CommandType = CommandType.Text;
                                con.Open();

                                int i = cmd.ExecuteNonQuery();
                                con.Close();
                                log.Accion = "Rol: " + Convert.ToString(row.Cells["rolid2"].Value) + " Eliminado al Usuario: " + UserCache.Usuario + "";
                                log.Form = "Login";
                                log.SaveLog();
                            }
                        }
                    }

                    MessageBox.Show("Cambios Aplicados de manera satisfactoria", "Configuracion Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetRoles();
                    GetRolesUsuarios();
                    dgbAdd.Rows.Clear();
                    dgbRemove.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            }

    }
}
