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
            if(Reason == null || Reason == "")
            {
                RedirectToPage("/Index");
            }
        }
    }
}
