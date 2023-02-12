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
        //if payment value is less than 0, go straight to confirm page
        public async Task<IActionResult> OnGetAsync()
        {
            pmtAmt = (int)Math.Round((amount - discount)*100);
            // if the amount payable is 0 (i.e. discounted 100%) it will redirect straight to the confirmation page instead of paying via Stripe
            if(pmtAmt <= 0 || amount <= 0)
            {
                int sid = await Process();
                return Redirect("/Purchase/Confirm?amount=" + Math.Round(amount - discount, 2) + "&id=" + sid + "&uid=" + id);
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

            // creates new item for tblSales detailing the user, time of sale, any discount and adds it to the table
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

            // for every item in the basket, creates a new item in tblItemsOnSale with the sale id, item id, cost at current time and quantity. Then removes each individual item from the basket
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

        // tries to charge, if there is any error (such as card decline) it returns to payment failed
        public async Task<IActionResult> OnPostChargeAsync(string stripeEmail, string stripeToken, double amount, double discount, string uid)
        {
            var cus = new CustomerService();
            var chs = new ChargeService();

            // try catch will catch any declined cards
            try
            {
                // creates a Stripe customer
                var cu = cus.Create(new CustomerCreateOptions
                {
                    Email = stripeEmail,
                    Source = stripeToken
                });

                // creates a Stripe charge
                var ch = chs.Create(new ChargeCreateOptions
                {
                    Amount = (int)((amount-discount)*100),
                    Description = "LTPR Charge",
                    Currency = "gbp",
                    Customer = cu.Id
                });

                int id = await Process();
                
                // if card successfully pays, proceed to confirmation page
                return Redirect("/Purchase/Confirm?amount=" + Math.Round(amount-discount, 2) + "&id=" + id + "&uid=" + uid);
            }
            // this catches when a card is declined either for insufficieunds, incorrect expiry date, security code or anything else
            catch (Exception ex)
            {
                // redirects to failed page with the message from Stripe
                return Redirect("/Purchase/PaymentFailed?reason=" + ex.Message);
            }
        }
    }
}
