using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LTPR.Data;
using LTPR.Models;
using Microsoft.EntityFrameworkCore;

namespace LTPR.Pages.Admin.DiscountCodes
{
    // standard ASP Razor Page CRUD page
    public class CreateModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public CreateModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public tblDiscountCodes tblDiscountCodes { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            // checks if the discount code already exists, and if it does it uses ModelState to return an error
            if(_context.tblDiscountCodes != null)
            {
                IList<tblDiscountCodes> tdc = await _context.tblDiscountCodes.ToListAsync();
                if(tdc.FirstOrDefault(m => m.DiscountCode == tblDiscountCodes.DiscountCode) != null)
                {
                    // this will set ModelState to not valid
                    ModelState.AddModelError("duplicate", "Discount Code already exists!");
                }
            }
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tblDiscountCodes.Add(tblDiscountCodes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
