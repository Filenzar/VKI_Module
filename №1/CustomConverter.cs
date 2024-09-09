using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CustomConverter
    {
        internal void Converting(string a, out int b)
        {
            b = Convert.ToInt32(a);
        }
        internal void Converting(string a, out double b)
        {
            b = Convert.ToDouble(a);
        }
        internal void Converting(string a, out byte b)
        {
            b = Convert.ToByte(a);
        }
    }
}
