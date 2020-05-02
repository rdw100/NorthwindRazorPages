using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthwindRazorPages.Models
{
    public partial class CustomerCustomerDemo
    {
        [Key]
        public string CustomerId { get; set; }

        public string CustomerTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographics CustomerType { get; set; }
    }
}
