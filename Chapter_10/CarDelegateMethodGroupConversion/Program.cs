using System;

namespace CarDelegateMethodGroupConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");

            Car c1 = new Car("SlugBug", 100, 10);

            c1.RegisterWithCarEngine(CallMeHere);

            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            c1.UnRegisterWithCarEngine(CallMeHere);

            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            Console.ReadLine();
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine($"=> {msg}");
            Console.WriteLine("***********************************\n");
        }

        public static void CallMeHere(string msg)
        {
            Console.WriteLine($"=> {msg.ToUpper()}");
        }
    }
}
