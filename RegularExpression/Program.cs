using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = @"ABCD!@#$%^&*()_+~{}|:""<>?`-=[]\; ',./a";
            Console.WriteLine(str);
            Match match = Regex.Match(str, @"[A-Z0-9a-z!@#$%^&*()_+~{}|:""<>?`\-=\[\]\\; ',./]+");
            //Match match = Regex.Match(str, @"$\d+");
            if (match.Success)
            {
                string outstr = match.Groups[0].Value;
                Console.WriteLine(outstr);
            }
            Console.Read();
        }
    }
}
