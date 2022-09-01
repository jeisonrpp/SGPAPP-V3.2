using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class frmEditFecha : Form
    {
        public frmEditFecha()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Esta seguro que desea asignar la fecha de muestra: "+txtFecha.Text+"?", "Asignar Fecha?", MessageBoxButtons.YesNo);
            if (resulta == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
