using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.Database.DataAccess.Models
{
	class Orders
	{
		int OrderId { get; set; }
		int PaymentId { get; set; }
		int CustomerId { get; set; }
	}
}
