using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesNorthwind.Data;
using RazorPagesNorthwind.Models;

namespace RazorPagesNorthwind.Pages.Suppliers
{
    public class CreateVmModel : PageModel
    {
        private readonly RazorPagesNorthwind.Data.SupplierContext _context;

        public CreateVmModel(RazorPagesNorthwind.Data.SupplierContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SupplierViewModel SupplierVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Supplier());
            entry.CurrentValues.SetValues(SupplierVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

    }
}
