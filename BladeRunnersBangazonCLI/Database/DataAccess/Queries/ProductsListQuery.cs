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
	class ProductsListQuery
	{
		readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

		public List<Product> GetProductsList()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var cmd = connection.CreateCommand();

				cmd.CommandText = @"select Title, Price
                                    from products";

				var reader = cmd.ExecuteReader();

				var products = new List<Product>();

				while (reader.Read())
				{
					var product = new Product()
					{
						Title = reader["Title"].ToString(),
						Price = double.Parse(reader["Price"].ToString())
					};

					products.Add(product);
				}
				return products;
				
			} //calls dispose() when the using stateme
		}
	}
}
