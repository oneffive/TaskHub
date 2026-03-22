using Dal.Entities;

namespace Dal.Repositories.Interfaces;

public interface ITaskRepository
{
    Task<TaskEntity> AddAsync(TaskEntity entity, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<TaskEntity>> ListAllAsync(CancellationToken cancellationToken = default);
    Task<TaskEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task RenameAsync(Guid id, string? title, CancellationToken cancellationToken = default);
    Task<bool> RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task RemoveAllAsync(CancellationToken cancellationToken = default);
}