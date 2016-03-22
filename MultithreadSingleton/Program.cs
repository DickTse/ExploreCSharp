using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExploreCSharp.MultithreadSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thd1 = new Thread(new ThreadStart(runThread));
            Thread thd2 = new Thread(new ThreadStart(runThread));
            thd1.Start();
            thd2.Start();
            thd1.Join();
            thd2.Join();
            Console.Write("Program finished. Press any key to exit.");
            Console.ReadKey();
        }

        private static void runThread()
        {
            Singleton instance = Singleton.Instance;
            instance.PrintMessage();
        }
    }
}
