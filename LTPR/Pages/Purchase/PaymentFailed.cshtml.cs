using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTPR.Pages.Purchase
{
    public class PaymentFailedModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Reason { get; set; }
        public void OnGet()
        {
            // if user has manually navigated to the page without a Stripe card decline reason, they are sent to the homepage
            if(Reason == null || Reason == "")
            {
                RedirectToPage("/Index");
            }
        }
    }
}
