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
            catch (Exception ex) { 
                return Enumerable.Empty<T>();
            }
        }

        public T GetById(int id)
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
            catch (Exception ex) {
                return obj;
            }
        }



        public void Update(T obj)
        {
            try
            {
                _context.Set<T>().Update(obj);
                _context.SaveChanges();
                
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured. Update not successful");
            }
        }
    }
}
