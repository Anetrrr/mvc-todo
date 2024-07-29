using TodoApp.Models;
using TodoApp.Persistence;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private IGenericRepository<TodoItem> _repository;
        public TodoService(IGenericRepository<TodoItem> repository)
        {
            _repository = repository;
        }
        public TodoItem InsertTodo(CreateTodoViewModel model)
        {
            var todoItem = new TodoItem();
            todoItem.Status=Status.Created;
            todoItem.Description = model.Description;

            var result = _repository.Insert(todoItem);
            if(result.Id > 0)
            {
                return result;
            }
            return new TodoItem();
        }
    }

    public interface ITodoService
    {
        TodoItem InsertTodo(CreateTodoViewModel model);

    }
}
