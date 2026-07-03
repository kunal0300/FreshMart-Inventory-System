using FreshMartPortal.Data;
using FreshMartPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshMartPortal.Pages.Vendors;

public class NewModel : PageModel
{
    private readonly StoreDbContext _db;

    public NewModel(StoreDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public VendorProfile Vendor { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        _db.VendorProfiles.Add(Vendor);
        await _db.SaveChangesAsync();

        return RedirectToPage("/Vendors/List");
    }
}