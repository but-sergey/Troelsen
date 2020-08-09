using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    class Program
    {
        static void DrawSquare(Square sq)
        {
            Console.WriteLine(sq.ToString());
            sq.Draw();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Conversions *****\n");

            Rectangle r = new Rectangle(15, 4);
            Console.WriteLine(r.ToString());
            r.Draw();
            Console.WriteLine();

            Square s = (Square)r;
            Console.WriteLine(s.ToString());
            s.Draw();
            Console.WriteLine();

            Rectangle rect = new Rectangle(10, 5);
            DrawSquare((Square)rect);
            Console.WriteLine();

            Square sq2 = (Square)90;
            Console.WriteLine($"sq2 = {sq2}");
            Console.WriteLine();

            int side = (int)sq2;
            Console.WriteLine($"Side length of sq2 = {side}");
            Console.WriteLine();

            Square s3 = new Square { Length = 7 };
            Rectangle rect2 = s3;
            Console.WriteLine($"rect2 = {rect2}");
            Console.WriteLine();

            Square s4 = new Square { Length = 3 };
            Rectangle rect3 = (Rectangle)s4;
            Console.WriteLine($"rect3 = {rect3}");
            Console.WriteLine();            

            Console.ReadLine();
        }
    }
}
