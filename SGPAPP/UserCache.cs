using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPAPP
{
    public class UserCache
    {
        public static string Usuario { get; set; }
        public static string Cedula { get; set; }
        public static string LoginName { get; set; }
        public static byte[] Password { get; set; }
        public static string Nivel { get; set; }

        public static string Status { get; set; }

        public static byte[] Salt { get; set; }

        public static int UserID { get; set; }

        public static List<UserRoles> RoleList = new List<UserRoles>();

        public static List<RolesEmpresa> EmpresaRoles = new List<RolesEmpresa>();

    }
}
