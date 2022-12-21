﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;
using System.Data.SqlClient;

namespace LTPR.Pages.Menus
{
    public class IndexModel : PageModel
    {
        private readonly LTPR.Data.LTPRContext _context;

        public IndexModel(LTPR.Data.LTPRContext context)
        {
            _context = context;
        }

        public IList<tblMenus> tblMenus { get;set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.tblMenus != null)
            {
                tblMenus = await _context.tblMenus.ToListAsync();

            }
        }
    }
}