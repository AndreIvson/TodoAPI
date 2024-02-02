using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Models;
using TodoAPI.Repository.Interface;

namespace TodoAPI.Repository
{
    public class TodoItemsRepostory : ITodoItemsRepository
    {
        private readonly TodoItemDbContext _dbContext;
        public TodoItemsRepostory(TodoItemDbContext todoItemDbContext)
        {
            _dbContext = todoItemDbContext;
        }
        public async Task<List<TodoItemsModel>> GetAllTodoItems()
        {
            List<TodoItemsModel> todoItems = await _dbContext.TodoItems.OrderBy(x => x.Id).ToListAsync();
            return todoItems;
        }

        public async Task<TodoItemsModel> GetById(int id)
        {
            TodoItemsModel todoItem = await _dbContext.TodoItems.FindAsync(id);

            return todoItem;
        }

        public async Task<TodoItemsModel> Post(TodoItemsModel todoItems)
        {
            await _dbContext.TodoItems.AddAsync(todoItems);
            await _dbContext.SaveChangesAsync();

            return todoItems;
        }

        public async Task<TodoItemsModel> Put(TodoItemsModel todoItems, int id)
        {

            TodoItemsModel todoItemsById = await _dbContext.TodoItems.FindAsync(id);

            if (todoItemsById == null)
            {
                return null;
            }

            todoItemsById.Title = todoItems.Title;
            todoItemsById.Content = todoItems.Content;
            todoItemsById.IsComplete = todoItems.IsComplete;

            _dbContext.TodoItems.Update(todoItemsById);
            await _dbContext.SaveChangesAsync();

            return todoItemsById;
        }
        public async Task<bool> Delete(int id)
        {
            TodoItemsModel todoItemsById = await _dbContext.TodoItems.FindAsync(id);

            if (todoItemsById == null)
            {
                return false;
            }

            _dbContext.TodoItems.Remove(todoItemsById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
