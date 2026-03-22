using Logic.Tasks.Models;

namespace Logic.Tasks.Services.Interfaces;

public interface ITaskService
{
    Task<TaskModel> CreateTaskAsync(string? title, Guid createdByUserId, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<TaskModel>> GetAllTasksAsync(CancellationToken cancellationToken);
    Task<TaskModel?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken);
    Task SetTaskTitleAsync(Guid id, string? title, CancellationToken cancellationToken);
    Task<bool> DeleteTaskByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAllTasksAsync(CancellationToken cancellationToken);
}