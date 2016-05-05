using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FixedLengthFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("D:\\Git\\ExploreCSharp\\FixedLengthFileReader\\data\\IECQDC035R20160401.txt");
            string line = lines[0];
            Header hdr = new Header();
            FixedLengthReader reader = new FixedLengthReader();
            reader.Read(line, hdr);
            Console.WriteLine(hdr.ToString());
            Console.Read();
        }
    }
}
