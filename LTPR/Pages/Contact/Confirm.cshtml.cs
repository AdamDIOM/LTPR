using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LTPR.Pages.Contact
{
    public class ConfirmModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }
        public void OnGet()
        {

        }
    }
}