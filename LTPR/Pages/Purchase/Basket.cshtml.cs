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

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        public ApplicationUser user { get; set; }
        public IList<tblBasket> tblBasket { get; set; }
        public IList<tblMenuItem> tblMenuItem { get; set; }
        public IList<tblMenus> tblMenus { get; set; }
        public IList<tblItemOnMenu> tblItemOnMenu { get; set; }
        public IList<tblDiscountCodes> tblDiscountCodes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DiscountCode { get; set; }
        [BindProperty]
        public string DiscountResponse { get; set; }
        public decimal DiscountAmount { get; set; }
        public bool DiscountIsPercent { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal DiscountValue { get; set; }

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
            if (_context.tblDiscountCodes != null)
            {
                tblDiscountCodes = await _context.tblDiscountCodes.ToListAsync();
            }
            user = await _userManager.GetUserAsync(User);
            DiscountResponse = "";
        }

        public string UpdateDiscount()
        {
            if (DiscountCode != null)
            {
                bool found = false;
                foreach (var code in tblDiscountCodes)
                {
                    if (code.DiscountCode == DiscountCode)
                    {
                        DiscountIsPercent = code.IsPercentage;
                        DiscountAmount = code.DiscountAmount;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    DiscountResponse = $"Discount code \"{DiscountCode}\" is invalid.";
                }
                else
                {
                    if (DiscountIsPercent)
                    {
                        DiscountValue = Math.Round(totalSum * (DiscountAmount / 100), 2);
                        DiscountResponse = $"Discount code \"{DiscountCode}\" gives {DiscountAmount.ToString("0.##")}% Discount, £{DiscountValue.ToString("0.00")} off.";
                    }
                    else
                    {
                        if(totalSum < DiscountAmount)
                        {
                            DiscountValue = totalSum;
                        }
                        else
                        {
                            DiscountValue = DiscountAmount;
                        }
                        DiscountResponse = $"Discount code \"{DiscountCode}\" gives £{DiscountAmount.ToString("0.00")} Discount!";
                    }
                }
            }
            else
            {
                DiscountResponse = "";
            }
            return "";
        }

        public async Task<IActionResult> OnPostQtyMinusAsync()
        {
            if (_context.tblBasket != null)
            {
                tblBasket = await _context.tblBasket.ToListAsync();
            }
            if (id < 0)
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
            if (id < 0)
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

        


        public  IActionResult OnPostCharge(decimal totalSum, decimal DiscountValue, string id)
        {
            return Redirect("Pay?amount=" + totalSum + "&discount=" + DiscountValue+"&id=" + id);
        }

        public  IActionResult OnPostDiscount(string DiscountCode)
        {
            return Redirect("Basket?DiscountCode=" + DiscountCode);
        }
    }
}
