using BladeRunnersBangazonCLI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.Database.DataAccess.Models
{
    class ActiveCustomerQuery
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

        public List<ActiveCustomer> GetActiveCustomer()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = @"select c.CustomerId, c.FirstName, c.LastName
	                                    from Customers c;";

                var reader = cmd.ExecuteReader();

                var activeCustomers = new List<ActiveCustomer>();

                while (reader.Read())
                {
                    var customer = new ActiveCustomer
                    {
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        CustomerId = int.Parse(reader["CustomerId"].ToString())
                    };

                    activeCustomers.Add(customer);
                }
                return activeCustomers;
            }
        }
    }
}
