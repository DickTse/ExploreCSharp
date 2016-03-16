using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadSingleton
{
    class Singleton
    {
        private static object lck = new object();
        private Singleton() { }
        private static Singleton instance;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
        public void PrintMessage()
        {
            lock(lck)
            { 
                Console.WriteLine("Message 1");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Message 2");
            }
        }
    }
}
