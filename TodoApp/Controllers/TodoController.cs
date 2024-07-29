using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
using TodoApp.Models;
using TodoApp.Persistence;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        //public Dictionary <int, TodoItem> Items { get; set; }
        private readonly IGenericRepository<TodoItem> _repo;
        private readonly ITodoService _todoService;

        public TodoController(IGenericRepository<TodoItem> repo, ITodoService todoService)
        {
            _repo = repo;
            _todoService = todoService;
        }
        public IActionResult Index()
        {
            var items = _todoService.GetTodos();
            ViewData["Items"] = items;
            return View(items);
        }
        public IActionResult CreateTodo()
        {
            //var item = new TodoItemViewModel { Items = Items };
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateTodo(CreateTodoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createdEntity = _todoService.InsertTodo(model);
                if (createdEntity != null) {
                    ViewData["Items"] = createdEntity;
                
                    return RedirectToAction(nameof(Index));
                }

            }
           
            //var item = new TodoItemViewModel { Items = Items };
            return View(model);
        }
    }
}
