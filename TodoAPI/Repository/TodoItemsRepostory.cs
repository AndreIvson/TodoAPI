using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Entities;
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
        public async Task<IEnumerable<TodoItem>> GetAllTodoItems()
        {
            List<TodoItem> todoItems = await _dbContext.TodoItems
                .Include(item => item.Tags)
                .OrderBy(x => x.Id)
                .ToListAsync();

            return todoItems;
        }

        public async Task<TodoItem?> GetById(int id)
        {
            TodoItem? todoItem = await _dbContext.TodoItems
                .Include(item => item.Tags)
                .FirstOrDefaultAsync(item => item.Id == id);

            return todoItem;
        }

        public async Task<TodoItem?> Create(TodoItem todoItem)
        {
            await _dbContext.TodoItems.AddAsync(todoItem);
            await _dbContext.SaveChangesAsync();
            return todoItem;
        }

        public async Task<TodoItem?> Update(TodoItem todoItems, int id)
        {
            TodoItem? todoItemsById = await _dbContext
                                                .TodoItems
                                                .Include(t => t.Tags)
                                                .FirstOrDefaultAsync(t => t.Id == id);

            // since c# 9, comparing "null" can be done using "is".
            if (todoItemsById is null)
            {
                return null;
            }

            todoItemsById.Title = todoItems.Title;
            todoItemsById.Content = todoItems.Content;
            todoItemsById.IsCompleted = todoItems.IsCompleted;

            foreach (var tag in todoItems.Tags)
            {
                bool tagAlreadyExists = todoItemsById.Tags.Contains(tag);

                if (!tagAlreadyExists)
                {
                    todoItemsById.AddTag(tag);
                }
            }

            _dbContext.TodoItems.Update(todoItemsById);
            await _dbContext.SaveChangesAsync();

            return todoItemsById;
        }

        public async Task<bool> Delete(int id)
        {
            TodoItem? todoItemsById = await _dbContext.TodoItems.FindAsync(id);

            if (todoItemsById is not null)
            {
                //Cascade delete of Tags configured on TodoItemsMap
                _dbContext.TodoItems.Remove(todoItemsById);

                try
                {
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"Erro ao excluir o item: {ex.Message}");
                }
            }

            return false;
        }
    }
}
