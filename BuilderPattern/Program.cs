﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern {
    class Program {
        static void Main(string[] args) {
            CarBuilderDirector director = new CarBuilderDirector();
            Car car = director.Construct();
            Console.WriteLine(car);
            Console.Read();
        }
    }
}
