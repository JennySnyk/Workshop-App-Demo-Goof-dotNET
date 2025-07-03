using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class ApiKeyModel : PageModel
    {
        public string ApiKey { get; private set; }

        public void OnGet()
        {
            // VULNERABLE: A hardcoded API key.
            ApiKey = "AIzaSyA...THIS_IS_A_FAKE_KEY...w-4sI";
        }
    }
}
