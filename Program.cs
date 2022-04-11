using System;

namespace Task3
{

    public class Program
    {
        public static void Main(string[] args)
        {

            var choice = new List<string>();
            choice.Add("sjjf");
            choice.Add("sagilahg");
            choice.Add("sjjfaggregag");
            for (int i = 0; i < args.Length; i++)
            {
                choice.Add(args[i]);
            }
            if (choice.Count() % 2 == 0)
            {
                Console.WriteLine("Error 1: Enter odd number of strings\nExample: stOne Paper sCiSsOrS");
            }
            if (choice.Count < 3)
            {
                Console.WriteLine("Error 3: Enter odd number  >3\nExample : stone paper sea");
            }
            bool repeat = false;
            for (int i = 0; i < choice.Count() - 1; i++)
            {
                for (int j = i + 1; j < choice.Count(); j++)
                {
                    if (choice[j] == choice[i]) repeat = true;
                }
            }
            if (repeat)
            {
                Console.WriteLine("Error 2: Please dont repeat strings\nExample: r0ck dog cat");
                return;
            }
            var table = new Table(choice);
            Console.WriteLine();
        }
    }
}