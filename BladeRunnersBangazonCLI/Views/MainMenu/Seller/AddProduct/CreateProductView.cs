using BladeRunnersBangazonCLI.DataAccess.Models;
using System;

namespace BladeRunnersBangazonCLI.Views
{
    class CreateProductView
    {
        public string GetProdcutTitle(ActiveCustomer selectedCustomer)
        {
            var getProductTitleView = new View();
            getProductTitleView.AddMenuText("");
            getProductTitleView.AddMenuText($"Current Active Customer: {selectedCustomer.FirstName} {selectedCustomer.LastName}");
            getProductTitleView.AddMenuText("Enter Product Title:");

            Console.Write(getProductTitleView.GetFullMenu());

            var productTitle = Console.ReadLine();

            return productTitle;
        }

        public double GetProdcutPrice(ActiveCustomer selectedCustomer)
        {
            var getProductPriceView = new View();
            getProductPriceView.AddMenuText("");
            getProductPriceView.AddMenuText($"Current Active Customer: {selectedCustomer.FirstName} {selectedCustomer.LastName}");
            getProductPriceView.AddMenuText("Enter Price:");

            Console.Write(getProductPriceView.GetFullMenu());

            var productPrice = Console.ReadLine();

            return double.Parse(productPrice);
        }

        public int GetProdcutQuantity(ActiveCustomer selectedCustomer)
        {
            var getProductQuantityView = new View();
            getProductQuantityView.AddMenuText("");
            getProductQuantityView.AddMenuText($"Current Active Customer: {selectedCustomer.FirstName} {selectedCustomer.LastName}");

            getProductQuantityView.AddMenuText("Enter Quantity:");

            Console.Write(getProductQuantityView.GetFullMenu());

            var productQuantity = Console.ReadLine();

            return int.Parse(productQuantity);
        }
    }
}
