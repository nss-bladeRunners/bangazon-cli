using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.DataAccess.Models
{
    class ActiveCustomer
    {
        internal class CustomerInfo
        {
            public int CustomerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int Zip { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }
    }
}
