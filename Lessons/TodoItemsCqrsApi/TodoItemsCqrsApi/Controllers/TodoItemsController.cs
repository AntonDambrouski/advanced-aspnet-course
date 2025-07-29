using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoItemsCqrsApi.Commands;

namespace TodoItemsCqrsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTodoItemCommand command, CancellationToken token)
        {
            var id = await mediator.Send(command, token);
            return Created($"api/todoitems/{id}",
                null);
        }

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
