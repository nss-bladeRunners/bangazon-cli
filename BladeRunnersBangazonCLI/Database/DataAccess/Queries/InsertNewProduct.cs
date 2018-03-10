using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BladeRunnersBangazonCLI.Database.DataAccess.Queries
{
    class InsertNewProduct
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

        public bool AddNewProduct(int customerId, string productTitle, double productPrice, int prodcutQuantity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"INSERT INTO Products(SellerId, Title, Price, Quantity, CreatedDate)
                                  VALUES (@SellerId, @Title, @Price, @Quantity, @CreatedDate)";

                var customerIdParam = new SqlParameter("@SellerId", SqlDbType.Int);
                customerIdParam.Value = customerId;
                cmd.Parameters.Add(customerIdParam);

                var productTitleParam = new SqlParameter("@Title", SqlDbType.VarChar);
                productTitleParam.Value = productTitle;
                cmd.Parameters.Add(productTitleParam);

                var productPriceParam = new SqlParameter("@Price", SqlDbType.Money);
                productPriceParam.Value = productPrice;
                cmd.Parameters.Add(productPriceParam);

                var productQuantityParam = new SqlParameter("@Quantity", SqlDbType.Int);
                productQuantityParam.Value = productPrice;
                cmd.Parameters.Add(productQuantityParam);

                var productDateParam = new SqlParameter("@CreatedDate", SqlDbType.Date);
                productDateParam.Value = DateTime.Now;
                cmd.Parameters.Add(productDateParam);

                connection.Open();

                var result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }
    }
}
