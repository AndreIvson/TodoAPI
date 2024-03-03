using Microsoft.AspNetCore.Mvc;
using TodoAPI.DTOs;
using TodoAPI.Repository.Interface;
using TodoAPI.Entities;

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
        public async Task<ActionResult<IEnumerable<TodoItemResponseDTO>>> GetAllTodoItems() 
        {
            IEnumerable<TodoItem> todoItems = await _todoItemsRepository.GetAllTodoItems();
            IEnumerable<TodoItemResponseDTO> todoItemsDTO = todoItems.Select(t => new TodoItemResponseDTO(t));

            if (!todoItemsDTO.Any())
            {
                return NotFound($"Nenhum registro encontrado no banco de dados.");
            }

            return Ok(todoItemsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemResponseDTO>> GetById(int id)
        {
            TodoItem? todoItem = await _todoItemsRepository.GetById(id);

            if(todoItem is null) 
            {
                return NotFound($"O item com o ID:{id} não foi encontrada no banco de dados.");
            }

            return Ok(new TodoItemResponseDTO(todoItem));
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemResponseDTO>> Post([FromBody] CreateTodoItemDTO todoItem)
        {
            TodoItem? todoEntity = todoItem.ToEntity();
            _ = await _todoItemsRepository.Create(todoEntity);
            return Ok(new TodoItemResponseDTO(todoEntity));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItemResponseDTO>> Put([FromRoute] int id, [FromBody] UpdateTodoItemDTO todoItem)
        {
            var todoEntity = todoItem.ToEntity(id);
            _ = await _todoItemsRepository.Update(todoEntity, id);

            if (todoItem is null)
            {
                return NotFound($"O item com o ID:{id} não foi encontrado no banco de dados.");
            }

            return Ok(new TodoItemResponseDTO(todoEntity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
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
