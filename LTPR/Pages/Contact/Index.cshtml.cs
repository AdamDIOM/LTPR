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
        public string Email { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                //client.connect instead?
                SmtpClient sc = new SmtpClient{
                    Credentials = new NetworkCredential("2126671@chester.ac.uk", "Che20021205"),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true, //with tls?
                    Host = "smtp.office365.com",
                    Port = 587
                };

                SmtpClient sc2 = new SmtpClient
                {
                    Credentials = new NetworkCredential("adam.drummond9@gmail.com", "xjiglfnicnibaffc"),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587
                };


                MailMessage m = new MailMessage();
                m.From = new MailAddress("adam.drummond9@gmail.com", "LTPR Enquiry");
                m.To.Add(new MailAddress("2126671@chester.ac.uk"));
                m.CC.Add(new MailAddress(Email));
                m.Body = $"{Name} said {Message}.";
                m.Subject = "LTPR Form Enquiry";
                sc2.Send(m);
                return Redirect("/Contact/Confirm?Message=" + Message);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Customer Contact Field Error", "Invalid data in customer contact form" + e.Message);
                return Page();
            }
        }
    }
}
