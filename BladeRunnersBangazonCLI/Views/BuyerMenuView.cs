using BladeRunnersBangazonCLI.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Queries;
using System;
using System.Collections.Generic;

namespace BladeRunnersBangazonCLI.Views

{
    class BuyerMenuView
    {
        public void BuyerMenu(ActiveCustomer activeCustomer)
        {
            View buyerMenu = new View();

            buyerMenu.AddMenuText("")
            .AddMenuOption("Shop")
            .AddMenuOption("Add a payment method")
            .AddMenuOption("Checkout")
            .AddMenuText("Press 0 to exit.");

            Console.Write(buyerMenu.GetFullMenu());
            ConsoleKeyInfo userOption = Console.ReadKey();
            OptionController(userOption, activeCustomer);
        }

        private void OptionController(ConsoleKeyInfo userInput, ActiveCustomer activeCustomer)
        {
            switch (userInput.KeyChar)
            {
                case '1'://Shop
					var shopView = new AvailableProductsView(); //class
					int orderId = 0;
					do
					{
						var selectedProduct = shopView.AvailableProducts(activeCustomer);
						var findOrder = new FindOrdersQuery();

						
						var orderList = new List<Orders>(findOrder.FindOrderByCustomerId(activeCustomer.CustomerId));

						if(orderId == 0)
						{
							var i = 0;
							foreach (var o in orderList) 
							{
								i++;

								if(o.PaymentId == "")
								{
									orderId = o.OrderId;
									break; 
								}
								else if (i == orderList.Count)
								{
									var newOrder = new CreateOrderQuery();
									orderId = newOrder.CreateOrder(activeCustomer.CustomerId);
								}
							}
						}
						var productOrder = new AddProductToProductOrderQuery();
						productOrder.AddProductToProductOrder(selectedProduct.ProductId, orderId);
					}
					while (shopView.productSelection != 0);

					break;

                case '2':
                    var paymentView = new PaymentView();
                    paymentView.CreatePayment(activeCustomer.CustomerId);
                    BuyerMenu(activeCustomer);
                    break;

                case '3': //Checkout
                    //TODO: Add Checkout function 

                default: //Default for Buyer Menu
                    break;
            }
        }
    }
}
