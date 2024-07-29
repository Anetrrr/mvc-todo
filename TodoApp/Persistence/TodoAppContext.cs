using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using TodoApp.Models;

namespace TodoApp.Persistence
{
    public class TodoAppContext : DbContext
    {
        public TodoAppContext(DbContextOptions options)
            :base(options)
        {
            
        }
        DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<TodoItem>()
                .HasData(new TodoItem { Id = 1, Description = "default todo", Status=Status.Created });

            base.OnModelCreating(modelBuilder);
        }
    }
}
