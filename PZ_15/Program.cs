namespace PZ_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите полный путь к каталогу: ");
                string path = Console.ReadLine(); //ввод полного пути
                if (!Directory.Exists(path)) //если нет такого каталога, то выводится сообщение
                {
                    Console.WriteLine("Каталога не существует");
                    return;
                }
                string[] files = Directory.GetFiles(path); //запись файлов в массив
                foreach (string file in files) //проходимся по всем файлам в директории
                {
                    try
                    {
                        FileInfo info = new FileInfo(file); //получение информации о файле
                        if (info.Extension == ".exe" && info.Length > 10 * 1024 * 1024) //если расширение экзэ и размер 10Мб то вывод
                        {
                            Console.WriteLine($"Найден файл по условию: {file}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при обработке файла: {file}\n{ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}