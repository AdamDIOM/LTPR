using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.MenuItem
{
    public class DetailsModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DetailsModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

      public tblMenuItem tblMenuItem { get; set; }


        public IList<tblIngredients> tblIngredients { get; set; } = default!;
        public IList<tblIngredientInItem> tblIngredientInItem { get; set; } = default!;

        public IList<tblImages> tblImages { get; set; } = default!;
        public IList<tblImageOnMenuItem> tblImageOnMenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblMenuItem == null)
            {
                return NotFound();
            }

            if (_context.tblIngredients != null)
            {
                tblIngredients = await _context.tblIngredients.ToListAsync();
            }
            if (_context.tblIngredientInItem != null)
            {
                tblIngredientInItem = await _context.tblIngredientInItem.ToListAsync();
            }

            if (_context.tblImages != null)
            {
                tblImages = await _context.tblImages.ToListAsync();
            }
            if (_context.tblImageOnMenuItem != null)
            {
                tblImageOnMenuItem = await _context.tblImageOnMenuItem.ToListAsync();
            }

            var tblmenuitem = await _context.tblMenuItem.FirstOrDefaultAsync(m => m.ID == id);
            if (tblmenuitem == null)
            {
                return NotFound();
            }
            else 
            {
                tblMenuItem = tblmenuitem;
            }
            return Page();
        }
    }
}
