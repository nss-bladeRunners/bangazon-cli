using BladeRunnersBangazonCLI.DataAccess.Models;
using System;


namespace BladeRunnersBangazonCLI.Views

{
    class BuyerMenuView
    {
        public void BuyerMenu(ActiveCustomer activeCustomer)
        {
            View buyerMenu = new View();

            buyerMenu.AddMenuText("")
            .AddMenuOption("Shop")
            .AddMenuOption("Add a payment method")
            .AddMenuOption("Checkout")
            .AddMenuText("Press 0 to exit.");

            Console.Write(buyerMenu.GetFullMenu());
            ConsoleKeyInfo userOption = Console.ReadKey();
            OptionController(userOption, activeCustomer);
        }

        private void OptionController(ConsoleKeyInfo userInput, ActiveCustomer activeCustomer)
        {
            switch (userInput.KeyChar)
            {
                case '1'://Shop
                    //TODO: Add Shop Function
                    break;

                case '2':
                    var paymentView = new PaymentView();
                    paymentView.CreatePayment(activeCustomer.CustomerId);
                    BuyerMenu(activeCustomer);
                    break;

                case '3': //Checkout
                    //TODO: Add Checkout function 

                default: //Default for Buyer Menu
                    break;
            }
        }
    }
}
