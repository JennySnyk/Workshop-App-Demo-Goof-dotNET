using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Text;
using Workshop_App_Demo_Goof_dotNET.Models;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class InsecureDeserializationModel : PageModel
    {
        public string DeserializedName { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }

        public void OnPost(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return;
            }

            try
            {
                var decodedData = Encoding.UTF8.GetString(Convert.FromBase64String(data));
                
                // Vulnerable code: Deserializing user input with dangerous settings
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                var user = JsonConvert.DeserializeObject<UserData>(decodedData, settings);

                DeserializedName = user?.Name ?? string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
