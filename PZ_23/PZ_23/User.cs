using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_23
{
    /// <summary>
    /// Создадим класс наследник от EventArgs для отправки сообщений
    /// </summary>
    public class UserEventArgs : EventArgs 
    {
        public string Message { get; set; }
    }
    internal class User
    {
        public string login;
        public string password;
        public DateOnly registrationDate;
        public string email;

        // Создадим ивент и делегат EventHandler
        public event EventHandler<UserEventArgs> DataChanged;
        /// <summary>
        /// Создадим метод, который будем вызывать при изменении значений. В нем вызывается ивент и меняется сообщение на переданное при вызове
        /// </summary>
        /// <param name="message"></param>
        protected virtual void OnDataChanged(string message) 
        {
            DataChanged?.Invoke(this, new UserEventArgs { Message = message });
        }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="registrationDate"></param>
        public User(string login, string password, string email, DateOnly registrationDate) 
        {
            this.login = login;
            this.password = password;
            this.registrationDate = registrationDate;
            this.email = email;
        }
        /// <summary>
        /// Метод изменения пароля. Запрашивает старый паролью При совпадении нового и старого паролей не позволяет сменить пароль
        /// </summary>
        public void ChangePassword()
        {
            Console.WriteLine("Insert your old password: ");
            if (Console.ReadLine() == password)
            {
                Console.WriteLine("Success! Insert new passport: ");
                string newPassword = Console.ReadLine();
                if (newPassword == password)
                {
                    OnDataChanged("Passwords can`t be same!\n----------------------------------------------");
                }
                else
                {
                    password = newPassword;
                    OnDataChanged("Password changed successfully\n----------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Incorrect old password. Password not changed.");
                ChangePassword();
            }
        }
        /// <summary>
        /// Метод смены электронной почты с минимальной валидацией и проверкой на изменение значения
        /// </summary>
        public void ChangeEmail()
        {
            Console.WriteLine("Insert new email: ");
            string newEmail = Console.ReadLine();
            if (newEmail == email)
            {
                OnDataChanged("Email can`t be same!\n----------------------------------------------");
            }
            else
            {
                if (newEmail.Contains("@email.com")) 
                {
                    email = newEmail;
                    OnDataChanged($"Email changed successfully, \nYour new email: {email}\n----------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Email isn`t correct, make sure email needs contain @email.com");
                    ChangeEmail();
                }
            }
            
        }
        /// <summary>
        /// Метод работы с заглушками
        /// </summary>
        public void Work()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{login} is working..");
            }
            Console.WriteLine("----------------------------------------------");
        }
        /// <summary>
        /// Метод получения информации о пользователе
        /// </summary>
        public void GetUserData() => Console.WriteLine($"{login}, {password}, {email}, {registrationDate}\n----------------------------------------------");
    }
}
