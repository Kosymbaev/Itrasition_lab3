using System;

namespace Task3
{

    public class Program
    {
        public static void Main(string[] args)
        {

            var choice = new List<string>();
            for (int i = 0; i < args.Length; i++)
            {
                choice.Add(args[i]);
            }
            if (choice.Count() % 2 == 0)
            {
                Console.WriteLine("Error 1: Enter odd number of strings\nExample: stOne Paper sCiSsOrS");
                return;
            }
            if (choice.Count < 3)
            {
                Console.WriteLine("Error 3: Enter odd number  >3\nExample : stone paper sea");
                return;
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
            
            
            while (true)
            {
                var random = new Random();
                int computerchoice = random.Next(0, choice.Count());
                string namecompchoice = choice[computerchoice];
                string nameuserchoice;
                MyHmac keyHmac = new MyHmac();
                Console.WriteLine("HMAC:\n" + keyHmac.returnHMAC(namecompchoice));
                Console.WriteLine("Avalable moves:");
                for (int i = 0; i < choice.Count; i++)
                {
                    Console.WriteLine(i+$" - {choice[i]}");
                }
                Console.WriteLine("0 - exit");
                Console.WriteLine("? - TableRules(help)");
                Console.WriteLine("Enter your choice:");
                string answer = Console.ReadLine();
                if (answer.All(Char.IsDigit) && Convert.ToInt32(answer) <= choice.Count() && answer != "0")
                {
                    nameuserchoice = choice[Convert.ToInt32(answer)];
                }
                else
                {
                    if (answer == "?")
                    {
                        var table = new Table(choice);
                        continue;
                    }
                    else
                    {
                        if (answer == "0") 
                        {
                            Console.WriteLine("Thanks for a game! Bye!");
                            break;
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}