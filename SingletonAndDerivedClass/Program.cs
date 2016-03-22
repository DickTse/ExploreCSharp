using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExploreCSharp.SingletonAndDerivedClass
{
    class Program
    {
        static void Main(string[] args)
        {
            SingletonBase baseObj = SingletonBase.Instance;
            baseObj.StaticNum = 1;
            SingletonChild childObj = SingletonChild.Instance;
            childObj.StaticNum = 2;
            Console.WriteLine(String.Format("baseObj: {0}", baseObj.StaticNum));
            Console.WriteLine(String.Format("childObj: {0}", childObj.StaticNum));
            Console.ReadKey();
        }
    }
}
