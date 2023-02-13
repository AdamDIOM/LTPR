using System;
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
    // standard ASP Razor Page CRUD page
    public class CreateModel : PageModel
    {
        // return url used with link tables
        [BindProperty(SupportsGet = true)]
        public string ru { get; set; }
        [BindProperty(SupportsGet = true)]
        public string noImg { get; set; }
        public string noImgMsg { get; set; }
        private readonly LTPR.Data.Admin _context;

        public CreateModel(LTPR.Data.Admin context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if(noImg == "true")
            {
                noImgMsg = "Image upload required.";
                ModelState.AddModelError("image", "No image uploaded.");
            }
            else
            {
                noImgMsg = "";
            }
            return Page();
        }

        [BindProperty]
        public tblImages tblImages { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                ModelState.AddModelError("image", "No image uploaded.");
                return Page();
            }

          // if the user has uploaded any files, set ImageData to the selected 
          if(Request.Form.Files.Count < 1)
            {
                return Redirect("Create?noImg=true");
            }
          foreach(var file in Request.Form.Files)
            {
                // copies file data into an array and then into the object
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                tblImages.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }
           

            _context.tblImages.Add(tblImages);
            await _context.SaveChangesAsync();

            // if there is no return url (e.g. to link table), go back to the Images Index
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
