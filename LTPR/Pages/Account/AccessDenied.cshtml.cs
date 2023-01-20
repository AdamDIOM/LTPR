using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTPR.Pages.Account
{
    public class AccessDeniedModel : PageModel
    {

		[BindProperty(SupportsGet = true)]
		public string ReturnUrl { get; set; }
		public void OnGet()
        {
        }
    }
}
