using TaskManagement.Contracts.Dtos;

namespace TaskManagement.Core.Services;

public interface ITaskService
{
    Task<TaskDto> CreateAsync(CreateTaskDto dto);
    Task<TaskDto> UpdateAsync(UpdateTaskDto dto);
    Task<List<TaskDto>> GetAllAsync();
    Task<TaskDto> GetByIdAsync(Guid id);
    Task DeleteAsync(Guid id);
}