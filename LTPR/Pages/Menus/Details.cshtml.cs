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
using Microsoft.AspNetCore.Identity;

namespace LTPR.Pages.Menus
{
    public class DetailsModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;

        public DetailsModel(LTPR.Data.Admin context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            this.signInManager = signInManager;
        }

        private readonly UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> signInManager;

      public tblMenus tblMenus { get; set; }
        public IList<tblItemOnMenu> tblItemOnMenu { get; set; } = default!;
        public IList<tblMenuItem> tblMenuItem { get; set; } = default!;

        public IList<tblIngredientInItem> tblIngredientInItem { get; set; } = default!;
        public IList<tblIngredients> tblIngredients { get; set; } = default!;

        public IList<tblImageOnMenuItem> tblImageOnMenuItem { get; set; } = default!;
        public IList<tblImages> tblImages { get; set; } = default!;

        public IList<tblBasket> tblBasket { get; set; } = default!;

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

            if (_context.tblIngredients != null)
            {
                tblIngredients = await _context.tblIngredients.ToListAsync();
            }

            if (_context.tblImageOnMenuItem != null)
            {
                tblImageOnMenuItem = await _context.tblImageOnMenuItem.ToListAsync();
            }
            if (_context.tblImages != null)
            {
                tblImages = await _context.tblImages.ToListAsync();
            }
            if (_context.tblBasket != null)
            {
                tblBasket = await _context.tblBasket.ToListAsync();
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

        public async Task<IActionResult> OnPostBasketAsync(int? id, int? iid)
        {
            if (id == null || iid == null)
            {
                return NotFound();
            }
            
            var user = await _userManager.GetUserAsync(User);
            //need to add check for item in basket
            var f = false;
            foreach(var item in _context.tblBasket)
            {
                if(item.UID == user.Id && item.IID == (int)iid && item.MID == (int)id)
                {
                    var i = await _context.tblBasket.FirstOrDefaultAsync(m => m.ID == item.ID);
                    i.Qty++;
                    _context.Attach(i).State = EntityState.Modified;
                    f = true;
                    break;
                }
            }
            if (!f)
            {
                _context.tblBasket.Add(new Models.tblBasket
                {
                    UID = user.Id, // get logged on user
                    IID = (int)iid, //get item from button
                    MID = (int)id, //get from details id
                    Qty = 1 //check if item already in basket
                });
            }
            
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        [BindProperty(SupportsGet = true)]
        public string qry { get; set; }

        [BindProperty(SupportsGet = true)]
        public int iid { get; set; }

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
