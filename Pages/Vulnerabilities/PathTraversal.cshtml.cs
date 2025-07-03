using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class PathTraversalModel : PageModel
    {
        public string FileContent { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }

        public void OnGet(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                return;
            }

            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            var filePath = Path.Combine(basePath, file);

            try
            {
                // Vulnerable code: directly using user input to construct a file path
                if (System.IO.File.Exists(filePath))
                {
                    FileContent = System.IO.File.ReadAllText(filePath);
                }
                else
                {
                    ErrorMessage = "File not found.";
                }
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
