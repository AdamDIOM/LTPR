﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using LTPR.Data;
using LTPR.Models;
using Microsoft.EntityFrameworkCore;

namespace LTPR.Pages
{

	public class IndexModel : PageModel
    {
        private readonly Data.Admin _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public IList<tblItemOnMenu> tblItemOnMenu { get; set; }
        public IList<tblMenuItem> tblMenuItem { get; set; }
        public IList<tblMenus> tblMenus { get; set; }
        public IList<tblBasket> tblBasket { get; set; }
        [BindProperty(SupportsGet = true)]
        public int iid { get; set; }
        public IndexModel(Data.Admin context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            if(_context.tblItemOnMenu != null)
            {
                tblItemOnMenu = await _context.tblItemOnMenu.ToListAsync();
            }
            if(_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
            }
            if(_context.tblMenus != null)
            {
                tblMenus = await _context.tblMenus.ToListAsync();
            }
            if(_context.tblBasket != null)
            {
                tblBasket = await _context.tblBasket.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostBasketAsync(int? iid, int? mid)
        {
            if (mid == null || iid == null)
            {
                return NotFound();
            }
            // finds current user and checks to see if item is already in basket
            var user = await _userManager.GetUserAsync(User);
            var f = false;
            foreach (var item in _context.tblBasket)
            {
                // if item is in user's basket, it increases Qty field by 1 and then adds modified EF model to context, staged for saving.
                if (item.UID == user.Id && item.IID == (int)iid && item.MID == (int)mid)
                {
                    var i = await _context.tblBasket.FirstOrDefaultAsync(m => m.ID == item.ID);
                    i.Qty++;
                    _context.Attach(i).State = EntityState.Modified;
                    f = true;
                    break;
                }
            }
            // if not found in current user's basket, a new entry is created.
            if (!f)
            {
                _context.tblBasket.Add(new Models.tblBasket
                {
                    UID = user.Id, // get logged on user
                    IID = (int)iid, //get item from button
                    MID = (int)mid, //get from details id
                    Qty = 1 //check if item already in basket
                });
            }
            // saves to database and reloads page
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}