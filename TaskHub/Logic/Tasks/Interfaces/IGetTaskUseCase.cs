using Logic.Tasks.Models;

namespace Logic.Tasks.Interfaces;

public interface IGetTaskUseCase
{
    Task<TaskModel?> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}