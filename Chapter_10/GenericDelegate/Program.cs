using System;

namespace GenericDelegate
{
    class Program
    {
        public delegate void MyGenericDelegate<T>(T arg);

        static void Main(string[] args)
        {
            Console.WriteLine("***** Generic Delegates *****\n");

            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Some string data");

            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntTarget);
            intTarget(9);

            Console.ReadLine();
        }

        static void StringTarget(string arg)
        {
            Console.WriteLine($"arg in uppercase is: {arg.ToUpper()}");
        }

        static void IntTarget(int arg)
        {
            Console.WriteLine($"++arg is: {++arg}");
        }
    }
}
