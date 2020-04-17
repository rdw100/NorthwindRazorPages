using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesNorthwind.Data;
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

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees
                //.Include( c => c.EmployeeTerritories)
                //.ThenInclude(c => c.Territory)
                //.ThenInclude(c => c.Region)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
