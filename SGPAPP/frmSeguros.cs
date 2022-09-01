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
    public partial class frmSeguros : Form
    {
        public frmSeguros()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void txttel_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNom.Text == "")
                {
                    MessageBox.Show("Debe completar los campos faltantes");
                }
                else
                {
                    using (var con = new SqlConnection(conect))
                    {
                        con.Open();
                        string ct = "select segseguro from tbseguros where segseguro = '" + txtNom.Text + "'";

                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            MessageBox.Show("Este seguro ya esta registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                            return;

                        }

                        else if ((rdr != null))
                        {
                            con.Close();
                            string Sql = "insert into tbSeguros(segseguro, segTel) values ('" + txtNom.Text + "', '" + txttel.Text + "')";
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
                            }

                            MessageBox.Show("Seguro Guardado Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            DateTime fechas1 = DateTime.Now;

                            String days = fechas1.Day.ToString();
                            String mess = fechas1.Month.ToString();
                            String years = fechas1.Year.ToString();

                            Logs log = new Logs();
                            log.Accion = "Seguro: " + txtNom.Text + " Guardado";
                            log.Form = "Registro de Seguros";
                            log.SaveLog();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
        }
    }
}
