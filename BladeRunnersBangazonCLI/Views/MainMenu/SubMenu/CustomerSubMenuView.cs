using BladeRunnersBangazonCLI.DataAccess.Models;
using System;

namespace BladeRunnersBangazonCLI.Views
{
    class CustomerSubMenuView
    {
        public string CustomerSubMenu(ActiveCustomer selectedCustomer)
        {
            View mainMenu = new View();

            mainMenu.AddMenuText("");
            mainMenu.AddMenuText($"Current Active Customer: {selectedCustomer.FirstName} {selectedCustomer.LastName}");
            mainMenu.AddMenuOption("Buyer Menu")
            .AddMenuOption("Seller Menu");
            //.AddMenuText("Press 0 to exit.");

            Console.Write(mainMenu.GetFullMenu());
            var userOption = Console.ReadLine();
            return userOption;
        }
    }
}

