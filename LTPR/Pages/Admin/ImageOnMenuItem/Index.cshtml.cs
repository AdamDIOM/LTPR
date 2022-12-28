using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.ImageOnMenuItem
{
    public class IndexModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public IndexModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        public IList<tblImageOnMenuItem> tblImageOnMenuItem { get;set; } = default!;
        public IList<tblMenuItem> tblMenuItem { get;set; } = default!;
        public IList<tblImages> tblImages { get;set; } = default!;

        public async Task OnGetAsync()
		{
			if (_context.tblImageOnMenuItem != null)
			{
				tblImageOnMenuItem = await _context.tblImageOnMenuItem.ToListAsync();
			}
			if (_context.tblMenuItem != null)
			{
				tblMenuItem = await _context.tblMenuItem.ToListAsync();
			}
			if (_context.tblImages != null)
			{
				tblImages = await _context.tblImages.ToListAsync();
			}
		}
    }
}
