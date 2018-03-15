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

                        var customerInfo = new InsertCustomerQuery();
                        customerInfo.InsertCustomer(customerFirstName, customerLastName, customerStreet, customerCity, customerState, customerZip, customerPhone, customerEmail);

                        break;

                    case '2': //"Select Customer"

                        var viewAllCustomers = new AllCustomersView();
                        _selectedCustomer = viewAllCustomers.SelectActiveCustomer();

                        var activeCustomerQuery = new SelectActiveCustomerQuery();
                        var activeCustomers = activeCustomerQuery.SelectActiveCustomer();

                        // BUY AND SELL SUB MENU
                        var customerSubMenu = new CustomerSubMenuView();
                        ConsoleKeyInfo userOption = customerSubMenu.CustomerSubMenu();

                        switch (userOption.KeyChar)
                        {
                            case '1': //Buyer Menu
                                var buyerMenu = new BuyerMenuView();
                                buyerMenu.BuyerMenu(_selectedCustomer);


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
                                        var addProduct = new InsertProductQuery();
                                        var newProduct = addProduct.InsertProduct(customerId, productTitle, productPrice, productQuantity);
                                        break;

                                    case '2': //Edit Product
                                        var viewAllProductsForSeller = new AllProductsForSellerView();
                                        var selectedProduct = viewAllProductsForSeller.SelectProduct(_selectedCustomer);
                                        var updateProductView = new UpdateProductView();

                                        ConsoleKeyInfo updateProduct = updateProductView.UpdateProductMenu(selectedProduct);
                                        switch (updateProduct.KeyChar)
                                        {
                                            case '1':
                                                var title = updateProductView.UpdateTitle();
                                                var updateProductTitleQuery = new UpdateProductQueries();
                                                var executeUpdateTitle = updateProductTitleQuery.UpdateProductTitle(selectedProduct.ProductId, title);
                                                break;

                                            case '2':
                                                var price = updateProductView.UpdatePrice();
                                                var updateProductPriceQuery = new UpdateProductQueries();
                                                var executeUpdatePrice = updateProductPriceQuery.UpdateProductPrice(selectedProduct.ProductId, price);
                                                break;

                                            case '3':
                                                var quantity = updateProductView.UpdateQuantity();
                                                var updateProductQuantityQuery = new UpdateProductQueries();
                                                var executeUpdateQuantity = updateProductQuantityQuery.UpdateProductQuantity(selectedProduct.ProductId, quantity);
                                                break;

                                            default: //Default for Update Product Menu
                                                break;
                                        }
                                        break;

                                    case '3': //Delete Product
                                        viewAllProductsForSeller = new AllProductsForSellerView();
                                        var productToDelete = viewAllProductsForSeller.SelectProduct(_selectedCustomer);
                                        var deleteProduct = new DeleteProductQuery();
                                        var executeDeleteProduct = deleteProduct.DeleteProduct(productToDelete.ProductId);

                                        break;

                                    case '4': //Revenue Report
                                        var revenueReportView = new RevenueReportView();
                                        revenueReportView.RunRevenueReport(_selectedCustomer); 
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

    

