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
    public partial class frmNoFact : Telerik.WinControls.UI.RadForm
    {
        public frmNoFact()
        {
            InitializeComponent();
        }
        SqlDataReader rdr = null;
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        private void radButton1_Click(object sender, EventArgs e)
        {
            if (txtNoFact.Text.Length > 0)
            {
                using (var con = new SqlConnection(conect))
                {
                    try
                    { 
                    con.Open();
                    string ct = "select refacturacionid from tbresultados where refacturacionid = '" + txtNoFact.Text + "'";

                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        MessageBox.Show("Este numero de facturacion ya se encuentra esta registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //con.Close();
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
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
        }

        private void txtNoFact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (txtNoFact.Text.Length > 0)
                {
                    using (var con = new SqlConnection(conect))
                    {
                        try { 
                        con.Open();
                        string ct = "select refacturacionid from tbresultados where refacturacionid = '" + txtNoFact.Text + "'";

                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            MessageBox.Show("Este numero de facturacion ya se encuentra esta registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //con.Close();
                            return;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
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
            }
            }
    }
}
