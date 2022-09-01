using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmPregistro : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;

        public frmPregistro()
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

                    Paciente = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
                    Cedula = this.radGridView1.CurrentRow.Cells[2].Value.ToString();
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
        String Paciente;
        String Cedula;
        String Fechan;
        String Seguro;
        String Sexo;
        String cambiada1;
        String cambiada2;
        bool Pnew = false;
        SqlDataReader rdr = null;
        DateTime Fecha = DateTime.Now;
        String IDprereg;

        private void frmPregistro_Load(object sender, EventArgs e)
        {
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            txtEmpresa.Select();
            cbbDoc.SelectedIndex = 0;
            cargacbbSeg();
            getEmpresas();
        }

        public void GetPacientes()
        {
            using (var con = new SqlConnection(conect))
            {            
                    int Rows;
                    Rows = dataGridView1.RowCount - 1;
                    con.Open();
                    cmd = new SqlCommand("SELECT distinct a.pPreId as [PREID], a.pId as [ID], RTRIM(a.pNom) as [Paciente], RTRIM(a.pCed) as [Cedula], RTRIM(a.pFecha) as [Fecha Nacimiento], RTRIM(a.pSeguro) as [Seguro], RTRIM(a.pSex) as [Sexo], RTRIM(a.pEmail) as [Email]  from tbpacientes a inner join tbEmpresas b on a.pEmpresa = b.EmNom where a.pEmpresa = '" + txtEmpresa.Text + "'", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    myDA.Fill(myDataSet, "Paciente");
                    dataGridView1.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                    dataGridView1.Columns["PREID"].DisplayIndex = 0;
                    dataGridView1.Columns["Paciente"].DisplayIndex = 1;
                    dataGridView1.Columns["Cedula"].DisplayIndex = 2;
                    dataGridView1.Columns["Fecha Nacimiento"].DisplayIndex = 3;
                    dataGridView1.Columns["Seguro"].DisplayIndex = 4;
                    dataGridView1.Columns["Sexo"].DisplayIndex = 5;
                    dataGridView1.Columns["Email"].DisplayIndex = 6;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                    if (row.Cells["PREID"].Value != DBNull.Value)
                    {
                        IDprereg = (string)row.Cells["PREID"].Value;
                    }
                    
                        Paciente = (string)row.Cells["Paciente"].Value;
                        Cedula = (string)row.Cells["Cedula"].Value;
                        Fechan = (string)row.Cells["Fecha Nacimiento"].Value;
                        Seguro = (string)row.Cells["Seguro"].Value;
                        Sexo = (string)row.Cells["Sexo"].Value;
                        radGridView1.Rows.Add(IDprereg, Paciente, Cedula, Fechan, Seguro, Sexo, (string)row.Cells["Email"].Value);
                    }
                
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (radGridView1.Rows.Count < 70)
            {
                using (var con = new SqlConnection(conect))
                {
                    if (txtEmpresa.Text == "" || txtDir.Text == "" || txtEmail.Text == "" || txtCel.Text == "" || txtFecha.MaskCompleted == false || txtCed.Text == "" || txtCed.Text == "   -       -")
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
                        string ct = "select preced from tbprepacientes where preced = '" + txtCed.Text + "' union select pced from tbPacientes where pced = '"+txtCed.Text+"'";

                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read() && txtCed.Text != "No Aplica" )
                        {
                            MessageBox.Show("Un Paciente con esta identificacion ya se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                            return;
                        }

                        else if ((rdr != null))
                        {
                            if (txtNom.Text.Length > 0)
                            {
                                String email = txtEmail2.Text;
                                string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                                if (Regex.IsMatch(email, expresion))
                                {
                                    if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                                    {
                                        AddPac();
                                        txtID.Text = "";
                                        txtID.Enabled = true;
                                        txtNom.Text = "";
                                        txtCed.Text = "";
                                        txtEmail2.Text = "";
                                        txtCed.Mask = "000-0000000-0";
                                        txtFecha.Mask = "00-00-0000";
                                        txtFecha.Text = "";
                                        rbF.Checked = false;
                                        rbM.Checked = false;
                                        txtNom.Enabled = false;
                                        txtCed.Enabled = false;
                                        cbbDoc.Enabled = false;
                                        cbbSeguro.Enabled = false;
                                        txtFecha.Enabled = false;
                                        chkCed.Enabled = false;
                                        chkFecha.Enabled = false;
                                        rbF.Enabled = false;
                                        rbM.Enabled = false;
                                        btnAdd.Enabled = false;
                                        button1.Enabled = false;
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
                    }
                    }
                }
            }

            else
            {
                MessageBox.Show("Ha alcanzado el limite de pacientes por empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddPac()
        {
            bool existe = false;
      
            if (radGridView1.RowCount >= 1)
            {
                for (int i = 0; i < radGridView1.RowCount; i++)
                {

                    if (Convert.ToString(radGridView1.Rows[i].Cells["column1"].Value) == txtCed.Text && txtCed.Text != "No Aplica")

                    {
                        MessageBox.Show("Un Paciente con esta cedula ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        existe = true;

                    }
                    else if (radGridView1.Rows[i].Cells["ID"].Value != null)
                    {
                        if (radGridView1.RowCount >= 1 && radGridView1.Rows[i].Cells["ID"].Value.ToString() == txtID.Text)

                        {
                            MessageBox.Show("Un Paciente con este ID ya ha sido agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            existe = true;

                        }
                    } 
                    else
                    {
                        existe = false;
                    }
                }
            }
            if (existe == false)
            {
                if (Pnew == true)
                {
                    radGridView1.Rows.Add(txtID.Text,txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtEmail.Text);
                    dgbUpd.Rows.Add(txtID.Text, txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtEmail.Text);
                    dgbAdd.Rows.Add(txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtID.Text, txtEmail.Text);
                    Pnew = false;
                }
                else
                {
                    radGridView1.Rows.Add(txtID.Text, txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtEmail.Text);
                    dgbUpd.Rows.Add(txtID.Text, txtNom.Text, txtCed.Text, txtFecha.Text, cbbSeguro.Text, Sexo, txtEmail.Text);
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
            frmSeguros seg = new frmSeguros();
            seg.ShowDialog();
            if (seg.DialogResult == DialogResult.OK)
            {
                cargacbbSeg();
            }
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

                    cambiada1 = year + "-" + mes + "-" + day;
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
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

        private void DataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (this.DataGridView7.Columns[e.ColumnIndex].Name == "Select")
                {
                    txtEmpresa.Text = (string)this.DataGridView7.Rows[e.RowIndex].Cells["Empresa"].Value;
                    txtDir.Text = (string)this.DataGridView7.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                    txtEmail.Text = (string)this.DataGridView7.Rows[e.RowIndex].Cells["Email"].Value;
                    txtCel.Text = (string)this.DataGridView7.Rows[e.RowIndex].Cells["Contacto"].Value;
                    Pruebas = (bool)this.DataGridView7.Rows[e.RowIndex].Cells["Pruebas"].Value;
                    Resultados = (bool)this.DataGridView7.Rows[e.RowIndex].Cells["Resultados"].Value;
    
                    //using (var con = new SqlConnection(conect))
                    //{
                    //    //string ct = "select * from tbpacientes where pempresa = '" + txtEmpresa.Text + "'";
                        //con.Open();
                        //cmd = new SqlCommand(ct);
                        //cmd.Connection = con;
                        //rdr = cmd.ExecuteReader();

                        //if (rdr.Read())
                        //{
                        //    DialogResult Resulta = MessageBox.Show("Esta empresa contiene pacientes de registro por empresa asociados, desea eliminarlos para poder continuar con este registro? De no eliminarlos no podra asociar pacientes por este modulo.", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        //    con.Close();

                        //    if (Resulta == DialogResult.Yes)
                        //    {
                        //        int Rows;
                        //        Rows = dataGridView1.RowCount - 1;
                        //        con.Open();
                        //        cmd = new SqlCommand("SELECT distinct a.pId as [ID], RTRIM(a.pNom) as [Paciente], RTRIM(a.pCed) as [Cedula], RTRIM(a.pFecha) as [Fecha Nacimiento], RTRIM(a.pSeguro) as [Seguro], RTRIM(a.pSex) as [Sexo]  from tbpacientes a inner join tbEmpresas b on a.pEmpresa = b.EmNom where a.pEmpresa = '" + txtEmpresa.Text + "'", con);
                        //        SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                        //        DataSet myDataSet = new DataSet();
                        //        myDA.Fill(myDataSet, "Paciente");
                        //        dataGridView1.DataSource = myDataSet.Tables["Paciente"].DefaultView;
                        //        dataGridView1.Columns["ID"].DisplayIndex = 0;
                        //        dataGridView1.Columns["Paciente"].DisplayIndex = 1;
                        //        dataGridView1.Columns["Cedula"].DisplayIndex = 2;
                        //        dataGridView1.Columns["Fecha Nacimiento"].DisplayIndex = 3;
                        //        dataGridView1.Columns["Seguro"].DisplayIndex = 4;
                        //        dataGridView1.Columns["Sexo"].DisplayIndex = 5;

                        //        foreach (DataGridViewRow row in dataGridView1.Rows)
                        //        {

                        //            Paciente = (string)row.Cells["Paciente"].Value;
                        //            Cedula = (string)row.Cells["Cedula"].Value;
                        //            dgbDelete.Rows.Add(Paciente, Cedula);
                        //        }


                        //        DataGridView7.Visible = false;
                        //        groupBox1.Visible = true;
                        //        btnSearch.Enabled = true;                           
                        //        txtID.Enabled = true;
                               
                        //    }
                        //    else
                        //    {

                        //    }
                        //}

                        //else if ((rdr != null))
                        //{

                            //con.Close();
                            GetPacientes();
                            DataGridView7.Visible = false;
                            groupBox1.Visible = true;
                            btnSearch.Enabled = true;
                            txtID.Enabled = true;
                            btnCrea.Enabled = false;
                        //}
                    //}
                    btnSav.Enabled = true;
                    tableLayoutPanel7.Visible = false;
                }
            }
        }
        public void getEmpresas()
        {
            using (var con = new SqlConnection(conect))
            {
                int Rows;
                Rows = DataGridView7.RowCount - 1;
                con.Open();
                //cmd = new SqlCommand("select DISTINCt(a.pEmpresa) as [Empresa], a.pFechareg as [Fecha Registro] from tbPacientes a  where a.pEmpresa IS NOT NULL ", con);
                cmd = new SqlCommand("select distinct emNom as [Empresa], emDir as [Direccion], emEmail as [Email], emContacto as [Contacto], emPruebas as [Pruebas], emResultados as [Resultados] from tbEmpresas order by emnom", con);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {
                using (var con = new SqlConnection(conect))
                {
                    string ct = "select preid, prenom, preced, presex, prefecha, predir, precel, preemail, preemail2, preseguro, prefechareg, preempresa from tbprepacientes where preid = '" + txtID.Text + "'";
                    con.Open();
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {

                        if (rdr[11] != DBNull.Value )
                        {
                            MessageBox.Show("Un paciente con este paciente ya ha sido registrado, puedes modificarlo por el registro individual.", "Cargar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //if (resulta == DialogResult.Yes)
                            //{
                            //    txtID.Enabled = false;
                            //    txtID.Text = rdr[0].ToString();
                            //    txtNom.Text = rdr[1].ToString();
                            //    txtCed.Mask = "";
                            //    txtCed.Text = rdr[2].ToString();
                            //    cbbSeguro.Text = rdr[9].ToString();
                            //    txtFecha.Mask = "";
                            //    txtFecha.Text = rdr[4].ToString();
                            //    if (rdr[4] != DBNull.Value)
                            //    {
                            //        DateTime fechana = DateTime.Parse(txtFecha.Text);
                            //        txtFecha.Text = fechana.ToString("dd-MM-yyyy");
                            //    }
                            //    if (rdr[3].ToString() == "Masculino")
                            //    {
                            //        rbM.Checked = true;
                            //    }
                            //    else
                            //    {
                            //        rbF.Checked = true;
                            //    }
                            //    txtNom.Enabled = true;
                            //    txtCed.Enabled = true;
                            //    cbbDoc.Enabled = true;
                            //    cbbSeguro.Enabled = true;
                            //    txtFecha.Enabled = true;
                            //    chkCed.Enabled = true;
                            //    chkFecha.Enabled = true;
                            //    rbF.Enabled = true;
                            //    rbM.Enabled = true;
                            //    btnAdd.Enabled = true;
                            //    button1.Enabled = true;
                            //}
                            //else
                            //{

                            //}
                        }
                        //else if (rdr[11] != DBNull.Value && rdr[11].ToString() == txtEmpresa.Text)
                        //{
                        //    txtID.Text = rdr[0].ToString();
                        //    txtID.Enabled = false;
                        //    txtNom.Text = rdr[1].ToString();
                        //    txtCed.Mask = "";
                        //    txtCed.Text = rdr[2].ToString();
                        //    cbbSeguro.Text = rdr[9].ToString();
                        //    txtFecha.Mask = "";
                        //    txtFecha.Text = rdr[4].ToString();
                        //    if (rdr[4] != DBNull.Value)
                        //    {
                        //        DateTime fechana = DateTime.Parse(txtFecha.Text);
                        //        txtFecha.Text = fechana.ToString("dd-MM-yyyy");
                             
                        //    }
                        //    if (rdr[3].ToString() == "Masculino")
                        //    {
                        //        rbM.Checked = true;
                        //    }
                        //    else
                        //    {
                        //        rbF.Checked = true;
                        //    }
                        //    txtNom.Enabled = true;
                        //    txtCed.Enabled = true;
                        //    cbbDoc.Enabled = true;
                        //    cbbSeguro.Enabled = true;
                        //    txtFecha.Enabled = true;
                        //    chkCed.Enabled = true;
                        //    chkFecha.Enabled = true;
                        //    rbF.Enabled = true;
                        //    rbM.Enabled = true;
                        //    btnAdd.Enabled = true;
                        //    button1.Enabled = true;

                        //}
                        else if (rdr[1] == DBNull.Value)
                        {

                            txtID.Text = rdr[0].ToString();
                            txtID.Enabled = false;
                            txtCed.Mask = "000-0000000-0";
                            txtFecha.Mask = "00-00-0000";
                            txtNom.Enabled = true;
                            txtEmail2.Enabled = true;
                            txtCed.Enabled = true;
                            cbbDoc.Enabled = true;
                            cbbSeguro.Enabled = true;
                            txtFecha.Enabled = true;
                            chkCed.Enabled = true;
                            chkFecha.Enabled = true;
                            rbF.Enabled = true;
                            rbM.Enabled = true;
                            btnAdd.Enabled = true;
                            button1.Enabled = true;
                            Pnew = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El ID ingresado no ha sido pre-registrado anteriormente, favor validar el mismo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
           
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

        private void btnSav_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Esta de seguro que desea Reiniciar la empresa: " + txtEmpresa.Text + "?", "Reiniciar Empresa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                using (var con = new SqlConnection(conect))
                {
                    foreach (DataGridViewRow row in dgbUpd.Rows)
                    {
                        try
                        {
                            Fechadehoy();
                            IDprereg = Convert.ToString(row.Cells["PreID"].Value);
                            Paciente = (string)row.Cells["Columnp"].Value;
                            Cedula = (string)row.Cells["Columnc"].Value;
                            Fechan = (string)row.Cells["dataGridViewTextBoxColumn3"].Value;
                            conviertefecha();
                            string sql = "update tbprepacientes set prenom = '"+ Paciente + "', preced= '"+ Cedula + "', presex= '"+ Convert.ToString(row.Cells["dataGridViewTextBoxColumn5"].Value) + "', prefecha= '"+ cambiada1 + "', predir= '"+ txtDir.Text + "', precel= '"+ txtCel.Text + "', preemail= '"+ Convert.ToString(row.Cells["Email2"].Value) + "', preseguro= '"+ Convert.ToString(row.Cells["dataGridViewTextBoxColumn4"].Value) + "',  preempresa = '"+ txtEmpresa.Text + "' where preid = '"+ Convert.ToString(row.Cells["PreID"].Value) + "'";
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
                            Logs log = new Logs();
                            log.Accion = "Paciente ID:"+IDprereg+", " + Paciente + " Agregado a Empresa: " + txtEmpresa.Text + "";
                            log.Form = "Pacientes Pre-Regisro";
                            log.SaveLog();

                            con.Close();

                        }

                    }

                }
                using (var con = new SqlConnection(conect))
                {
                    try
                    {
                        if (dgbAdd.RowCount >= 1)
                        {
                            SqlCommand AddPacientes = new SqlCommand("Insert into tbpacientes values (@pNom, @pCed, @pSex, @pFecha, @pDir, @pCel, @pEmail, @pEmail2, @pSeguro, @pFechareg, @pEmpresa, @Referidor, @preID)", con);
                            con.Open();
                            Fechadehoy();
                            foreach (DataGridViewRow row in dgbAdd.Rows)

                            {
                                Paciente = (string)row.Cells["Column5"].Value;
                                Cedula = (string)row.Cells["Column6"].Value;
                                Fechan = (string)row.Cells["Column7"].Value;
                                IDprereg = (string)row.Cells["IDpre"].Value;
                                conviertefecha();

                                AddPacientes.Parameters.Clear();
                                AddPacientes.Parameters.AddWithValue("@pNom", Convert.ToString(row.Cells["Column5"].Value));
                                AddPacientes.Parameters.AddWithValue("@pCed", Convert.ToString(row.Cells["Column6"].Value));
                                AddPacientes.Parameters.AddWithValue("@pSex", Convert.ToString(row.Cells["Column9"].Value));
                                AddPacientes.Parameters.AddWithValue("@pFecha", cambiada1);
                                AddPacientes.Parameters.AddWithValue("@pDir", txtDir.Text);
                                AddPacientes.Parameters.AddWithValue("@pCel", txtCel.Text);
                                AddPacientes.Parameters.AddWithValue("@pEmail", Convert.ToString(row.Cells["Email"].Value));
                                AddPacientes.Parameters.AddWithValue("@pEmail2", txtEmail.Text);
                                AddPacientes.Parameters.AddWithValue("@pSeguro", Convert.ToString(row.Cells["Column8"].Value));
                                AddPacientes.Parameters.AddWithValue("@pFechareg", cambiada2);
                                AddPacientes.Parameters.AddWithValue("@pEmpresa", txtEmpresa.Text);
                                AddPacientes.Parameters.AddWithValue("@Referidor", DBNull.Value);
                                AddPacientes.Parameters.AddWithValue("@preID", IDprereg);
                                AddPacientes.ExecuteNonQuery();

                                Logs log = new Logs();
                                log.Accion = "Paciente: " + Paciente + " Registrado en Empresa: " + txtEmpresa.Text + "";
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
                                Logs log = new Logs();
                                log.Accion = "Paciente: " + Paciente + " Eliminado de Empresa: " + txtEmpresa.Text + "";
                                log.Form = "Reinicio de Empresas";
                                log.SaveLog();

                                con.Close();
                               
                            }

                        }
                    }

                }
                
                DialogResult resultas = MessageBox.Show("Desea reiniciar esta empresa para asignarle pruebas?", "Reinicio de Empresas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultas == DialogResult.Yes)
                {
                    UpdateEmpresa();
                }
                MessageBox.Show("Cambios Realizados Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radGridView1.Rows.Clear();
                dgbUpd.Rows.Clear();
                dgbDelete.Rows.Clear();
                dgbAdd.Rows.Clear();
                txtNom.Text = "";
                txtCed.Text = "";
                txtEmail2.Text = "";
                txtFecha.Text = "";
                rbF.Checked = false;
                rbM.Checked = false;
                chkCed.Checked = false;
                chkFecha.Checked = false;
                btnSav.Enabled = false;
                txtEmpresa.Enabled = false;
                groupBox1.Visible = false;
                btnSearch.Enabled = false;
                getEmpresas();
                DataGridView7.Visible = true;
                tableLayoutPanel7.Visible = true;
                txtEmpresa.Text = "";
                txtDir.Text = "";
                txtCel.Text = "";
                txtEmail.Text = "";
                btnAdd.Enabled = false;
                btnSearch.Enabled = false;

                if (cbbDoc.Text == "Cedula")
                {
                    txtCed.Mask = "000-0000000-0";
                }
                else
                {
                    txtCed.Mask = "";
                }
            }
        }

        public void InsertaPacientes()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {

                    SqlCommand AddPacientes = new SqlCommand("Insert into tbpacientes values (@pNom, @pCed, @pSex, @pFecha, @pDir, @pCel, @pEmail, @pEmail2, @pSeguro, @pFechareg, @pEmpresa, @Referidor)", con);
                    con.Open();
                    Fechadehoy();
                    foreach (DataGridViewRow row in dgbAdd.Rows)

                    {
                        Paciente = (string)row.Cells["Column5"].Value;
                        Cedula = (string)row.Cells["Column6"].Value;
                        Fechan = (string)row.Cells["Column7"].Value;
                        conviertefecha();

                        AddPacientes.Parameters.Clear();
                        AddPacientes.Parameters.AddWithValue("@pNom", Convert.ToString(row.Cells["Column5"].Value));
                        AddPacientes.Parameters.AddWithValue("@pCed", Convert.ToString(row.Cells["Column6"].Value));
                        AddPacientes.Parameters.AddWithValue("@pSex", Convert.ToString(row.Cells["Column9"].Value));
                        AddPacientes.Parameters.AddWithValue("@pFecha", cambiada1);
                        AddPacientes.Parameters.AddWithValue("@pDir", txtDir.Text);
                        AddPacientes.Parameters.AddWithValue("@pCel", txtCel.Text);
                        AddPacientes.Parameters.AddWithValue("@pEmail", txtEmail.Text);
                        AddPacientes.Parameters.AddWithValue("@pEmail2", DBNull.Value);
                        AddPacientes.Parameters.AddWithValue("@pSeguro", Convert.ToString(row.Cells["Column8"].Value));
                        AddPacientes.Parameters.AddWithValue("@pFechareg", cambiada2);
                        AddPacientes.Parameters.AddWithValue("@pEmpresa", txtEmpresa.Text);
                        AddPacientes.Parameters.AddWithValue("@Referidor", DBNull.Value);
                        AddPacientes.ExecuteNonQuery();

                        Logs log = new Logs();
                        log.Accion = "Paciente: " + Paciente + " Registrado en Empresa: " + txtEmpresa.Text + "";
                        log.Form = "Reinicio de Empresas";
                        log.SaveLog();

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
                            cmd = new SqlCommand("select distinct emNom as [Empresa], emDir as [Direccion], emEmail as [Email], emContacto as [Contacto], emPruebas as [Pruebas], emResultados as [Resultados] from tbEmpresas where emnom like '%" + txtConsulta.Text + "%' order by emnom ", con);
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

        private void DataGridView7_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void cbbDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnCrea_Click(object sender, EventArgs e)
        {
            frmCreaEmpresa crea = new frmCreaEmpresa();
            crea.ShowDialog();
            if (crea.DialogResult == DialogResult.OK)
            {
                getEmpresas();
            }
        }
    }
}
