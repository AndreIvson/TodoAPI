using System.ComponentModel.DataAnnotations;
using TodoAPI.Entities;

namespace TodoAPI.DTOs
{
    public class CreateTodoItemDTO
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(800, MinimumLength = 5)]
        public string Content { get; set; } = string.Empty;

        public TodoItem ToEntity()
        {
            return new TodoItem(id: default, title: Title, content: Content, isCompleted: false);
        }
    }
}
