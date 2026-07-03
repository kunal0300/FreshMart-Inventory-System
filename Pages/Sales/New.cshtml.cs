using FreshMartPortal.Data;
using FreshMartPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreshMartPortal.Pages.Sales
{
    public class NewModel : PageModel
    {
        private readonly StoreDbContext _db;

        public NewModel(StoreDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public CheckoutRecord Sale { get; set; } = new();

        public List<StockItem> Items { get; set; } = new();

        public async Task OnGetAsync()
        {
            Items = await _db.StockItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var item = await _db.StockItems
                .FirstOrDefaultAsync(x => x.StockItemId == Sale.StockItemId);

            if (item == null)
            {
                return Page();
            }

            Sale.ProductTitle = item.ItemTitle;
            Sale.SalePrice = item.UnitCost * Sale.QuantitySold;
            Sale.SaleDate = DateTime.Now;

            item.UnitsAvailable -= Sale.QuantitySold;

            if (item.UnitsAvailable <= 0)
            {
                item.AvailabilityStatus = "Out of Stock";
            }
            else if (item.UnitsAvailable <= item.ReorderPoint)
            {
                item.AvailabilityStatus = "Low Stock";
            }
            else
            {
                item.AvailabilityStatus = "Available";
            }

            _db.CheckoutRecords.Add(Sale);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Sales/History");
        }
    }
}