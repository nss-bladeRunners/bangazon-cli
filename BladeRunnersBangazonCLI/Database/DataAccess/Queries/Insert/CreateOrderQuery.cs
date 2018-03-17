using BladeRunnersBangazonCLI.Database.DataAccess.Models;
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
	class CreateOrderQuery
	{
		readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

		public int CreateOrder(int selectedUserId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				var cmd = connection.CreateCommand();

				cmd.CommandText = @"INSERT INTO orders (CustomerId, PaymentId)
                                  VALUES (@CustomerId, null)
								  select SCOPE_IDENTITY()";

				var selectedUserIdParam = new SqlParameter("@CustomerId", SqlDbType.Int);
				selectedUserIdParam.Value = selectedUserId;
				cmd.Parameters.Add(selectedUserIdParam);

				connection.Open();

				var result = cmd.ExecuteScalar();

				return Convert.ToInt32(result);
			}
		}

	}
}
