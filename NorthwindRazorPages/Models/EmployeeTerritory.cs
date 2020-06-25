using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthwindRazorPages.Models
{
    public partial class EmployeeTerritory
    {
        [Key]
        public int EmployeeId { get; set; }

        public string TerritoryId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Territory Territory { get; set; }
    }
}
