using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesNorthwind.Models
{
    public class SupplierProductGroup
    {
        public int CategoryId { get; set; }
        public int ProductCount { get; set; }
    }
}