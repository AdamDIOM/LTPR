using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.Ingredients
{
    // standard ASP Razor Page CRUD page
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ru { get; set; }
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
        public tblIngredients tblIngredients { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tblIngredients.Add(tblIngredients);
            await _context.SaveChangesAsync();

            if (ru == "")
            {
                return RedirectToPage("./Index");
            }
            else
            {
                try
                {
                    return RedirectToPage(ru);
                }
                catch
                {
                    return RedirectToPage("./Index");
                }
            }
        }
    }
}
