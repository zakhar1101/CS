using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace WinFormsApp6
{
    class Class1
    {
        public static bool OK()
        {
            try
            {
                Dns.GetHostEntry("ya.ru");
                return true;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
                return false;
            }
        }
    }
}
