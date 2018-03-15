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
            var userOption = Console.ReadLine();
            OptionController(userOption, activeCustomer);
        }

        private void OptionController(string userInput, ActiveCustomer activeCustomer)
        {
            var input = Convert.ToChar(userInput);

            switch (input)
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
