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
    public partial class frmCitastime : Form
    {
        public frmCitastime()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string cambiada1;

        private void frmCitastime_Load(object sender, EventArgs e)
        {
            GetHorarioCitas();
        }
        public void GetHorarioCitas()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "Select ctTimeMinWeek, ctTimeMaxWeek, ctTimeMinWeekend, ctTimeMaxWeekend from tbcitastime where ctid = '1' ";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtMinWeek.Text = reader[0].ToString();
                        txtMaxWeek.Text = reader[1].ToString();
                        txtMinSab.Text = reader[2].ToString();
                        txtMaxSab.Text = reader[3].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado la configuracion de Horarios de Citas!");
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

        private void btnSavec_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "update tbCitasTime set ctTimeMaxWeek = '" + txtMaxWeek.Text + "', ctTimeMaxWeekend= '" + txtMaxSab.Text + "', ctTimeMinWeek= '" + txtMinWeek.Text + "', ctTimeMinWeekend= '" + txtMinSab.Text + "' where ctid = '1'";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Configuracion Actualizada Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
