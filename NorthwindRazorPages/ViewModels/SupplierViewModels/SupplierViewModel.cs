using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindRazorPages.Models
{
    /// <summary>
    /// Represents a subset of the properties included in the Supplier model.
    /// </summary>
    /// <remarks>
    /// This ViewModel is an intermediary 1-1 map solution to overposting with the downside of duplication.
    /// </remarks>
    public class SupplierViewModel
    {
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
    }
}
