using System;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");

            Car c1 = new Car("SlugBug", 100, 10);

            c1.AboutToBlow += delegate
            {
                Console.WriteLine("Eek! Going too fast!");
            };

            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine($"Message from Car: {e.msg}");
            };

            c1.Exploded += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine($"Fatal Message from Car: {e.msg}");
            };

            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            Console.ReadLine();
        }
    }
}
