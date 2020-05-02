using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindRazorPages.Data;
using NorthwindRazorPages.Models;

namespace NorthwindRazorPages.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SupplierContext _context;

        public AboutModel(SupplierContext context)
        {
            _context = context;
        }

        public IList<SupplierProductGroupViewModel> Suppliers { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<SupplierProductGroupViewModel> data =
                from product in _context.Products
                group product by product.CategoryId into productGroup
                select new SupplierProductGroupViewModel()
                {
                    CategoryId = (int)productGroup.Key,
                    ProductCount = productGroup.Count()
                };

            Suppliers = await data.AsNoTracking().ToListAsync();
        }
    }
}