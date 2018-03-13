using System;

namespace BladeRunnersBangazonCLI.Views
{
    class CreateProductView
    {
        public string GetProdcutTitle()
        {
            var getProductTitleView = new View();
            getProductTitleView.AddMenuText("");
            getProductTitleView.AddMenuText("Enter Product Title:");

            Console.Write(getProductTitleView.GetFullMenu());

            var productTitle = Console.ReadLine();

            return productTitle;
        }

        public double GetProdcutPrice()
        {
            var getProductPriceView = new View();
            getProductPriceView.AddMenuText("");
            getProductPriceView.AddMenuText("Enter Price:");

            Console.Write(getProductPriceView.GetFullMenu());

            var productPrice = Console.ReadLine();

            return double.Parse(productPrice);
        }

        public int GetProdcutQuantity()
        {
            var getProductQuantityView = new View();
            getProductQuantityView.AddMenuText("");
            getProductQuantityView.AddMenuText("Enter Quantity:");

            Console.Write(getProductQuantityView.GetFullMenu());

            var productQuantity = Console.ReadLine();

            return int.Parse(productQuantity);
        }
    }
}
