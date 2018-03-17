using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace BladeRunnersBangazonCLI.Database.DataAccess.Queries
{
    class SelectClosedOrdersByCustomerQuery
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

        public List<CompletedOrder> SelectOrderByCustomer(int customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                var cmd = connection.CreateCommand();

                cmd.CommandText = @"SELECT  
                                        po.OrderId, p.Title, count(p.ProductId) as Quantity, sum(price) as ProductTotal from orders o

                                            JOIN ProductOrders po on o.OrderId = po.OrderId
                                            JOIN Products p on po.ProductId = p.ProductId

                                        WHERE p.SellerId = @customerId
                                        AND o.PaymentId is not null

                                        GROUP BY po.OrderId, p.Title
                                        ORDER BY po.OrderId";

                var CustomerIdParam = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int);
                CustomerIdParam.Value = customerId;
                cmd.Parameters.Add(CustomerIdParam);

                connection.Open();

                var reader = cmd.ExecuteReader();
                var orders = new List<CompletedOrder>();

                while (reader.Read())
                {
                    var order = new CompletedOrder
                    {
                        OrderId = int.Parse(reader["OrderId"].ToString()),
                        ProductName = reader["Title"].ToString(),
                        ProductTotal = double.Parse(reader["ProductTotal"].ToString()),
                        Quantity = int.Parse(reader["Quantity"].ToString())
                    };

                    orders.Add(order);
                }

                return orders;

            }
        }

    }
}
