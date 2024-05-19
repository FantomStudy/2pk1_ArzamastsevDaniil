using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_23
{
    internal class Controller
    {
        /// <summary>
        /// при ивенте вызывается метод HandleDataChanged
        /// </summary>
        /// <param name="user"></param>
        public Controller(User user) => user.DataChanged += HandleDataChanged;
        /// <summary>
        /// обработчик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleDataChanged(object sender, UserEventArgs e) => Console.WriteLine(e.Message);
    }
}
