using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshMartPortal.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Username { get; set; } = "";

    [BindProperty]
    public string Password { get; set; } = "";

    public string ErrorMessage { get; set; } = "";

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (Username == "admin" && Password == "admin123")
        {
            HttpContext.Session.SetString("UserLoggedIn", "true");
            HttpContext.Session.SetString("Username", Username);

            return RedirectToPage("/Dashboard/Stats");
        }

        ErrorMessage = "Invalid username or password.";
        return Page();
    }
}