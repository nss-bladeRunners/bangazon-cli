using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.Database.DataAccess.Models
{
	public class ProductOrder
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int ProductOrderId { get; set; }
	}
}
