﻿using BladeRunnersBangazonCLI.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Queries;
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
            var activeCustomerQuery = new SelectActiveCustomerQuery();
            var customers = activeCustomerQuery.SelectActiveCustomer();

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
            if (customerSelected == 0)
            {
                return null;
            }
            var selectedCustomer = allCustomers[customerSelected - 1];

            return allCustomers.First<ActiveCustomer>(x => x == selectedCustomer);
        }
    }
}
