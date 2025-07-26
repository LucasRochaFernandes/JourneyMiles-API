﻿namespace JourneyMiles.API.Shared.Exceptions;

public class ValidationException : AppException
{
    public IList<string> Errors { get; set; }

    public ValidationException(IList<string> errors) : base(string.Empty)
    {
        Errors = errors;
    }
}
