namespace Api.Controllers.Tasks.Request;

public record CreateTaskRequest
{
    public string? Title { get; init; }
    public required Guid CreatedByUserId { get; init; }
}