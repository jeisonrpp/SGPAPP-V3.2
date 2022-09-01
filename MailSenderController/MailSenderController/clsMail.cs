using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailSenderController
{
    public class clsMail
    {

        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlConnection con = new SqlConnection(conect);
        public String MailFrom;
        public String MailName;
        public String MailSubject;
        public String MailText;
        public String MailSMTP;
        public String MailPort;
        public bool MailSSL;
        public String MailUser;
        public String MailPass;


        public void GetMailSetup()
        {
            try
            {
                string sql = "Select mailfrom, mailname, mailsubject, mailtext, mailsmtp, mailport, mailssl, mailuser, mailpass from tbemail where mailid = '1'  ";
                //SqlConnection con = new SqlConnection(cs.ConnectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader;
                cmd.CommandType = CommandType.Text;
                con.Open();


                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MailFrom = reader[0].ToString();
                    MailName = reader[1].ToString();
                    MailSubject = reader[2].ToString();
                    MailText = reader[3].ToString();
                    MailSMTP = reader[4].ToString();
                    MailPort = reader[5].ToString();
                    MailSSL = bool.Parse(reader[6].ToString());
                    MailUser = reader[7].ToString();
                    MailPass = reader[8].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la Conexion, Favor verificar conexion a internet. Error :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                con.Close();
            }
        }

    }
}
