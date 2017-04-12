namespace _02.Ladybugs
{
    using System;
    using System.Linq;

    public class Ladybugs
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var ladybugIndexes = Console.ReadLine()
                .Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var field = new int[size];

            foreach (var index in ladybugIndexes)
            {
                if (index > field.Length - 1 || index < 0)
                {
                    continue;
                }
                else
                {
                    field[index] = 1;
                }
            }

            var command = Console.ReadLine();

            while (true)
            {
                if (command == "end")
                {
                    break;
                }

                var currentCommand = command
                    .Split(new char[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries);
                var currentLadybugIndex = int.Parse(currentCommand[0]);
                var currentDirection = currentCommand[1];
                var flightLength = int.Parse(currentCommand[2]);

                if (currentLadybugIndex > field.Length - 1 || currentLadybugIndex < 0)
                {
                    command = Console.ReadLine();
                    continue;
                }
                else if (field[currentLadybugIndex] == 0)
                {
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    field[currentLadybugIndex] = 0;

                    while (true)
                    {
                        if (currentDirection == "right")
                        {
                            currentLadybugIndex += flightLength;
                        }
                        else
                        {
                            currentLadybugIndex -= flightLength;
                        }
                        if (currentLadybugIndex > field.Length - 1 || currentLadybugIndex < 0)
                        {
                            break;
                        }
                        else if (field[currentLadybugIndex] == 1)
                        {
                            continue;
                        }
                        else
                        {
                            field[currentLadybugIndex] = 1;
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
