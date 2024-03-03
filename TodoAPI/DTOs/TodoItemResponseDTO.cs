using TodoAPI.Entities;

namespace TodoAPI.DTOs
{
    public class TodoItemResponseDTO
    {

        public TodoItemResponseDTO(TodoItem todoItem)
        {
            Id = todoItem.Id;
            Title = todoItem.Title;
            Content = todoItem.Content;
            IsCompleted = todoItem.IsCompleted;
            CreatedAt = todoItem.CreatedAt;
            Tags = todoItem.Tags.Select(tag => tag.Name!);
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public IEnumerable<string> Tags { get; set; } = new List<string>();
    }
}
