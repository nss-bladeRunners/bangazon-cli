using BladeRunnersBangazonCLI.DataAccess.Models;
using System;
namespace BladeRunnersBangazonCLI.Views
{
    class SellerMenuView
    {
        public string SellerMenu(ActiveCustomer selectedCustomer)
        {
            View sellerMenu = new View();

            sellerMenu.AddMenuText("");
            sellerMenu.AddMenuText($"Current Active Customer: {selectedCustomer.FirstName} {selectedCustomer.LastName}");
            sellerMenu.AddMenuOption("Add a Product")
            .AddMenuOption("Edit a Product")
            .AddMenuOption("Delete a Product")
            .AddMenuOption("View Revenue Report");
            //.AddMenuText("Press 0 to exit.");

            Console.Write(sellerMenu.GetFullMenu());
			var userOption = Console.ReadLine(); 
            return userOption;
        }
    }
}
