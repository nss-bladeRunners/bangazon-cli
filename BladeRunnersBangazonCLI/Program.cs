using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using BladeRunnersBangazonCLI.Models;
using BladeRunnersBangazonCLI.Views;
using System;


namespace BladeRunnersBangazonCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainView();

            var run = true;
            while (run)
            {
                ConsoleKeyInfo userInput = mainMenu.MainMenu();

                switch (userInput.KeyChar)
                {
                    case '0':
                        run = false;
                        break;

                    case '1':
                        var newCreateCustomer = new NewCustomerView();

                        var customerFirstName = newCreateCustomer.GetFirstName();
                        var customerLastName = newCreateCustomer.GetLastName();
                        var customerStreet = newCreateCustomer.GetStreet();
                        var customerCity = newCreateCustomer.GetCity();
                        var customerState = newCreateCustomer.GetState();
                        var customerZip = newCreateCustomer.GetZip();
                        var customerPhone = newCreateCustomer.GetPhone();
                        var customerEmail = newCreateCustomer.GetEmail();

                        var customerInfo = new CreateNewCustomer();
                        customerInfo.CreateCustomer(customerFirstName, customerLastName, customerStreet, customerCity, customerState, customerZip, customerPhone, customerEmail);
                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine("Select active customer:");
                        Console.ReadLine();

                        var activeCustomerQuery = new ActiveCustomerQuery();
                        var activeCustomers = activeCustomerQuery.GetActiveCustomer();
                        break;

                    default:
                        break;

                }
            }
        }
    }
}
