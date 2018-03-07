using BladeRunnersBangazonCLI.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Queries;
using System;
using System.Collections.Generic;

namespace BladeRunnersBangazonCLI.Views
{
    class AllProductsForSellerView
    {
        public ConsoleKeyInfo SelectProduct(ActiveCustomer activeCustomer)
        {
            var ProductList = new List<Product>();
            var productQuery = new ProductBySellerQuery();
            var products = productQuery.GetProductBySeller(activeCustomer.CustomerId);

            var productsForSellerView = new View();
            productsForSellerView.AddMenuText("");
            productsForSellerView.AddMenuText($"Products for {activeCustomer.FirstName} {activeCustomer.LastName}:");

            foreach (var product in products)
            {
                ProductList.Add(product);
                productsForSellerView.AddMenuOption($"{product.Title} ");
            };
            productsForSellerView.AddMenuText("Press 0 to go BACK.");

            Console.Write(productsForSellerView.GetFullMenu());

            ConsoleKeyInfo userOption = Console.ReadKey();
            return userOption;

        }

    }
}
