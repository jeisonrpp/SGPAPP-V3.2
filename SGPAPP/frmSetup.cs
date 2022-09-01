using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace SGPAPP
{

    public partial class frmSetup : Form
    {
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string cambiada1;
        int UserID;

        public frmSetup()
        {
            InitializeComponent();
        }

        private void cbbSeguro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cbbPlantilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnPacient_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Usuarios") || UserCache.Nivel == "Admin")
            {
                frmUSer us = new frmUSer();
            us.ShowDialog();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Email") || UserCache.Nivel == "Admin")
            {
                frmEmail em = new frmEmail();
            em.ShowDialog();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Plantilla") || UserCache.Nivel == "Admin")
            {
                frmPlantilla pl = new frmPlantilla();
            pl.ShowDialog();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Citas") || UserCache.Nivel == "Admin")
            {
                frmCitastime ct = new frmCitastime();
            ct.ShowDialog();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Logs") || UserCache.Nivel == "Admin")
            {
                frmLogs lo = new frmLogs();
            lo.ShowDialog();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Pruebas") || UserCache.Nivel == "Admin")
            {
                frmTiposPruebas prt = new frmTiposPruebas();
            prt.ShowDialog();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
