using FreshMartPortal.Data;
using FreshMartPortal.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreshMartPortal.Pages.Inventory;

public class ListModel : PageModel
{
    private readonly StoreDbContext _db;
    public ListModel(StoreDbContext db) => _db = db;

    public List<StockItem> Items { get; set; } = new();

    public async Task OnGetAsync()
    {
        Items = await _db.StockItems.OrderBy(x => x.ItemTitle).ToListAsync();
    }
}
