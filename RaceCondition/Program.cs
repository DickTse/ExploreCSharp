using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RaceCondition {
    class Param {
        private int _idx = 0;
        internal int Idx {
            get {
                lock(this) { 
                    return _idx;
                }
            }
            set {
                lock(this) { 
                    _idx = value;
                }
            }
        }

        static volatile Param _instance;
        static object _syncRoot = new object();

        private Param() { }
        public static Param Instance {
            get { 
                if (_instance == null)
                    lock(_syncRoot) {
                       if (_instance == null)
                            _instance = new Param();
                    }
                return _instance;
            }
        }
    }
    class Program {
        static readonly object lockObj = new object();
        static ManualResetEvent wait = new ManualResetEvent(false);
        static void startThread(object param) {
            Thread t = Thread.CurrentThread;
            t.Name = "Thread" + Convert.ToString(((Param)param).Idx);
            lock(param) { 
                
                Console.WriteLine(t.Name + " " + ((Param)param).Idx);
                wait.Set();
                Thread.Sleep(100);
                Console.WriteLine(t.Name + " " + ((Param)param).Idx);
            }
        }
        static void Main(string[] args) {
            Param param = Param.Instance;
            param.Idx = 1;
            wait.Reset();
            Thread t = new Thread(startThread);
            t.Start(param);
            wait.WaitOne();
            Param param2 = Param.Instance;
            param2.Idx = 2;
            Thread t2 = new Thread(startThread);
            t2.Start(param2);
            t.Join();
            t2.Join();
            Console.Read();
        }
    }
}
