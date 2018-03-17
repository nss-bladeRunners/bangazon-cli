using BladeRunnersBangazonCLI.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Queries;
using System;

namespace BladeRunnersBangazonCLI.Views
{
    class PaymentView
    {
        public void CreatePayment(ActiveCustomer selectedCustomer)
        {
            var db = new InsertPaymentQuery(); 

            var payment = new PaymentCreationModel();
            payment.Type = GetPaymentType(selectedCustomer);
            payment.AccountNumber = GetAccountNumber();
            payment.CustomerId = selectedCustomer.CustomerId;
            db.InsertPayment(payment.Type, payment.AccountNumber, payment.CustomerId);
        }

        public string GetPaymentType(ActiveCustomer selectedCustomer)
        {
            var paymentOption = new View();
            paymentOption.AddMenuText("");
            paymentOption.AddMenuText($"Current Active Customer: {selectedCustomer.FirstName} {selectedCustomer.LastName}");
            paymentOption.AddMenuText("Enter the payment type:");

            Console.Write(paymentOption.GetFullMenu());

            var paymentType = Console.ReadLine();

            return paymentType;
        }

        public string GetAccountNumber()
        {
            var accountNumberOption = new View();
            accountNumberOption.AddMenuText("");
            accountNumberOption.AddMenuText("Enter the account number:");

            Console.Write(accountNumberOption.GetFullMenu());

            var accountNumber = Console.ReadLine();

            return accountNumber;
        }
    }
}
