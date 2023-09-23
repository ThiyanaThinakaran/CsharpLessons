using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Day6._0
{
    internal class Cars
    {
        public class Car
        {
            public string RegistrationNo { get; set; }
            public string Model { get; set; }
            public FuelType FuelType { get; set; }
            public string[] Wheels { get; set; }
            public Engine CarEngine { get; set; }

            public Car(string registrationNo, string model, FuelType fuelType, string[] wheels)
            {
                RegistrationNo = registrationNo;
                Model = model;
                FuelType = fuelType;
                Wheels = wheels;
                CarEngine = new Engine();
            }

            public class Engine
            {
                public int NoOfCylinders { get; set; }

                public Engine()
                {
                    NoOfCylinders = 4; // Default value for demonstration purposes
                }
            }
        }

        public enum FuelType
        {
            Petrol,
            Diesel,
            Electric,
            Hybrid
        }

        public class Program
        {
            public static void TestMethod(string[] args)
            {
                string[] carWheels = { "Left", "Right", "Rear Left", "Rear Right" };

                Car myCar = new Car("ABC123", "Hyundai", FuelType.Petrol, carWheels);

                Console.WriteLine("Registration No: " + myCar.RegistrationNo);
                Console.WriteLine("Model: " + myCar.Model);
                Console.WriteLine("Fuel Type: " + myCar.FuelType);
                Console.WriteLine("Wheels: ");
                foreach (string wheel in myCar.Wheels)
                {
                    Console.WriteLine("- " + wheel);
                }
                Console.WriteLine("Number of Cylinders in the Engine: " + myCar.CarEngine.NoOfCylinders);
            }
        }
    }
}

