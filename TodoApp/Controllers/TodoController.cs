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
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
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
        
            return View(model);
            
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult GetOneTodo(int id)
        {
            var entity = _todoService.GetOneTodo(id);

            return View("Update", entity);    

        }

        
        [HttpPut, ValidateAntiForgeryToken]
        public IActionResult Update(TodoItem model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
             _todoService.UpdateTodo(model);
                return RedirectToAction("GetTodos");
           
        }

        [HttpDelete, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            _todoService.DeleteTodo(id);
            return RedirectToAction("GetTodos");
        }

       
    }
}

