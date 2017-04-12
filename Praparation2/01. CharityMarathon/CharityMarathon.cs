namespace _01.CharityMarathon
{
    using System;

    public class CharityMarathon
    {
        public static void Main()
        {
            long marathonCountDays = long.Parse(Console.ReadLine());
            long runnersCount = long.Parse(Console.ReadLine());
            long lapNumbers = long.Parse(Console.ReadLine());
            long lapLenght = long.Parse(Console.ReadLine());
            long trackCapacity = long.Parse(Console.ReadLine());
            decimal moneyPerKilometer = decimal.Parse(Console.ReadLine());

            long totalRunnersPerDay = trackCapacity * marathonCountDays;

            if (totalRunnersPerDay > runnersCount)
            {
                totalRunnersPerDay = runnersCount;
            }

            decimal totalKilometers = (totalRunnersPerDay * lapNumbers * lapLenght) / 1000.0m;
            decimal moneyRaised = totalKilometers * moneyPerKilometer;

            Console.WriteLine("Money raised: {0:f2}", moneyRaised);
        }
    }
}