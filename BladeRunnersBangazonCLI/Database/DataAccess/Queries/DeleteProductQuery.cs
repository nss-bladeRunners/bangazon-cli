using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.Database.DataAccess.Queries
{
    class DeleteProductQuery
    {

        readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

        public bool DeleteProduct(int productId)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"Delete from Products 
                                    where Products.ProductId = @ProductId";

                var productIdParam = new SqlParameter("@ProductId", SqlDbType.Int);
                productIdParam.Value = productId;
                cmd.Parameters.Add(productIdParam);

                connection.Open();

                var result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }

    }
}
