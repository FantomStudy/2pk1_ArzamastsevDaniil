namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число не меньше,чем 2: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int i = 2;
            while (i <= a)
            {
                i++;
                if (a % i == 0)
                {
                    break;
                }
            }
            Console.WriteLine("Наименьший натуральный делитель этого числа: " + i);
        }
    }
}