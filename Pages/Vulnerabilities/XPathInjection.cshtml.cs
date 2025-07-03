using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Xml.XPath;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class XPathInjectionModel : PageModel
    {
        public List<string> Usernames { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public void OnPost(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return;
            }

            var xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "users.xml");
            var doc = new XPathDocument(xmlPath);
            var nav = doc.CreateNavigator();

            // Vulnerable code: directly concatenating user input into the XPath query
            var query = $"/users/user[name='{username}']/name";
            
            try
            {
                var iterator = nav.Select(query);
                while (iterator.MoveNext())
                {
                    if (iterator.Current != null)
                    {
                        Usernames.Add(iterator.Current.Value);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
