using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class SstiModel : PageModel
    {
        [BindProperty]
        public string Template { get; set; }
        public string RenderedResult { get; set; }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(Template))
            {
                try
                {
                    // VULNERABLE: A simple, custom template engine that replaces {{...}} with evaluated content.
                    // This is a naive implementation susceptible to injection.
                    // A payload like {{ System.Diagnostics.Process.Start("open", "-a Calculator") }} could execute code.
                    var user = new { Name = "Guest", IsAdmin = false };
                    RenderedResult = Regex.Replace(Template, @"{{(.*?)}}", match =>
                    {
                        var code = match.Groups[1].Value.Trim();
                        // A real SSTI vulnerability is often more complex, but this simulates the core issue.
                        // For this demo, we'll just reflect the code back.
                        // In a real, more powerful (and dangerous) engine, this could be evaluated.
                        if (code.ToLower().Contains("system.diagnostics"))
                        {
                            return "SYSTEM COMMAND DETECTED";
                        }
                        return $"EVALUATED: {code}";
                    });
                }
                catch (System.Exception ex)
                {
                    RenderedResult = $"Error: {ex.Message}";
                }
            }
            else
            {
                RenderedResult = "Please provide a template.";
            }
        }
    }
}
