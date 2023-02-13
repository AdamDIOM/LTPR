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
    // standard ASP Razor Page CRUD page
    public class IndexModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public IndexModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        public IList<tblMenuItem> tblMenuItem { get;set; } = default!;
        public List<tblMenuItem> tblMIList { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public int Unretire { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
                tblMIList = tblMenuItem.ToList();
                // this shows the retired items at the bottom
                tblMIList = tblMIList.OrderBy(x => x.Retired).ToList();

            }
            // if there is a route parameter for unretire, get the menu item and set retired to false.
            if(Unretire > 0)
            {
                var tblmenuitem = await _context.tblMenuItem.FirstOrDefaultAsync(m => m.ID == Unretire);
                tblmenuitem.Retired = false;
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return Page();
            }
        }
    }
}
