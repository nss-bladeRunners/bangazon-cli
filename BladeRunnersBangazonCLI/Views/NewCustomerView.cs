using BladeRunnersBangazonCLI.Views;
using System;

namespace BladeRunnersBangazonCLI
{
    class NewCustomerView
    {
        public string GetFirstName()
        {
            var createCustomerView = new View();
            createCustomerView.AddMenuText("");
            createCustomerView.AddMenuText("Enter customer first name:");

            Console.Write(createCustomerView.GetFullMenu());

            var customerFirstName = Console.ReadLine();

            return customerFirstName;
        }

        public string GetLastName()
        {
            var createCustomerView = new View();
            createCustomerView.AddMenuText("");
            createCustomerView.AddMenuText("Enter customer last name:");

            Console.Write(createCustomerView.GetFullMenu());

            var customerLastName = Console.ReadLine();

            return customerLastName;
        }

        public string GetStreet()
        {
            var createCustomerView = new View();
            createCustomerView.AddMenuText("");
            createCustomerView.AddMenuText("Enter customer street address:");

            Console.Write(createCustomerView.GetFullMenu());

            var customerStreet = Console.ReadLine();

            return customerStreet;
        }

        public string GetCity()
        {
            var createCustomerView = new View();
            createCustomerView.AddMenuText("");
            createCustomerView.AddMenuText("Enter customer city:");

            Console.Write(createCustomerView.GetFullMenu());

            var customerCity = Console.ReadLine();

            return customerCity;
        }

        public string GetState()
        {
            var createCustomerView = new View();
            createCustomerView.AddMenuText("");
            createCustomerView.AddMenuText("Enter customer state:");

            Console.Write(createCustomerView.GetFullMenu());

            var customerState = Console.ReadLine();

            return customerState;
        }

        public string GetZip()
        {
            var createCustomerView = new View();
            createCustomerView.AddMenuText("");
            createCustomerView.AddMenuText("Enter customer zip code:");

            Console.Write(createCustomerView.GetFullMenu());

            var customerZip = Console.ReadLine();

            return customerZip;
        }

        public string GetEmail()
        {
            var createCustomerView = new View();
            createCustomerView.AddMenuText("");
            createCustomerView.AddMenuText("Enter customer email address:");

            Console.Write(createCustomerView.GetFullMenu());

            var customerEmail = Console.ReadLine();

            return customerEmail;
        }

        public string GetPhone()
        {
            var createCustomerView = new View();
            createCustomerView.AddMenuText("");
            createCustomerView.AddMenuText("Enter customer phone number:");

            Console.Write(createCustomerView.GetFullMenu());

            var customerPhone = Console.ReadLine();

            return customerPhone;
        }
    }
}
