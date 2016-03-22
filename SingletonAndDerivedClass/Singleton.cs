using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreCSharp.SingletonAndDerivedClass
{
    class SingletonBase
    {
        protected SingletonBase() { }
        private static SingletonBase instance;
        private int staticNum;
        public static SingletonBase Instance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonBase();
                return instance;
            }
        }
        public int StaticNum
        {
            get { return staticNum; }
            set { staticNum = value; }
        }
    }

    class SingletonChild : SingletonBase
    {
        private SingletonChild() { }
        private static SingletonChild instance;
        public new static SingletonChild Instance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonChild();
                return instance;
            }
        }
    }
}
