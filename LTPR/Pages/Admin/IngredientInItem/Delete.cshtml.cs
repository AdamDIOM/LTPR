using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.IngredientInItem
{
    public class DeleteModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DeleteModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        [BindProperty]
      public tblIngredientInItem tblIngredientInItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblIngredientInItem == null)
            {
                return NotFound();
            }

            var tblingredientinitem = await _context.tblIngredientInItem.FirstOrDefaultAsync(m => m.KID == id);

            if (tblingredientinitem == null)
            {
                return NotFound();
            }
            else 
            {
                tblIngredientInItem = tblingredientinitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tblIngredientInItem == null)
            {
                return NotFound();
            }
            var tblingredientinitem = await _context.tblIngredientInItem.FindAsync(id);

            if (tblingredientinitem != null)
            {
                tblIngredientInItem = tblingredientinitem;
                _context.tblIngredientInItem.Remove(tblIngredientInItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
