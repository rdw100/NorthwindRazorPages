using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindRazorPages.Data;
using NorthwindRazorPages.Data.EmployeeViewModels;
using NorthwindRazorPages.Models;

namespace NorthwindRazorPages.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindRazorPages.Data.EmployeeContext _context;

        public IndexModel(NorthwindRazorPages.Data.EmployeeContext context)
        {
            _context = context;
        }

        public EmployeeIndexData EmployeeData { get; set; }
        public int EmployeeID { get; set; }
        public string TerritoryID { get; set; }

        public async Task OnGetAsync(int? id, int? employeeID)
        {
            EmployeeData = new EmployeeIndexData();
            EmployeeData.Employees = await _context.Employees
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
                Employee employee = EmployeeData.Employees.Single(
                    i => i.EmployeeId == id.Value);
                EmployeeData.Territories = employee.EmployeeTerritories.Select(s => s.Territory); //s.TerritoryId
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
