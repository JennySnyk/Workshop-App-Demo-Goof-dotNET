using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Microsoft.AspNetCore.Http;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class InsecureRandomModel : PageModel
    {
        public string ResetToken { get; set; }

        public void OnGet()
        {
            // VULNERABLE: System.Random is not cryptographically secure and should not be used for generating security-sensitive tokens.
            var random = new Random();
            var tokenValue = random.Next(100000, 999999);
            ResetToken = tokenValue.ToString("D6");

            // Using the weak token in a security-sensitive context (cookie)
            Response.Cookies.Append("SessionToken", ResetToken, new CookieOptions { HttpOnly = true });
        }
    }
}

