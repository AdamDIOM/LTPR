﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.Images
{
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
        public tblImages tblImages { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                //return Page();
            }

          foreach(var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                tblImages.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }
           

            _context.tblImages.Add(tblImages);
            await _context.SaveChangesAsync();

            if(ru == "")
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
