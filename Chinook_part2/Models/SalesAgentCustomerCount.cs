using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook_part2.Models
{
    public class SalesAgentCustomerCount
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerCount { get; set; }
    }
}
