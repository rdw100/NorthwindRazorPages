using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindRazorPages.Data;
using NorthwindRazorPages.Models;

namespace NorthwindRazorPages.Pages.Suppliers
{
    public class CreateModel : PageModel
    {
        private readonly SupplierContext _context;

        public CreateModel(SupplierContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Supplier Supplier { get; set; }

        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptySupplier = new Supplier();

            if (await TryUpdateModelAsync<Supplier>(
                emptySupplier,
                "supplier",   // Prefix for form value.
                s => s.CompanyName, s => s.ContactName, s => s.ContactTitle, s => s.Address, s => s.City, s => s.Region, s => s.PostalCode, s => s.Country, s => s.Phone, s => s.Fax, s => s.HomePage))
            {
                _context.Suppliers.Add(emptySupplier);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
