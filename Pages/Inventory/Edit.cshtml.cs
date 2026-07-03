using FreshMartPortal.Data;
using FreshMartPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshMartPortal.Pages.Inventory;

public class EditModel : PageModel
{
    private readonly StoreDbContext _db;

    public EditModel(StoreDbContext db)
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
        if (Entry.UnitsAvailable <= 0)
        {
            Entry.AvailabilityStatus = "Out of Stock";
        }
        else if (Entry.UnitsAvailable <= Entry.ReorderPoint)
        {
            Entry.AvailabilityStatus = "Low Stock";
        }
        else
        {
            Entry.AvailabilityStatus = "Available";
        }

        _db.StockItems.Update(Entry);
        await _db.SaveChangesAsync();

        return RedirectToPage("/Inventory/List");
    }
}