using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class frmConsolida : Form
    {
        public frmConsolida()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();


        private void frmConsolida_Load(object sender, EventArgs e)
        {
          
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
        private void btnSav_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
