using System.ComponentModel.Design;

namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            double x, y, f, t;
            Console.WriteLine("Введите n: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите x: ");
            x = Convert.ToDouble(Console.ReadLine());
            if (x < 0)
            {
                y = 18 * n / Math.Cos(x);
            }
            else
            {
                y = 4 * Math.Pow(x, 2) + 8 * n;
            }
            if (y <= 5)
            {
                f = n * Math.Sqrt(3 * x - 5 * y);
            }
            else
            {
                f = 30;
            }
            t = 100 * x + 20 * n * x * y; 
            Console.WriteLine("n = " + n);
            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + Math.Round(y, 2));
            Console.WriteLine("f = " + Math.Round(f, 2));
            Console.WriteLine("t = " + Math.Round(t, 2));
            
        }
    }
}