using LTPR.Data;
using LTPR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;

namespace LTPR.Pages.Purchase
{
    public class BasketModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty(SupportsGet = true)]
        public decimal totalSum { get; set; }

        [BindProperty(SupportsGet =true)]
        public int id { get; set; }
        public ApplicationUser user { get; set; }
        public IList<tblBasket> tblBasket { get; set; }
        public IList<tblMenuItem> tblMenuItem { get; set; }
        public IList<tblMenus> tblMenus { get; set; }
        public IList<tblItemOnMenu> tblItemOnMenu { get; set; }

        public BasketModel(Data.Admin context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task OnGetAsync()
        {
            if (_context.tblBasket != null)
            {
                tblBasket = await _context.tblBasket.ToListAsync();
            }
            if (_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
            }
            if (_context.tblMenus != null)
            {
                tblMenus = await _context.tblMenus.ToListAsync();
            }
            if (_context.tblItemOnMenu != null)
            {
                tblItemOnMenu = await _context.tblItemOnMenu.ToListAsync();
            }
            user = await _userManager.GetUserAsync(User);
        }

        public async Task<IActionResult> OnPostQtyMinusAsync()
        {
            if (_context.tblBasket != null)
            {
                tblBasket = await _context.tblBasket.ToListAsync();
            }
            if (id == null || id < 0)
            {
                return NotFound();
            }
            else
            {
                foreach(var item in tblBasket)
                {
                    if (item.ID == id)
                    {
                        item.Qty--;
                        if (item.Qty < 1)
                        {
                            _context.tblBasket.Remove(item);
                        }
                        else
                        {
                            _context.Attach(item).State = EntityState.Modified;
                        }
                        await _context.SaveChangesAsync();
                        return RedirectToPage();
                    }
                }
                return NotFound();
            }
        }
        public async Task<IActionResult> OnPostQtyPlusAsync()
        {
            if (_context.tblBasket != null)
            {
                tblBasket = await _context.tblBasket.ToListAsync();
            }
            if (id == null || id < 0)
            {
                return NotFound();
            }
            else
            {
                foreach (var item in tblBasket)
                {
                    if (item.ID == id)
                    {
                        item.Qty++;
                        _context.Attach(item).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        return RedirectToPage();
                    }
                }
                return NotFound();
            }
        }

        


        public async Task<IActionResult> OnPostChargeAsync(decimal totalSum, string id)
        {
            return Redirect("Pay?amount=" + Math.Round(totalSum*100) + "&id=" + id);
        }
    }
}
