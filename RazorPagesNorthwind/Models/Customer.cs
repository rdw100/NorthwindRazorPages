using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesNorthwind.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ICollection<Order> Orders { get; set; }
        //[ForeignKey("OrderID, ProductID")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
