using FreshMartPortal.Data;
using FreshMartPortal.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreshMartPortal.Pages;

public class ProductSearchModel : PageModel
{
    private readonly StoreDbContext _db;

    public ProductSearchModel(StoreDbContext db)
    {
        _db = db;
    }

    public List<StockItem> Results { get; set; } = new();

    public string Message { get; set; } = "";

    public async Task OnGetAsync(string? query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            Message = "No search entered.";
            return;
        }

        string search = query.ToLower();

        var items = await _db.StockItems.ToListAsync();

        foreach (var item in items)
        {
            if (item.ItemTitle.ToLower().Contains(search) ||
                item.Barcode.ToLower().Contains(search) ||
                item.BrandOrSupplier.ToLower().Contains(search) ||
                item.Department.ToLower().Contains(search))
            {
                Results.Add(item);
            }
        }

        Message = $"Found {Results.Count} matching product(s).";
    }
}