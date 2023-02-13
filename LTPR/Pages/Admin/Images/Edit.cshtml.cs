using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;

namespace LTPR.Pages.Admin.Images
{
    // standard ASP Razor Page CRUD page
    public class EditModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public EditModel(LTPR.Data.Admin context)
        {
            _context = context;
        }
        [BindProperty]
        public tblImages tblImages { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblImages == null)
            {
                return NotFound();
            }

            var tblimages =  await _context.tblImages.FirstOrDefaultAsync(m => m.ID == id);
            if (tblimages == null)
            {
                return NotFound();
            }
            tblImages = tblimages;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            tblImages.ImageData = tblImages.ImageData.ToArray();
            if (!ModelState.IsValid)
            {
                //return Page();
            }

            _context.Attach(tblImages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblImagesExists(tblImages.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        // checks if a table exists by attempting to return an item of specific id
        private bool tblImagesExists(int id)
        {
          return _context.tblImages.Any(e => e.ID == id);
        }
    }
}
