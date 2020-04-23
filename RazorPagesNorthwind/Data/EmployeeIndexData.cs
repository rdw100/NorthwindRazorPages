﻿using RazorPagesNorthwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesNorthwind.Data.EmployeeViewModels
{
    public class EmployeeIndexData
    {
        public IEnumerable<Employee> Employees{ get; set; }
        public IEnumerable<EmployeeTerritory> EmployeeTerritories { get; set; }
        public IEnumerable<Territory> Territories { get; set; }
    }
}
