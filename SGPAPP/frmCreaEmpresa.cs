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
    public partial class frmCreaEmpresa : Form
    {
        public frmCreaEmpresa()
        {
            InitializeComponent();
        }

        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        DateTime Fecha;
        string cambiada2;
        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertaEmpresa();
        }

        public void InsertaEmpresa()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    Fechadehoy();
                    SqlCommand AddEmpresa = new SqlCommand("Insert into tbEmpresas values (@pEmpresa, @pDir, @pEmail, @pCel, @Pruebas, @Resultados, @pFechaReg, @empruebaid)", con);
                    con.Open();


                    AddEmpresa.Parameters.Clear();
                    AddEmpresa.Parameters.AddWithValue("@pEmpresa", txtEmpresa.Text);
                    AddEmpresa.Parameters.AddWithValue("@pDir", txtDir.Text);
                    AddEmpresa.Parameters.AddWithValue("@pEmail", txtEmail.Text);
                    AddEmpresa.Parameters.AddWithValue("@pCel", txtCel.Text);
                    AddEmpresa.Parameters.AddWithValue("@empruebaid", DBNull.Value);
                    AddEmpresa.Parameters.AddWithValue("@Pruebas", SqlDbType.Bit).Value = false;                    
                    AddEmpresa.Parameters.AddWithValue("@Resultados", SqlDbType.Bit).Value = false;
                    AddEmpresa.Parameters.AddWithValue("@pFechareg", cambiada2);

                    AddEmpresa.ExecuteNonQuery();
                    MessageBox.Show("La empresa ha sido creada de manera exitosa!", "Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logs log = new Logs();
                    log.Accion = "Empresa: " + txtEmpresa.Text + " Creada";
                    log.Form = "Creacion de Empresas";
                    log.SaveLog();
                    con.Close();
                    this.DialogResult = DialogResult.OK;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
