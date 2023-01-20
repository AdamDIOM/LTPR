using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LTPR.Data;
using LTPR.Models;
using Microsoft.AspNetCore.Identity;

namespace LTPR.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
		private readonly UserManager<ApplicationUser> _userManager;

		public IndexModel(
			UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;

		}

		public IQueryable<ApplicationUser> users { get;set; } = default!;

        public void OnGet()
        {
            users = _userManager.Users;
        }
    }
}
