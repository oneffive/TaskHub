using Dal.Repositories.Interfaces;
using Logic.Tasks.Interfaces;
using Logic.Tasks.Models;

namespace Api.UseCases.Tasks;

internal sealed class GetTasksUseCase : IGetTasksUseCase
{
    private readonly ITaskRepository _repository;

    public GetTasksUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<TaskModel>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.ListAllAsync(cancellationToken);
        return entities
            .Select(e => new TaskModel(e.Id, e.Title, e.CreatedByUserId, e.CreatedUtc))
            .ToArray();
    }
}