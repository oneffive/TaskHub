using Logic.Tasks.Interfaces;
using Logic.Tasks.Models;
using Logic.Tasks.Services.Interfaces;

namespace Logic.Tasks.Services;

internal sealed class TaskService : ITaskService
{
    private readonly ICreateTaskUseCase _create;
    private readonly IGetTasksUseCase _getAll;
    private readonly IGetTaskUseCase _getOne;
    private readonly ISetTaskTitleUseCase _setTitle;
    private readonly IDeleteTaskUseCase _deleteOne;
    private readonly IDeleteTasksUseCase _deleteAll;

    public TaskService(
        ICreateTaskUseCase create,
        IGetTasksUseCase getAll,
        IGetTaskUseCase getOne,
        ISetTaskTitleUseCase setTitle,
        IDeleteTaskUseCase deleteOne,
        IDeleteTasksUseCase deleteAll)
    {
        _create = create;
        _getAll = getAll;
        _getOne = getOne;
        _setTitle = setTitle;
        _deleteOne = deleteOne;
        _deleteAll = deleteAll;
    }

    public async Task<TaskModel> CreateTaskAsync(string? title, Guid createdByUserId, CancellationToken cancellationToken)
    {
        return await _create.ExecuteAsync(title, createdByUserId, cancellationToken);
    }

    public async Task<IReadOnlyCollection<TaskModel>> GetAllTasksAsync(CancellationToken cancellationToken)
    {
        return await _getAll.ExecuteAsync(cancellationToken);
    }

    public async Task<TaskModel?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var task = await _getOne.ExecuteAsync(id, cancellationToken);
        if (task == null)
        {
            return null;
        }

        return task;
    }

    public async Task SetTaskTitleAsync(Guid id, string? title, CancellationToken cancellationToken)
    {
        await _setTitle.ExecuteAsync(id, title, cancellationToken);
    }

    public async Task<bool> DeleteTaskByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _deleteOne.ExecuteAsync(id, cancellationToken);
    }

    public async Task DeleteAllTasksAsync(CancellationToken cancellationToken)
    {
        await _deleteAll.ExecuteAsync(cancellationToken);
    }
}