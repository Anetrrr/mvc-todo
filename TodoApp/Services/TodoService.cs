using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public IEnumerable<TodoItem> GetTodos()
        {
            return _repository.GetAll();
        }

        public TodoItem InsertTodo(CreateTodoViewModel model)
        {
            var todoItem = new TodoItem();
            todoItem.Status = Status.Created;
            todoItem.Description = model.Description;

            var result = _repository.Insert(todoItem);
            if (result.Id > 0)
            {
                return result;
            }
            return new TodoItem();
        }

        public TodoItem GetOneTodo(int? id)
        {
            var entity = _repository.GetById(id);
            return entity;
        }

        public void DeleteTodo(int id)
        {
            var entity = _repository.GetById(id) as TodoItem;
            if (entity != null)
            {
                _repository.Delete(entity.Id);
                
            }
        }
        public void UpdateTodo(TodoItem model)
        {
            try
            {
                var entity = _repository.GetById(model.Id);
                if (entity != null)
                {
                    entity.Description = model.Description;
                    entity.Status = model.Status;

                    _repository.Update(entity);
                    
                }

               
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured. Update failed");

            }
        }

      
    } 

    public interface ITodoService
    {
        IEnumerable<TodoItem> GetTodos();
        TodoItem InsertTodo(CreateTodoViewModel model);

        TodoItem GetOneTodo(int? id);

        void DeleteTodo(int id);

        void UpdateTodo(TodoItem model);



    }
}
