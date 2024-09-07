using Azure;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TodoApp.Models;

namespace TodoApp.Persistence
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private readonly TodoAppContext _context;
        public Repository(TodoAppContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            try
            {
                var data = _context.Set<T>().Find(id);
                if (data != null)
                {
                    _context.Remove(data);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured. Delete not successful");
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }

        public T GetById(int? id)
        {
            try
            {
                var todo = _context.Set<T>().Find(id);

                if (todo == null)
                {
                    throw new Exception($"Item with id {id} not found");
                }
                return todo;
            }

            catch (Exception ex)
            {
                throw new Exception("Error occured");
            }
        }

        public T Insert(T obj)
        {
            try
            {
                _context.Set<T>().Add(obj);
                _context.SaveChanges();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
        }



        public void Update(T obj)
        {
            try
            {
                // Extract the ID from the object (assuming the ID property is named 'Id')
                var idProperty = typeof(T).GetProperty("Id");

                if (idProperty == null)
                {
                    throw new Exception("ID property not found in the object.");
                }

                var idValue = idProperty.GetValue(obj);

                if (idValue == null)
                {
                    throw new Exception("ID cannot be null.");
                }

                var entity = _context.Set<T>().Find(idValue);

                if (entity == null)
                {
                    throw new Exception("Entity with the given ID not found");
                }

                // Update entity's properties with obj's values
                _context.Entry(entity).CurrentValues.SetValues(obj);

                // Save changes
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                // Throw a more informative exception while preserving the original exception details
                throw new Exception("An error occurred. Update not successful", ex);
            }
        }

       
    }
}
