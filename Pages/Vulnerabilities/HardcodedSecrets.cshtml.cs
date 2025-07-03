using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class HardcodedSecretsModel : PageModel
    {
        // Vulnerable code: hardcoded secret
        private const string ApiKey = "sk_live_1234567890abcdefghijklmnopqrstuvwxyz";
        
        public string RevealedApiKey { get; set; } = string.Empty;
        
        public void OnGet()
        {
            RevealedApiKey = ApiKey;
        }
    }
}
