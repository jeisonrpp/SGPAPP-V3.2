using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmTest : Telerik.WinControls.UI.RadForm
    {
        public frmTest()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn2 = new GridViewCommandColumn();
            commandColumn2.Name = "CommandColumn2";
            commandColumn2.UseDefaultText = true;
            commandColumn2.Image = Properties.Resources.icons8_search_16;
            commandColumn2.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn2.FieldName = "ProductName";
            commandColumn2.HeaderText = "Ver si esta vaina funciona";
            radGridView1.MasterTemplate.Columns.Add(commandColumn2);
            radGridView1.CommandCellClick += new CommandCellClickEventHandler(radGridView1_CommandCellClick);
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
           
        }
        void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
            MessageBox.Show("Esta vaina funciona" + ((sender as GridCommandCellElement)).Value);
        }
    }
}
