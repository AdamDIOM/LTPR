using LTPR.Data;
using LTPR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LTPR.Pages.Admin.Users
{
    public class OrdersModel : PageModel
    {
        private readonly Data.Admin _context;
        public IList<tblSales> tblSales;
        public IList<tblItemsOnSale> tblItemsOnSale;
        public IList<tblMenuItem> tblMenuItem;
        public UserManager<ApplicationUser> UserManager;

        public OrdersModel(Data.Admin context, UserManager<ApplicationUser> um)
        {
            _context = context;
            UserManager = um;
        }
        public async Task OnGetAsync()
        {
            if(_context.tblSales != null)
            {
                tblSales = await _context.tblSales.ToListAsync();
            }
            if(_context.tblItemsOnSale != null)
            {
                tblItemsOnSale = await _context.tblItemsOnSale.ToListAsync();
            }
            if(_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
            }
        }
    }
}
