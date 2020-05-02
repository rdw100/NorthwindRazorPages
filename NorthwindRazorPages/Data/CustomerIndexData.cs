using NorthwindRazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindRazorPages.Data
{
    public class CustomerIndexData
    {
        public IEnumerable<Customer> Customers{ get; set; }
        public IEnumerable<Product> Products{ get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderDetails> OrdersDetails { get; set; }
    }
}
