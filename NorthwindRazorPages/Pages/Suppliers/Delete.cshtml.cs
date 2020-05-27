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
    public class DeleteModel : PageModel
    {
        private readonly SupplierContext _context;

        public DeleteModel(SupplierContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Supplier Supplier { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplier = await _context.Suppliers
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SupplierId == id);

            if (Supplier == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            try
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
