using BladeRunnersBangazonCLI.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.Views
{
	class AvailableProductsView
	{
		public int productSelection;

		public Product AvailableProducts(ActiveCustomer activeCustomer)
		{
			var ProductList = new List<Product>();
			var productQuery = new AvailableProductsQuery();
			var products = productQuery.GetAvailableProducts(activeCustomer.CustomerId);

			var availableProducts = new View();
			availableProducts.AddMenuText("");
			availableProducts.AddMenuText("Products available for purchase:");

			foreach (var product in products)
			{
				ProductList.Add(product);
				availableProducts.AddMenuOption($"{product.Title}");
			};

			availableProducts.AddMenuText("Press 0 to go BACK.");

			Console.Write(availableProducts.GetFullMenu());

			int productSelected = int.Parse(Console.ReadLine().ToString());
			productSelection = productSelected;
			var selectedProduct = ProductList[productSelected - 1];
			selectedProduct.Quantity--; 

			return ProductList.First<Product>(x => x == selectedProduct);

		}

	}
}
