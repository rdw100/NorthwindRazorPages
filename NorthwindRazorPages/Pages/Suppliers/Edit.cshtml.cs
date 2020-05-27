using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthwindRazorPages.Data;
using NorthwindRazorPages.Models;

namespace NorthwindRazorPages.Pages.Suppliers
{
    public class EditModel : PageModel
    {
        private readonly SupplierContext _context;

        public EditModel(SupplierContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Supplier Supplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplier = await _context.Suppliers.FindAsync(id);

            if (Supplier == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var supplierToUpdate = await _context.Suppliers.FindAsync(id);

            if (supplierToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Supplier>(
                supplierToUpdate,
                "supplier",
                s => s.CompanyName, s => s.ContactName, s => s.ContactTitle, s => s.Address, s => s.City, s => s.Region, s => s.PostalCode, s => s.Country, s => s.Phone, s => s.Fax, s => s.HomePage))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierId == id);
        }
    }
}
