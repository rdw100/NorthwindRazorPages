using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesNorthwind.Data;
using RazorPagesNorthwind.Models;

namespace RazorPagesNorthwind.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SupplierContext _context;

        public AboutModel(SupplierContext context)
        {
            _context = context;
        }

        public IList<SupplierProductGroup> Suppliers { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<SupplierProductGroup> data =
                from product in _context.Products
                group product by product.CategoryId into productGroup
                select new SupplierProductGroup()
                {
                    CategoryId = (int)productGroup.Key,
                    ProductCount = productGroup.Count()
                };

            Suppliers = await data.AsNoTracking().ToListAsync();
        }
    }
}