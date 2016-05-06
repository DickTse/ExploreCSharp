using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolableObject {
    interface IPoolableObject : IDisposable {
        int Size { get; }
        void Reset();
        void SetPoolManager(PoolManager poolManager);
    }

    class PoolManager {
        private class Pool {
            public int PooledSize { get; set; }
            public int Count { get { return this.Stack.Count; } }
            public Stack<IPoolableObject> Stack { get; private set; }
            public Pool() {
                this.Stack = new Stack<IPoolableObject>();
            }
        }

        const int MaxSizePerType = 10 * (1 << 10);  // 10 MB

        Dictionary<Type, Pool> pools = new Dictionary<Type, Pool>();

        public int TotalCount {
            get {
                int sum = 0;
                foreach (var pool in this.pools.Values) {
                    sum += pool.Count;
                }
                return sum;
            }
        }

        public T GetObject<T>() where T : class, IPoolableObject, new() {
            Pool pool;
            T valueToReturn = null;
            if (pools.TryGetValue(typeof(T), out pool)) {
                if (pool.Stack.Count > 0) {
                    valueToReturn = pool.Stack.Pop() as T;
                }
            }
            if (valueToReturn == null) {
                valueToReturn = new T();
            }
            valueToReturn.SetPoolManager(this);
            return valueToReturn;
        }

        public void ReturnObject<T>(T value) where T : class, IPoolableObject, new() {
            Pool pool;
            if (!pools.TryGetValue(typeof(T), out pool)) {
                pool = new Pool();
                pools[typeof(T)] = pool;
            }

            if (value.Size + pool.PooledSize < MaxSizePerType) {
                pool.PooledSize += value.Size;
                value.Reset();
                pool.Stack.Push(value);
            }
        }

    }

    class MyObject : IPoolableObject {
        private PoolManager poolManager;
        public byte[] Data { get; set; }
        public int UsableLength { get; set; }

        public int Size {
            get { return Data != null ? Data.Length : 0; }
        }

        void IPoolableObject.Reset() {
            UsableLength = 0;
        }

        void IPoolableObject.SetPoolManager(PoolManager poolManager) {
            this.poolManager = poolManager;
        }

        public void Dispose() {
            this.poolManager.ReturnObject(this);
        }
    }

    class Program {
        static void Main(string[] args) {
            PoolManager poolManager = new PoolManager();
            Console.WriteLine($"poolManager.TotalCount before creating any poolable object = {poolManager.TotalCount}");
            Console.WriteLine();
            using (MyObject obj = new MyObject()) {
                Console.WriteLine("A new poolable object is created.");
                (obj as IPoolableObject).SetPoolManager(poolManager);
                obj.Data = new byte[15];
                Console.WriteLine($"Object's size = {obj.Size}");
                Console.WriteLine($"Object's usable length = {obj.UsableLength}");
            }
            Console.WriteLine("The first poolable object is disposed. The object is returned to the pool.");
            Console.WriteLine($"After the first poolable object is disposed, poolManager.TotalCount = {poolManager.TotalCount}");
            Console.WriteLine();

            using (MyObject obj2 = new MyObject()) {
                Console.WriteLine("Another new poolable object is created.");
                (obj2 as IPoolableObject).SetPoolManager(poolManager);
                obj2.Data = new byte[28];
                Console.WriteLine($"Object's size = {obj2.Size}");
                Console.WriteLine($"Object's usable length = {obj2.UsableLength}");
            }
            Console.WriteLine("The second poolable object is disposed. The object is returned to the pool.");
            Console.WriteLine($"After the second poolable object is disposed, poolManager.TotalCount = {poolManager.TotalCount}");
            Console.WriteLine();

            using (MyObject obj3 = poolManager.GetObject<MyObject>()) {
                Console.WriteLine("The third poolable object is created. It is created by getting the last object from the pool manager.");
                Console.WriteLine($"Object's size = {obj3.Size}");
                Console.WriteLine($"Object's usable length = {obj3.UsableLength}");
            }
            Console.WriteLine("The third poolable object is disposed. The object is returned to the pool.");
            Console.WriteLine($"After the third poolable object is disposed, poolManager.TotalCount = {poolManager.TotalCount}");
            Console.WriteLine();

            using (MyObject obj4 = poolManager.GetObject<MyObject>()) {
                Console.WriteLine("The forth poolable object is created. It is created by getting the last object from the pool manager.");
                Console.WriteLine($"Object's size = {obj4.Size}");
                Console.WriteLine($"Object's usable length = {obj4.UsableLength}");
            }
            Console.WriteLine("The forth poolable object is disposed. The object is returned to the pool.");
            Console.WriteLine($"After the forth poolable object is disposed, poolManager.TotalCount = {poolManager.TotalCount}");
            Console.Read();
        }
    }
}
