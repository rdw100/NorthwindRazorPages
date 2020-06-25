using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindRazorPages.Models
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

        [Required]
        [StringLength(5)]
        public string CustomerId { get; set; }

        [StringLength(40)]
        public string CompanyName { get; set; }

        [Display(Name = "Contact")]
        [StringLength(30)]
        public string ContactName { get; set; }

        [Display(Name = "Title")]
        [StringLength(30)]
        public string ContactTitle { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [Display(Name = "ZIP")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }

        //[ForeignKey("CustomerId")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
