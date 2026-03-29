using Dal.Context;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories;

public sealed class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<TaskEntity> AddAsync(TaskEntity entity, CancellationToken cancellationToken)
    {
        _context.Tasks.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<IReadOnlyCollection<TaskEntity>> ListAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Tasks
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<TaskEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task RenameAsync(Guid id, string? title, CancellationToken cancellationToken)
    {
        var entity = await _context.Tasks.FindAsync(new object[] { id }, cancellationToken);
        if (entity is null) return;

        entity.Title = title;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> RemoveByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Tasks.FindAsync(new object[] { id }, cancellationToken);
        if (entity is null) return false;

        _context.Tasks.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task RemoveAllAsync(CancellationToken cancellationToken)
    {
        await _context.Tasks.ExecuteDeleteAsync(cancellationToken);
    }
}