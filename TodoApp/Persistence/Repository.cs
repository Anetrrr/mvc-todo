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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
