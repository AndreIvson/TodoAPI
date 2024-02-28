using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoAPI.Models
{
    public class TodoItemsDTO
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }

        [Required]
        [StringLength(800, MinimumLength = 5)]
        public string? Content { get; set; }
    }
    public class TodoItemsModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }
        [Required]
        [StringLength(800, MinimumLength = 5)]
        public string? Content { get; set; }
        public bool IsCompleted { get; set; } = false;
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
    public class Tag
    {
        [JsonIgnore]
        public int TagId { get; set; }
        [StringLength(30, MinimumLength = 1)]
        public string? TagName { get; set; }
    }
}
