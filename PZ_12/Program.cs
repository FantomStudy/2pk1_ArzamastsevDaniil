namespace PZ_12
{
    internal class Program
    {
            static void Main(string[] args)
            {
                Console.Write("Введите строку: ");
                string input = Console.ReadLine(); //ввод строки
                string reversed = ReverseString(input); //вызов фунции

                Console.WriteLine($"Перевернутая строка: {reversed}"); //вывод результата
            }
            static string ReverseString(string input) //функция, переворачивающая строку
            {
                char[] charArray = input.ToCharArray(); //массив символов

                int left = 0; // самый левый символ
                int right = charArray.Length - 1; // самый правый символ

                while (left < right)
                {
                    char temp = charArray[left]; // Обмен значениями между символами
                    charArray[left] = charArray[right];
                    charArray[right] = temp;

                    left++; // Перемещение по массиву
                    right--;
                }

                return new string(charArray);
            }
        }
    }