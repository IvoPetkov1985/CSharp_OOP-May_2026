namespace _03.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumption = double.Parse(carData[2]);
                Car car = new(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            string commandLine = Console.ReadLine();

            while (commandLine != "End")
            {
                string[] tokens = commandLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[1];
                double kilometers = double.Parse(tokens[2]);
                Car carToDrive = cars.FirstOrDefault(c => c.Model == model);

                if (carToDrive != null)
                {
                    carToDrive.Drive(kilometers);
                }

                commandLine = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }

    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double TraveledDistance { get; set; }

        public void Drive(double kilometers)
        {
            double neededAmount = kilometers * FuelConsumption;

            if (neededAmount <= FuelAmount)
            {
                FuelAmount -= neededAmount;
                TraveledDistance += kilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {TraveledDistance}";
        }
    }
}
