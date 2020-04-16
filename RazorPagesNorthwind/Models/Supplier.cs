using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesNorthwind.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Display(Name = "ID")]
        public int SupplierId { get; set; }

        [Required]
        [Display(Name = "Company")]
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

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [Display(Name = "Website")]
        public string HomePage { get; set; }

        [NotMapped]
        public string Secret { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
