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

namespace SGPAPP
{
    public partial class frmTiposPruebas : Form
    {
        public frmTiposPruebas()
        {
            InitializeComponent();
        }

        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        int PruebaID;
        bool Modify = false;
        bool labs;
        bool Esp;
        private void btnSavep_Click(object sender, EventArgs e)
        {
            if (chkLab.Checked == true)
            {
                labs = true;
            }
            else
            {
                labs = false;
            }
            if (chkES.Checked == true)
            {
                Esp = true;
            }
            else
            {
                Esp = false;
            }

            if (Modify == true)
            {
                using (var con = new SqlConnection(conect))
                {
                   
                    string sql = "update tbPruebas set prTipo = '"+txtTipo.Text+"', prNombre ='"+txtPrueba.Text+"', prTiempo = '"+txtTiempo.Text+ "', prUnidad = '" + txtUnd.Text + "', prValores = '" + txtValMin.Text+" - "+txtValMax.Text + "', prlaboratorios = '" +labs + "'5, prvalmin = '" + txtValMin.Text + "', prvalmax = '" + txtValMax.Text + "', prEspecial = '"+Esp+"' where prid = " + PruebaID+"";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            MessageBox.Show("Prueba Actualizada Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:" + ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                        con.Close();
                        Logs log = new Logs();
                        log.Accion = "Prueba: " + txtPrueba.Text + " Actualizada";
                        log.Form = "Actualizacion de Pruebas";
                        log.SaveLog();
                        btnDelete.Enabled = false;
                        txtPrueba.Text = "";
                        txtTiempo.Text = "";
                        txtTipo.Text = "";
                        txtUnd.Text = "";
                        txtValMax.Text = "";
                        txtValMin.Text = "";
                        chkLab.Checked = false;
                        Modify = false;

                    }
                        
                }
            }
            else
            {
                using (var con = new SqlConnection(conect))
                {
                    con.Open();
                    string ct = "select * from tbPruebas where prTipo = '" + txtTipo.Text + "' and prNombre = '" + txtPrueba.Text + "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MessageBox.Show("Esta Prueba ya esta registrada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        return;

                    }
                    else if ((rdr != null))
                    {
                        con.Close();
                        string Sql = "insert into tbPruebas(prTipo, prNombre, prTiempo, prunidad, prvalores, prlaboratorios, prvalmin, prvalmax, prEspecial) values ('" + txtTipo.Text + "', '" + txtPrueba.Text + "', '" + txtTiempo.Text + "', '" + txtUnd.Text + "', '" + txtValMin.Text + " - " + txtValMax.Text + "', '" + labs + "', '" + txtValMin.Text + "', '" + txtValMax.Text + "', '"+Esp+"')";
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

                            Logs log = new Logs();
                            log.Accion = "Prueba: " + txtPrueba.Text + " Creada";
                            log.Form = "Creacion de Pruebas";
                            log.SaveLog();

                            txtPrueba.Text = "";
                            txtTiempo.Text = "";
                            txtTipo.Text = "";
                            txtUnd.Text = "";
                            txtValMax.Text = "";
                            txtValMin.Text = "";
                            chkLab.Checked = false;
                            chkES.Checked = false;
                            Modify = false;

                        }

                        }
                    }
            }
            GetData();
        }

      
        public void GetData()
        {
            try
            {
                using (var con = new SqlConnection(conect))
                {
                    int Rows;
                    Rows = dataGridView1.RowCount - 1;
                    con.Open();
                    cmd = new SqlCommand("select  prID as [ID de Prueba], prTipo as [Tipo de Prueba], prNombre as [Prueba], prUnidad as [Unidad], prValores as [Valores Esperados], prValmin as [Valores Minimos], prValmax as [Valores Maximos],  prLaboratorios as [Laboratorios], prTiempo as [Tiempo de Prueba], prEspecial as [Especial] from tbpruebas", con);
                    SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                    DataSet myDataSet = new DataSet();
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                    dataGridView1.RowHeadersVisible = false;
                    myDA.Fill(myDataSet, "Usuario");
                    dataGridView1.DataSource = myDataSet.Tables["Usuario"].DefaultView;
                    dataGridView1.Columns["ID de Prueba"].Visible = false;
                    dataGridView1.Columns["Tipo de Prueba"].DisplayIndex = 0;
                    dataGridView1.Columns["Prueba"].DisplayIndex = 1;
                    dataGridView1.Columns["Tiempo de Prueba"].DisplayIndex = 2;
                    dataGridView1.Columns["Valores Minimos"].Visible = false;
                    dataGridView1.Columns["Valores Maximos"].Visible = false;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void frmTiposPruebas_Load(object sender, EventArgs e)
        {
            GetData();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Consult")
                {
                    PruebaID = (int)this.dataGridView1.Rows[e.RowIndex].Cells["ID de Prueba"].Value;
                    txtTipo.Text = (string)this.dataGridView1.Rows[e.RowIndex].Cells["Tipo de Prueba"].Value;
                    txtPrueba.Text = (string)this.dataGridView1.Rows[e.RowIndex].Cells["Prueba"].Value;
                    txtTiempo.Text = (string)this.dataGridView1.Rows[e.RowIndex].Cells["Tiempo de Prueba"].Value.ToString();
                    txtUnd.Text = (string)this.dataGridView1.Rows[e.RowIndex].Cells["Unidad"].Value;
                    txtValMin.Text = (string)this.dataGridView1.Rows[e.RowIndex].Cells["Valores Minimos"].Value;
                    txtValMax.Text = (string)this.dataGridView1.Rows[e.RowIndex].Cells["Valores Maximos"].Value;
                    if ((bool)this.dataGridView1.Rows[e.RowIndex].Cells["Laboratorios"].Value == true)
                    {
                        chkLab.Checked = true;
                    }
                    if ((bool)this.dataGridView1.Rows[e.RowIndex].Cells["Especial"].Value == true)
                    {
                        chkES.Checked = true;
                    }

                    Modify = true;
                    btnDelete.Enabled = true;
                    
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "Consult" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridView1.Rows[e.RowIndex].Cells["Consult"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\\resourses\search.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dataGridView1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dataGridView1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                dataGridView1.Columns["Consult"].DisplayIndex = 10;
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (UserCache.Nivel == "Admin")
            {
                DialogResult resulta = MessageBox.Show("Seguro quiere eliminar esta Prueba: " + txtPrueba.Text + " ?", "Eliminar Prueba?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    String Sql = "delete from tbPruebas where prID = '" + PruebaID + "'";
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

                        Logs log = new Logs();
                        log.Accion = "Prueba: " + txtPrueba.Text + " Eliminada";
                        log.Form = "Eliminacion de Pruebas";
                        log.SaveLog();
                        txtPrueba.Text = "";
                        txtTiempo.Text = "";
                        txtTipo.Text = "";
                        btnDelete.Enabled = false;
                        Modify = false;
                        GetData();
                    }
                }
            }

            else
            {
                MessageBox.Show("Solo usuarios administradores pueden eliminar pruebas", "Eliminar Prueba?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            //if (dgbAdd.RowCount < 1)
            //{
            //    dgbAdd.Columns.Add("clComp", "Campo");
            //}
         
            
        }

        private void dgbAdd_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
          
        }

        private void dgbAdd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
