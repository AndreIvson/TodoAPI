using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoAPI.Models
{
    public class TodoItemsModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }

        [Required]
        [StringLength (800, MinimumLength = 5)]
        public string? Content { get; set; }

        public bool? IsComplete { get; set; } = false;

        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }

        public object ModeloPost()
        {
            return new
            {
                Title,
                Content   
            };
        }

        public object ModeloPut()
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
