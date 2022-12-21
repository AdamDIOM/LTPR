﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.Ingredients
{
    public class IndexModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public IndexModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        public IList<tblIngredients> tblIngredients { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.tblIngredients != null)
            {
                tblIngredients = await _context.tblIngredients.ToListAsync();
            }
        }
    }
}
