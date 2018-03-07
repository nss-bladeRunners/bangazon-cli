using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.Views
{
    class CustomerSubMenuView
    {
        public ConsoleKeyInfo CustomerSubMenu()
        {
            View mainMenu = new View();

            mainMenu.AddMenuText("");
            mainMenu.AddMenuOption("Buyer Menu")
            .AddMenuOption("Seller Menu")
            .AddMenuText("Press 0 to exit.");

            Console.Write(mainMenu.GetFullMenu());
            ConsoleKeyInfo userOption = Console.ReadKey();
            return userOption;
        }
    }
}

