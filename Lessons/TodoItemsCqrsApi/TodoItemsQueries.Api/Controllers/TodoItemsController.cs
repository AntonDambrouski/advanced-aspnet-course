using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoItemsCqrsApi.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoItemsQueries.Api.Controllers
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
    }
}
