using BladeRunnersBangazonCLI.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BladeRunnersBangazonCLI.Views
{
    class AllProductsForSellerView
    {
        public Product SelectProduct(ActiveCustomer activeCustomer)
        {
            var ProductList = new List<Product>();
            var productQuery = new SelectProductsBySellerQuery();
            var products = productQuery.SelectProductsBySeller(activeCustomer.CustomerId);

            var productsForSellerView = new View();
            productsForSellerView.AddMenuText("");
            productsForSellerView.AddMenuText($"Products for {activeCustomer.FirstName} {activeCustomer.LastName}:");

            foreach (var product in products)
            {
                ProductList.Add(product);
                productsForSellerView.AddMenuOption($"{product.Title} ");
            };
            //productsForSellerView.AddMenuText("Press 0 to go BACK.");

            Console.Write(productsForSellerView.GetFullMenu());


            int productSelected = int.Parse(Console.ReadLine().ToString());
            if (productSelected == 0)
            {
                return null;
            }
            var selectedProduct = ProductList[productSelected - 1];

            return ProductList.First<Product>(x => x == selectedProduct);

        }
    }
}
