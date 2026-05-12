namespace _04.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());

            Car[] cars = new Car[carsCount];

            for (int i = 0; i < carsCount; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];
                Engine engine = new(engineSpeed, enginePower);
                Cargo cargo = new(cargoWeight, cargoType);
                Car car = new(model, engine, cargo);
                cars[i] = car;
            }

            string command = Console.ReadLine();

            Car[] selectedCars = null;

            if (command == "fragile")
            {
                selectedCars = Array
                    .FindAll(cars, c => c.Cargo.CargoType == "fragile" && c.Cargo.Weight < 1000);
            }
            else if (command == "flamable")
            {
                selectedCars = Array
                    .FindAll(cars, c => c.Cargo.CargoType == "flamable" && c.Engine.Power > 250);
            }

            foreach (Car car in selectedCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }

    public class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; set; }

        public int Power { get; set; }
    }

    public class Cargo
    {
        public Cargo(int weight, string cargoType)
        {
            Weight = weight;
            CargoType = cargoType;
        }

        public int Weight { get; set; }

        public string CargoType { get; set; }
    }
}
