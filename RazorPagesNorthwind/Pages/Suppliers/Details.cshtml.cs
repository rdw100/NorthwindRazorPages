using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesNorthwind.Data;
using RazorPagesNorthwind.Models;

namespace RazorPagesNorthwind.Pages.Suppliers
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesNorthwind.Data.SupplierContext _context;

        public DetailsModel(RazorPagesNorthwind.Data.SupplierContext context)
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
