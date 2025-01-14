﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.MenuItem
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
        public tblMenuItem tblMenuItem { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tblMenuItem.Add(tblMenuItem);
            await _context.SaveChangesAsync();

            // checks to see whether there is a return url parameter such as a link table in the url
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
