using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace Workshop_App_Demo_Goof_dotNET.Pages.Vulnerabilities
{
    public class SqliModel : PageModel
    {
        public List<string> Usernames { get; set; } = new List<string>();
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            // Setup an in-memory SQLite database for the demo
            using (var connection = new SqliteConnection("Data Source=:memory:"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    CREATE TABLE users (id INTEGER PRIMARY KEY, username TEXT NOT NULL);
                    INSERT INTO users (username) VALUES ('admin'), ('user1'), ('user2');
                ";
                command.ExecuteNonQuery();
            }
        }

        public void OnPost(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return;
            }

            // Vulnerable code: directly concatenating user input into the SQL query
            using (var connection = new SqliteConnection("Data Source=:memory:"))
            {
                connection.Open();

                // Re-create the table and data for each request to simulate a persistent DB
                var setupCommand = connection.CreateCommand();
                setupCommand.CommandText =
                @"
                    CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, username TEXT NOT NULL);
                    INSERT INTO users (username) VALUES ('admin'), ('user1'), ('user2') ON CONFLICT(username) DO NOTHING;
                ";
                setupCommand.ExecuteNonQuery();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT username FROM users WHERE username = '" + username + "'";

                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usernames.Add(reader.GetString(0));
                        }
                    }
                }
                catch (SqliteException ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
        }
    }
}
