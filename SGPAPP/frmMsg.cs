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
    public partial class frmMsg : Form
    {
        public frmMsg()
        {
            InitializeComponent();
        }
        public bool Ingles = false;

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult guardar = MessageBox.Show("Seguro deseas enviar estos resultados por correo?", "Envio de resultados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (guardar == DialogResult.Yes)
            {
               
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult guardar = MessageBox.Show("Seguro deseas reimprimir estos resultados?", "Reimpresion de resultados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (guardar == DialogResult.Yes)
            {
                
                this.DialogResult = DialogResult.Yes;
            }
        }

        private void chkIng_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmMsg_Load(object sender, EventArgs e)
        {

        }
    }
}
