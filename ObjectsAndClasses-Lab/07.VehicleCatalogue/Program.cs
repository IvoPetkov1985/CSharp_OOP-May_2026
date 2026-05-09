namespace _07.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            Catalog catalog = new();

            while (inputLine != "end")
            {
                string[] vehicleTokens = inputLine
                    .Split("/", StringSplitOptions.RemoveEmptyEntries);
                string vehicleType = vehicleTokens[0];
                string brand = vehicleTokens[1];
                string model = vehicleTokens[2];
                int value = int.Parse(vehicleTokens[3]);

                if (vehicleType == "Car")
                {
                    Car car = new(brand, model, value);
                    catalog.Cars.Add(car);
                }
                else
                {
                    Truck truck = new(brand, model, value);
                    catalog.Trucks.Add(truck);
                }

                inputLine = Console.ReadLine();
            }

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");

                foreach (Car car in catalog.Cars.OrderBy(c => c.Brand))
                {
                    Console.WriteLine(car.ToString());
                }
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (Truck truck in catalog.Trucks.OrderBy(t => t.Brand))
                {
                    Console.WriteLine(truck.ToString());
                }
            }
        }
    }

    class Catalog
    {
        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }

        public ICollection<Car> Cars { get; set; }

        public ICollection<Truck> Trucks { get; set; }
    }

    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {HorsePower}hp";
        }
    }

    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }
}
