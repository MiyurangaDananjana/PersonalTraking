using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalTraking
{
   public class UserStatic
    {
        public static int EmployeeID { get; set; }
        public static int UserNo { get; set; }
        public static bool? isAdmin { get; set; }

        public string EmpName { get; set; }
    }
}
