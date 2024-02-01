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
            return await _dbContext.TodoItems.ToListAsync();
        }

        public async Task<TodoItemsModel> GetById(int id)
        {
            return await _dbContext.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TodoItemsModel> Post(TodoItemsModel todoItems)
        {
            await _dbContext.TodoItems.AddAsync(todoItems);
            await _dbContext.SaveChangesAsync();

            return todoItems;
        }

        public async Task<TodoItemsModel> Put(TodoItemsModel todoItems, int id)
        {
            TodoItemsModel todoItemsById = await GetById(id);

            if(todoItemsById == null) 
            {
                throw new Exception($"Lista de tarefas para o ID:{id} não foi encontrada no banco de dados.");
            }

            todoItemsById.Name = todoItems.Name;
            todoItemsById.IsComplete = todoItems.IsComplete;

            _dbContext.TodoItems.Update(todoItemsById);
            await _dbContext.SaveChangesAsync();

            return todoItemsById;
        }
        public async Task<bool> Delete(int id)
        {
            TodoItemsModel todoItemsById = await GetById(id);

            if (todoItemsById == null)
            {
                throw new Exception($"Lista de tarefas para o ID:{id} não foi encontrada no banco de dados.");
            }

            _dbContext.TodoItems.Remove(todoItemsById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
