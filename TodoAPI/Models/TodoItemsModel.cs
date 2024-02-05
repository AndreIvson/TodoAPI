using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    public class TodoItemsModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }

        [Required]
        [StringLength (800, MinimumLength = 5)]
        public string? Content { get; set; }

        public bool? IsComplete { get; set; } = false;

        public DateTime? CreatedAt { get; set; }

        public object Modelo()
        {
            return new
            {
                Title,
                Content,
                IsComplete
            };
        }
    }
}
