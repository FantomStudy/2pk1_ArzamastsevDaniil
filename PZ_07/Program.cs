namespace PZ_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int s1 = Convert.ToInt32(Console.ReadLine());
            int s2 = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[s1, s2];
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < s1; i++)
            {
                for (int j = 0; j < s2; j++)
                {
                    array[i, j] = r.Next(-20, 20);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            int max = array[0, 0];
            int imax = 0, jmax = 0 ;
            for (int i = 0; i < s1; i++)
            {
                for (int j = 0; j < s2; j++)
                {
                 if (array[i, j] > max)
                 {
                   max = array[i, j ];
                   imax = i;
                   jmax = j;
                 }
                }
            }
            Console.WriteLine("Максимальный элемент: " + max);
            Console.WriteLine("Индексы: " + imax + " " + jmax);

        }
    }
}