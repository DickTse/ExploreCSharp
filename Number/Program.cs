using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "99999999999999999";
            decimal d = Convert.ToDecimal(s) / 100;
            Console.WriteLine(String.Format("{0:0.00}", d));
            Console.Read();
        }
    }
}
