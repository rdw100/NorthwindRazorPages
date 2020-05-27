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
    public class CreateVmModel : PageModel
    {
        private readonly SupplierContext _context;

        public CreateVmModel(SupplierContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SupplierViewModel SupplierVM { get; set; }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    var entry = _context.Add(new Supplier());
        //    entry.CurrentValues.SetValues(SupplierVM);
        //    await _context.SaveChangesAsync();
        //    return RedirectToPage("./Index");
        //}

    }
}
