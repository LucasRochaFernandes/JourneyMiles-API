namespace JourneyMiles.API.Shared.Exceptions;

public class AppException : SystemException
{
    public AppException(string message) : base(message)
    {
    }
}
