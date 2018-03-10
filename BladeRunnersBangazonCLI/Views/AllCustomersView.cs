using BladeRunnersBangazonCLI.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BladeRunnersBangazonCLI.Views
{
    class AllCustomersView
    {
        public ActiveCustomer SelectActiveCustomer()
        {
            var allCustomers = new List<ActiveCustomer>();
            var activeCustomerQuery = new ActiveCustomerQuery();
            var customers = activeCustomerQuery.GetActiveCustomer();

            var viewAllCustomers = new View();
            viewAllCustomers.AddMenuText("");
            viewAllCustomers.AddMenuText("Select Customer:");

            foreach (var customer in customers)
            {
                allCustomers.Add(customer);
                viewAllCustomers.AddMenuOption($"{customer.FirstName} {customer.LastName}");
            }

            viewAllCustomers.AddMenuText("Press 0 to go BACK.");

            Console.Write(viewAllCustomers.GetFullMenu());

            var customerSelected = int.Parse(Console.ReadLine().ToString());
            var selectedCustomer = allCustomers[customerSelected - 1];

            return allCustomers.First<ActiveCustomer>(x => x == selectedCustomer);
        }
    }
}
