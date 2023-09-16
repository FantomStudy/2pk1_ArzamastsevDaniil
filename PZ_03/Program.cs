using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер дня: ");
            int day = Convert.ToInt32(Console.ReadLine());
           // введем переменную дня и конвертируем ее в целочисленный формат
            switch (day) //оператор свитч для выбора кейса
            {
                case int num when (num >= 1 && num <= 10): //переменная num приравнивается к переменной day. затем переменная num сравнивается со  необходимыми значениямию
                    Console.WriteLine("принадлежит первой декаде");
                   
                    break;
                case int num when (num >= 11 && num <= 20):
                    Console.WriteLine("принадлежит второй декаде");
                    break;
                case int num when (num >= 21 && num <= 31):
                    Console.WriteLine("принадлежит третьей декаде");
                    break;
                case int num when (num < 1 || num > 31 ): //если переменная не подходит ни под один из условий
                    Console.WriteLine("некорректно");
                    break;
            }
           
           

        }
    }
}