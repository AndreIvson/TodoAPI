namespace TodoAPI.Models
{
    public class TodoItemsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Boolean IsComplete { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
