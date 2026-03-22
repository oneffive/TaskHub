using Dal.Entities;
using Dal.Repositories.Interfaces;
using Logic.Tasks.Interfaces;
using Logic.Tasks.Models;

namespace Api.UseCases.Tasks;

internal sealed class CreateTaskUseCase : ICreateTaskUseCase
{
    private readonly ITaskRepository _repository;

    public CreateTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskModel> ExecuteAsync(string? title, Guid createdByUserId, CancellationToken cancellationToken)
    {
        var newEntity = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Title = title,
            CreatedByUserId = createdByUserId,
            CreatedUtc = DateTimeOffset.UtcNow,
        };

        var saved = await _repository.AddAsync(newEntity, cancellationToken);
        return ToModel(saved);
    }

    private static TaskModel ToModel(TaskEntity e) =>
        new(e.Id, e.Title, e.CreatedByUserId, e.CreatedUtc);
}