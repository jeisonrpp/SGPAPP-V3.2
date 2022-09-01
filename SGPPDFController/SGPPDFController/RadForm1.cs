using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SGPPDFController
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();

        public void GetPendientes()
        {

            using (var con = new SqlConnection(conect))
            {
                listView1.View = View.Details;
                con.Open();

                SqlCommand cmd = new SqlCommand("select cpreid, cpgenerate, cpfecha, cphora, cpuser from tbcontrolpdf where cpgenerate = 0 ", con);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DataTable DT = new DataTable();
                DA.Fill(DS, "PDF");
                con.Close();

                DT = DS.Tables["PDF"];
                int i;
                for (i = 0; i <= DT.Rows.Count - 1; i++)
                {
                    listView1.Items.Add(DT.Rows[i].ItemArray[0].ToString());
                    listView1.Items[i].SubItems.Add(DT.Rows[i].ItemArray[1].ToString());
                    listView1.Items[i].SubItems.Add(DT.Rows[i].ItemArray[2].ToString());
                    listView1.Items[i].SubItems.Add(DT.Rows[i].ItemArray[3].ToString());
                    listView1.Items[i].SubItems.Add(DT.Rows[i].ItemArray[4].ToString());
                    listView1.Items[i].SubItems.Add(DT.Rows[i].ItemArray[5].ToString());
                }


            }

        }
        private void RadForm1_Load(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //var timer = new System.Timers.Timer(TimeSpan.FromMinutes(0.10).TotalMilliseconds);
            //timer.Elapsed += async (sender2, e2) =>
            //{
            GetPendientes();

            //};
            //timer.Start();
        }
    }
}
