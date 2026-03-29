using Logic.Tasks.Models;

namespace Logic.Tasks.Interfaces;

public interface ICreateTaskUseCase
{
    Task<TaskModel> ExecuteAsync(string? title, Guid createdByUserId, CancellationToken cancellationToken);
}