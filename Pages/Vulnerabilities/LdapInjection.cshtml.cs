using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.DirectoryServices.Protocols;
using System.Net;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class LdapInjectionModel : PageModel
    {
        public string Message { get; set; } = string.Empty;

        public void OnPost(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return;
            }

            // This is a mock implementation and will not connect to a real LDAP server.
            // It demonstrates the vulnerable code pattern.
            try
            {
                using (var connection = new LdapConnection(new LdapDirectoryIdentifier("localhost")))
                {
                    // Vulnerable code: directly concatenating user input into the LDAP filter
                    var filter = $"(uid={username})";
                    var request = new SearchRequest("dc=example,dc=com", filter, SearchScope.Subtree, null);
                    
                    // The following line would throw an exception because there's no server.
                    // var response = (SearchResponse)connection.SendRequest(request);
                    
                    Message = $"Successfully created LDAP query with filter: {filter}. In a real scenario, this would be sent to the server.";
                }
            }
            catch (LdapException ex)
            {
                Message = $"LDAP Exception (expected in this demo): {ex.Message}";
            }
            catch (System.Exception ex)
            {
                Message = $"An unexpected error occurred: {ex.Message}";
            }
        }
    }
}
