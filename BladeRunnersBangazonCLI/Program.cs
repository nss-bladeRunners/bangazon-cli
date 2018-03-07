using BladeRunnersBangazonCLI.Views;
using System;

namespace BladeRunnersBangazonCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //var mainMenu = new MainView();

            //var run = true;
            //while (run)
            //{
            //    ConsoleKeyInfo userInput = mainMenu.MainMenu();

            //    switch (userInput.KeyChar)
            //    {
            //        case '0':
            //            run = false;
            //            break;

            //        case '1':

            //            break;

            //        case '2': 

            //            break;

            //        default:
            //            break;
            //    }
            //}



            var paymentView = new PaymentView();
            paymentView.AddPayment(); 
        }
    }
}
