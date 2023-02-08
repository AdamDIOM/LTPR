using LTPR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LTPR.Pages.Purchase
{
    public class ConfirmModel : PageModel
    {
        private readonly Data.Admin _context;
        [BindProperty(SupportsGet = true)]
        public double amount { get; set; }
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        [BindProperty(SupportsGet = true)]
        public string uid { get; set; }
        public IList<tblSales> tblSales { get; set; }
        public tblSales sale { get; set; }
        public IList<tblItemsOnSale> tblItemsOnSale { get; set; }
        public IList<tblMenuItem>  tblMenuItem { get; set; }
        public IList<tblMenus> tblMenus { get; set; }

        public ConfirmModel(Data.Admin context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            if(_context.tblSales != null)
            {
                tblSales = await _context.tblSales.ToListAsync();
                foreach(var s in tblSales)
                {
                    if(s.ID == id)
                    {
                        sale = s;
                        break;
                    }
                }
            }
            if(_context.tblItemsOnSale != null)
            {
                tblItemsOnSale = await _context.tblItemsOnSale.ToListAsync();
            }
            if(_context.tblMenuItem != null)
            {
                tblMenuItem = await _context.tblMenuItem.ToListAsync();
            }
            if(_context.tblMenus != null)
            {
                tblMenus = await _context.tblMenus.ToListAsync();
            }
        }

        public string CheckSale(double calc)
        {
            if(amount != calc)
            {
                Response.Redirect("/Index");
            }
            if(uid != sale.UID)
            {
                Response.Redirect("/Index");
            }
            return "";
        }
    }
}
