using BladeRunnersBangazonCLI.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using BladeRunnersBangazonCLI.Database.DataAccess.Queries;
using System;
using System.Collections.Generic;

namespace BladeRunnersBangazonCLI.Views
{
    class RevenueReportView
    {
        public void RunRevenueReport(ActiveCustomer activeCustomer)
        {
            var revenueReport = new ReportView(); 
            var db = new SelectClosedOrdersByCustomerQuery();

            var orders = db.SelectOrderByCustomer(activeCustomer.CustomerId);


            //Add title
            revenueReport.AddReportTitleLine("Revenue Report", $"{activeCustomer.FirstName} {activeCustomer.LastName}");


            //get each item for each order 
            var orderIndex = 0; 
            foreach (CompletedOrder currentOrder in orders)
            {
                //if not the first record
                if (orderIndex > 0)
                {
                    //check if it's a new order 
                    var previousOrderId = orders[orderIndex - 1].OrderId;
                    if (previousOrderId != currentOrder.OrderId)
                    {
                        //add the order line
                        revenueReport.AddReportSection($"Order Number: {currentOrder.OrderId}");
                        revenueReport.AddColumnHeaders("Product", "Quantity", "Total");
                    }
                }
                else // first order 
                {
                    revenueReport.AddReportSection($"Order Number: {currentOrder.OrderId}");
                    revenueReport.AddColumnHeaders("Product", "Quantity", "Total"); 
          
                }
                //add the line item
                revenueReport.AddReportLineItem(currentOrder.ProductName, currentOrder.Quantity, currentOrder.ProductTotal);
                //increment the order count
                orderIndex++;
            }
            Console.WriteLine(revenueReport.GetFullMenu());
            Console.ReadLine(); 

        }
    }
}
