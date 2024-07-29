
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class TodoItem : Base
    {
        
        public string Description { get; set; }
        public Status Status { get; set; }
       
    }
    public class TodoItem2 : Base
    {

        public string Description { get; set; }
        public Status Status { get; set; }

    }
    public enum Status
    {
        Created = 1,
        Started,
        Completed,
    }

    // For generic properties
    public class Base
    {
        public Base()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
            IsActive = true;

        }
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }

    public class CreateTodoViewModel
    {
        [MinLength(3)]
        [MaxLength(1000)]
        public string Description { get; set; }
    }

}

  
