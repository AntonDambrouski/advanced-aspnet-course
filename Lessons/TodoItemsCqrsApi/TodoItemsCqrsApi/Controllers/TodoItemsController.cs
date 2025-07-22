using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoItemsCqrsApi.Commands;
using TodoItemsCqrsApi.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoItemsCqrsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController(IMediator mediator) : ControllerBase
    {
        // GET: api/<TodoItemsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await mediator.Send(new GetAllTodoItemsQuery());
            return Ok(items);
        }

        // GET api/<TodoItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await mediator.Send(new GetTodoItemByIdQuery(id));
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST api/<TodoItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTodoItemCommand command, CancellationToken token)
        {
            var id = await mediator.Send(command, token);
            return Created($"api/todoitems/{id}",
                null);
        }

        // PUT api/<TodoItemsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTodoItemCommand command, CancellationToken token)
        {
            if (id != command.Id)
            {
                return BadRequest("Id mismatch");
            }

            try
            {
                await mediator.Send(command, token);
            }
            catch (ArgumentNullException)
            {
                return NotFound("Item not found");
            }
            

            return NoContent();
        }

        // DELETE api/<TodoItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await mediator.Send(new DeleteTodoItemCommand(id));
            if (deleted)
            {
                return Ok("Item successfully deleted");
            }

            return BadRequest($"Unable to delete item with id: {id}");
        }
    }
}
