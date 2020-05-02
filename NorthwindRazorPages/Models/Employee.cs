using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindRazorPages.Models
{
    public partial class Employee
    {
        //public Employee()
        //{
        //    EmployeeTerritories = new HashSet<EmployeeTerritory>();
        //    InverseReportsToNavigation = new HashSet<Employee>();
        //    //Territories = new HashSet<Territory>();
        //    //Region = new HashSet<Region>();
        //    Orders = new HashSet<Order>();
        //}

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        [ForeignKey("Manager")]
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }

        //public int RegionId { get; set; }
        //public int TerritoryId { get; set; }

        //public virtual EmployeeTerritory EmployeeTerritory { get; set; }
        //public virtual Territory mTerritory { get; set; }
        //public virtual Region mRegion { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual ICollection<Employee> DirectReports { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
