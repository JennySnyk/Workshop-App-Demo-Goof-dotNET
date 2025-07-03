using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class UnvalidatedRedirectModel : PageModel
    {
        public IActionResult OnGet(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                return Page();
            }

            // Vulnerable code: redirecting to a user-provided URL without validation
            return Redirect(returnUrl);
        }
    }
}
