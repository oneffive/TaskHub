using Logic.Tasks.Models;

namespace Logic.Tasks.Interfaces;

public interface IGetTasksUseCase
{
    Task<IReadOnlyCollection<TaskModel>> ExecuteAsync(CancellationToken cancellationToken);
}