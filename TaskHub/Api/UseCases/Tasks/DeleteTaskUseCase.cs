using Dal.Repositories.Interfaces;
using Logic.Tasks.Interfaces;

namespace Api.UseCases.Tasks;

internal sealed class DeleteTaskUseCase : IDeleteTaskUseCase
{
    private readonly ITaskRepository _repository;

    public DeleteTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.RemoveByIdAsync(id, cancellationToken);
    }
}