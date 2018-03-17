using BladeRunnersBangazonCLI.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using System;

namespace BladeRunnersBangazonCLI.Views
{
    class UpdateProductView
    {

        public string UpdateProductMenu(Product selectedProduct, ActiveCustomer selectedCustomer)
        {
            View UpdateProductMenu = new View();

            UpdateProductMenu.AddMenuText("");
            UpdateProductMenu.AddMenuText($"Current Active Customer: {selectedCustomer.FirstName} {selectedCustomer.LastName}");
            UpdateProductMenu.AddMenuOption($"Change Title '{selectedProduct.Title}'")
            .AddMenuOption($"Change Price '{selectedProduct.Price}'")
            .AddMenuOption($"Change Quantity '{selectedProduct.Quantity}'")
            .AddMenuText("Press 0 to exit.");

            Console.Write(UpdateProductMenu.GetFullMenu());
            var userOption = Console.ReadLine();
            return userOption;
        }

        public string UpdateTitle()
        {
            var updateProductTitleView = new View();
            updateProductTitleView.AddMenuText("");
            updateProductTitleView.AddMenuText("Enter Product Title:");

            Console.Write(updateProductTitleView.GetFullMenu());

            var productTitle = Console.ReadLine();

            return productTitle;
        }

        public double UpdatePrice()
        {
            var updateProductPriceView = new View();
            updateProductPriceView.AddMenuText("");
            updateProductPriceView.AddMenuText("Enter Product Price:");

            Console.Write(updateProductPriceView.GetFullMenu());

            var productPrice = Console.ReadLine();

            return double.Parse(productPrice);
        }

        public int UpdateQuantity()
        {
            var updateProductQuantityView = new View();
            updateProductQuantityView.AddMenuText("");
            updateProductQuantityView.AddMenuText("Enter Product Quantity:");

            Console.Write(updateProductQuantityView.GetFullMenu());

            var productQuantity = Console.ReadLine();

            return int.Parse(productQuantity);
        }
    }
}
