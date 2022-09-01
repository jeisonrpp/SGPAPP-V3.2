using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class frmEmail : Form
    {
        public frmEmail()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;

        private void frmEmail_Load(object sender, EventArgs e)
        {
            CargaDatos();
        }
        public void CargaDatos()
        {
            using (var con = new SqlConnection(conect))
            {
                try { 
                string sql = "Select mailfrom, mailname, mailsubject, mailtext, mailsmtp, mailport, mailssl, mailuser, mailpass from tbemail where mailid = '1'";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtFrom.Text = reader[0].ToString();
                        txtName.Text = reader[1].ToString();
                        txtSubject.Text = reader[2].ToString();
                        txtText.Text = reader[3].ToString();
                        txtSmtp.Text = reader[4].ToString();
                        txtPort.Text = reader[5].ToString();
                        cbbSSL.Text = reader[6].ToString();
                        txtMail.Text = reader[7].ToString();
                        txtPassword.Text = reader[8].ToString();

                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado la configuracion!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Seguro quiere actualizar la configuracion del correo?", "Actualizar Correo?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                using (var con = new SqlConnection(conect))
                {
                    try
                    { 
                    string sql = "update tbEmail set mailfrom = '" + txtFrom.Text + "', mailName= '" + txtName.Text + "', mailSubject= '" + txtSubject.Text + "', mailtext= '" + txtText.Text + "', mailsmtp= '" + txtSmtp.Text + "' , mailport= '" + txtPort.Text + "', mailssl= '" + cbbSSL.Text + "' , mailuser= '" + txtMail.Text + "', mailpass= '" + txtPassword.Text + "' where mailid = '1'";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                   
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            MessageBox.Show("Configuracion Actualizada Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                    finally
                    {
                        string localIP;
                        using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                        {
                            socket.Connect("8.8.8.8", 65530);
                            IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                            localIP = endPoint.Address.ToString();
                        }
                        String PC = "Computer Name: " + Environment.MachineName;
                        localIP = "IP: " + localIP;

                        con.Close();
                        DateTime fechas1 = DateTime.Now;
                        String days = fechas1.Day.ToString();
                        String mess = fechas1.Month.ToString();
                        String years = fechas1.Year.ToString();
                        string cambiadas1 = years + "-" + mess + "-" + days;
                        String Hora = DateTime.Now.ToString("hh:mm");

                        try
                        { 
                        string Sql2 = "insert into tbLogs(logFecha, logHora, logForm, logAccion, logUser, logPC, logIP) values ('" + cambiadas1 + "', '" + Hora + "', 'Configuracion Mail', 'Configuracion de Email Actualizada','" + UserCache.LoginName + "', '" + PC + "', '" + localIP + "')";
                        // con = new SqlConnection(cs.ConnectionString);
                        cmd = new SqlCommand(Sql2, con);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        
                            int i = cmd.ExecuteNonQuery();


                    }
                        catch (Exception ex)
                    {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                    }
                    finally
                        {
                            con.Close();
                            this.Close();

                        }
                    }
                }
            }
        }
    }
}
