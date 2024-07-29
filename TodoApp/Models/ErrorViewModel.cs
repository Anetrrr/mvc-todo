namespace TodoApp.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class TodoItemViewModel
    {
        public Dictionary<int, TodoItem> Items { get; set; }
    }
}
