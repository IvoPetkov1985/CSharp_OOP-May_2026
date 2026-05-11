using System.Text;

namespace _06.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IVehicle> vehicles = new();

            while (input != "End")
            {
                string[] vehicleTokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = vehicleTokens[0];
                string model = vehicleTokens[1];
                string color = vehicleTokens[2];
                int horsePower = int.Parse(vehicleTokens[3]);

                IVehicle vehicle = null;

                if (type == "car")
                {
                    vehicle = new Car(model, color, horsePower);
                }
                else if (type == "truck")
                {
                    vehicle = new Truck(model, color, horsePower);
                }

                vehicles.Add(vehicle);

                input = Console.ReadLine();
            }

            string vehicleInfo = Console.ReadLine();

            while (vehicleInfo != "Close the Catalogue")
            {
                IVehicle vehicle = vehicles.Find(v => v.Model == vehicleInfo);

                if (vehicle != null)
                {
                    Console.WriteLine(vehicle);
                }

                vehicleInfo = Console.ReadLine();
            }

            List<IVehicle> cars = vehicles.FindAll(v => v.GetType().Name == "Car");
            List<IVehicle> trucks = vehicles.FindAll(v => v.GetType().Name == "Truck");

            double averageCarHorsePower = 0;

            if (cars.Any())
            {
                averageCarHorsePower = cars.Average(c => c.HorsePower);
            }

            double averageTruckHorsePower = 0;

            if (trucks.Any())
            {
                averageTruckHorsePower = trucks.Average(t => t.HorsePower);
            }

            Console.WriteLine($"Cars have average horsepower of: {averageCarHorsePower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsePower:F2}.");
        }
    }

    interface IVehicle
    {
        string Model { get; set; }

        string Color { get; set; }

        int HorsePower { get; set; }
    }

    abstract class Vehicle : IVehicle
    {
        public Vehicle(string model, string color, int horsePower)
        {
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.AppendLine($"Type: {GetType().Name}");
            builder.AppendLine($"Model: {Model}");
            builder.AppendLine($"Color: {Color}");
            builder.AppendLine($"Horsepower: {HorsePower}");
            return builder.ToString().TrimEnd();
        }
    }

    class Truck : Vehicle
    {
        public Truck(string model, string color, int horsePower) :
            base(model, color, horsePower)
        {
        }
    }

    class Car : Vehicle
    {
        public Car(string model, string color, int horsePower) :
            base(model, color, horsePower)
        {
        }
    }
}
