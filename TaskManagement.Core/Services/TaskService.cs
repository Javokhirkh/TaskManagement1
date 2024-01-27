using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManagement.Contracts.Dtos;
using TaskManagement.Core.Data;
using TaskManagement.Core.Exceptions;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Core.Services;

public class TaskService : ITaskService
{
    private readonly ILogger<TaskService> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMapper _mapper;

    public TaskService(
        ApplicationDbContext context,
        ILogger<TaskService> logger,
        IDateTimeProvider dateTimeProvider,
        IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
    }


    public async Task<TaskDto> CreateAsync(CreateTaskDto dto)
    {
        var task = _mapper.Map<TaskEntity>(dto);

        task.CreatedAt = _dateTimeProvider.Now;

        await _context.Tasks.AddAsync(task);

        await _context.SaveChangesAsync();

        _logger.LogInformation("Task {TaskId} created", task.Id);

        return _mapper.Map<TaskDto>(task);
    }

    public async Task<TaskDto> UpdateAsync(UpdateTaskDto dto)
    {
        var task = await _context.Tasks.FindAsync(dto.Id);

        if (task == null)
        {
            throw new TaskNotFoundException("Task not found");
        }

        _mapper.Map(dto, task);

        task.UpdatedAt = _dateTimeProvider.Now;

        await _context.SaveChangesAsync();

        _logger.LogInformation("Task {TaskId} updated", task.Id);

        return _mapper.Map<TaskDto>(task);
    }

    public async Task<List<TaskDto>> GetAllAsync()
    {
        var tasks = await _context.Tasks.ToListAsync();

        return _mapper.Map<List<TaskDto>>(tasks);
    }

    public async Task<TaskDto> GetByIdAsync(Guid id)
    {
        var task = await _context.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (task == null)
        {
            throw new TaskNotFoundException("Task not found");
        }

        return _mapper.Map<TaskDto>(task);
    }

    public async Task DeleteAsync(Guid id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
        {
            throw new TaskNotFoundException("Task not found");
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Task {TaskId} deleted", task.Id);
    }
}