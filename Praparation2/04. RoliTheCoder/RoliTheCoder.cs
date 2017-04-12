namespace _04.RoliTheCoder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Event
    {
        public string Name { get; set; }

        public SortedSet<string> Participants { get; set; }

    }

    public class RoliTheCoder
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var dict = new Dictionary<int, string>();
            var events = new List<Event>();

            while (inputLine != "Time for Code")
            {
                var tokens = inputLine
                    .Split(new char[] { ' ' }
                    , StringSplitOptions.RemoveEmptyEntries);

                var isExist = false;

                var currentId = int.Parse(tokens[0]);
                var currentEventName = string.Empty;

                if (tokens[1].StartsWith("#"))
                {
                    currentEventName = tokens[1].Trim('#');
                }
                else
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                var participants = new SortedSet<string>();

                if (tokens.Length > 2)
                {
                    if (!tokens.Skip(2).All(p => p.StartsWith("@")))
                    {
                        inputLine = Console.ReadLine();
                        continue;
                    }

                    for (int i = 2; i < tokens.Length; i++)
                    {
                        participants.Add(tokens[i]);
                    }
                }

                if (dict.ContainsKey(currentId))
                {
                    if (!dict[currentId].Contains(currentEventName))
                    {
                        inputLine = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        foreach (var item in events)
                        {
                            if (item.Name == currentEventName)
                            {
                                foreach (var participant in participants)
                                {
                                    item.Participants.Add(participant);
                                }
                            }
                        }

                        isExist = true;
                    }
                }
                if (!dict.ContainsKey(currentId))
                {
                    dict.Add(currentId, "");
                }
                if (!dict[currentId].Contains(currentEventName))
                {
                    dict[currentId] = currentEventName;
                }

                if (!isExist)
                {
                    events.Add(new Event { Name = currentEventName, Participants = participants });
                }

                inputLine = Console.ReadLine();
            }

            foreach (var item in events.OrderByDescending(x => x.Participants.Count).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Participants.Count}");

                foreach (var participant in item.Participants)
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }
}

