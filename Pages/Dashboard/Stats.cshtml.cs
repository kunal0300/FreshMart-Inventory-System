using FreshMartPortal.Data;
using FreshMartPortal.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreshMartPortal.Pages.Dashboard;

public class StatsModel : PageModel
{
    private readonly StoreDbContext _db;

    public StatsModel(StoreDbContext db)
    {
        _db = db;
    }

    public int TotalProducts { get; set; }
    public int TotalStock { get; set; }
    public int LowStock { get; set; }
    public int TotalSales { get; set; }

    public List<StockItem> LowStockItems { get; set; } = new();

    public async Task OnGetAsync()
    {
        TotalProducts = await _db.StockItems.CountAsync();
        TotalStock = await _db.StockItems.SumAsync(x => x.UnitsAvailable);
        LowStock = await _db.StockItems.CountAsync(x => x.UnitsAvailable <= x.ReorderPoint);
        TotalSales = await _db.CheckoutRecords.CountAsync();

        LowStockItems = await _db.StockItems
            .Where(x => x.UnitsAvailable <= x.ReorderPoint)
            .OrderBy(x => x.UnitsAvailable)
            .ToListAsync();
    }
}