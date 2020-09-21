using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNP2_LINQ_Ass3
{
    class Customer
    {
        public string Name { get; set; }
        public string City { get; set; }
        public Order[] Orders { get; set; }
    }
}
