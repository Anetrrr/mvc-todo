using TodoApp.Models;

namespace TodoApp.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Insert(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
