using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BladeRunnersBangazonCLI.Database.DataAccess.Queries
{
    class ProductBySellerQuery
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

        public List<Product> GetProductBySeller(int customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                var cmd = connection.CreateCommand();

                cmd.CommandText = @"select *
                                    from Products p right join Customers c
                                    on p.SellerId = c.CustomerId
                                    where p.SellerId = @CustomerId";

                var CustomerIdParam = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int);
                CustomerIdParam.Value = customerId;
                cmd.Parameters.Add(CustomerIdParam);

                connection.Open();
                var reader = cmd.ExecuteReader();

                var products = new List<Product>();

                while (reader.Read())
                {
                    var product = new Product
                    {
                        Title = reader["Title"].ToString(),
                        ProductId = int.Parse(reader["ProductId"].ToString()),
                        Price = double.Parse(reader["Price"].ToString()),
                        Quantity = int.Parse(reader["Quantity"].ToString())
                    };

                    products.Add(product);
                }

                return products;

            }
        }

    }
}
