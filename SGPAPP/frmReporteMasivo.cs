﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmReporteMasivo : Telerik.WinControls.UI.RadForm
    {
        public frmReporteMasivo()
        {
            InitializeComponent();
            this.radGridView1.CellBeginEdit += new GridViewCellCancelEventHandler(radGridView1_CellBeginEdit);
            dta.Columns.Add("Id", typeof(int));
            dta.Columns.Add("Result", typeof(string));
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        DataTable dta = new DataTable();
        DataTable dt = new DataTable();
        String Prueba;
        bool Influenzatest = false;
        bool Anticuerpo = false;
        DateTime Fecha = DateTime.Now;
        String day;
        String mes;
        String year;
        String cambiada1;
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
        String mail;
        String mail2;
        String Cedula;
        private void frmReporteMasivo_Load(object sender, EventArgs e)
        {

            CargaCbbPruebas();
        }
        public void CargaCbbPruebas()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (prNombre) as [Pruebas] from tbPruebas where prlaboratorios = 0 order by prNombre", con);

                da.Fill(ds);
                cbbPrueba.DataSource = ds.Tables[0].DefaultView;
                cbbPrueba.ValueMember = "Pruebas";
                cbbPrueba.Text = "Seleccione el tipo de prueba";
                this.cbbPrueba.MultiColumnComboBoxElement.DropDownWidth = 100;
                this.cbbPrueba.EditorControl.TableElement.Font = new System.Drawing.Font("Segoe UI", 12F);
                con.Close();
            }
        }
        public void GetPruebas()
        {
            try
            {

                using (var con = new SqlConnection(conect))
                {

                    SqlDataAdapter da = new SqlDataAdapter("spGetPruebasPendientes", con);

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);
                    da.SelectCommand.Parameters.AddWithValue("@Pruebas", cbbPrueba.Text);
                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
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


                        //foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
                        //{
                        GridViewRowInfo rows = radGridView1.CurrentRow;
                        Prueba = radGridView1.Rows[rows.Index].Cells[7].Value.ToString();
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

                                cbbResults2.Name = "cbbResults2";
                            cbbResults.HeaderText = "igG";
                            cbbResults2.HeaderText = "igM";
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
                            radGridView1.Columns.Move(0, 11);
                            radGridView1.Columns[9].IsVisible = false;
                            radGridView1.Columns[1].ReadOnly = true;
                            radGridView1.Columns[2].ReadOnly = true;
                            radGridView1.Columns[3].ReadOnly = true;
                            radGridView1.Columns[4].ReadOnly = true;
                            radGridView1.Columns[5].ReadOnly = true;
                            radGridView1.Columns[6].ReadOnly = true;
                            radGridView1.Columns[7].ReadOnly = true;
                            radGridView1.Columns[8].ReadOnly = true;
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
                            radGridView1.Columns.Move(0, 11);
                            radGridView1.Columns[9].IsVisible = false;
                            radGridView1.Columns[1].ReadOnly = true;
                            radGridView1.Columns[2].ReadOnly = true;
                            radGridView1.Columns[3].ReadOnly = true;
                            radGridView1.Columns[4].ReadOnly = true;
                            radGridView1.Columns[5].ReadOnly = true;
                            radGridView1.Columns[6].ReadOnly = true;
                            radGridView1.Columns[7].ReadOnly = true;
                            radGridView1.Columns[8].ReadOnly = true;
                        }
                        else
                        {
                            chkEnglish.Width = 60;
                            this.radGridView1.Columns.Add(chkEnglish);
                            foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
                            {
                                this.radGridView1.Rows[rowInfo.Index].Cells["cbbResults"].Value = 0;
                            }
                            radGridView1.Columns.Move(0, 11);
                            radGridView1.Columns[9].IsVisible = false;
                            radGridView1.Columns[1].ReadOnly = true;
                            radGridView1.Columns[2].ReadOnly = true;
                            radGridView1.Columns[3].ReadOnly = true;
                            radGridView1.Columns[4].ReadOnly = true;
                            radGridView1.Columns[5].ReadOnly = true;
                            radGridView1.Columns[6].ReadOnly = true;
                            radGridView1.Columns[7].ReadOnly = true;
                            radGridView1.Columns[8].ReadOnly = true;
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;


                fecha1 = Fecha;

                day = fecha1.Day.ToString();
                mes = fecha1.Month.ToString();
                year = fecha1.Year.ToString();

                cambiada1 = year + "-" + mes + "-" + day;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
        private void radGridView1_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            RadDropDownListEditor comboBoxEditor = this.radGridView1.ActiveEditor as RadDropDownListEditor;
            if (comboBoxEditor != null)
            {
                comboBoxEditor.EditorElement.StretchVertically = false;
                comboBoxEditor.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
                comboBoxEditor.DropDownSizingMode = SizingMode.UpDownAndRightBottom;
            }
            RadMultiColumnComboBoxElement mccb = e.ActiveEditor as RadMultiColumnComboBoxElement;
            if (mccb != null)
            {
                mccb.AutoSizeDropDownToBestFit = true;
            }
        }

        private void cbbPrueba_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            if (cbbPrueba.Text != "Seleccione el tipo de prueba")
            {             
                GetPruebas();
                cbbPrueba.Enabled = false;
                btnCarga.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el tipo de prueba");
            }
        }
        public void GetPaciente()
        {
            //obtener los datos del paciente
            using (var con = new SqlConnection(conect))
            {
                string sql = "SELECT  RTRIM(pFecha) as [Edad] , RTRIM(pemail) as [Email] , RTRIM(pdir) as [Direccion], RTRIM(pemail2) as [Email2] from tbpacientes where pID = '" + pacID + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                       
                        Edad = reader[0].ToString();
                        if (Edad == "1900-01-01")
                        {
                          Edad = "-";
              
                        }
                        else
                        {
                            Edad = Convert.ToString(DateTime.Today.AddTicks(-DateTime.Parse(Edad).Ticks).Year - 1);
                            Edad = Edad + " años";
  
                        }
                        Fechan = reader[0].ToString();
                        mail = reader[1].ToString();
                        dir = reader[2].ToString();
                        mail2 = reader[3].ToString();

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
            int count = 0;
            foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
            {
                if (radGridView1.Rows[rowInfo.Index].Cells[0].Value != null)
                {
                    count = count+1;
                }
            }
            if (count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un resultado para reportar", "Asignar Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult resulta = MessageBox.Show("Esta seguro que desea asignar estos resultados?", "Asignar Resultados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {

                    try
                    {
                        using (var con = new SqlConnection(conect))
                        {
                            foreach (GridViewRowInfo rowInfo in radGridView1.Rows) if (radGridView1.Rows[rowInfo.Index].Cells[0].Value != null)
                                {
                                    conviertefecha();
                                    Prueba = radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString();
                                    PrID = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[1].Value);
                                    pacID = Convert.ToInt32(radGridView1.Rows[rowInfo.Index].Cells[2].Value);
                                    GetPaciente();
                                    Paciente = radGridView1.Rows[rowInfo.Index].Cells[3].Value.ToString();
                                    Cedula = radGridView1.Rows[rowInfo.Index].Cells[4].Value.ToString();
                                    HoraRegistro = DateTime.Now;
                                    English = false;
                                    if (Prueba == "Antigeno" && radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString() != "0" || Prueba == "Sars Cov-2" && radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString() != "0" || Prueba == "Influenza" && radGridView1.Rows[rowInfo.Index].Cells[9].Value.ToString() != "0" || radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString() != "0" || Prueba == "Anticuerpo-Covid" && radGridView1.Rows[rowInfo.Index].Cells[9].Value.ToString() != "0" || radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString() != "0")
                                    {
                                        switch (Prueba)
                                        {
                                            case "Antigeno":
                                                if (radGridView1.Rows[rowInfo.Index].Cells[10].Value == null) { CT = "-"; }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[12].Value != null) { English = true; }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString() == "1")
                                                { Resultado = "Positivo"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString() == "2") { Resultado = "Negativo"; }
                                                Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF, rePruebaID) values (" + pacID + ", '" + Paciente + "', '" + dir + "', '" + Fechan + "', '" + Edad + "', '" + Cedula + "','" + radGridView1.Rows[rowInfo.Index].Cells[5].Value.ToString() + "', '" + radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() + "', '" + Resultado + "', '" + Resultado + "', '" + CT + "', NULL, NULL,'" + cambiada1 + "' , '" + radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString() + "',  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString() + "',NULL , '" + radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString() + "')";
                                                break;
                                            case "Sars Cov-2":
                                                if (radGridView1.Rows[rowInfo.Index].Cells[10].Value == null) { CT = "-"; }
                                                else { CT = radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString(); }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[12].Value != null) { English = true; }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString() == "1")
                                                { Resultado = "Detectado"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[9].Value.ToString() == "2") { Resultado = "No Detectado"; }
                                                Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF, rePruebaID) values (" + pacID + ", '" + Paciente + "', '" + dir + "', '" + Fechan + "', '" + Edad + "', '" + Cedula + "','" + radGridView1.Rows[rowInfo.Index].Cells[5].Value.ToString() + "', '" + radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() + "', '" + Resultado + "', '" + Resultado + "', '" + CT + "', NULL, NULL,'" + cambiada1 + "' , '" + radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString() + "',  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString() + "',NULL , '" + radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString() + "')";
                                                break;
                                            case "Influenza":
                                                if (radGridView1.Rows[rowInfo.Index].Cells[11].Value == null) { CT = "-"; }
                                                else { CT = radGridView1.Rows[rowInfo.Index].Cells[11].Value.ToString(); }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[13].Value == null) { CT2 = "-"; }
                                                else { CT2 = radGridView1.Rows[rowInfo.Index].Cells[13].Value.ToString(); }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString() == "1")
                                                { Resultado = "Detectado"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString() == "2") { Resultado = "No Detectado"; }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[12].Value.ToString() == "1")
                                                { Resultado2 = "Detectado"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[12].Value.ToString() == "2") { Resultado2 = "No Detectado"; }
                                                Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF, rePruebaID) values (" + pacID + ", '" + Paciente + "', '" + dir + "', '" + Fechan + "', '" + Edad + "', '" + Cedula + "','" + radGridView1.Rows[rowInfo.Index].Cells[5].Value.ToString() + "', '" + radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() + "', '" + Resultado + "', '" + Resultado + "', '" + CT + "',  '" + Resultado2 + "',  '" + CT2 + "','" + cambiada1 + "' , '" + radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString() + "',  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString() + "',NULL , '" + radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString() + "')";
                                                break;
                                            case "Anticuerpo-Covid":
                                                if (radGridView1.Rows[rowInfo.Index].Cells[11].Value == null) { CT = "-"; }
                                                else { CT = radGridView1.Rows[rowInfo.Index].Cells[11].Value.ToString(); }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[13].Value == null) { CT2 = "-"; }
                                                else { CT2 = radGridView1.Rows[rowInfo.Index].Cells[13].Value.ToString(); }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString() == "1")
                                                { Resultado = "Positivo"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[10].Value.ToString() == "2") { Resultado = "Negativo"; }
                                                if (radGridView1.Rows[rowInfo.Index].Cells[12].Value.ToString() == "1")
                                                { Resultado2 = "Positivo"; }
                                                else if (radGridView1.Rows[rowInfo.Index].Cells[12].Value.ToString() == "2") { Resultado2 = "Negativo"; }
                                                Sql = "insert into tbResultados(rePacid, rePaciente, reDir, reFechan, reEdad, reCed, reTipop, rePrueba, reResultado, reResultado1, reCT, reResultado2, reCT2, reFecha, refecham, reHora, reHoram, reDocPDF, rePruebaID) values (" + pacID + ", '" + Paciente + "', '" + dir + "', '" + Fechan + "', '" + Edad + "', '" + Cedula + "','" + radGridView1.Rows[rowInfo.Index].Cells[5].Value.ToString() + "', '" + radGridView1.Rows[rowInfo.Index].Cells[6].Value.ToString() + "', '" + Resultado + "', '" + Resultado + "', '" + CT + "',  '" + Resultado2 + "',  '" + CT2 + "','" + cambiada1 + "' , '" + radGridView1.Rows[rowInfo.Index].Cells[7].Value.ToString() + "',  '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', '" + radGridView1.Rows[rowInfo.Index].Cells[8].Value.ToString() + "',NULL , '" + radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString() + "')";
                                                break;
                                        }
                                        cmd = new SqlCommand(Sql, con);
                                        cmd.CommandType = CommandType.Text;
                                        con.Open();
                                        try
                                        {
                                            int i = cmd.ExecuteNonQuery();

                                            DelPrueba();
                                            GeneratePDF();
                                            SendMail();
                                            Logs log = new Logs();
                                            log.Accion = "Resultados del paciente: " + Paciente + " Reportados";
                                            log.Form = "Asignacion de Resultados Masivos";
                                            log.SaveLog();
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
                                    else
                                    {
                                        MessageBox.Show("Debe seleccionar el resultado.", "Operacion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            MessageBox.Show("Resultados generados satisfactoriamente.", "Operacion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);                      
                            this.Close();
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
                if (mail2.Length > 0)
                {
                    mail = mail + ", " + mail2;
                }
                String Query2 = "insert into tbControlMail (cmreid, cmpruebaempresaid, cmmail, cmfecha, cmhora, cmenviado, cmerror) values ((select reid from tbResultados where rePruebaID = " + PrID + " and repacid = " + pacID + "), '0', '" + mail + "', '" + cambiada1 + "', '" + HoraRegistro.ToString("hh:mm tt", CultureInfo.InvariantCulture) + "', 0, NULL) ";
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
                String Sqls = "delete from tbPruebasPendientes where ppID = '" + PrID + "'";

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
