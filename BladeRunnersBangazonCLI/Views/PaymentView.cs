using BladeRunnersBangazonCLI.Database.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.Views
{
    class PaymentView
    {
        public void CreatePayment(int activeCustomerId)
        {
            var db = new PaymentQueries(); 

            var payment = new PaymentCreationModel();
            payment.Type = GetPaymentType();
            payment.AccountNumber = GetAccountNumber();
            payment.CustomerId = activeCustomerId;
            db.AddPayment(payment.Type, payment.AccountNumber, payment.CustomerId);
        }

        public string GetPaymentType()
        {
            var paymentOption = new View();
            paymentOption.AddMenuText("");
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
