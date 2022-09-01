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

            DateTime fechas1 = DateTime.Now;
            String days = fechas1.Day.ToString();
            String mess = fechas1.Month.ToString();
            String years = fechas1.Year.ToString();
            string cambiadas1 = years + "-" + mess + "-" + days;
            String Hora = DateTime.Now.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            using (var con = new SqlConnection(conect))
            {
                string Sql = "insert into tbLogs(logFecha, logHora, logForm, logAccion, logUser, logPC, logIP) values ('" + cambiadas1 + "', '" + Hora + "', '"+Form+"', '"+Accion+"','" + UserCache.LoginName + "','" + PC + "','" + localIP + "')";

                cmd = new SqlCommand(Sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
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
