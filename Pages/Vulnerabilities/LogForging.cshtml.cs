using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class LogForgingModel : PageModel
    {
        private readonly ILogger<LogForgingModel> _logger;
        public string Message { get; set; } = string.Empty;

        public LogForgingModel(ILogger<LogForgingModel> logger)
        {
            _logger = logger;
        }

        public void OnPost(string logMessage)
        {
            if (string.IsNullOrEmpty(logMessage))
            {
                return;
            }

            // Vulnerable code: writing user input directly to the log
            _logger.LogInformation(logMessage);
            Message = $"Logged: {logMessage}";
        }
    }
}
