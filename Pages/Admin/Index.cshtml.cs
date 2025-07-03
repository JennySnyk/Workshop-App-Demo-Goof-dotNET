using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Admin
{
    // VULNERABLE: This page is not protected by any authorization mechanism.
    // It should have an [Authorize(Roles = "Admin")] attribute.
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
