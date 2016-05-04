using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace List {
    interface IClass1 {
        string Str { get; set; }
    }

    class Class2 : IClass1 {
        public string Str { get; set; }
    }
    class Program {
        private const int MAX_CYCLE = 10;
        static void Main(string[] args) {
            TimeSpan totalTime = new TimeSpan();
            for (int j=0; j<MAX_CYCLE; j++) { 
                Stopwatch sw = new Stopwatch();
                List<Class2> strings = new List<Class2>();
                sw.Start();
                for (int i=0; i<1000000; i++) {
                    strings.Add(new Class2() { Str = new String('A', 1024) });
                }
                List<IClass1> class1 = strings.ConvertAll(x => (IClass1)x);
                sw.Stop();
                totalTime += sw.Elapsed;
                Console.WriteLine($"Elapsed time of round {j+1}: {sw.Elapsed}.");
            }
            Console.WriteLine($"Total elapsed time = {totalTime}");
            Console.WriteLine($"Average elapsed time = {totalTime.TotalSeconds / MAX_CYCLE}s");
            Console.Read();
        }
    }
}
