using BladeRunnersBangazonCLI.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Queries;
using BladeRunnersBangazonCLI.Views;
using System;


namespace BladeRunnersBangazonCLI
{
    class Program
    {
        static ActiveCustomer _selectedCustomer;

        static void Main(string[] args)
        {
            var mainMenu = new MainView();

            var run = true;
            while (run)
            {
                //MAIN MENU
                ConsoleKeyInfo userInput = mainMenu.MainMenu();

                switch (userInput.KeyChar)
                {
                    case '0':
                        run = false;
                        break;

                    case '1': //"Add Customer"
                        var newCreateCustomer = new NewCustomerView();

                        var customerFirstName = newCreateCustomer.GetFirstName();
                        var customerLastName = newCreateCustomer.GetLastName();
                        var customerStreet = newCreateCustomer.GetStreet();
                        var customerCity = newCreateCustomer.GetCity();
                        var customerState = newCreateCustomer.GetState();
                        var customerZip = newCreateCustomer.GetZip();
                        var customerPhone = newCreateCustomer.GetPhone();
                        var customerEmail = newCreateCustomer.GetEmail();

                        var customerInfo = new CreateNewCustomer();
                        customerInfo.CreateCustomer(customerFirstName, customerLastName, customerStreet, customerCity, customerState, customerZip, customerPhone, customerEmail);

                        break;

                    case '2': //"Select Customer"

                        var viewAllCustomers = new AllCustomersView();
                        _selectedCustomer = viewAllCustomers.SelectActiveCustomer();

                        var activeCustomerQuery = new ActiveCustomerQuery();
                        var activeCustomers = activeCustomerQuery.GetActiveCustomer();

                        // BUY AND SELL SUB MENU
                        var customerSubMenu = new CustomerSubMenuView();
                        ConsoleKeyInfo userOption = customerSubMenu.CustomerSubMenu();

                        switch (userOption.KeyChar)
                        {
                            case '1': //Buyer Menu

								var buyerMenu = new AddProductToOrderView();
								buyerMenu.GetProductList();

								

								break;
                            case '2': //Seller Menu
                                var sellerMenu = new SellerMenuView();
                                ConsoleKeyInfo sellerInput = sellerMenu.SellerMenu();
                                switch (sellerInput.KeyChar)
                                {
                                    case '1'://Add Product
                                        var addProductView = new CreateProductView();
                                        var customerId = (_selectedCustomer.CustomerId);
                                        var productTitle = addProductView.GetProdcutTitle();
                                        var productPrice = addProductView.GetProdcutPrice();
                                        var productQuantity = addProductView.GetProdcutQuantity();
                                        var addProduct = new InsertNewProduct();
                                        var newProduct = addProduct.AddNewProduct(customerId, productTitle, productPrice, productQuantity);
                                        break;

                                    case '2':
                                        break;

                                    default: //Default for Seller Menu
                                        break;
                                }

                                break;
                            default: //Default for BUY/SELL Menu
                                break;

                        }

                        break;
                    default: //Default for Main Menu
                        break;
                }
            }
        }
    }
}

    

