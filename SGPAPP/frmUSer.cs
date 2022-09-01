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
    public partial class frmUSer : Form
    {
        public frmUSer()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn3 = new GridViewCommandColumn();
            commandColumn3.Name = "commandColumn3";
            commandColumn3.UseDefaultText = true;
            commandColumn3.Image = Properties.Resources.icons8_checkmark_16;
            commandColumn3.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn3.FieldName = "select";
            commandColumn3.HeaderText = "Seleccionar";
            commandColumn3.AllowFiltering = true;
            radGridView5.MasterTemplate.Columns.Add(commandColumn3);
            radGridView5.CommandCellClick += new CommandCellClickEventHandler(radGridView5_CommandCellClick);
        }

       
        private void radGridView5_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            //MessageBox.Show(e.Row.Cells["Usuario"].Value.ToString());
       
            UserID = (int)e.Row.Cells["ID"].Value;
            txtNom.Text = (string)e.Row.Cells["Nombre"].Value;
            txtPass.Text = (string)e.Row.Cells["Password"].Value.ToString();
            Password = (byte[])e.Row.Cells["Password"].Value;
            saltold = (byte[])e.Row.Cells["Salt"].Value;
            txtCed.Text = (string)e.Row.Cells["Cedula"].Value;
            txtUser.Text = (string)e.Row.Cells["Usuario"].Value;
            cbbNivel.Text = (string)e.Row.Cells["Nivel"].Value;
            cbbStatus.Text = (string)e.Row.Cells["Estado"].Value;
            btnSav.Visible = false;
            btnUpd.Visible = true;
            btnDel.Enabled = true;
            btnRoles.Enabled = true;
            btnEmpresa.Enabled = true;
        }

        private void frmUSer_Load(object sender, EventArgs e)
        {
           
            cbbNivel.Text = "Seleccione el Nivel";
            cbbStatus.Text = "Seleccione el Estado";
            GetData();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string cambiada1;
        int UserID;
        byte[] Password;
        byte[] saltold;
        public void GetData()
        {
            try
            {
                using (var con = new SqlConnection(conect))
                {
     
                    con.Open();
                                     
                    SqlDataAdapter da = new SqlDataAdapter("spGetUsuarios", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);
                    da.Fill(dt);
                    this.radGridView5.DataSource = dt;
                    this.radGridView5.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    
                    if(radGridView5.Columns[0].Name=="commandColumn3")
                    {
                        radGridView5.Columns.Move(0, 9);

                    }
                 
                    radGridView5.Columns[4].IsVisible = false;
                    radGridView5.Columns[8].IsVisible = false;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Seguro quiere eliminar el Usuario: " + txtNom.Text + " ?", "Eliminar Usuario?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                String Sql = "delete from tbUsuarios where uID = '" + UserID + "'";
                SqlConnection con = new SqlConnection(conect);
                SqlCommand cmd = new SqlCommand(Sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex);
                }
                finally
                {
                    con.Close();
                    DateTime fechas1 = DateTime.Now;
                    String days = fechas1.Day.ToString();
                    String mess = fechas1.Month.ToString();
                    String years = fechas1.Year.ToString();
                    string cambiadas1 = years + "-" + mess + "-" + days;
                    String Hora = DateTime.Now.ToString("hh:mm");


                    string Sql2 = "insert into tbLogs(logFecha, logHora, logForm, logAccion, logUser) values ('" + cambiadas1 + "', '" + Hora + "', 'Eliminiacion de Usuarios', 'Usuario: " + txtUser.Text + " Eliminado','" + UserCache.LoginName + "')";
                    // con = new SqlConnection(cs.ConnectionString);
                    cmd = new SqlCommand(Sql2, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                        Limpiar();
                        btnDel.Enabled = false;
                        btnRoles.Enabled = false;
                        btnEmpresa.Enabled = false;
                        btnSav.Visible = true;
                        btnUpd.Visible = false;
                        GetData();
                    }
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
               
            }
        }

        private void dataGridView3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

        private void btnMdf_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(conect))
            {               
                  byte []  salt = clsEncrypt.GenerateSalt();
                var hashedPassword = clsEncrypt.HashPasswordWithSalt(Encoding.UTF8.GetBytes(txtPass.Text), salt);
            
                string sql = "update tbUsuarios set uNombre = '" + txtNom.Text + "', uCedula= '" + txtCed.Text + "', uUser= '" + txtUser.Text + "', uPassword= @pass , uLevel= '" + cbbNivel.Text + "', ustatus= '" + cbbStatus.Text + "' , uSalt= @salt where uid = '" + UserID + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                if (txtPass.Text != Password.ToString())
                {
                    cmd.Parameters.Add("@salt", SqlDbType.VarBinary).Value = salt;
                    cmd.Parameters.Add("@pass", SqlDbType.VarBinary).Value = hashedPassword;
                }
                else
                {
                    cmd.Parameters.Add("@salt", SqlDbType.VarBinary).Value = saltold;
                    cmd.Parameters.Add("@pass", SqlDbType.VarBinary).Value = Password;
                }
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Usuario Actualizado Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                }
                finally
                {
                    con.Close();
                    DateTime fechas1 = DateTime.Now;
                    String days = fechas1.Day.ToString();
                    String mess = fechas1.Month.ToString();
                    String years = fechas1.Year.ToString();
                    string cambiadas1 = years + "-" + mess + "-" + days;
                    String Hora = DateTime.Now.ToString("hh:mm");


                    string Sql = "insert into tbLogs(logFecha, logHora, logForm, logAccion, logUser) values ('" + cambiadas1 + "', '" + Hora + "', 'Modificacion de Usuarios', 'Usuario: " + txtUser.Text + " Modificado','" + UserCache.LoginName + "')";
                    // con = new SqlConnection(cs.ConnectionString);
                    cmd = new SqlCommand(Sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                        Limpiar();
                        btnDel.Enabled = false;
                        btnRoles.Enabled = false;
                        btnEmpresa.Enabled = false;
                        btnSav.Visible = true;
                        btnUpd.Visible = false;
                        GetData();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] salt = clsEncrypt.GenerateSalt();
                var hashedPassword = clsEncrypt.HashPasswordWithSalt(Encoding.UTF8.GetBytes(txtPass.Text), salt);

                if (txtNom.Text == "" || txtCed.Text == "" || txtUser.Text == "" || txtPass.Text == "")
                {
                    MessageBox.Show("Debe completar los campos faltantes");
                }
                else
                {
                    using (var con = new SqlConnection(conect))
                    {
                        con.Open();
                        string ct = "select * from tbUsuarios where uCedula = '" + txtCed.Text + "' or uUser = '" + txtUser.Text + "'";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            MessageBox.Show("Este Usuario ya esta registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                            return;

                        }


                        else if ((rdr != null))
                        {
                            con.Close();
                            conviertefecha();
                            string Sql = "insert into tbUsuarios(uNombre, uCedula, uUser, uPassword, uLevel, uFecha, ustatus, usalt) values ('" + txtNom.Text + "', '" + txtCed.Text + "', '" + txtUser.Text + "', @Pass ,'" + cbbNivel.Text + "', '" + cambiada1 + "', '" + cbbStatus.Text + "', @Salt)";
                            // con = new SqlConnection(cs.ConnectionString);
                            cmd = new SqlCommand(Sql, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@salt", SqlDbType.VarBinary).Value = salt;
                            cmd.Parameters.Add("@pass", SqlDbType.VarBinary).Value = hashedPassword;

                            con.Open();
                            try
                            {
                                int i = cmd.ExecuteNonQuery();
                                MessageBox.Show("Usuario Creado Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error:" + ex.ToString());
                            }
                            finally
                            {
                                con.Close();
                                SaveLog();
                                Limpiar();
                                GetData();
                            }
                        }
                    }
                }
            }
             
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
        }
        public void SaveLog()
        {
            Logs log = new Logs();
            log.Accion = "Usuario: " + txtUser.Text + " Creado";
            log.Form = "Creacion de Usuarios";
            log.SaveLog();

        }
        public void Limpiar()
        {
            txtNom.Text = "";
            txtUser.Text = "";
            txtCed.Text = "";
            txtPass.Text = "";
            cbbNivel.Text = "Seleccione el Nivel";
            cbbStatus.Text = "Seleccione el Estado";
            UserID = 0;
            btnDel.Enabled = false;
            btnSav.Visible = true;
            btnUpd.Visible = false;
            btnRoles.Enabled = false;
            btnEmpresa.Enabled = false;
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

        private void txtConsultaR_Leave(object sender, EventArgs e)
        {
            if (txtConsultaR.Text == "")
            {
                txtConsultaR.Text = "Digite Nombre del Usuario";
                txtConsultaR.ForeColor = Color.Silver;


            }
        }

        private void txtConsultaR_Enter(object sender, EventArgs e)
        {
            if (txtConsultaR.Text == "Digite Nombre del Usuario")
            {
                txtConsultaR.Text = "";
                txtConsultaR.ForeColor = Color.MidnightBlue;
            }
        }

        private void txtConsultaR_TextChanged(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(conect))
            {

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("spGetUsuarios", con);
                DataTable dt = new DataTable();
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nombre", txtConsultaR.Text);
                da.Fill(dt);
                this.radGridView5.DataSource = dt;
                this.radGridView5.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(conect))
            {
                byte[] salt = clsEncrypt.GenerateSalt();
                var hashedPassword = clsEncrypt.HashPasswordWithSalt(Encoding.UTF8.GetBytes(txtPass.Text), salt);

                string sql = "update tbUsuarios set uNombre = '" + txtNom.Text + "', uCedula= '" + txtCed.Text + "', uUser= '" + txtUser.Text + "', uPassword= @pass , uLevel= '" + cbbNivel.Text + "', ustatus= '" + cbbStatus.Text + "' , uSalt= @salt where uid = '" + UserID + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                if (txtPass.Text != Password.ToString())
                {
                    cmd.Parameters.Add("@salt", SqlDbType.VarBinary).Value = salt;
                    cmd.Parameters.Add("@pass", SqlDbType.VarBinary).Value = hashedPassword;
                }
                else
                {
                    cmd.Parameters.Add("@salt", SqlDbType.VarBinary).Value = saltold;
                    cmd.Parameters.Add("@pass", SqlDbType.VarBinary).Value = Password;
                }
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Usuario Actualizado Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                }
                finally
                {
                    con.Close();
                    DateTime fechas1 = DateTime.Now;
                    String days = fechas1.Day.ToString();
                    String mess = fechas1.Month.ToString();
                    String years = fechas1.Year.ToString();
                    string cambiadas1 = years + "-" + mess + "-" + days;
                    String Hora = DateTime.Now.ToString("hh:mm");


                    string Sql = "insert into tbLogs(logFecha, logHora, logForm, logAccion, logUser) values ('" + cambiadas1 + "', '" + Hora + "', 'Modificacion de Usuarios', 'Usuario: " + txtUser.Text + " Modificado','" + UserCache.LoginName + "')";
                    // con = new SqlConnection(cs.ConnectionString);
                    cmd = new SqlCommand(Sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                        Limpiar();
                        btnDel.Enabled = false;
                        btnRoles.Enabled = false;
                        btnEmpresa.Enabled = false;
                        btnSav.Visible = true;
                        btnUpd.Visible = false;
                        GetData();
                    }
                }
            }
        }

        private void btnSav_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] salt = clsEncrypt.GenerateSalt();
                var hashedPassword = clsEncrypt.HashPasswordWithSalt(Encoding.UTF8.GetBytes(txtPass.Text), salt);

                if (txtNom.Text == "" || txtCed.Text == "" || txtUser.Text == "" || txtPass.Text == "")
                {
                    MessageBox.Show("Debe completar los campos faltantes");
                }
                else
                {
                    using (var con = new SqlConnection(conect))
                    {
                        con.Open();
                        string ct = "select * from tbUsuarios where uCedula = '" + txtCed.Text + "' or uUser = '" + txtUser.Text + "'";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            MessageBox.Show("Este Usuario ya esta registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                            return;

                        }


                        else if ((rdr != null))
                        {
                            con.Close();
                            conviertefecha();
                            string Sql = "insert into tbUsuarios(uNombre, uCedula, uUser, uPassword, uLevel, uFecha, ustatus, usalt) values ('" + txtNom.Text + "', '" + txtCed.Text + "', '" + txtUser.Text + "', @Pass ,'" + cbbNivel.Text + "', '" + cambiada1 + "', '" + cbbStatus.Text + "', @Salt)";
                            // con = new SqlConnection(cs.ConnectionString);
                            cmd = new SqlCommand(Sql, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@salt", SqlDbType.VarBinary).Value = salt;
                            cmd.Parameters.Add("@pass", SqlDbType.VarBinary).Value = hashedPassword;

                            con.Open();
                            try
                            {
                                int i = cmd.ExecuteNonQuery();
                                MessageBox.Show("Usuario Creado Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error:" + ex.ToString());
                            }
                            finally
                            {
                                con.Close();
                                SaveLog();
                                Limpiar();
                                GetData();
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Seguro quiere eliminar el Usuario: " + txtNom.Text + " ?", "Eliminar Usuario?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                String Sql = "delete from tbUsuarios where uID = '" + UserID + "'";
                SqlConnection con = new SqlConnection(conect);
                SqlCommand cmd = new SqlCommand(Sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex);
                }
                finally
                {
                    con.Close();
                    DateTime fechas1 = DateTime.Now;
                    String days = fechas1.Day.ToString();
                    String mess = fechas1.Month.ToString();
                    String years = fechas1.Year.ToString();
                    string cambiadas1 = years + "-" + mess + "-" + days;
                    String Hora = DateTime.Now.ToString("hh:mm");


                    string Sql2 = "insert into tbLogs(logFecha, logHora, logForm, logAccion, logUser) values ('" + cambiadas1 + "', '" + Hora + "', 'Eliminiacion de Usuarios', 'Usuario: " + txtUser.Text + " Eliminado','" + UserCache.LoginName + "')";
                    // con = new SqlConnection(cs.ConnectionString);
                    cmd = new SqlCommand(Sql2, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                        Limpiar();
                        btnDel.Enabled = false;
                        btnSav.Visible = true;
                        btnUpd.Visible = false;
                        btnRoles.Enabled = false;
                        btnEmpresa.Enabled = false;
                        GetData();
                    }
                }
            }
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            txtNom.Text = "";
            txtUser.Text = "";
            txtCed.Text = "";
            txtPass.Text = "";
            cbbNivel.Text = "Seleccione el Nivel";
            cbbStatus.Text = "Seleccione el Estado";
            UserID = 0;
            btnDel.Enabled = false;
            btnSav.Visible = true;
            btnUpd.Visible = false;
            btnRoles.Enabled = false;
            btnEmpresa.Enabled = false;
        }

        private void radGridView5_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            if (radGridView5.Columns[8].Name == "commandColumn3")
            {
                radGridView5.Columns.Remove(radGridView5.Columns[8]);
            }
           

        }

        private void radGridView5_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            
        }

        private void cbbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            frmRoles r = new frmRoles();
            r.Userid = UserID;
            r.User = txtUser.Text;
            r.ShowDialog();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            frmRolesEmpresa es = new frmRolesEmpresa();
            es.UserID = UserID;
            es.User = txtUser.Text;
            es.ShowDialog();
        }
    }
}
