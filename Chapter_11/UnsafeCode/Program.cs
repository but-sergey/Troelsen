using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace UnsafeCode
{
    class Program
    {
        unsafe struct Node
        {
            public int Value;
            public Node* Left;
            public Node* Right;
        }

        public struct Node2
        {
            public int Value;
            public unsafe Node2* Left;
            public unsafe Node2* Right;
        }

        static unsafe void SquareIntPointer(int* myIntPointer)
        {
            *myIntPointer *= *myIntPointer;
        }

        static unsafe void PrintValueAndAddress()
        {
            int myInt;
            int* ptrToMyInt = &myInt;
            *ptrToMyInt = 123;
            Console.WriteLine($"Value of myInt {myInt}");
            Console.WriteLine("Address of myInt {0:X}", (int)&ptrToMyInt);
        }

        public unsafe static void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        public static void SafeSwap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        struct Point
        {
            public int x;
            public int y;
            public override string ToString() => $"({x}, {y})";
        }

        static unsafe void UsePointerToPoint()
        {
            Point point;
            Point* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine(p->ToString());

            Point point2;
            Point* p2 = &point2;
            (*p2).x = 100;
            (*p2).y = 200;
            Console.WriteLine((*p2).ToString());
        }

        static unsafe void UnsafeStackAlloc()
        {
            char* p = stackalloc char[256];
            for(int k = 0; k < 256; k++)
            {
                p[k] = (char)k;
            }
        }

        class PointRef
        {
            public int x;
            public int y;
            public override string ToString() => $"({x}, {y})";
        }

        public unsafe static void UseAndPinPoint()
        {
            PointRef pt = new PointRef
            {
                x = 5,
                y = 6
            };

            fixed(int* p = &pt.x)
            {
            }

            Console.WriteLine($"Point is: {pt}");
        }

        static unsafe void Main(string[] args)
        {
            int myInt = 5;
            SquareIntPointer(&myInt);
            Console.WriteLine($"myInt: {myInt}");

            PrintValueAndAddress();

            int i = 10, j = 20;

            Console.WriteLine("\n***** Safe swap *****");
            Console.WriteLine($"Values before safe swap: i = {i}, j = {j}");
            SafeSwap(ref i, ref j);
            Console.WriteLine($"Values after safe swap: i = {i}, j = {j}");

            Console.WriteLine("\n***** Unsafe swap *****");
            Console.WriteLine($"Values before unsafe swap: i = {i}, j = {j}");
            unsafe { UnsafeSwap(&i, &j); }
            Console.WriteLine($"Values ofter unsafe swap: i = {i}, j = {j}");
            Console.WriteLine();

            UsePointerToPoint();

            Console.ReadLine();
        }
    }
}
