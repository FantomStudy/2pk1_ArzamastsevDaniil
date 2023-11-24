namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] array = str.Split(' ');
            foreach (string text in array)
            {
                int ind = text.IndexOf('@');
                if (ind != -1)
                {
                    string name = text.Substring(0, ind);
                    Console.WriteLine($"hello, {name}");
                }

                
            }
        }
    }
}