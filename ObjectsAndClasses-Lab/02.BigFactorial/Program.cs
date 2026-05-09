using System.Numerics;

namespace _02.BigFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            BigInteger result = 1;

            for (int i = 2; i <= inputNumber; i++)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}
