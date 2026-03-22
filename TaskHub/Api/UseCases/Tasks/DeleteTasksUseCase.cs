using Dal.Repositories.Interfaces;
using Logic.Tasks.Interfaces;

namespace Api.UseCases.Tasks;

internal sealed class DeleteTasksUseCase : IDeleteTasksUseCase
{
    private readonly ITaskRepository _repository;

    public DeleteTasksUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _repository.RemoveAllAsync(cancellationToken);
    }
}