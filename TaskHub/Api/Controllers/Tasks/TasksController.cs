using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;
using Logic.Tasks.Models;
using Logic.Tasks.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Api.Attributes;
using Api.Filters;

namespace Api.Controllers.Tasks;

[Route("tasks")]
[ApiController]
[ServiceFilter(typeof(StudentInfoHeadersFilter))]
[ServiceFilter(typeof(RequestLoggingFilter))]
public sealed class TasksController : ControllerBase
{
    private readonly ITaskService _tasks;

    public TasksController(ITaskService tasks)
    {
        _tasks = tasks;
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidateCreateTaskRequestFilter))]
    public async Task<ActionResult<TaskResponse>> AddTaskAsync(
        [FromBody] CreateTaskRequest? body,
        CancellationToken ct)
    {
        var model = await _tasks.CreateTaskAsync(body!.Title, body.CreatedByUserId, ct);
        var response = MapToResponse(model);
        return CreatedAtAction("FetchTaskById", new { id = response.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<TaskResponse>>> FetchAllTasksAsync(
        CancellationToken ct)
    {
        var models = await _tasks.GetAllTasksAsync(ct);
        return Ok(models.Select(MapToResponse).ToList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskResponse>> FetchTaskByIdAsync(
        [FromRouteTaskId] Guid id,
        CancellationToken ct)
    {
        var model = await _tasks.GetTaskByIdAsync(id, ct);
        if (model is null)
        {
            return NotFound();
        }

        return Ok(MapToResponse(model));
    }

    [HttpPut("{id}/title")]
    [ServiceFilter(typeof(ValidateSetTaskTitleRequestFilter))]
    public async Task<IActionResult> UpdateTaskTitleAsync(
        [FromRouteTaskId] Guid id,
        [FromBody] SetTaskTitleRequest? body,
        CancellationToken ct)
    {
        await _tasks.SetTaskTitleAsync(id, body!.Title, ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveTaskByIdAsync(
        [FromRouteTaskId] Guid id,
        CancellationToken ct)
    {
        var removed = await _tasks.DeleteTaskByIdAsync(id, ct);
        if (!removed)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveAllTasksAsync(CancellationToken ct)
    {
        await _tasks.DeleteAllTasksAsync(ct);
        return NoContent();
    }

    private static TaskResponse MapToResponse(TaskModel m)
    {
        return new TaskResponse
        {
            Id = m.Id,
            Title = m.Title,
            CreatedByUserId = m.CreatedByUserId,
            CreatedUtc = m.CreatedUtc,
        };
    }
}