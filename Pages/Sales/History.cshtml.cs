using FreshMartPortal.Data;
using FreshMartPortal.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreshMartPortal.Pages.Sales
{
    public class HistoryModel : PageModel
    {
        private readonly StoreDbContext _db;

        public HistoryModel(StoreDbContext db)
        {
            _db = db;
        }

        public List<CheckoutRecord> Sales { get; set; } = new();

        public async Task OnGetAsync()
        {
            Sales = await _db.CheckoutRecords
                .OrderByDescending(x => x.SaleDate)
                .ToListAsync();
        }
    }
}