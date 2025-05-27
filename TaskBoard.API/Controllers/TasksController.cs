using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Queries;
using TaskBoard.Application.Tasks.Commands;
using TaskBoard.Domain.Entities;

namespace TaskBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAll()
        {
            var tasks = await _mediator.Send(new GetAllTasksQuery());
            return Ok(tasks);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TaskItem>> GetById(Guid id)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery(id));
            if (task == null) return NotFound();
            return Ok(task);
        }


        [HttpPost]
        public async Task<ActionResult<TaskItem>> Create([FromBody] CreateTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateTaskCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch");

            var success = await _mediator.Send(command);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var success = await _mediator.Send(new DeleteTaskCommand(id));
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
