using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BladeRunnersBangazonCLI.Database.DataAccess.Queries
{
    class UpdateProductQuery
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

        public bool UpdateProductTitle(int productId, string title)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"Update Products 
                                    set Products.Title = @Title
                                    where Products.ProductId = @ProductId";

                var productIdParam = new SqlParameter("@ProductId", SqlDbType.Int);
                productIdParam.Value = productId;
                cmd.Parameters.Add(productIdParam);

                var productTitleParam = new SqlParameter("@Title", SqlDbType.VarChar);
                productTitleParam.Value = title;
                cmd.Parameters.Add(productTitleParam);

                connection.Open();

                var result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }

        public bool UpdateProductPrice(int productId, double price)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"Update Products 
                                    set Products.Price = @Price
                                    where Products.ProductId = @ProductId";

                var productIdParam = new SqlParameter("@ProductId", SqlDbType.Int);
                productIdParam.Value = productId;
                cmd.Parameters.Add(productIdParam);

                var productPriceParam = new SqlParameter("@Price", SqlDbType.VarChar);
                productPriceParam.Value = price;
                cmd.Parameters.Add(productPriceParam);

                connection.Open();

                var result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }

        public bool UpdateProductQuantity(int productId, int quantity)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"Update Products 
                                    set Products.Quantity = @Quantity
                                    where Products.ProductId = @ProductId";

                var productIdParam = new SqlParameter("@ProductId", SqlDbType.Int);
                productIdParam.Value = productId;
                cmd.Parameters.Add(productIdParam);

                var productQuantityParam = new SqlParameter("@Quantity", SqlDbType.Int);
                productQuantityParam.Value = quantity;
                cmd.Parameters.Add(productQuantityParam);

                connection.Open();

                var result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }
    }
}
