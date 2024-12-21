namespace BaseUtils.FlowControl.ErrorType;
public record ErrorResponse
{
    public ErrorTypeEnum ErrorType { get; }
    public string ErrorMessage { get; } 

    public const string InvalidOperationDefaultMessage = "Invalid operation.";
    public const string InvalidTypeDefaultMessage = "Invalid object.";
    public const string NotFoundDefaultMessage = "Object not found.";
    public const string NoAccessDefaultMessage = "Unauthorized operation.";
    public const string CriticalDefaultMessage = "Critical failure.";

    protected ErrorResponse(ErrorTypeEnum httpStatusCode, string? errorMessage)
    {
        ErrorType = httpStatusCode;
        ErrorMessage = CheckErrorMessage(errorMessage);
    }

    private string CheckErrorMessage(string? errorMessage)
    {
        if (!string.IsNullOrEmpty(errorMessage))
            return errorMessage;

        return ErrorType switch
        {
            ErrorTypeEnum.InvalidTypeError => InvalidTypeDefaultMessage,
            ErrorTypeEnum.NotFoundError => NotFoundDefaultMessage,
            ErrorTypeEnum.NoAccessError => NoAccessDefaultMessage,
            ErrorTypeEnum.CriticalError => CriticalDefaultMessage,
            _ => InvalidOperationDefaultMessage
        };
    }

    public static ErrorResponse InvalidOperationError (string? errorMessage) 
    => new (ErrorTypeEnum.InvalidOperationError, errorMessage);

    public static ErrorResponse InvalidTypeError (string? errorMessage) 
    => new (ErrorTypeEnum.InvalidTypeError, errorMessage);

    public static ErrorResponse NotFoundError (string? errorMessage) 
    => new (ErrorTypeEnum.NotFoundError, errorMessage);

    public static ErrorResponse NoAccessError (string? errorMessage) 
    => new (ErrorTypeEnum.NoAccessError, errorMessage);

    public static ErrorResponse CriticalError (string? errorMessage) 
    => new (ErrorTypeEnum.CriticalError, errorMessage);
}