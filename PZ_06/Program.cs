namespace PZ_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] array1 = new int[30];
            // Исходный массив
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < array1.Length; i++)
            {

                array1[i] = r.Next(-50, 51);
                Console.Write($" {array1[i]}");
            }
            Console.WriteLine();
            // Копирование положительных значений и подсчет 
            int count = array1.Where(x => x > 0).Count(); //Переменная счетчика. метод фильтрации Where для поиска чисел =>0 
            int[] array2 = array1.Where(x => x > 0).ToArray(); //новый массив для положительных чисел
            Console.WriteLine($"Количество положительных значений: {count}");
            Console.WriteLine("Положительные значения:");
            foreach (int num in array2)
            {
                Console.Write($"{num} ");
            }
        }
    }
    
}