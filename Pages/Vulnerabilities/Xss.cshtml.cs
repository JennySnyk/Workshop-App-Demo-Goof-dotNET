using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class XssModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Query { get; set; } = string.Empty;

        public void OnGet()
        {
        }
    }
}
