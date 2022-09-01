using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPAPP
{
    public class CitasTime
    {
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        public String WeekMax;
        public String WeekMin;
        public String WeekendMax;
        public String WeekendMin;
        public void GetTimeSetp()
        {
            using (var con = new SqlConnection(conect))
            {
                string sql = "select CONVERT(varchar(15),CAST(cttimemaxweek AS TIME),100) as [Hora Maxima de Semana], CONVERT(varchar(15),CAST(cttimemaxweekend AS TIME),100) as [Hora Maxima de Sabados],  CONVERT(varchar(15),CAST(ctTimeminweek AS TIME),100) as [Hora Minima de Semana],  CONVERT(varchar(15),CAST(cttimeminweekend AS TIME),100) as [Hora Minima de Sabados] from tbcitastime where ctid = '1' ";
                //SqlConnection con = new SqlConnection(cs.ConnectionString);
                cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        WeekMax = reader[0].ToString();
                        WeekendMax = reader[1].ToString();
                        WeekMin = reader[2].ToString();
                        WeekendMin = reader[3].ToString();                        
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }

        }
    }
}
