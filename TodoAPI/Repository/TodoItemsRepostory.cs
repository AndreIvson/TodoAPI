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
            List<TodoItemsModel> todoItems = await _dbContext.TodoItems
                .Include(item => item.Tags)
                .OrderBy(x => x.Id)
                .ToListAsync();

            return todoItems;
        }

        public async Task<TodoItemsModel> GetById(int id)
        {
            TodoItemsModel todoItem = await _dbContext.TodoItems
                .Include(item => item.Tags)
                .FirstOrDefaultAsync(item => item.Id == id);

            return todoItem;
        }

        public async Task<TodoItemsModel> Post(TodoItemsDTO todo)
        {
            TodoItemsModel todoModel = new TodoItemsModel
            {
                Title = todo.Title,
                Content = todo.Content,
            };

            await _dbContext.TodoItems.AddAsync(todoModel);
            await _dbContext.SaveChangesAsync();

            return todoModel;
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
            todoItemsById.IsCompleted = todoItems.IsCompleted;

            todoItemsById.Tags.Clear();

            foreach (var tag in todoItems.Tags)
            {
                Tag existingTag = _dbContext.Set<Tag>().FirstOrDefault(t => t.TagName == tag.TagName);

                if (existingTag != null)
                {
                    todoItemsById.Tags.Add(existingTag);
                }
                else
                {
                    todoItemsById.Tags.Add(new Tag { TagName = tag.TagName });
                }
            }

            _dbContext.TodoItems.Update(todoItemsById);
            await _dbContext.SaveChangesAsync();

            return todoItemsById;
        }
        public async Task<bool> Delete(int id)
        {
            TodoItemsModel todoItemsById = await _dbContext.TodoItems
                                                        .Include(t => t.Tags)
                                                        .FirstOrDefaultAsync(t => t.Id == id);

            if (todoItemsById == null)
            {
                return false;
            }

            todoItemsById.Tags.Clear();

            _dbContext.TodoItems.Remove(todoItemsById);

            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Erro ao excluir o item: {ex.Message}");
                return false;
            }
        }

    }
}
