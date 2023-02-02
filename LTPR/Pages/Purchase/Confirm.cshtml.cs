using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTPR.Pages.Purchase
{
    public class ConfirmModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int amount { get; set; }
        public void OnGet()
        {
        }
    }
}
