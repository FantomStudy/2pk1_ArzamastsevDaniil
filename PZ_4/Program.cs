﻿namespace PZ_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание номер 1");
            //Вывести на экран построчно целые числа из указанного диапазона и с указанным шагом.
            int d = 0; //n - выводимое число
            for (int i = 0; i < 21; i++) //i - счетчик
            {
                Console.WriteLine(d);
                d = d + 4; // +4 - шаг, указанный в таблице

            }


            Console.WriteLine("Задание номер 2");
            //Вывести на экран в одну строку 7 символов в алфавитном порядке, начиная с символа 'c'
            char l = 'c'; // Заданный символ
            int s = 7; // сколько символов вывести
            for (int i = 0; i < s; i++) //пока i < указанного количества символов цикл выполняется
            {
                Console.Write(l); //вывод l
                l++; //задает l следующее значение
            }
            Console.WriteLine();

            Console.WriteLine("Задание номер 3");
            //Вывести на экран посимвольно n знаков ‘#’ в m строках
            for (int i = 0; i < 6; i++) //вывод строки с # указанное количество раз
            {
                for (int j = 0; j < 5; j++)//вывод # указанное количество раз в 1 строку
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Задание номер 4");
            //Из диапазона значений вывести значения кратные числу b через пробел, используя один цикл. В конце вывести количество кратных чисел
            int h, u, k;
            h = -500; //низший порог
            u = -299; //высший порог
            k = 5; //делитель
            for (int i = h; i < u; i++)
            {
                if (i % k == 0) //если остаток от деления i на к = 0, то вывод i
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("Задание нормер 5");
            //Выводить значение a и b, на каждом шаге итерации a инкрементировать, b декрементировать до тех пор, пока разница между ними не будет равна 15
            int a, b;
            a = 1; b = 40;
            for (; Math.Abs(a - b) != 15; a++, b--) // делать пока сумма а и б не станет = 15
            {
                Console.WriteLine("a = " + a + "; b = " + b);
            }
        }
    }
}