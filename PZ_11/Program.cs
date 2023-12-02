namespace PZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число n: ");
            int n = Convert.ToInt32(Console.ReadLine()); //ввод n(предельное число)
            GetLimitSumm(n, out int summ); //вызов метода
            Console.WriteLine($"Сумма простых чисел до {n}: {summ}");
        }

        //метод, определяющий простые числа. 
        static bool Simple(int number)
        {
            if (number < 2) //условие 1
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++) // условие 2
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true; //число простое
        }
        static void GetLimitSumm(int n, out int summ)
        {
            //начальная сумма = 0, если функция симпл передает фолз, функция остается 0
            summ = 0; 
            //цикл, определяющий сумму. если симпл передает тру, то сумма прибавляет это значение
            for (int i = 2; i <= n; i++) 
            {
                if (Simple(i)) //вызов функции симпл (на проверку простое ли число i)
                {
                    summ += i;
                }
            }
        }
    }
}