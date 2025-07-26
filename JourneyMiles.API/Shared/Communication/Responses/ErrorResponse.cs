namespace JourneyMiles.API.Shared.Communication.Responses;

public sealed class ErrorResponse
{
    public IList<string> Errors { get; set; }

    public ErrorResponse(IList<string> errors)
    {
        Errors = errors;
    }
    public ErrorResponse(string message)
    {
        Errors = new List<string> { message };
    }
}
