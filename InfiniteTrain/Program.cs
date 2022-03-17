using System;

namespace InfiniteTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            var pressedButton = new ConsoleKey();
            while (pressedButton != ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("Enter count of railway carriages");
                int carriagesCount;
                Train train;
                try
                {
                    carriagesCount = int.Parse(Console.ReadLine());
                    train = new Train(carriagesCount);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine($"Created a train with {carriagesCount} cars\nLaunch the little man who will count the carriages");
                var countedCarriagesCount = train.CountCarriages();
                Console.WriteLine($"The little man counted {countedCarriagesCount} carriages");
                Console.WriteLine("Press any key to start over or Esc to exit");
                pressedButton = Console.ReadKey().Key;
            }
        }
    }
}