using FreshMartPortal.Data;
using FreshMartPortal.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreshMartPortal.Pages.Vendors;

public class ListModel : PageModel
{
    private readonly StoreDbContext _db;

    public ListModel(StoreDbContext db)
    {
        _db = db;
    }

    public List<VendorProfile> Vendors { get; set; } = new();

    public async Task OnGetAsync()
    {
        Vendors = await _db.VendorProfiles.ToListAsync();
    }
}