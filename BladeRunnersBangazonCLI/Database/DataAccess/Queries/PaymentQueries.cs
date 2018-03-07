using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BladeRunnersBangazonCLI.Database.Queries
{
    public class PaymentQueries
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

        public bool AddPayment(string type, string accountNumber, int customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Payments]
                                           ([Type]
                                           ,[AccountNumber]
                                           ,[CustomerId])
                                     VALUES
                                           (@type
                                           ,@accountNumber
                                           ,@customerId)";

                connection.Open();

                //setup Type param
                var typeParam = new SqlParameter("@type", SqlDbType.NVarChar);
                typeParam.Value = type;
                cmd.Parameters.Add(typeParam);

                //setup AccountNumber param
                var accountNumberParam = new SqlParameter("@accountNumber", SqlDbType.NVarChar);
                accountNumberParam.Value = accountNumber;
                cmd.Parameters.Add(accountNumberParam);

                //setup CustomerId param
                var customerIdParam = new SqlParameter("@customerId", SqlDbType.Int);
                customerIdParam.Value = customerId;
                cmd.Parameters.Add(customerIdParam);

                var result = cmd.ExecuteNonQuery();
                return result == 1;

            }
        }
    }
}
