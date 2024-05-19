namespace PZ_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Danya", "123", "Arz@email.com", new DateOnly(2022, 1, 6));
            Controller controller = new Controller(user1);
            user1.GetUserData();
            user1.Work();
            user1.ChangeEmail();
            user1.ChangePassword();
        }
    }
}
