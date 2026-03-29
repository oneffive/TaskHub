namespace Logic.Tasks.Interfaces;

public interface ISetTaskTitleUseCase
{
    Task ExecuteAsync(Guid id, string? title, CancellationToken cancellationToken);
}