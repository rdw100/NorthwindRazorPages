using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindRazorPages.Data;
using NorthwindRazorPages.Models;

namespace NorthwindRazorPages.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindRazorPages.Data.SupplierContext _context;

        public IndexModel(NorthwindRazorPages.Data.SupplierContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string ContactSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Supplier> Supplier { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ContactSort = sortOrder == "Contact" ? "contact_desc" : "Contact";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Supplier> supplierQuery = from s in _context.Suppliers
                                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                supplierQuery = supplierQuery.Where(s => s.CompanyName.ToUpper().Contains(searchString.ToUpper())
                                                      || s.ContactName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    supplierQuery = supplierQuery.OrderByDescending(s => s.CompanyName);
                    break;
                case "Contact":
                    supplierQuery = supplierQuery.OrderBy(s => s.ContactName);
                    break;
                case "contact_desc":
                    supplierQuery = supplierQuery.OrderByDescending(s => s.ContactName);
                    break;
                default:
                    supplierQuery = supplierQuery.OrderBy(s => s.CompanyName);
                    break;
            }

            int pageSize = 3;
            Supplier = await PaginatedList<Supplier>.CreateAsync(
                supplierQuery.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
