using BladeRunnersBangazonCLI.DataAccess.Models;
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
	class AddProductToProductOrderQuery
	{
		readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

		public bool AddProductToProductOrder(int selectedProductId, int orderId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				var cmd = connection.CreateCommand();

				cmd.CommandText = @"INSERT INTO ProductOrders (ProductId, OrderId)
                                  VALUES (@ProductId, @OrderId)";

				var selectedProductIdParam = new SqlParameter("@ProductId", SqlDbType.Int);
				selectedProductIdParam.Value = selectedProductId;
				cmd.Parameters.Add(selectedProductIdParam);

				var orderIdParam = new SqlParameter("@OrderId", SqlDbType.Int);
				orderIdParam.Value = orderId;
				cmd.Parameters.Add(orderIdParam);

				connection.Open();

				var reader = cmd.ExecuteNonQuery();

				return reader == 1;
			}
		}
	}	
}
