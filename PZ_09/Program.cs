namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str; //создание переменной со строкой
            int count = 0; //счетчик задания строк
            while (true) //бесконечный цикл
            {
                str = Console.ReadLine(); //код строки
                if (str[0] == '_') //условие если первый символ _ то конец цикла
                    break;
                else
                    count++; //прибавление счетчика если не выполнено условие
            }
            Console.WriteLine();
            for (int i = 0; i < count + 1; i++) //вывод строки по счетчику
            {
                Console.WriteLine(str);
            }
        }
    }
}