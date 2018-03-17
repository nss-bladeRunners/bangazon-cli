using BladeRunnersBangazonCLI.Database.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.Database.DataAccess.Queries
{
	class AvailableProductsQuery
	{
		readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

		public List<Product> GetAvailableProducts(int selectedUserId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var cmd = connection.CreateCommand();

				cmd.CommandText = @"select *
								from products 
								where sellerId != @SelectedUserId
								and quantity > 0";

				var SelectedUserIdParam = new SqlParameter("@SelectedUserId", System.Data.SqlDbType.Int);
				SelectedUserIdParam.Value = selectedUserId;
				cmd.Parameters.Add(SelectedUserIdParam);

				var products = new List<Product>();

				var reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					var product = new Product()
					{
						Title = reader["Title"].ToString(),
						Price = double.Parse(reader["Price"].ToString()),
						ProductId = int.Parse(reader["ProductId"].ToString()),
						SellerId = int.Parse(reader["SellerId"].ToString()),
						Quantity = int.Parse(reader["Quantity"].ToString())
					};

					products.Add(product);
				}
				return products;

			} 
		}
	}
}
