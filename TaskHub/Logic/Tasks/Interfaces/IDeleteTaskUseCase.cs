namespace Logic.Tasks.Interfaces;

public interface IDeleteTaskUseCase
{
    Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}