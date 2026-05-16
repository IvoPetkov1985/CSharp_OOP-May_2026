namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        public const double DefaultFuelConsumption = 1.25;

        protected Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption
        {
            get
            {
                return DefaultFuelConsumption;
            }
        }

        public virtual void Drive(double kilometers)
        {
            double neededFuel = FuelConsumption * kilometers;

            if (Fuel >= neededFuel)
            {
                Fuel -= neededFuel;
            }
        }
    }
}
