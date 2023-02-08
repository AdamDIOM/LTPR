using LTPR.Data;
using LTPR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe;
using Stripe.Terminal;

namespace LTPR.Pages.Purchase
{
    public class PayModel : PageModel
    {
        private readonly LTPR.Data.Admin _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PayModel(Data.Admin context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public string id { get; set; }

        [BindProperty(SupportsGet = true)]
        public double amount { get; set; }
        [BindProperty(SupportsGet = true)]
        public double discount { get; set; }
        public int pmtAmt { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            pmtAmt = (int)Math.Round((amount - discount)*100);
            if(pmtAmt <= 0 || amount <= 0)
            {
                int sid = await Process();
                return Redirect("/Purchase/Confirm?amount=" + Math.Round(amount - discount, 2) + "&id=" + sid + "&uid=" + id);

                //process
            }
            else
            {
                return Page();
            }
        }

        public async Task<int> Process()
        {

            var user = await _userManager.GetUserAsync(User);
            var uid = user.Id;

            var sale = new tblSales
            {
                UID = user.Id,
                OrderTime = DateTime.Now
            };

            if(discount != 0)
            {
                sale.Discount = discount;
            }
            else
            {
                discount = 0;
            }

            _context.tblSales.Add(sale);

            await _context.SaveChangesAsync();

            foreach (var item in _context.tblBasket)
            {
                decimal c = 0;
                if (item.UID == uid)
                {
                    foreach (var i in _context.tblItemOnMenu)
                    {
                        if (item.IID == i.IID && item.MID == i.MID)
                        {
                            c = i.Cost;
                        }
                    }
                    _context.tblItemsOnSale.Add(new tblItemsOnSale
                    {
                        SID = sale.ID,
                        IID = item.IID,
                        Cost = c,
                        Qty = item.Qty
                    });
                    _context.tblBasket.Remove(item);
                }
            }

            await _context.SaveChangesAsync();

            return sale.ID;
        }

        public async Task<IActionResult> OnPostChargeAsync(string stripeEmail, string stripeToken, double amount, double discount, string uid)
        {
            var cus = new CustomerService();
            var chs = new ChargeService();

            try
            {
                var cu = cus.Create(new CustomerCreateOptions
                {
                    Email = stripeEmail,
                    Source = stripeToken
                });

                var ch = chs.Create(new ChargeCreateOptions
                {
                    Amount = (int)((amount-discount)*100),
                    Description = "LTPR Charge",
                    Currency = "gbp",
                    Customer = cu.Id
                });

                int id = await Process();

                return Redirect("/Purchase/Confirm?amount=" + Math.Round(amount-discount, 2) + "&id=" + id + "&uid=" + uid);
            }
            catch (Exception ex)
            {
                return Redirect("/Purchase/PaymentFailed?reason=" + ex.Message);
            }
        }
    }
}
