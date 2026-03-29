namespace Logic.Tasks.Interfaces;

public interface IDeleteTasksUseCase
{
    Task ExecuteAsync(CancellationToken cancellationToken);
}