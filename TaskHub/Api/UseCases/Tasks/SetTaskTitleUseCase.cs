using Dal.Repositories.Interfaces;
using Logic.Tasks.Interfaces;

namespace Api.UseCases.Tasks;

internal sealed class SetTaskTitleUseCase : ISetTaskTitleUseCase
{
    private readonly ITaskRepository _repository;

    public SetTaskTitleUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id, string? title, CancellationToken cancellationToken)
    {
        await _repository.RenameAsync(id, title, cancellationToken);
    }
}