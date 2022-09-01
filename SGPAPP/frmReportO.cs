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
    public partial class frmReportO : Telerik.WinControls.UI.RadForm
    {
        public frmReportO()
        {
            InitializeComponent();
            dta.Columns.Add("Id", typeof(int));
            dta.Columns.Add("Result", typeof(string));
        }
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;
        static string conect = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        public String Empresa;
        String Prueba;
        DataTable dta = new DataTable();
        bool Influenzatest;
        bool Anticuerpo;
        DateTime Fecha = DateTime.Now;
        string cambiada1;
        public int pacID;
        public int PrID;
        String Paciente;
        String Sql;
        String Fechan;
        DateTime HoraRegistro;
        String Resultado;
        String Resultado2;
        String CT;
        String CT2;
        String dir;
        bool English;
        String Edad;
        public String mail;
        public String mail2;
        String Cedula;
        public int PruebaEmpresa;
        DateTime FechaMuestra;
        DateTime HoraMuestra;
        String Tipop;
        String MailP;
        public int LoteID;
        int ConteoNoReportados = 0;
        private void frmReportO_Load(object sender, EventArgs e)
        {
            GetPacientes();
            lblname.Text = Empresa;
            lblmail.Text = mail;
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
                    da.SelectCommand.Parameters.AddWithValue("@tipo", "Result");
                    da.SelectCommand.Parameters.AddWithValue("@PruebaEmpresa", PruebaEmpresa);
                    da.SelectCommand.Parameters.AddWithValue("@LotID", LoteID);
                    da.Fill(dt);
                    if (dt.Rows.Count < 1)
                    {
                        MessageBox.Show("Esta empresa no tiene pacientes agregados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    else
                    {
                        this.radGridView1.DataSource = dt;
                        GridViewComboBoxColumn cbbResults = new GridViewComboBoxColumn();
                        GridViewComboBoxColumn cbbResults2 = new GridViewComboBoxColumn();
                        GridViewTextBoxColumn txtCT2 = new GridViewTextBoxColumn();
                        GridViewCheckBoxColumn chkEnglish = new GridViewCheckBoxColumn();
                        cbbResults.Name = "cbbResults";
                        cbbResults.HeaderText = "Resultado";
                        cbbResults2.Name = "cbbResults2";
                        cbbResults2.HeaderText = "Resultado2";
                        txtCT2.Name = "txtCT2";
                        txtCT2.HeaderText = "Valor CT2";
                        chkEnglish.Name = "chkEnglish";
                        chkEnglish.HeaderText = "Generar en Ingles";
                        cbbResults.Width = 110;
                        cbbResults2.Width = 110;
                        if (radGridView1.RowCount > 0)
                        {


                            GridViewRowInfo rows = radGridView1.CurrentRow;
                            Prueba = radGridView1.Rows[rows.Index].Cells[5].Value.ToString();
                            if (Prueba == "Antigeno")
                                {
                                    dta.Rows.Add(0, "Seleccione el Resultado");
                                    dta.Rows.Add(1, "Positivo");
                                    dta.Rows.Add(2, "Negativo");
                                }
                                if (Prueba == "Sars Cov-2")
                                {
                                    dta.Rows.Add(0, "Seleccione el Resultado");
                                    dta.Rows.Add(1, "Detectado");
                                    dta.Rows.Add(2, "No Detectado");
                                }
                                if (Prueba == "Influenza")
                                {

                                    cbbResults2.Name = "cbbResults2";
                                cbbResults.HeaderText = "Influenza A";
                                cbbResults2.HeaderText = "Influenza B";
                                cbbResults2.Width = 110;
                                    dta.Rows.Add(0, "Seleccione el Resultado");
                                    dta.Rows.Add(1, "Detectado");
                                    dta.Rows.Add(2, "No Detectado");
                                    cbbResults2.DataSource = dta;
                                    cbbResults2.DisplayMember = "Result";
                                    cbbResults2.ValueMember = "Id";
                                    Influenzatest = true;
                                }
                                if (Prueba == "Anticuerpo-Covid")
                                {
                                cbbResults.HeaderText = "igG";
                                cbbResults2.HeaderText = "igM";
                                cbbResults2.Name = "cbbResults2";
                                    cbbResults2.HeaderText = "Resultado2";
                                    cbbResults2.Width = 110;
                                    dta.Rows.Add(0, "Seleccione el Resultado");
                                    dta.Rows.Add(1, "Positivo");
                                    dta.Rows.Add(2, "Negativo");
                                    cbbResults2.DataSource = dta;
                                    cbbResults2.DisplayMember = "Result";
                                    cbbResults2.ValueMember = "Id";
                                    Anticuerpo = true;
                                }
                   

                            cbbResults.DataSource = dta;
                            cbbResults.DisplayMember = "Result";
                            cbbResults.ValueMember = "Id";

                            this.radGridView1.Columns.Add(cbbResults);
                            if (Influenzatest == true)
                            {
                                this.radGridView1.Columns.Add(cbbResults2);
                                this.radGridView1.Columns.Add(txtCT2);
                                foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
                                {
                                    this.radGridView1.Rows[rowInfo.Index].Cells["cbbResults2"].Value = 0;
                                    this.radGridView1.Rows[rowInfo.Index].Cells["cbbResults"].Value = 0;
                                }
                                radGridView1.Columns.Move(0, 7);
                                radGridView1.Columns[1].ReadOnly = true;
                                radGridView1.Columns[2].ReadOnly = true;
                                radGridView1.Columns[3].ReadOnly = true;
                                radGridView1.Columns[4].ReadOnly = true;
                                radGridView1.Columns[5].ReadOnly = true;
                                //radGridView1.Columns[6].ReadOnly = true;
                                //radGridView1.Columns[7].ReadOnly = true;
                                //radGridView1.Columns[8].ReadOnly = true;
                            }
                            else if (Anticuerpo == true)
                            {
                                this.radGridView1.Columns.Add(cbbResults2);
                                this.radGridView1.Columns.Add(txtCT2);
                                foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
                                {
                                    this.radGridView1.Rows[rowInfo.Index].Cells["cbbResults2"].Value = 0;
                                    this.radGridView1.Rows[rowInfo.Index].Cells["cbbResults"].Value = 0;
                                }
                                radGridView1.Columns.Move(0, 7);
                                radGridView1.Columns[1].ReadOnly = true;
                                radGridView1.Columns[2].ReadOnly = true;
                                radGridView1.Columns[3].ReadOnly = true;
                                radGridView1.Columns[4].ReadOnly = true;
                                radGridView1.Columns[5].ReadOnly = true;
                                //radGridView1.Columns[6].ReadOnly = true;
                                //radGridView1.Columns[7].ReadOnly = true;
                                //radGridView1.Columns[8].ReadOnly = true;
                            }
                            else
                            {
                                chkEnglish.Width = 60;
                                this.radGridView1.Columns.Add(chkEnglish);
                                foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
                                {
                                    this.radGridView1.Rows[rowInfo.Index].Cells["cbbResults"].Value = 0;
                                }
                                radGridView1.Columns.Move(0, 7);
                                radGridView1.Columns[1].ReadOnly = true;
                                radGridView1.Columns[2].ReadOnly = true;
                                radGridView1.Columns[3].ReadOnly = true;
                                radGridView1.Columns[4].ReadOnly = true;
                                radGridView1.Columns[5].ReadOnly = true;
                                //radGridView1.Columns[6].ReadOnly = true;
                                //radGridView1.Columns[7].ReadOnly = true;
                                //radGridView1.Columns[8].ReadOnly = true;
                            }
                            con.Close();
                        }
                    }
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
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
                DateTime fecha1;


                fecha1 = Fecha;

                string day = fecha1.Day.ToString();
                string mes = fecha1.Month.ToString();
                string year = fecha1.Year.ToString();

                cambiada1 = year + "-" + mes + "-" + day;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
        public void GetPaciente()
        {
            //obtener los datos del paciente
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT  pemail as [Email] from tbpacientes where pID = '" + pacID + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        //Edad = reader[0].ToString();
                        //if (Edad == "1900-01-01")
                        //{
                        //    Edad = "-";

                        //}
                        //else
                        //{
                        //    Edad = Convert.ToString(DateTime.Today.AddTicks(-DateTime.Parse(Edad).Ticks).Year - 1);
                        //}
                        //    Edad = Edad + " años";
                        //    Fechan = reader[0].ToString();
                        //    Paciente = reader[2].ToString();
                        //    Cedula = reader[3].ToString();
                            MailP =reader[4].ToString();

                        //dir = reader[1].ToString();


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
        public void getPrueba()
        {
            //obtener los datos del paciente
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT  RTRIM(ppFecha) as [FechaMuestra], RTRIM(ppHora) as [HoraMuestra], ppTipo as [TipoPrueba]  from tbPruebaspendientes where pppacID = '" + pacID + "' and ppempresaid = '"+ PrID + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {     
                        FechaMuestra = Convert.ToDateTime(reader[0].ToString());
                        HoraMuestra = Convert.ToDateTime(reader[1].ToString());
                        Tipop = reader[2].ToString();


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
        private void btnSav_Click(object sender, EventArgs e)
        {
            
                DialogResult resulta = MessageBox.Show("Esta seguro que desea asignar estos resultados?", "Asignar Resultados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                 ConteoNoReportados = 0;
                //try
                //{
                foreach (GridViewRowInfo rowInfo in radGridView1.Rows) 
                    {
                        if (radGridView1.Rows[rowInfo.Index].Cells[0].Value != null)
                        {
                        ConteoNoReportados++;
                        }
                    }
                        using (var con = new SqlConnection(conect))
                        {
                            foreach (GridViewRowInfo rowInfo in radGridView1.Rows) if (radGridView1.Rows[rowInfo.Index].Cells[0].Value == null)
                                {
                                    conviertefecha();
                                    Prueba = radGridView1.Rows[rowInfo.Index].Cells[4].Value.ToString();
                                    PrID = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[1].Value);
                                    pacID = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[2].Value);
                                    Paciente = Convert.ToString(radGridView1.Rows[rowInfo.Index].Cells[3].Value);
                            //GetPaciente();
                            //getPrueba();
                            English = false;
                                    HoraRegistro = DateTime.Now;
                                    if (Prueba == "Antigeno" && radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() != "0" || Prueba == "Sars Cov-2" && radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() != "0" || Prueba == "Influenza" && radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() != "0" || radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString() != "0" || Prueba == "Anticuerpo-Covid" && radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() != "0" || radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString() != "0")
                                    {
                                        switch (Prueba)
                                        {
                                            case "Antigeno":
                                                if (radGridView1.Rows[rowInfo.Index].Cells[7].Value == null) { CT = "-"; }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[8].Value != null) { English = true; }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() == "1")
                                                { Resultado = "Positivo"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() == "2") { Resultado = "Negativo"; }
                                        //Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF,reEmpresa,  rePruebaID) values (" + pacID + ", '" + Paciente + "', '" + dir + "', '" + Fechan + "', '" + Edad + "', '" + Cedula + "','" + Tipop + "', '" + radGridView1.Rows[rowInfo.Index].Cells[4].Value.ToString() + "', '" + Resultado + "', '" + Resultado + "', '" + CT + "', NULL, NULL,'" + cambiada1 + "' , (select ppfecha from tbPruebasPendientes where ppempresaid = " + PrID + " and pppacid = " + pacID + "),  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" +HoraMuestra.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "',NULL , '" + Empresa + "','" + radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString() + "')";                                      
                                            con.Open();
                                            cmd = new SqlCommand(Sql, con);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.CommandText = "spInsertEmpresasResults";                                                           
                                            cmd.Parameters.Add(new SqlParameter("@pacid", SqlDbType.Int)).Value = pacID;
                                            cmd.Parameters.Add(new SqlParameter("@resultado", SqlDbType.VarChar)).Value = Resultado;
                                            cmd.Parameters.Add(new SqlParameter("@resultado2", SqlDbType.VarChar)).Value = DBNull.Value;
                                            cmd.Parameters.Add(new SqlParameter("@ct", SqlDbType.NChar)).Value = CT;
                                            cmd.Parameters.Add(new SqlParameter("@ct2", SqlDbType.NChar)).Value = DBNull.Value;
                                            cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date)).Value = cambiada1;
                                            cmd.Parameters.Add(new SqlParameter("@hora", SqlDbType.VarChar)).Value = HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                                            cmd.Parameters.Add(new SqlParameter("@empresa", SqlDbType.VarChar)).Value = Empresa;
                                            cmd.Parameters.Add(new SqlParameter("@pruebaid", SqlDbType.Int)).Value = PrID;
                 
                                       

                                        break;
                                            case "Sars Cov-2":
                                                if (radGridView1.Rows[rowInfo.Index].Cells[7].Value == null) { CT = "-"; }
                                                else { CT = radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString(); }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[8].Value != null) { English = true; }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() == "1")
                                                { Resultado = "Detectado"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() == "2") { Resultado = "No Detectado"; }
                                        //Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF,reEmpresa,  rePruebaID) values (" + pacID + ", '" + Paciente + "', '" + dir + "', '" + Fechan + "', '" + Edad + "', '" + Cedula + "','" + Tipop + "', '" + radGridView1.Rows[rowInfo.Index].Cells[4].Value.ToString() + "', '" + Resultado + "', '" + Resultado + "', '" + CT + "', NULL, NULL,'" + cambiada1 + "' , (select ppfecha from tbPruebasPendientes where ppempresaid = " + PrID + " and pppacid = " + pacID + "),  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + HoraMuestra.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "',NULL , '" + Empresa + "','" + radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString() + "')";
                                        con.Open();
                                        cmd = new SqlCommand(Sql, con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.CommandText = "spInsertEmpresasResults";
                                        cmd.Parameters.Add(new SqlParameter("@pacid", SqlDbType.Int)).Value = pacID;
                                        cmd.Parameters.Add(new SqlParameter("@resultado", SqlDbType.VarChar)).Value = Resultado;
                                        cmd.Parameters.Add(new SqlParameter("@resultado2", SqlDbType.VarChar)).Value = DBNull.Value;
                                        cmd.Parameters.Add(new SqlParameter("@ct", SqlDbType.NChar)).Value = CT;
                                        cmd.Parameters.Add(new SqlParameter("@ct2", SqlDbType.NChar)).Value = DBNull.Value;
                                        cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date)).Value = cambiada1;
                                        cmd.Parameters.Add(new SqlParameter("@hora", SqlDbType.VarChar)).Value = HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                                        cmd.Parameters.Add(new SqlParameter("@empresa", SqlDbType.VarChar)).Value = Empresa;
                                        cmd.Parameters.Add(new SqlParameter("@pruebaid", SqlDbType.Int)).Value = PrID;
                                        break;
                                            case "Influenza":
                                                if (radGridView1.Rows[rowInfo.Index].Cells[7].Value == null) { CT = "-"; }
                                                else { CT = radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString(); }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[9].Value == null) { CT2 = "-"; }
                                                else { CT2 = radGridView1.Rows[rowInfo.Index].Cells[9].Value.ToString(); }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() == "1")
                                                { Resultado = "Detectado"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() == "2") { Resultado = "No Detectado"; }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString() == "1")
                                                { Resultado2 = "Detectado"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString() == "2") { Resultado2 = "No Detectado"; }
                                        //Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF, reEmpresa,  rePruebaID) values (" + pacID + ", '" + Paciente + "', '" + dir + "', '" + Fechan + "', '" + Edad + "', '" + Cedula + "','" + Tipop + "', '" + radGridView1.Rows[rowInfo.Index].Cells[4].Value.ToString() + "', '" + Resultado + "', '" + Resultado + "', '" + CT + "',  '" + Resultado2 + "',  '" + CT2 + "','" + cambiada1 + "' , (select ppfecha from tbPruebasPendientes where ppempresaid = " + PrID + " and pppacid = " + pacID + "),  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + HoraMuestra.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "',NULL ,'" + Empresa + "', '" + radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString() + "')";
                                        con.Open();
                                        cmd = new SqlCommand(Sql, con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.CommandText = "spInsertEmpresasResults";
                                        cmd.Parameters.Add(new SqlParameter("@pacid", SqlDbType.Int)).Value = pacID;
                                        cmd.Parameters.Add(new SqlParameter("@resultado", SqlDbType.VarChar)).Value = Resultado;
                                        cmd.Parameters.Add(new SqlParameter("@resultado2", SqlDbType.VarChar)).Value = Resultado2;
                                        cmd.Parameters.Add(new SqlParameter("@ct", SqlDbType.NChar)).Value = CT;
                                        cmd.Parameters.Add(new SqlParameter("@ct2", SqlDbType.NChar)).Value = CT2;
                                        cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date)).Value = cambiada1;
                                        cmd.Parameters.Add(new SqlParameter("@hora", SqlDbType.VarChar)).Value = HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                                        cmd.Parameters.Add(new SqlParameter("@empresa", SqlDbType.VarChar)).Value = Empresa;
                                        cmd.Parameters.Add(new SqlParameter("@pruebaid", SqlDbType.Int)).Value = PrID;
                                        break;
                                            case "Anticuerpo-Covid":
                                                if (radGridView1.Rows[rowInfo.Index].Cells[7].Value == null) { CT = "-"; }
                                                else { CT = radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString(); }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[9].Value == null) { CT2 = "-"; }
                                                else { CT2 = radGridView1.Rows[rowInfo.Index].Cells[9].Value.ToString(); }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() == "1")
                                                { Resultado = "Positivo"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() == "2") { Resultado = "Negativo"; }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString() == "1")
                                                { Resultado2 = "Positivo"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString() == "2") { Resultado2 = "Negativo"; }
                                        // Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF, reEmpresa, rePruebaID) values (" + pacID + ", '" + Paciente + "', '" + dir + "', '" + Fechan + "', '" + Edad + "', '" + Cedula + "','" + Tipop + "', '" + radGridView1.Rows[rowInfo.Index].Cells[4].Value.ToString() + "', '" + Resultado + "', '" + Resultado + "', '" + CT + "',  '" + Resultado2 + "',  '" + CT2 + "','" + cambiada1 + "' , (select ppfecha from tbPruebasPendientes where ppempresaid = " + PrID + " and pppacid = " + pacID + "),  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + HoraMuestra.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "',NULL ,'"+Empresa+"','" + radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString() + "')";
                                        con.Open();
                                        cmd = new SqlCommand(Sql, con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.CommandText = "spInsertEmpresasResults";
                                        cmd.Parameters.Add(new SqlParameter("@pacid", SqlDbType.Int)).Value = pacID;
                                        cmd.Parameters.Add(new SqlParameter("@resultado", SqlDbType.VarChar)).Value = Resultado;
                                        cmd.Parameters.Add(new SqlParameter("@resultado2", SqlDbType.VarChar)).Value = Resultado2;
                                        cmd.Parameters.Add(new SqlParameter("@ct", SqlDbType.NChar)).Value = CT;
                                        cmd.Parameters.Add(new SqlParameter("@ct2", SqlDbType.NChar)).Value = CT2;
                                        cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.Date)).Value = cambiada1;
                                        cmd.Parameters.Add(new SqlParameter("@hora", SqlDbType.VarChar)).Value = HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                                        cmd.Parameters.Add(new SqlParameter("@empresa", SqlDbType.VarChar)).Value = Empresa;
                                        cmd.Parameters.Add(new SqlParameter("@pruebaid", SqlDbType.Int)).Value = PrID;
                                        break;
                                        }
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    DelPrueba();
                                    GeneratePDF();
                                    Logs log = new Logs();
                                    log.Accion = "Resultados del paciente: " + Paciente + " del Lote: "+LoteID+", Empresa: " + Empresa + " Reportados";
                                    log.Form = "Asignacion de Resultados: Empresas";
                                    log.SaveLog();
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                finally
                                {
                                    con.Close();

                                }
                 
                                    }
                                    else
                                    {
                                        MessageBox.Show("Debe seleccionar el resultado.", "Operacion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                        SendMail();
                        ResultadoEmpresa();
                        MessageBox.Show("Resultados generados satisfactoriamente.", "Operacion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    //}

                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}
                }
            
        }
        public void ResultadoEmpresa()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    if (ConteoNoReportados == 0)
                    {
                        string sql = "update tbLotesempresa set lotResultados = 1 where lotid = '" + LoteID + "'";

                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0) ;
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
                    Logs log = new Logs();
                    log.Accion = "Resultados de Empresa: " + Empresa + " Reportados";
                    log.Form = "Asignacion de Resultados: Empresas";
                    log.SaveLog();
                }
            }
        }
        public void GeneratePDF()
        {
            using (var con = new SqlConnection(conect))
            {
                String Query = "insert into tbcontrolpdf (cpreid, cppacid, cpgenerate, cpfecha, cphora, cpuser, cpenglish) values ((select reid from tbResultados where rePruebaID = " + PrID + " and repacid = " + pacID + "), " + pacID + ", '0', '" + cambiada1 + "', '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + UserCache.Usuario + "', @English) ";
                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@English", English);
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
                }
            }
        }
        public void SendMail()
        {
            using (var con = new SqlConnection(conect))
            {
               
                String Query2 = "insert into tbControlMail (cmreid, cmpruebaempresaid, cmmail, cmfecha, cmhora, cmenviado, cmerror) values ((select reid from tbResultados where rePruebaID = " + PrID + " and repacid = " + pacID + "), '"+PrID+"', '" + mail + "', '" + cambiada1 + "', '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', 0, NULL) ";
                cmd = new SqlCommand(Query2, con);
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
                }
            }
        }
        public void DelPrueba()
        {
            using (var con = new SqlConnection(conect))
            {
                String Sqls = "delete from tbPruebasPendientes where ppempresaid = '" + PrID + "' and pppacid = "+pacID+"";

                SqlCommand cmd = new SqlCommand(Sqls, con);
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
                }
            }
        }
    }
}
