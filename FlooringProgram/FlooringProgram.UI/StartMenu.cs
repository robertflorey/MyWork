using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI
{
    class StartMenu
    {
        public StartMenu()
        {
            Console.WriteLine("Please chose the number for what you want to do.");
            Console.WriteLine("1. Display Orders");
            Console.WriteLine("2. Add an Order");
            Console.WriteLine("3. Edit an Order");
            Console.WriteLine("4. Remove an Order");
            Console.WriteLine("5. Quit");
        }

        public int GetUserPick()
        {
            string input = Console.ReadLine();
            int userPick;
            int.TryParse(input, out userPick);
            return userPick;
        }
    }
}
