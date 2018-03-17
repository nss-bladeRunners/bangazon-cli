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
	class FindOrdersQuery
	{
		readonly string _connectionString = ConfigurationManager.ConnectionStrings["BladeRunners"].ConnectionString;

		public List<Order> FindOrderByOrderId(int orderId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{

				var cmd = connection.CreateCommand();

				cmd.CommandText = @"select *
                                    from orders
                                    where orderId = @OrderId";

				var OrderIdParam = new SqlParameter("@OrderId", System.Data.SqlDbType.Int);
				OrderIdParam.Value = orderId;
				cmd.Parameters.Add(OrderIdParam);

				connection.Open();
				var reader = cmd.ExecuteReader();

				var orders = new List<Order>();

				while (reader.Read())
				{
					var order = new Order
					{
						OrderId = int.Parse(reader["OrderId"].ToString()),
						PaymentId = int.Parse(reader["PaymentId"].ToString()),
						CustomerId = int.Parse(reader["CustomerId"].ToString())
					};

					orders.Add(order);
				}

				return orders;

			}
		}

		public int FindOpenOrderByCustomerId(int customerId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{

				var cmd = connection.CreateCommand();

				cmd.CommandText = @"select *
                                from orders
                                where customerId = @CustomerId";

				var CustomerIdParam = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int);
				CustomerIdParam.Value = customerId;
				cmd.Parameters.Add(CustomerIdParam);

				connection.Open();
				var reader = cmd.ExecuteReader();

				var orders = new List<Order>();

				while (reader.Read())
				{
					var order = new Order();
					order.OrderId = int.Parse(reader["OrderId"].ToString());
					order.PaymentId = string.IsNullOrEmpty(reader["PaymentId"].ToString()) ? (int?)null : int.Parse(reader["PaymentId"].ToString());  // todo returns null sometimes
					order.CustomerId = int.Parse(reader["CustomerId"].ToString());

					orders.Add(order);
				}

				var orderId = 0;

				foreach (var order in orders)
				{
					if (order.PaymentId == null)
					{
						orderId = order.OrderId;
						break;
					}
				}
				return orderId;

			}
		}
	}
}
