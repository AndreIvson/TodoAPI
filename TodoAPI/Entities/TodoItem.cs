namespace TodoAPI.Entities
{
    /*
       Changing class name from "TodoItems" to "TodoItem" pluralization since this class represents only 1 todo item.
       Removing Model postfix, this class represents an "Entity" in DDD
       Removing [JsonIgnore] attribute and other validations, validation responsibility will be transfered to the TodoItemsDTO class.
       Using IEnumerable<Tag> instead of List<Tag>, search for Interfaces vs concrete classes, suggested AI prompt: which are the benefits of using interfaces over concrete classes in lists using c#?
       Property CreatedAt can be considered as required, there's no way a Todo Item can be created without this information.       
    */

    public class TodoItem
    {
        private readonly List<Tag> _tags;

        public TodoItem() 
        {
            Title = string.Empty;
            Content = string.Empty;
            _tags = new List<Tag>();
            CreatedAt = DateTime.UtcNow;
        }

        public TodoItem(int id, string title, string content, bool isCompleted) : this() 
        {
            Id = id;
            Title = title;
            Content = content;
            IsCompleted = isCompleted;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; private set; }
        public IEnumerable<Tag> Tags { get { return _tags; } }


        // Add behaviour, Tags belong to a TodoItem, so it make sense to have a method to AddTag in the TodoItem class.
        public void AddTag(Tag tag)
        {
            _tags.Add(tag);
        }
    }
}
