﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.Database.DataAccess.Models
{
	class Orders
	{
		public int OrderId { get; set; }
		public int? PaymentId { get; set; }
		public int CustomerId { get; set; }
	}
}
