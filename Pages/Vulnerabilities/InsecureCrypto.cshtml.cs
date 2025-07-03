using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class InsecureCryptoModel : PageModel
    {
        public string HashedPassword { get; set; } = string.Empty;

        public void OnPost(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return;
            }

            // Vulnerable code: using a weak hashing algorithm (MD5)
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                HashedPassword = BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
