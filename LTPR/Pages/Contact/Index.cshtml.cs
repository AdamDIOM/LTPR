using LTPR.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;
using LTPR.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LTPR.Pages.Contact
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        public string Name { get; set; }
        [BindProperty]
        [Required]
        public string Message { get; set; }

        [BindProperty]
        public List<decimal> la { get; set; }
        [BindProperty]
        public List<decimal> lg { get; set; }
        [BindProperty]
        public List<string> names { get; set; }
        [BindProperty]
        public List<string> phnums { get; set; }


        private readonly Data.Admin _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> signInManager;

        public IList<tblRestaurants> tblRestaurants { get; set; }

        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, Data.Admin context)
        {
            _userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            if (signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                Email = await _userManager.GetEmailAsync(user);
            }
            if(_context.tblRestaurants != null)
            {
                tblRestaurants = await _context.tblRestaurants.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.tblRestaurants != null)
            {
                tblRestaurants = await _context.tblRestaurants.ToListAsync();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                // links to email client
                SmtpClient sc = new SmtpClient
                {
                    Credentials = new NetworkCredential("adam.drummond9@gmail.com", "xjiglfnicnibaffc"),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587
                };


                MailMessage m = new MailMessage();
                // from gmail address
                m.From = new MailAddress("adam.drummond9@gmail.com", "LTPR Enquiry");
                // sent to Chester email address (emulating restaurant address)
                m.To.Add(new MailAddress("2126671@chester.ac.uk"));
                // CC in user's email
                m.CC.Add(new MailAddress(Email));
                // adds text and subject line then sends
                m.Body = $"{Name} said {Message}.";
                m.Subject = "LTPR Form Enquiry";
                sc.Send(m);
                // provided nothing failed, redirects to confirmation page to show user their message.
                return Redirect("/Contact/Confirm?Message=" + Message);
            }
            // if something goes wrong, the page is reloaded with an error message
            catch (Exception e)
            {
                ModelState.AddModelError("Customer Contact Field Error", "Invalid data in customer contact form" + e.Message);
                return Page();
            }
        }
    }
}
