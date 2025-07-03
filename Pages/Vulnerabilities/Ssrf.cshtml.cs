using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class SsrfModel : PageModel
    {
        public string UrlContent { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }

        public async Task OnPostAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return;
            }

            try
            {
                // Vulnerable code: making a request to a user-provided URL without validation
                using (var client = new HttpClient())
                {
                    UrlContent = await client.GetStringAsync(url);
                }
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
