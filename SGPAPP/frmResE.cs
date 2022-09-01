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
using System.Runtime;
using System.Runtime.InteropServices;
using Telerik.WinControls.UI;
using System.Text.RegularExpressions;

namespace SGPAPP
{
    public partial class frmResE : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;
        Logs log = new Logs();

        public frmResE()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn4 = new GridViewCommandColumn();
            commandColumn4.Name = "commandColumn4";
            commandColumn4.UseDefaultText = true;
            commandColumn4.Image = (Image)(new Bitmap(Properties.Resources.icons8_delete_35, new Size(25, 25)));
            commandColumn4.ImageAlignment = ContentAlignment.MiddleCenter;

            commandColumn4.FieldName = "select";
            commandColumn4.HeaderText = "Eliminar";
            radGridView1.MasterTemplate.Columns.Add(commandColumn4);
            radGridView1.CommandCellClick += new CommandCellClickEventHandler(radGridView1_CommandCellClick);
        }

        private void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (this.radGridView1.Rows.Count > 0)
                {

                    Paciente = this.radGridView1.CurrentRow.Cells[0].Value.ToString();
                    Cedula = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
                    radGridView1.Rows.RemoveAt(this.radGridView1.SelectedRows[0].Index);
                    dgbDelete.Rows.Add(Paciente, Cedula);

                    if (dgbAdd.RowCount >= 1)
                    {
                        for (int i = 0; i < dgbAdd.RowCount; i++)
                        {
                            if (Convert.ToString(dgbAdd.Rows[i].Cells["Column5"].Value) == Paciente && Convert.ToString(dgbAdd.Rows[i].Cells["Column6"].Value) == Cedula)
                            {
                                dgbAdd.Rows.Remove(dgbAdd.Rows[i]);
                            }

                        }
                    }
                    if (dgbUpd.RowCount >= 1)
                    {
                        for (int i = 0; i < dgbUpd.RowCount; i++)
                        {
                            if (Convert.ToString(dgbUpd.Rows[i].Cells["Columnp"].Value) == Paciente && Convert.ToString(dgbUpd.Rows[i].Cells["Columnc"].Value) == Cedula)
                            {
                                dgbUpd.Rows.Remove(dgbUpd.Rows[i]);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione el registro que desea eliminar de la lista.");
            }
        }

        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        bool Pruebas;
        bool Resultados;
        int ID;
        String contraseniaAleatoria;
        String pass;
        String pEmail;
        String Paciente;
        String Cedula;
        String PacienteId;
        String Fechan;
        String Seguro;
        String Sexo;
        String cambiada1;
        String cambiada2;
        bool Pnew = false;
        SqlDataReader rdr = null;
        DateTime Fecha = DateTime.Now;
        public int LotID;
       public bool esLote = false;
        String CED = "";

        private void txtEmpresa_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                using (var con = new SqlConnection(conect))
                {
                    string sql = "select emNom as [Empresa], emDir as [Direccion], emEmail as [Email], emContacto as [Contacto], emPruebas as [Pruebas], emResultados as [Resultados] from tbEmpresas where emNom = '" + txtEmpresa.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        con.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Resultados = (bool)reader[4];
                            Pruebas = (bool)reader[5];

                            if (Resultados == true && Pruebas == true || Resultados == false && Pruebas == false)
                            {
                                txtEmpresa.Text = reader[0].ToString();
                                txtDir.Text = reader[1].ToString();
                                txtEmail.Text = reader[2].ToString();
                                txtCel.Text = reader[3].ToString();
                                txtEmpresa.Enabled = false;
                                //GetPacientes();
                                btnSav.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Esta empresa tiene pendiente, pruebas o resultados, debe finalizar estos procesos para poder reiniciarla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se ha encontrado una empresa con este nombre registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        if (con.State == ConnectionState.Open)
                        {
                            con.Dispose();

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
                }
            }
        }
        public void GetPacientes()
        {
            using (var con = new SqlConnection(conect))
            {
                int Rows;
                Rows = dataGridView1.RowCount - 1;
                con.Open();
                cmd = new SqlCommand("SELECT distinct a.pId as [ID], RTRIM(a.pNom) as [Paciente], RTRIM(a.pCed) as [Cedula], RTRIM(a.pFecha) as [Fecha Nacimiento], RTRIM(a.pSeguro) as [Seguro], RTRIM(a.pSex) as [Sexo], RTRIM(a.pEmail) as [Email]  from tbpacientes a inner join tbEmpresas b on a.pEmpresa = b.EmNom where a.pEmpresa = '" + txtEmpresa.Text + "' and a.plotid = "+LotID+"", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Paciente");
                dataGridView1.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                dataGridView1.Columns["ID"].DisplayIndex = 0;
                dataGridView1.Columns["Paciente"].DisplayIndex = 1;
                dataGridView1.Columns["Cedula"].DisplayIndex = 2;
                dataGridView1.Columns["Fecha Nacimiento"].DisplayIndex = 3;
                dataGridView1.Columns["Seguro"].DisplayIndex = 4;
                dataGridView1.Columns["Sexo"].DisplayIndex = 5;
                dataGridView1.Columns["Email"].DisplayIndex = 6;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    Paciente = (string)row.Cells["Paciente"].Value;
                    Cedula = (string)row.Cells["Cedula"].Value;
                    Fechan = (string)row.Cells["Fecha Nacimiento"].Value;
                    Seguro = (string)row.Cells["Seguro"].Value;
                    Sexo = (string)row.Cells["Sexo"].Value;
                    if (row.Cells["Email"].Value == DBNull.Value)
                    {
                        pEmail = "";
                    }
                    else
                    {
                        pEmail = (string)row.Cells["Email"].Value;
                    }
                    radGridView1.Rows.Add(Paciente, Cedula, Fechan, Seguro, Sexo, pEmail);
                }
            }
            }

        private void frmResE_Load(object sender, EventArgs e)
        {
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            txtEmpresa.Select();
            cbbDoc.SelectedIndex = 0;
            cargacbbSeg();
            getEmpresas();
        }
        public void cargacbbSeg()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (segSeguro) as Seguros from tbSeguros order by segseguro", con);

                da.Fill(ds, "Seguros");
                cbbSeguro.DataSource = ds.Tables[0].DefaultView;
                cbbSeguro.ValueMember = "Seguros";
                cbbSeguro.Text = "Seleccione el Seguro";


                con.Close();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
        }
        public void AddPac()
        {
            bool existe = false;

            if (radGridView1.RowCount >= 1)
            {
                for (int i = 0; i < radGridView1.RowCount; i++)
                {
                    if (Convert.ToString(radGridView1.Rows[i].Cells["Column1"].Value) == txtCed.Text && txtCed.Text != "No Aplica")

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
                if (Pnew ==true)
                {
                    radGridView1.Rows.Add(txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtEmail2.Text);
                    dgbUpd.Rows.Add(txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtEmail2.Text);
                    Pnew = false;
                }
                else
                {
                    radGridView1.Rows.Add(txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtEmail2.Text);
                    dgbAdd.Rows.Add(txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtEmail2.Text);
                }
            }
        }

        private void rbF_CheckedChanged(object sender, EventArgs e)
        {
            if (rbF.Checked == true)
            {
                rbM.Checked = false;
                Sexo = "Femenino";
            }
        }

        private void rbM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbM.Checked == true)
            {
                rbF.Checked = false;
                Sexo = "Masculino";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void chkCed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCed.Checked == true)
            {
                txtCed.Mask = "";
                txtCed.Text = "No Aplica";
                txtCed.Enabled = false;
            }
            else
            {
                txtCed.Text = "";
                txtCed.Enabled = true;
            }
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecha.Checked == true)
            {
                txtFecha.Mask = "";
                txtFecha.Text = "No Aplica";
                txtFecha.Enabled = false;
            }
            else
            {
                txtFecha.Mask = "00-00-0000";
                txtFecha.Text = "";
                txtFecha.Enabled = true;
            }
        }

        private void cbbDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDoc.Text == "Cedula")
            {
                txtCed.Mask = "000-0000000-0";
            }
            else
            {
                txtCed.Mask = "";
            }
        }
        public void Fechadehoy()
        {
            try
            {
                DateTime fecha2;


                fecha2 = Fecha;

                String day = fecha2.Day.ToString();
                String mes = fecha2.Month.ToString();
                String year = fecha2.Year.ToString();

                cambiada2 = year + "-" + mes + "-" + day;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;
                if (Fechan == "No Aplica")
                {
                    cambiada1 = "1900-01-01";
                }
                else
                {
                    fecha1 = DateTime.ParseExact(Fechan, "dd-MM-yyyy", null);


                    String day = fecha1.Day.ToString();
                    String mes = fecha1.Month.ToString();
                    String year = fecha1.Year.ToString();

                    if (int.Parse(day) <= 9)
                    {
                        day = "0" + day;
                    }
                    if (int.Parse(mes) <= 9)
                    {
                        mes = "0" + mes;
                    }

                    cambiada1 = year + "-" + mes + "-" + day;
                    contraseniaAleatoria = day + mes + year;
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
               

        }
        public void UpdateEmpresa()
        {
            using (var con = new SqlConnection(conect))
            {
                 
                if (Pruebas == true && Resultados == true)
                {
                    string sql = "update tbEmpresas set emPruebas = 0, emResultados = 0 where emnom = '" + txtEmpresa.Text + "'";

                    SqlCommand cmd = new SqlCommand(sql, con);
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
                        Logs log = new Logs();
                        log.Accion = "Empresa: " + txtEmpresa.Text + " Reiniciada";
                        log.Form = "Reinicio de Empresas";
                        log.SaveLog();
                    }
                }
            }
        }

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void advancedDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.DataGridView7.Columns[e.ColumnIndex].Name == "Select" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.DataGridView7.Rows[e.RowIndex].Cells["Select"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\resourses\check.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.DataGridView7.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.DataGridView7.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;

            }
        }
       
        private void DataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (this.DataGridView7.Columns[e.ColumnIndex].Name == "Select")
                {
                    if (UserCache.EmpresaRoles.Any(item => item.EmpresaRol == (string)this.DataGridView7.Rows[e.RowIndex].Cells["Empresa"].Value) || UserCache.EmpresaRoles.Any(item => item.EmpresaRol == "Todas*"))
                    {
                        txtEmpresa.Text = (string)this.DataGridView7.Rows[e.RowIndex].Cells["Empresa"].Value;
                    txtDir.Text = (string)this.DataGridView7.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                    txtEmail.Text = (string)this.DataGridView7.Rows[e.RowIndex].Cells["Email"].Value;
                    txtCel.Text = (string)this.DataGridView7.Rows[e.RowIndex].Cells["Contacto"].Value;
                    Pruebas = (bool)this.DataGridView7.Rows[e.RowIndex].Cells["Pruebas"].Value;
                    Resultados = (bool)this.DataGridView7.Rows[e.RowIndex].Cells["Resultados"].Value;
                    DataGridView7.Visible = false;
                    groupBox1.Visible = true;
                    btnConsulta.Enabled = true;
                    btnAd.Enabled = true;
                    //GetPacientes();
                    btnSav.Enabled = true;
                    tableLayoutPanel7.Visible = false;
                    }

                    else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                
            }
            }
        }
        public void getEmpresas()
        {
            using (var con = new SqlConnection(conect))
            {
                if (esLote == false)
                {
                    int Rows;
                    Rows = DataGridView7.RowCount - 1;
                    con.Open();
                    //cmd = new SqlCommand("select DISTINCt(a.pEmpresa) as [Empresa], a.pFechareg as [Fecha Registro] from tbPacientes a  where a.pEmpresa IS NOT NULL ", con);
                    cmd = new SqlCommand("select distinct emNom as [Empresa], emDir as [Direccion], emEmail as [Email], emContacto as [Contacto], emPruebas as [Pruebas], emResultados as [Resultados] from tbEmpresas where emnom <> 'Todas*' order by emnom", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "Paciente");
                    DataGridView7.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                    DataGridView7.Columns["Empresa"].DisplayIndex = 0;
                    DataGridView7.Columns["Direccion"].DisplayIndex = 1;
                    DataGridView7.Columns["Email"].DisplayIndex = 2;
                    DataGridView7.Columns["Contacto"].DisplayIndex = 3;
                    DataGridView7.Columns["Pruebas"].Visible = false;
                    DataGridView7.Columns["Resultados"].Visible = false;
                    this.DataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                    con.Close();
                }
                else

                {
                    string sql = "Select emNom , emDir , emEmail , emContacto from tbempresas where emnom = '" + txtEmpresa.Text + "'  ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();


                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtDir.Text = reader[1].ToString();
                        txtEmail.Text = reader[2].ToString();
                        txtCel.Text = reader[3].ToString();
                        DataGridView7.Visible = false;
                        groupBox1.Visible = true;
                        btnConsulta.Enabled = true;
                        btnAd.Enabled = true;
                        GetPacientes();
                        btnSav.Enabled = true;
                        tableLayoutPanel7.Visible = true;
                    }
                    }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (txtConsulta.Text.Length == 0)
                {
                    getEmpresas();
                }
                else
                {
                    try
                    {
                        using (var con = new SqlConnection(conect))
                        {
                            int Rows;
                            Rows = DataGridView7.RowCount - 1;
                            con.Open();
                            //cmd = new SqlCommand("select DISTINCt(a.pEmpresa) as [Empresa], a.pFechareg as [Fecha Registro] from tbPacientes a  where a.pEmpresa IS NOT NULL ", con);
                            cmd = new SqlCommand("select distinct emNom as [Empresa], emDir as [Direccion], emEmail as [Email], emContacto as [Contacto], emPruebas as [Pruebas], emResultados as [Resultados] from tbEmpresas where emnom like '%"+txtConsulta.Text+ "%' and emnom <> 'Todas*' order by emnom ", con);
                            SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                            DataSet myDataSet = new DataSet();
                            myDA.Fill(myDataSet, "Paciente");
                            DataGridView7.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                            DataGridView7.Columns["Empresa"].DisplayIndex = 0;
                            DataGridView7.Columns["Direccion"].DisplayIndex = 1;
                            DataGridView7.Columns["Email"].DisplayIndex = 2;
                            DataGridView7.Columns["Contacto"].DisplayIndex = 3;
                            DataGridView7.Columns["Pruebas"].Visible = false;
                            DataGridView7.Columns["Resultados"].Visible = false;
                            this.DataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


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

        private void txtConsulta_Leave(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "")
            {
                txtConsulta.Text = "Digite Nombre de la Empresa";
                txtConsulta.ForeColor = Color.Silver;
                getEmpresas();
            }
        }

        private void txtConsulta_Enter(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "Digite Nombre de la Empresa")
            {
                txtConsulta.Text = "";
                txtConsulta.ForeColor = Color.MidnightBlue;
            }
        }
        public void GeneraCed()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    if (CED == "")
                    {
                        string sql = "Select MAX(pid) from tbpacientes";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        SqlDataReader reader;
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            CED = reader[0].ToString();
                            CED = Convert.ToString(int.Parse(CED) + 1);
                            Random rced = new Random();
                            string nums = "000000000000000000000000000000";
                            int Longitud = nums.Length;
                            int longi = CED.Length;
                            char caracter;
                            int longitudCed = 11 - longi;
                            Cedula = string.Empty;
                            for (int i = 0; i < longitudCed; i++)
                            {
                                caracter = nums[rced.Next(Longitud)];
                                Cedula += caracter.ToString();

                            }
                            Cedula = Cedula + CED;
                            string result = string.Format("{0:000-0000000-0}", int.Parse(Cedula));
                            Cedula = result;
                        }
                        con.Close();
                    }
                    else
                    {
                        CED = Convert.ToString(int.Parse(CED) + 1);
                        Random rced = new Random();
                        string nums = "000000000000000000000000000000";
                        int Longitud = nums.Length;
                        int longi = CED.Length;
                        char caracter;
                        int longitudCed = 11 - longi;
                        Cedula = string.Empty;
                        for (int i = 0; i < longitudCed; i++)
                        {
                            caracter = nums[rced.Next(Longitud)];
                            Cedula += caracter.ToString();

                        }
                        Cedula = Cedula + CED;
                        string result = string.Format("{0:000-0000000-0}", int.Parse(Cedula));
                        Cedula = result;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }
        public void GeneraCred()
        {
            if (Cedula == "No Aplica")
            {
                GeneraCed();
            }

            if (contraseniaAleatoria == "")
            {
                Random rdn = new Random();
                string caracteres = "1234567890";
                int longitud = caracteres.Length;
                char letra;
                int longitudContrasenia = 8;
                contraseniaAleatoria = string.Empty;
                for (int i = 0; i < longitudContrasenia; i++)
                {
                    letra = caracteres[rdn.Next(longitud)];
                    contraseniaAleatoria += letra.ToString();
                }
            }


            pass = clsEncrypt.GetSHA256(contraseniaAleatoria);


            using (var con = new SqlConnection(conect))
            {
                SqlCommand AddPruebas = new SqlCommand("Insert into tbCredenciales values (@Pacid, @Docid, @Password)", con);
                con.Open();

                AddPruebas.Parameters.Clear();
                AddPruebas.Parameters.AddWithValue("@Pacid", Convert.ToString(PacienteId));
                AddPruebas.Parameters.AddWithValue("@Docid", Cedula);
                AddPruebas.Parameters.AddWithValue("@Password", pass);
                AddPruebas.ExecuteNonQuery();
                con.Close();

            }

        }
        public void cargapruebas()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "Select pid from tbpacientes where pnom = '" + Paciente + "' and pced = '" + Cedula + "'  ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    PacienteId = reader[0].ToString();
                }
                con.Close();

            }
        }
        private void btnSav_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Esta de seguro que desea Reiniciar la empresa: " + txtEmpresa.Text + "?", "Reiniciar Empresa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {                
                using (var con = new SqlConnection(conect))
                {
                    try
                    {                        
                        Fechadehoy();
                        if (esLote == false)                      
                        {
                            LotID = 0;
                            InsertLot();
                        }
                        if (dgbAdd.RowCount >= 1)
                        {                          
                            SqlCommand AddPacientes = new SqlCommand("Insert into tbpacientes values (@pNom, @pCed, @pSex, @pFecha, @pDir, @pCel, @pEmail, @pEmail2, @pSeguro, @pFechareg, @pEmpresa, @Referidor, @preid, @plot)", con);
                            con.Open();
                            //Fechadehoy();
                            foreach (DataGridViewRow row in dgbAdd.Rows)

                            {
                                Paciente = (string)row.Cells["Column5"].Value;
                                Cedula = (string)row.Cells["Column6"].Value;
                                Fechan = (string)row.Cells["Column7"].Value;
                                contraseniaAleatoria = "";
                                conviertefecha();

                                AddPacientes.Parameters.Clear();
                                AddPacientes.Parameters.AddWithValue("@pNom", Convert.ToString(row.Cells["Column5"].Value));
                                AddPacientes.Parameters.AddWithValue("@pCed", Convert.ToString(row.Cells["Column6"].Value));
                                AddPacientes.Parameters.AddWithValue("@pSex", Convert.ToString(row.Cells["Column9"].Value));
                                AddPacientes.Parameters.AddWithValue("@pFecha", cambiada1);
                                AddPacientes.Parameters.AddWithValue("@pDir", txtDir.Text);
                                AddPacientes.Parameters.AddWithValue("@pCel", txtCel.Text);
                                if (Convert.ToString(row.Cells["Email"].Value).Length > 0)
                                {
                                    AddPacientes.Parameters.AddWithValue("@pEmail", Convert.ToString(row.Cells["Email"].Value));
                                }
                                else
                                {
                                    AddPacientes.Parameters.AddWithValue("@pEmail", DBNull.Value);
                                }
                                AddPacientes.Parameters.AddWithValue("@pEmail2", txtEmail.Text);
                                AddPacientes.Parameters.AddWithValue("@pSeguro", Convert.ToString(row.Cells["Column8"].Value));
                                AddPacientes.Parameters.AddWithValue("@pFechareg", cambiada2);
                                AddPacientes.Parameters.AddWithValue("@pEmpresa", txtEmpresa.Text);
                                AddPacientes.Parameters.AddWithValue("@Referidor", DBNull.Value);
                                AddPacientes.Parameters.AddWithValue("@preid", DBNull.Value);
                                AddPacientes.Parameters.AddWithValue("@plot", LotID);
                                AddPacientes.ExecuteNonQuery();
                                cargapruebas();
                                GeneraCred();
 
                                log.Accion = "Paciente: " + Paciente + " Registrado en Empresa: "+txtEmpresa.Text+"";
                                log.Form = "Reinicio de Empresas";
                                log.SaveLog();
                            }



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

                if (dgbDelete.RowCount >= 1)
                {
                    using (var con = new SqlConnection(conect))
                    {

                        foreach (DataGridViewRow row in dgbDelete.Rows)
                        {
                            try
                            {
                                Paciente = (string)row.Cells["Column2"].Value;
                                Cedula = (string)row.Cells["Column3"].Value;
                                string sql = "update tbpacientes set pempresa = null where pnom = '" + Paciente + "' and pced = '" + Cedula + "'";
                                SqlCommand cmd = new SqlCommand(sql, con);
                                cmd.CommandType = CommandType.Text;
                                con.Open();

                                int i = cmd.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                con.Close();
                                return;
                            }
                            finally
                            {
                               
                                log.Accion = "Paciente: " + Paciente + " Eliminado de Empresa: " + txtEmpresa.Text + "";
                                log.Form = "Reinicio de Empresas";
                                log.SaveLog();

                                con.Close();

                            }

                        }
                    }

                }
                if (dgbUpd.RowCount >= 1)
                {
                    using (var con = new SqlConnection(conect))
                    {
                        
                        
                        foreach (DataGridViewRow row in dgbUpd.Rows)
                        {
                            try
                            {
                                Paciente = (string)row.Cells["columnp"].Value;
                                Cedula = (string)row.Cells["columnc"].Value;
                                string sql = "update tbpacientes set pempresa = '" + txtEmpresa.Text + "', plotid =" + LotID + " where pnom = '" + Paciente + "' and pced = '" + Cedula + "'";
                                SqlCommand cmd = new SqlCommand(sql, con);
                                cmd.CommandType = CommandType.Text;
                                con.Open();

                                int i = cmd.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                con.Close();
                                return;
                            }
                            finally
                            {
                            
                                log.Accion = "Paciente: " + Paciente + " Agregado a Empresa: " + txtEmpresa.Text + "";
                                log.Form = "Reinicio de Empresas";
                                log.SaveLog();

                                con.Close();

                            }
                        }

                    }
                }
                //DialogResult resultas = MessageBox.Show("Desea reiniciar esta empresa para asignarle pruebas?", "Reinicio de Empresas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (resultas == DialogResult.Yes)
                //{
                //    UpdateEmpresa();
                //}
                if (esLote == false)
                {
                    log.Accion = "Nuevo Lote: "+LotID+" Generado";
                    log.Form = "Reinicio de Empresas";
                    log.SaveLog();
                }
                else
                {
                    log.Accion = "Lote: "+LotID+" Modificado";
                    log.Form = "Reinicio de Empresas";
                    log.SaveLog();
                }
                MessageBox.Show("Cambios Realizados Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radGridView1.Rows.Clear();
                dgbUpd.Rows.Clear();
                dgbDelete.Rows.Clear();
                dgbAdd.Rows.Clear();
                txtNom.Text = "";
                txtCed.Text = "";
                txtFecha.Text = "";
                txtEmail.Text = "";
                txtEmail2.Text = "";
                rbF.Checked = false;
                rbM.Checked = false;
                chkCed.Checked = false;
                chkFecha.Checked = false;
                btnSav.Enabled = false;
                txtEmpresa.Enabled = false;
                groupBox1.Visible = false;
                btnConsulta.Enabled = false;
                getEmpresas();
                DataGridView7.Visible = true;
                tableLayoutPanel7.Visible = true;
                txtEmpresa.Text = "";
                txtDir.Text = "";
                txtCel.Text = "";
                txtEmail.Text = "";
                btnAd.Enabled = false;
                btnConsulta.Enabled = false;

                if (cbbDoc.Text == "Cedula")
                {
                    txtCed.Mask = "000-0000000-0";
                }
                else
                {
                    txtCed.Mask = "";
                }
                this.DialogResult = DialogResult.OK;
            }
        }
        public void InsertLot()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    SqlCommand AddLote = new SqlCommand("Insert into tbLotesEmpresa values (@lotEmpresa, @lotPruebas, @lotResultados, @lotFechaReg, @lotUsuario, @lotpruebaid) select scope_identity()", con);


                    AddLote.CommandType = CommandType.Text;
                    AddLote.Parameters.AddWithValue("@lotEmpresa", txtEmpresa.Text);
                    AddLote.Parameters.AddWithValue("@lotPruebas", SqlDbType.Bit).Value = false;
                    AddLote.Parameters.AddWithValue("@lotResultados", SqlDbType.Bit).Value = false;
                    AddLote.Parameters.AddWithValue("@lotFechaReg", cambiada2);
                    AddLote.Parameters.AddWithValue("@lotUsuario", UserCache.Usuario);
                    AddLote.Parameters.AddWithValue("@lotpruebaid", DBNull.Value);
                    con.Open();
                    LotID = Convert.ToInt32(AddLote.ExecuteScalar());
                    con.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {

                frmConsultad cd = new frmConsultad();
                cd.ShowDialog();
                if (cd.DialogResult == DialogResult.Yes)
                {
                    if (cd.Empresap.Length > 0 && cd.Empresap != "null")
                    {
                        DialogResult resulta = MessageBox.Show("Este paciente ya esta asociado a la empresa " + cd.Empresap + ", esta seguro que desea agregarlo?", "Cargar Paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resulta == DialogResult.Yes)
                        {
                            txtNom.Text = cd.PacienteNom;
                            txtCed.Mask = "";
                            txtCed.Text = cd.Cedula;
                            cbbSeguro.Text = cd.Seguro;
                            txtFecha.Mask = "";
                            txtFecha.Text = cd.Fechan;
                            txtEmail2.Text = cd.Email;
                            if (cd.Sexo == "Masculino")
                            {
                                rbM.Checked = true;
                            }
                            else
                            {
                                rbF.Checked = true;
                            }
                            Pnew = true;
                        }
                        else
                        {

                        }
                    }
                    else

                    {

                        txtNom.Text = cd.PacienteNom;
                        txtCed.Mask = "";
                        txtCed.Text = cd.Cedula;
                        cbbSeguro.Text = cd.Seguro;
                        txtFecha.Mask = "";
                        txtFecha.Text = cd.Fechan;
                        txtEmail2.Text = cd.Email;
                        if (cd.Sexo == "Masculino")
                        {
                            rbM.Checked = true;
                        }
                        else
                        {
                            rbF.Checked = true;
                        }
                        Pnew = true;
                    }
                    txtNom.Enabled = false;
                    txtCed.Enabled = false;
                    cbbSeguro.Enabled = false;
                    txtFecha.Enabled = false;
                    txtEmail2.Enabled = false;
                    rbM.Enabled = false;
                    rbF.Enabled = false;
                    cbbDoc.Enabled = false;
                    chkCed.Enabled = false;
                    chkFecha.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            frmSeguros seg = new frmSeguros();
            seg.ShowDialog();
            if (seg.DialogResult == DialogResult.OK)
            {
                cargacbbSeg();
            }
        }

        private void btnAd_Click(object sender, EventArgs e)
        {
            if (radGridView1.Rows.Count < 70)
            {
                using (var con = new SqlConnection(conect))
                {
                    if (txtEmpresa.Text == "" || txtDir.Text == "" || txtEmail.Text == "" || txtCel.Text == "" || txtFecha.MaskCompleted == false)
                    {
                        MessageBox.Show("Debe completar los campos faltantes de la empresa o el paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (rbF.Checked == false && rbM.Checked == false)
                    {
                        MessageBox.Show("Debe seleccionar el sexo del paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        con.Close();
                        con.Open();
                        string ct = "select pced, pnom from tbpacientes where pced = '" + txtCed.Text + "'";

                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read() && txtCed.Text != "No Aplica" && Pnew == false)
                        {
                            MessageBox.Show("Este Paciente ya se encuentra esta registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                            return;
                        }

                        else if ((rdr != null))
                        {
                            if (txtNom.Text.Length > 0)
                            {
                                if (txtEmail2.Text.Length > 0)
                                {
                                    String email = txtEmail2.Text;
                                    string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                                    if (Regex.IsMatch(email, expresion))
                                    {
                                        if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                                        {
                                            AddPac();
                                            txtNom.Text = "";
                                            txtCed.Text = "";
                                            txtEmail2.Text = "";
                                            txtCed.Mask = "000-0000000-0";
                                            txtFecha.Mask = "00-00-0000";
                                            txtFecha.Text = "";
                                            rbF.Checked = false;
                                            rbM.Checked = false;
                                            btnSav.Enabled = true;
                                            txtEmpresa.Enabled = false;
                                            txtDir.Enabled = false;
                                            txtCel.Enabled = false;
                                            txtEmail.Enabled = false;
                                            chkCed.Checked = false;
                                            chkFecha.Checked = false;
                                            con.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El email ingresado no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    AddPac();
                                    txtNom.Text = "";
                                    txtCed.Text = "";
                                    txtEmail2.Text = "";
                                    txtCed.Mask = "000-0000000-0";
                                    txtFecha.Mask = "00-00-0000";
                                    txtFecha.Text = "";
                                    rbF.Checked = false;
                                    rbM.Checked = false;
                                    btnSav.Enabled = true;
                                    txtEmpresa.Enabled = false;
                                    txtDir.Enabled = false;
                                    txtCel.Enabled = false;
                                    txtEmail.Enabled = false;
                                    chkCed.Checked = false;
                                    chkFecha.Checked = false;

                                    con.Close();
                                }
                                txtNom.Enabled = true;
                                txtCed.Enabled = true;
                                cbbSeguro.Enabled = true;
                                txtFecha.Enabled = true;
                                txtEmail2.Enabled = true;
                                rbM.Enabled = true;
                                rbF.Enabled = true;
                                cbbDoc.Enabled = true;
                                chkCed.Enabled = true;
                                chkFecha.Enabled = true;
                            }
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("Ha alcanzado el limite de pacientes por empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
