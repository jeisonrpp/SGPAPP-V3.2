using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class frmLoadPDF : Form
    {
        public frmLoadPDF()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        clsRandomNo rd = new clsRandomNo();
        public String Factid;
        bool generado = false;
        bool abort = false;

        private async void frmLoadPDF_Load(object sender, EventArgs e)
        {
            ShowLoading();
            timer1.Interval = 15000;
            timer1.Enabled = true;
            Task oTask = new Task(LoadThread);
            oTask.Start();
            await oTask;
            HideLoading();
        }
        public void LoadThread()
        {
            Thread.Sleep(30000);
            timer1.Enabled = false;
            if (generado == false)
            {

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate { this.Close(); }));
                }
                //MessageBox.Show("El PDF ha tardado demasiado en generarse, puede consultar el PDF en Resultados Pendientes una vez se genere.");
                this.DialogResult = DialogResult.No;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        public void ShowLoading()
        {
            Loading.Visible = true;
            Loading.Load(Environment.CurrentDirectory + @"\\resourses\\Spinner.gif");
            Loading.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public void HideLoading()
        {
            Loading.Visible = false;
        }

        public void CheckPDF()
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                con.Open();
                using (SqlCommand cm = con.CreateCommand())
                {
                    cm.CommandText = "Select top 1 redocpdf, repaciente from tbpreresultados where reFacturacionID ='" + Factid + "' and redocpdf is not null";
                    String realname;
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            generado = true;
                            timer1.Enabled = false;
                            rd.GetNo();
                            realname = dr[1].ToString();
                            int size = 1024 * 1024;
                            byte[] buffer = new byte[size];
                            int readBytes = 0;
                            int index = 0;
                            string fileName = @"C:\SGP\" + rd.RandomNo + " - " + realname + ".pdf";
                            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                while ((readBytes = (int)dr.GetBytes(0, index, buffer, 0, size)) > 0)
                                {
                                    fs.Write(buffer, 0, readBytes);
                                    index += readBytes;
                                }
                            }
                            Process prc = new Process();
                            prc.StartInfo.FileName = fileName;
                            prc.Start();
                            this.DialogResult = DialogResult.Yes;
                            this.Close();
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckPDF();
        }
    }
}
