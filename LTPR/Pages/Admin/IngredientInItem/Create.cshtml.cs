using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.IngredientInItem
{
    public class CreateModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public CreateModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        public IList<tblMenuItem> tblMenuItem { get; set; } = default!;
        public IList<tblIngredients> tblIngredients { get; set; } = default!;
        public IList<tblIngredientInItem> tblIII { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
            }
            if (_context.tblIngredients != null)
            {
                tblIngredients = await _context.tblIngredients.ToListAsync();
            }
            if (_context.tblIngredientInItem != null)
            {
                tblIII = await _context.tblIngredientInItem.ToListAsync();
            }
            return Page();
        }

        [BindProperty]
        public tblIngredientInItem tblIngredientInItem { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
            _context.tblIngredientInItem.Add(tblIngredientInItem);
            await _context.SaveChangesAsync();
            }
            catch { }

            return RedirectToPage("./Index");
        }
    }
}
