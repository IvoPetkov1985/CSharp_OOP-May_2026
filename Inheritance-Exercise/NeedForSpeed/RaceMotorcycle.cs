namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public new const double DefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
