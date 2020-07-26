using System;
using System.Collections.Generic;

namespace SimpleLambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lambdas *****\n");
            TraditionalDelegateSyntax();
            Console.ReadLine();
        }

        static void TraditionalDelegateSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);

            Console.WriteLine("Here are you even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write($"{evenNumber}\t");
            }
            Console.WriteLine();
        }

        static bool IsEvenNumber(int i)
        {
            return (i % 2) == 0;
        }
    }
}
