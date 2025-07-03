using Workshop_App_Demo_Goof_dotNET.Models;
using System.Collections.Generic;
using System.Linq;

namespace Workshop_App_Demo_Goof_dotNET.Services
{
    public class TodoService
    {
        private readonly List<Todo> _todos = new List<Todo>();
        private int _nextId = 1;

        public TodoService()
        {
            // Pre-populate with some data
            Add(new Todo { Text = "Set up the security demo" });
            Add(new Todo { Text = "Add a dozen SCA vulnerabilities" });
            Add(new Todo { Text = "Add a dozen SAST vulnerabilities" });
        }

        public List<Todo> GetAll() => _todos;

        public void Add(Todo todo)
        {
            todo.Id = _nextId++;
            _todos.Add(todo);
        }

        public void Delete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _todos.Remove(todo);
            }
        }
    }
}
