using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.IO;

namespace SGPAPP
{
    public partial class frmPreResultados : Telerik.WinControls.UI.RadForm
    {
        public frmPreResultados()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn2 = new GridViewCommandColumn();
            commandColumn2.Name = "CommandColumn2";
            commandColumn2.UseDefaultText = true;
            commandColumn2.Image = Properties.Resources.icons8_checkmark_16;
            commandColumn2.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn2.FieldName = "select";
            commandColumn2.HeaderText = "Seleccionar";
            radGridView1.MasterTemplate.Columns.Add(commandColumn2);
            radGridView1.CommandCellClick += new CommandCellClickEventHandler(radGridView1_CommandCellClick);
        }
        
        private void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {

            IDre = (int)e.Row.Cells["ID de Resultado"].Value;
            name = (string)e.Row.Cells["Paciente"].Value;
            CheckPDF();
            if (checkPDF == true)
            {
                Process prc = new Process();
                prc.StartInfo.FileName = fileName;
                prc.Start();
                
                checkPDF = false;
            }
            else
            {
                MessageBox.Show("Este Resultado aun no ha sido generado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CheckPDF()
        {
            int rowIndex = radGridView1.CurrentCell.RowIndex;
            IDre = (int)this.radGridView1.Rows[rowIndex].Cells["ID de Resultado"].Value;
            name = (string)this.radGridView1.Rows[rowIndex].Cells["Paciente"].Value;

            using (var con = new SqlConnection(conect))
            {
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCargaPDFPreResultados";
                SqlDataReader reader;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = IDre;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        checkPDF = true;
                        string realname = reader[0].ToString();
                        int size = 1024 * 1024;
                        byte[] buffer = new byte[size];
                        int readBytes = 0;
                        int index = 0;
                        docname = name + "-" + rd.RandomNo + ".pdf";
                        fileName = @"C:\SGP\" + name + "-" + rd.RandomNo + ".pdf";
                        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            while ((readBytes = (int)reader.GetBytes(0, index, buffer, 0, size)) > 0)
                            {
                                fs.Write(buffer, 0, readBytes);
                                index += readBytes;
                            }
                        }
                    }
                    else
                    {
                        checkPDF = false;
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
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
  
        String docname;
        String name;    
        int PacID;
        int PruebaID;
        clsMail cm = new clsMail();
        int IDre;
        string fileName;
        bool validapr = false;
        clsRandomNo rd = new clsRandomNo();
        int Rows;
        int FactID;
        String Tipo;
        bool checkPDF;

        private void frmPreResultados_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {


            using (var con = new SqlConnection(conect))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetpreResults", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", (object)DBNull.Value);


                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    if (radGridView1.Columns[0].Name == "CommandColumn2")
                    {
                        radGridView1.Columns.Move(0, 18);
                        radGridView1.Columns[1].IsVisible = false;
                        radGridView1.Columns[8].IsVisible = false;
                        radGridView1.Columns[11].IsVisible = false;
                        radGridView1.Columns[12].IsVisible = false;
                        radGridView1.Columns[13].IsVisible = false;
                        radGridView1.Columns[19].IsVisible = false;
                        radGridView1.Columns[20].IsVisible = false;
                        
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
            }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (txtConsulta.Text.Length == 0)
                {
                    GetData();
                }
                else
                {

                    using (var con = new SqlConnection(conect))
                    {
                        try
                        {
                            //con = new SqlConnection(cs.ConnectionString);
                            con.Open();
                            SqlDataAdapter da = new SqlDataAdapter("spGetpreResults", con);
                            DataTable dt = new DataTable();
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@Nombre", txtConsulta.Text);


                            da.Fill(dt);
                            this.radGridView1.DataSource = dt;
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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
           
            }

        private void btnSav_Click(object sender, EventArgs e)
        {
            int rowIndex = radGridView1.CurrentCell.RowIndex;
            Tipo = radGridView1.Rows[rowIndex].Cells[8].Value.ToString();
            PacID = int.Parse(radGridView1.Rows[rowIndex].Cells[1].Value.ToString());
            name = radGridView1.Rows[rowIndex].Cells[2].Value.ToString();

                using (var con = new SqlConnection(conect))
                {
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand("", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spDeletePreResult";
                        cmd.Parameters.Add(new SqlParameter("@refactid", SqlDbType.Int)).Value = (int)radGridView1.Rows[rowIndex].Cells[20].Value;
                       
                        cmd.ExecuteNonQuery();

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
            MessageBox.Show("Pruebas devueltas a Gestion de Resultados con Exito!", "Pruebas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetData();
           
        }       
        private void radButton1_Click(object sender, EventArgs e)
        {
            CheckPDF();
            if (checkPDF == true)
            {

                int rowIndex = radGridView1.CurrentCell.RowIndex;
                DialogResult resulta = MessageBox.Show("Esta seguro que desea aprobar los resultados de: " + radGridView1.Rows[rowIndex].Cells[2].Value.ToString() + "?", "Aprobar Resultados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Tipo = radGridView1.Rows[rowIndex].Cells[8].Value.ToString();
                PacID = int.Parse(radGridView1.Rows[rowIndex].Cells[1].Value.ToString());
                
                if (resulta == DialogResult.Yes)
                {
                    foreach (GridViewRowInfo rowInfo in radGridView1.Rows) if ((int)radGridView1.Rows[rowInfo.Index].Cells[1].Value == PacID && (string)radGridView1.Rows[rowInfo.Index].Cells[8].Value == Tipo)
                        {
                            using (var con = new SqlConnection(conect))
                            {
                                try
                                {
                                    con.Open();
                                    cmd = new SqlCommand("", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "spInsertResultadosLab";
                                    cmd.Parameters.Add(new SqlParameter("@reid", SqlDbType.VarChar)).Value = radGridView1.Rows[rowInfo.Index].Cells[0].Value.ToString();
                                    cmd.Parameters.Add(new SqlParameter("@insertedfactid", SqlDbType.Int)).Direction = ParameterDirection.Output;                                  
                                    cmd.ExecuteNonQuery();
                                    FactID = (int)cmd.Parameters["@insertedfactid"].Value;

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
                                Logs log = new Logs();
                                log.Accion = "Resultados Aprobados a Prueba ID: " + PruebaID + " del Paciente: " + name + "";
                                log.Form = "Aprobar Resultados";
                                log.SaveLog();

                            }
                        }
                    SendMail(FactID);
                    MessageBox.Show("Resultados Aprobados Correctamente!", "Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetData();
                }
            }
            else
            {
                MessageBox.Show("Este Resultado aun no ha sido generado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
       
        public void SendMail(int id)
        {
            using (var con = new SqlConnection(conect))
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertSendMailControl";
                cmd.Parameters.Add(new SqlParameter("@refactid", id));

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void frmPreResultados_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
