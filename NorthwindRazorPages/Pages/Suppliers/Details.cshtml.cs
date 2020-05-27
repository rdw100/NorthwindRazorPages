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
    public class DetailsModel : PageModel
    {
        private readonly SupplierContext _context;

        public DetailsModel(SupplierContext context)
        {
            _context = context;
        }

        public Supplier Supplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Supplier = await _context.Suppliers.FirstOrDefaultAsync(m => m.SupplierId == id);

            Supplier = await _context.Suppliers
                .Include(s => s.Products)
                .ThenInclude(e => e.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SupplierId == id);

            if (Supplier == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
