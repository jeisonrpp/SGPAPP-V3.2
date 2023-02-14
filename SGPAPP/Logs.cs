using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public class Logs
    {
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        public String Accion { get; set; }
        public String Form { get; set; }

        

        public void SaveLog()
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


            using (var con = new SqlConnection(conect))
            {
                
                con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertaLogs";
                cmd.Parameters.Add(new SqlParameter("@form", SqlDbType.VarChar)).Value = Form;
                cmd.Parameters.Add(new SqlParameter("@accion", SqlDbType.VarChar)).Value = Accion;
                cmd.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar)).Value = UserCache.LoginName;
                cmd.Parameters.Add(new SqlParameter("@pc", SqlDbType.VarChar)).Value = PC;
                cmd.Parameters.Add(new SqlParameter("@ip", SqlDbType.VarChar)).Value = localIP;

                try
                {
                    int i = cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
