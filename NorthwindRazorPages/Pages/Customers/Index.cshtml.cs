using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindRazorPages.Data;
using NorthwindRazorPages.Models;

namespace NorthwindRazorPages.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindRazorPages.Data.CustomerContext _context;

        public IndexModel(NorthwindRazorPages.Data.CustomerContext context)
        {
            _context = context;
        }

        //public IList<Customer> Customer { get;set; }
        public CustomerIndexData CustomerData { get; set; }
        public int OrderID { get; set; }
        public string ProductID { get; set; }

        public async Task OnGetAsync()
        {
            //Customer = await _context.Customers.ToListAsync();
            CustomerData = new CustomerIndexData();
            CustomerData.Customers = await _context.Customers
                .Include(customer => customer.Orders)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
