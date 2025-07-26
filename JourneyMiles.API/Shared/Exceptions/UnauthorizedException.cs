namespace JourneyMiles.API.Shared.Exceptions;

public class UnauthorizedException : AppException
{
    public UnauthorizedException() : base("Email and/or password invalid")
    {
    }
}
