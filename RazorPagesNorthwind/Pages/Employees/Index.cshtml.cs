using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesNorthwind.Data;
using RazorPagesNorthwind.Data.EmployeeViewModels;
using RazorPagesNorthwind.Models;

namespace RazorPagesNorthwind.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesNorthwind.Data.EmployeeContext _context;

        public IndexModel(RazorPagesNorthwind.Data.EmployeeContext context)
        {
            _context = context;
        }

        public EmployeeIndexData EmployeeData { get; set; }
        public int EmployeeID { get; set; }
        public string TerritoryID { get; set; }

        public async Task OnGetAsync(int? id, int? employeeID)
        {
            EmployeeData = new EmployeeIndexData();
            EmployeeData.idEmployees = await _context.Employees
                .Include(i => i.EmployeeTerritories)
                    .ThenInclude(i => i.Territory)
                //.Include(i => i.EmployeeTerritories)
                //    .ThenInclude(i => i.Territory)
                //    .ThenInclude(i => i.Region)
                .AsNoTracking()
                .OrderBy(i => i.LastName)
                .ToArrayAsync();

            if (id != null)
            {
                EmployeeID = id.Value;
                Employee employee = EmployeeData.idEmployees.Single(
                    i => i.EmployeeId == id.Value);
                EmployeeData.idTerritories = employee.EmployeeTerritories.Select(s => s.Territory); //s.TerritoryId
            }

            //if (TerritoryID != null)
            //{
            //    TerritoryID = id.Value;
            //    var selectedTerritory = EmployeeData.idTerritories
            //        .Where(x => x.TerritoryId == TerritoryID).Single();
            //    EmployeeData.
            //}
        }
    }
}
