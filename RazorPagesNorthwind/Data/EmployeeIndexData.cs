using RazorPagesNorthwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesNorthwind.Data.EmployeeViewModels
{
    public class EmployeeIndexData
    {
        public IEnumerable<Employee> idEmployees{ get; set; }
        public IEnumerable<EmployeeTerritory> idEmployeeTerritories { get; set; }
        public IEnumerable<Territory> idTerritories { get; set; }
    }
}
