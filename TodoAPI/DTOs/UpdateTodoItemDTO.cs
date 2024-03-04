using System.ComponentModel.DataAnnotations;
using TodoAPI.Entities;

namespace TodoAPI.DTOs
{
    public class UpdateTodoItemDTO
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(800, MinimumLength = 5)]
        public string Content { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();

        public TodoItem ToEntity(int id)
        {
            var entity = new TodoItem(id, this.Title, this.Content, this.IsCompleted);
            
            foreach(var tagName in Tags)
            {
                entity.AddTag(new Tag(tagName));
            }

            return entity;
        }
    }
}
