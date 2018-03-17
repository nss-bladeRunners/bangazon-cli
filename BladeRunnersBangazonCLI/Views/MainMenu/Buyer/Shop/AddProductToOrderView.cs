using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.Views
{
	class AddProductToOrderView
	{
		public ConsoleKeyInfo GetProductList()
		{
			var products = new List<Product>();
			var productQuery = new ProductsListQuery();
			var getProducts = productQuery.GetProductsList();

			var viewAllProducts = new View();

			viewAllProducts.AddMenuText("");
			viewAllProducts.AddMenuText("Products List:");

			foreach (var product in getProducts)
			{
				products.Add(product);
				viewAllProducts.AddMenuOption($"{product.Title} {product.Price}");
			}

			viewAllProducts.AddMenuText("Press 0 to go back");
			

			Console.Write(viewAllProducts.GetFullMenu());
			ConsoleKeyInfo userOption = Console.ReadKey();

			return userOption;
		}
	}
}
