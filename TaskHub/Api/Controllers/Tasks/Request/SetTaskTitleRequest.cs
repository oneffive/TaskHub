namespace Api.Controllers.Tasks.Request;

public record SetTaskTitleRequest
{
    public string? Title { get; init; }
}