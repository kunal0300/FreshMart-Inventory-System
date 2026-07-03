using FreshMartPortal.Data;
using FreshMartPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshMartPortal.Pages.Inventory;

public class RemoveModel : PageModel
{
    private readonly StoreDbContext _db;

    public RemoveModel(StoreDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public StockItem Entry { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var item = await _db.StockItems.FindAsync(id);

        if (item == null)
        {
            return RedirectToPage("/Inventory/List");
        }

        Entry = item;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var item = await _db.StockItems.FindAsync(Entry.StockItemId);

        if (item != null)
        {
            _db.StockItems.Remove(item);
            await _db.SaveChangesAsync();
        }

        return RedirectToPage("/Inventory/List");
    }
}