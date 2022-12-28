using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;
using NuGet.Packaging;

namespace LTPR.Pages.Menus
{
    public class DetailsModel : PageModel
    {
        private readonly LTPR.Data.LTPRContext _context;

        public DetailsModel(LTPR.Data.LTPRContext context)
        {
            _context = context;
        }

      public tblMenus tblMenus { get; set; }
        public IList<tblItemOnMenu> tblItemOnMenu { get; set; } = default!;
        public IList<tblMenuItem> tblMenuItem { get; set; } = default!;

        public IList<tblIngredientInItem> tblIngredientInItem { get; set; } = default!;
        public IList<tblIngredients> tblIngredients { get; set; } = default!;

        public IList<tblImageOnMenuItem> tblImageOnMenuItem { get; set; } = default!;
        public IList<tblImages> tblImages { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblMenus == null)
            {
                return NotFound();
            }

            //if (_context.tblItemOnMenu != null)
            {
                if (!string.IsNullOrEmpty(qry))
                {
                    tblItemOnMenu = await _context.tblItemOnMenu
                        .FromSqlRaw("SELECT tblItemOnMenu.ID, tblItemOnMenu.MID, tblItemOnMenu.IID FROM tblItemOnMenu INNER JOIN tblMenuItem ON tblItemOnMenu.IID = tblMenuItem.ID WHERE tblMenuItem.Name LIKE '%" + qry + "%'").ToListAsync();
                } else
                {
                    tblItemOnMenu = await _context.tblItemOnMenu.ToListAsync();
                }
            }

            if (_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
            }

            if (_context.tblIngredientInItem != null)
            {
                tblIngredientInItem = await _context.tblIngredientInItem.ToListAsync();
            }

            if (_context.tblIngredient != null)
            {
                tblIngredients = await _context.tblIngredient.ToListAsync();
            }

            if (_context.tblImageOnMenuItem != null)
            {
                tblImageOnMenuItem = await _context.tblImageOnMenuItem.ToListAsync();
            }
            if (_context.tblImages != null)
            {
                tblImages = await _context.tblImages.ToListAsync();
            }

            var tblmenus = await _context.tblMenus.FirstOrDefaultAsync(m => m.ID == id);
            if (tblmenus == null)
            {
                return NotFound();
            }
            else
            {
                tblMenus = tblmenus;
            }

            return Page();
        }

        [BindProperty(SupportsGet = true)]
        public string qry { get; set; }

        /*public async Task<IActionResult> OnPostSearchAsync(int? id)
        {
            tblItemOnMenu = await _context.tblItemOnMenu
                .FromSqlRaw("SELECT tblItemOnMenu.ID, tblItemOnMenu.MID, tblItemOnMenu.IID FROM tblItemOnMenu INNER JOIN tblMenuItem ON tblItemOnMenu.IID = tblMenuItem.ID WHERE tblMenuItem.Name LIKE '%" + qry + "%'").ToListAsync();
            //tblItemOnMenu.AddRange(await _context.tblItemOnMenu.ToListAsync());
            
            //return Page();
            /*if (_context.tblItemOnMenu != null)
            {
                tblItemOnMenu = await _context.tblItemOnMenu./*FromSqlRaw("SELECT tblItemOnMenu.ID, tblItemOnMenu.MID, tblItemOnMenu.IID FROM tblItemOnMenu INNER JOIN tblMenuItem ON tblItemOnMenu.IID = tblMenuItem.ID WHERE tblMenuItem.Name LIKE '" + Search + "%'").*//*ToListAsync();
            }
            *//*
            if (_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
            }

            if (_context.tblIngredientInItem != null)
            {
                tblIngredientInItem = await _context.tblIngredientInItem.ToListAsync();
            }

            if (_context.tblIngredient != null)
            {
                tblIngredients = await _context.tblIngredient.ToListAsync();
            }

            if (_context.tblImageOnMenuItem != null)
            {
                tblImageOnMenuItem = await _context.tblImageOnMenuItem.ToListAsync();
            }
            if (_context.tblImages != null)
            {
                tblImages = await _context.tblImages.ToListAsync();
            }

            var tblmenus = await _context.tblMenus.FirstOrDefaultAsync(m => m.ID == id);
            if (tblmenus == null)
            {
                return NotFound();
            }
            else
            {
                tblMenus = tblmenus;
            }
            return Page();
        }*/
    }
}
