namespace _03.NetherRealms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Demon
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public double Damage { get; set; }

    }

    public class NetherRealms
    {
        public static void Main()
        {
            var dragonsNames = Console.ReadLine()
                .Split(new char[] { ',', ' '}
                , StringSplitOptions.RemoveEmptyEntries);
            var healthRegex = new Regex(@"[^0-9\+\-\*\.\/]");
            var damageRegex = new Regex(@"-?\d+\.?\d*");
            var arithmeticSymbols = new Regex(@"[\*\/]");
            var demons = new List<Demon>();

            foreach (var dragonName in dragonsNames)
            {
                var health = 0;

                var healthSymbolsMatches = healthRegex.Matches(dragonName);

                foreach (Match symbol in healthSymbolsMatches)
                {
                    health += symbol.Value.ToCharArray().First();
                }

                double damage = 0;

                var damageSymbolsMatches = damageRegex.Matches(dragonName);

                foreach (Match symbol in damageSymbolsMatches)
                {
                    damage += double.Parse(symbol.Value);
                }

                var arithmeticSymbolsMatches = arithmeticSymbols.Matches(dragonName);

                foreach (Match symbol in arithmeticSymbolsMatches)
                {
                    if (symbol.Value == "*")
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                var currentDemon = new Demon { Name = dragonName, Health = health, Damage = damage };

                demons.Add(currentDemon);
            }

            foreach (var demon in demons.OrderBy(n => n.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }           
        }
    }
}
