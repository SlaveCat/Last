using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class connection
    {
        public static string con()
        {
            string cons = @"Data Source=DESKTOP-SRTCC3M\SQLEXPRESS;Initial Catalog=Session1_00;Integrated Security=True";
            return cons;
        }
    }
}
