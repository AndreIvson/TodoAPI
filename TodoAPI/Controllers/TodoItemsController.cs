using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;
using TodoAPI.Repository.Interface;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemsRepository _todoItemsRepository;
        public TodoItemsController(ITodoItemsRepository todoItemsRepository)
        {
            _todoItemsRepository = todoItemsRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<TodoItemsModel>>> GetAllTodoItems() 
        {
            List<TodoItemsModel> todoItems = await _todoItemsRepository.GetAllTodoItems();

            if (todoItems == null || todoItems.Count == 0)
            {
                return NotFound($"Nenhum registro encontrado no banco de dados.");
            }

            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemsModel>> GetById(int id)
        {
            TodoItemsModel todoItems = await _todoItemsRepository.GetById(id);

            if(todoItems == null) 
            {
                return NotFound($"O item com o ID:{id} não foi encontrada no banco de dados.");
            }

            return Ok(todoItems);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemsDTO>> Post([FromBody] TodoItemsDTO todo)
        {
            TodoItemsModel todoItemsModel = await _todoItemsRepository.Post(todo);
            return Ok(todoItemsModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItemsModel>> Put([FromBody] TodoItemsModel todoItemsModel, int id)
        {
            todoItemsModel.Id = id;
            TodoItemsModel todoItems = await _todoItemsRepository.Put(todoItemsModel, id);

            if (todoItems == null)
            {
                return NotFound($"O item com o ID:{id} não foi encontrado no banco de dados.");
            }

            return Ok(todoItems);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItemsModel>> Delete(int id)
        {
            bool deleted = await _todoItemsRepository.Delete(id);

            if (!deleted) 
            {
                return NotFound($"O item com o ID:{id} não foi encontrada no banco de dados.");
            }
            return NoContent();
        }

    }
}
