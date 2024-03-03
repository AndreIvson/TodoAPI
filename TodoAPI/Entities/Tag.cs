namespace TodoAPI.Entities
{
    /*
      Suggestion: it's not required prefix properties with the class name:  TagId = Id, TagName = Name 
     */
    public class Tag
    {
        public Tag(string name) 
        {
            Name = name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public IEnumerable<TodoItem> TodoItems { get; set; }
    }
}
