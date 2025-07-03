using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Workshop_App_Demo_Goof_dotNET.Models;
using Workshop_App_Demo_Goof_dotNET.Services;

namespace Workshop_App_Demo_Goof_dotNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TodoService _todoService;

        public IndexModel(TodoService todoService)
        {
            _todoService = todoService;
        }

        public IList<Todo> Todos { get; set; } = new List<Todo>();

        [BindProperty]
        public Todo NewTodo { get; set; } = new Todo();

        public void OnGet()
        {
            Todos = _todoService.GetAll();
        }

        public JsonResult OnPost()
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(NewTodo.Text))
            {
                return new JsonResult(new { success = false, message = "Invalid input" });
            }

            _todoService.Add(NewTodo);
            return new JsonResult(NewTodo);
        }

        public JsonResult OnPostDelete(int id)
        {
            _todoService.Delete(id);
            return new JsonResult(new { success = true });
        }
    }
}
