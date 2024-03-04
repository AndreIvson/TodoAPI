using TodoAPI.Entities;


namespace TodoAPI.Repository.Interface
{
    public interface ITodoItemsRepository
    {
        // Using IEnumerable<Tag> instead of List<Tag>, search for Interfaces vs concrete classes, suggested AI prompt: which are the benefits of using interfaces over concrete classes in lists using c#?
        Task<IEnumerable<TodoItem>> GetAllTodoItems();
        Task<TodoItem?> GetById(int id);

        //Readability: renaming from Post to Create, nothing wrong with the name in particular, but POST, PUT etc are HTTP Methods specific.
        Task<TodoItem?> Create(TodoItem todo);
        Task<TodoItem?> Update(TodoItem todoItems, int id);
        Task<bool> Delete(int id);
    }
}
