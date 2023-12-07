namespace PZ_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string inputpath = @"input.txt"; //указываем относительный путь исходного файла
            FileStream inputfile = new FileStream(inputpath, FileMode.Create, FileAccess.ReadWrite); //обозначаем путь, режим работы и доступа
            Console.WriteLine("Запоняем файл input.txt случайными числами...");
            using (inputfile)
            {
                using (StreamWriter writer = new StreamWriter(inputfile))
                {
                    for (int i = 0; i < 100; i++) //цикл для записи случайных числе построчно в файл
                    {
                        int rndnum = rnd.Next(0, 100);
                        writer.WriteLine(rndnum);
                    }
                }

            }
            Console.WriteLine("Выполняем сортировку...");
            string outputpath = @"output.txt"; //указываем относительный путь для конечного файла
            using (FileStream outputfile = new FileStream(outputpath, FileMode.Create, FileAccess.ReadWrite))
            {
                using (StreamWriter sort = new StreamWriter(outputfile))
                {
                    string[] array = File.ReadAllLines(inputpath); //считываем содержимое исходного файла в массив строк
                    int[] numbers = Array.ConvertAll(array, x => int.Parse(x)); //конвертируем из строк в целые числа 
                    Array.Sort(numbers); //сортировка
                    for (int i = 0; i < numbers.Length; i++) //цикл для записи в конечный файл
                    {
                        sort.WriteLine(numbers[i]);
                    }
                }
            }
            Console.WriteLine("Работа выполнена успешно!");
        }
    }
}