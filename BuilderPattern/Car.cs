using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern {
    // Represents a product created by the builder.
    class Car {
        public Car() { }
        public int Wheels { get; set; }
        public string Color { get; set; }
        public override string ToString() {
            return String.Format("Color: {0}; Wheels {1}", Color, Convert.ToString(Wheels));
        }
    }

    // The builder abstraction.
    interface ICarBuilder {
        void SetColor(string color);
        void SetWheels(int count);
        Car GetResult();
    }

    // Concrete builder implementation.
    class CarBuilder : ICarBuilder {
        private Car _car;
        public CarBuilder() {
            this._car = new Car();
        }
        public void SetColor(string color) {
            this._car.Color = color;
        }
        public void SetWheels(int count) {
            this._car.Wheels = count;
        }
        public Car GetResult() {
            return this._car;
        }
    }

    // The director
    class CarBuilderDirector {
        public Car Construct() {
            CarBuilder builder = new CarBuilder();
            builder.SetColor("Red");
            builder.SetWheels(4);
            return builder.GetResult();
        }
    }
}
