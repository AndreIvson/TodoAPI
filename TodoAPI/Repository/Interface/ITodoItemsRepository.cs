using TodoAPI.Models;

namespace TodoAPI.Repository.Interface
{
    public interface ITodoItemsRepository
    {
        Task<List<TodoItemsModel>> GetAllTodoItems();
        Task<TodoItemsModel> GetById(int id);
        Task<TodoItemsModel> Post(TodoItemsModel todoItems);
        Task<TodoItemsModel> Put(TodoItemsModel todoItems, int id);
        Task<bool> Delete(int id);
    }
}
