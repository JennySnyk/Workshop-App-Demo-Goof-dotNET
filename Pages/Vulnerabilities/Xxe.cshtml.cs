using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;
using System.IO;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class XxeModel : PageModel
    {
        [BindProperty]
        public string XmlContent { get; set; }
        public string ParsedResult { get; set; }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(XmlContent))
            {
                try
                {
                    // VULNERABLE: DtdProcessing is enabled, allowing XXE
                    var settings = new XmlReaderSettings()
                    {
                        DtdProcessing = DtdProcessing.Parse, // This is the vulnerability
                        MaxCharactersFromEntities = 1024
                    };

                    using (var stringReader = new StringReader(XmlContent))
                    using (var xmlReader = XmlReader.Create(stringReader, settings))
                    {
                        var document = new XmlDocument();
                        document.Load(xmlReader);
                        ParsedResult = document.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    ParsedResult = $"Error parsing XML: {ex.Message}";
                }
            }
            else
            {
                ParsedResult = "Please provide XML content to parse.";
            }
        }
    }
}
