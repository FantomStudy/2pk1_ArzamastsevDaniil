using System.Reflection.Metadata.Ecma335;

namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для работы с программой введите переменные: a, b, c");
            //создаём переменные с типом данных string, чтобы пользователь мог ввести значения переменных сам
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            string str3 = Console.ReadLine();
            //при невозможности конвертации блок try-catch поймает ошибку и выведет сообщение.
            try
            {
                //создаём переменные a, b, c и присвоим им значения переменных str1, 2, 3 соответственно
                double a, b, c;
                a = Convert.ToDouble(str1);
                b = Convert.ToDouble(str2);
                c = Convert.ToDouble(str3);
                Console.WriteLine("Значения заданы успешно!");
                Console.WriteLine("Вычисляем пример...");
                //создаём переменную result, значение которой будет определяться формулой из условия
                double result;
                //чтобы записать формулу используем клаcc Math.
                result = Math.Log(Math.Pow(b, -Math.Sqrt(Math.Abs(a)))) * (a - b / 2) + Math.Pow(Math.Sin(Math.Atan(c)), 2);
                //выведем ответ в строку консоли
                Console.WriteLine("Пример решен! Ответ: " + result);
            }
            catch (Exception)
            {
                Console.WriteLine("Извините, задайте корректное значение");   
            }
           
        }
    }
}