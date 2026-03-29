namespace Api.Controllers.Tasks.Response;

public record TaskResponse
{
    public required Guid Id { get; init; }
    public string? Title { get; init; }
    public required Guid CreatedByUserId { get; init; }
    public required DateTimeOffset CreatedUtc { get; init; }
}