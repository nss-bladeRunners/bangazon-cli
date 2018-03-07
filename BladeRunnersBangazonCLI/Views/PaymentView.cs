using BladeRunnersBangazonCLI.Database.Queries;
using System;

namespace BladeRunnersBangazonCLI.Views
{
    class PaymentView
    {
        public void AddPayment()
        {
            var payment = new PaymentCreationModel();
            var db = new PaymentQueries();
            //TODO: Add buyer menu instead of main menu
            var mainMenu = new MainView(); 

            payment.CustomerId = 1;

            Console.WriteLine("");
            Console.WriteLine("@Add a Payment Method");
            Console.WriteLine("");

            Console.WriteLine("What type of account is this?");
            payment.Type = Console.ReadLine();

            Console.WriteLine("What is the account number?");
            payment.AccountNumber = Console.ReadLine();

            Console.WriteLine($"Would you like to add Payment Type: {payment.Type} with the account number {payment.AccountNumber}? (Y/N)");

            if (Console.ReadLine().ToUpper() == "Y")
            {
                db.AddPayment(payment.Type, payment.AccountNumber, payment.CustomerId);
                //TODO: Add code to move back to the Buyer screen
                mainMenu.MainMenu();
                
            }
            else
            {
                Console.WriteLine("Exit payment entry? (Y/N)");

                if (Console.ReadLine().ToUpper() == "Y")
                {
                    //TODO: Add code to move back to the Buyer screen
                    mainMenu.MainMenu();
                }
                else
                {
                    AddPayment(); 
                }
            }            
        }
    }
}
