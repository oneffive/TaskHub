using Dal.Repositories.Interfaces;
using Logic.Tasks.Interfaces;
using Logic.Tasks.Models;

namespace Api.UseCases.Tasks;

internal sealed class GetTaskUseCase : IGetTaskUseCase
{
    private readonly ITaskRepository _repository;

    public GetTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskModel?> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.FindByIdAsync(id, cancellationToken);
        if (entity is null) return null;

        return new TaskModel(entity.Id, entity.Title, entity.CreatedByUserId, entity.CreatedUtc);
    }
}