﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Menus
{
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
        public tblMenus tblMenus { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tblMenus.Add(tblMenus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
