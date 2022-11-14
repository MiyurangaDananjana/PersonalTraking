using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


   public class Genaral
    {
        public static bool isNumber (KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))// can type nu,ber only
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

