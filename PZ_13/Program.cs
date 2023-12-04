namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) //бесконечный цикл для повторного запуска программы
            {
                Console.Write("Введите номер задания: ");
                int programm = Convert.ToInt32(Console.ReadLine());
                int n; double res; // ввод основных переменных, чтобы не конфликтовали в разных кейсах

                switch (programm) //выбор программы
                {
                    case 1: //задание 1, алгебраическая прогрессия

                        int a = -8; int d = -1;
                        Console.WriteLine($"Первый член алгебраической прогрессии: {a}, шаг: {d}");
                        Console.Write("Введите n: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        res = alg_recurs(a, d, n); //вызов функции с рекурсией 1, см. ниже
                        Console.WriteLine($"Член номер n данной прогрессии: {Math.Round(res, 0)}");
                        break;

                    case 2: //задание 2, геометрическая прогрессия

                        double b = 3; double q = -0.5;
                        Console.WriteLine($"Первый член геометрической прогрессии: {b}, знаменатель прогрессии: {q}");
                        Console.Write("Введите n: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        res = geo_recurs(b, q, n); //вызов функции с рекурсией 2, см. ниже
                        Console.WriteLine($"Член номер n данной прогрессии: {res}");
                        break;

                    case 3: //задание 3, вывод чисел от A до B

                        Console.Write("Введите число A: ");
                        int A = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите число B: ");
                        int B = Convert.ToInt32(Console.ReadLine());
                        if (A < B) //условие вывода в порядке возрастания или убывания
                        {
                            enum_a(A, B);
                        }
                        else
                        {
                            enum_b(A, B);
                        }
                        break;

                    case 4: //"задание на 5", номер 1

                        Console.Write("Введите конечное число n: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Сумма чисел от 1 до n: {summ(n)}"); //вызов функции с рекурсией 4
                        break;
                }
                Console.WriteLine(); //отступ
            }
        }
        static int alg_recurs(int a, int d, int n) //рекурсия 1. если н не 1, то рекурсивно значение прибавляется на шаг
        {
            if (n == 1)
            {
                return a;
            }
            else
            {
                return alg_recurs(a, d, n - 1) + d;
            }
        }

        static double geo_recurs(double b, double q, int n) //рекурсия 2. если н не 1, то значение возрастает в кью раз
        {
            if (n == 1)
            {
                return b;
            }
            else
            {
                return geo_recurs(b, q, n - 1) * q;
            }
        }

        static void enum_a(int A, int B) //рекурсия 3.1. вывод в порядке возрастания
        {
            if (A <= B)
            {
                Console.Write(A + " ");
                enum_a(A + 1, B);
            }
        }
        static void enum_b(int A, int B) //рекурсия 3.2. вывод в порядке убывания
        {
            if (A >= B)
            {
                Console.Write(A + " ");
                enum_b(A - 1, B);
            }
        }
        static int summ(int n) //рекурсия 4, если н не 1, то н прибавляется к предыдущим числам
        {
            if (n == 1) 
            {
                return 1;
            }
            else
            {
               return n + summ(n - 1);
            }
        }
    }
}