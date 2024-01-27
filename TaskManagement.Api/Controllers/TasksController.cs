using Microsoft.AspNetCore.Mvc;
using TaskManagement.Api.Middlewares;
using TaskManagement.Contracts.Dtos;
using TaskManagement.Core.Services;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
[Produces("application/json")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    /// <summary>
    ///   Get all tasks
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TaskDto>))]
    public async Task<ActionResult<List<TaskDto>>> GetAllAsync()
    {
        var tasks = await _taskService.GetAllAsync();
        return Ok(tasks);
    }
    
    /// <summary>
    ///  Get a task by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
    public async Task<ActionResult<TaskDto>> GetByIdAsync(Guid id)
    {
        var task = await _taskService.GetByIdAsync(id);
        return Ok(task);
    }

    /// <summary>
    ///  Create a task
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
    public async Task<ActionResult<TaskDto>> CreateAsync(CreateTaskDto dto)
    {
        var task = await _taskService.CreateAsync(dto);
        return Ok(task);
    }


    /// <summary>
    ///  Update a task
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
    public async Task<ActionResult<TaskDto>> UpdateAsync(Guid id, UpdateTaskDto dto)
    {
        dto.Id = id;
        var task = await _taskService.UpdateAsync(dto);
        return Ok(task);
    }

    /// <summary>
    ///  Delete a task
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await _taskService.DeleteAsync(id);
        return NoContent();
    }
}