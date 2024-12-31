using BaseUtils.Utils;

namespace BaseUtils.FlowControl.ErrorType;
public record ErrorResponse
{
    public string? ErrorValue { get; }
    public ErrorTypeEnum ErrorType { get; }
    private string ErrorText { get; }
    public Guid ErrorId { get; }

    public const string InvalidOperationDefaultMessage = "Invalid operation.";
    public const string InvalidTypeDefaultMessage = "Invalid object type.";
    public const string NotFoundDefaultMessage = "Object not found.";
    public const string NoAccessDefaultMessage = "Unauthorized operation.";
    public const string CriticalDefaultMessage = "Critical failure.";

    public const string ReferenceToVariable = "{var}";

    protected ErrorResponse(ErrorTypeEnum errorType, string? errorText, string? errorValue) 
    {
        ErrorType = errorType;
        ErrorText = CheckErrorMessage(errorText);
        ErrorValue = errorValue;
        ErrorId = Guid.NewGuid();
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

    public static ErrorResponse InvalidOperationError(string? errorMessage = null) 
    => InvalidOperationError<string>(errorMessage, null);
    public static ErrorResponse InvalidOperationError<T> (string? errorMessage, T? errorValue) 
    => new (ErrorTypeEnum.InvalidOperationError, errorMessage, GetValueToString(errorValue));

    public static ErrorResponse InvalidTypeError(string? errorMessage = null) 
    => InvalidTypeError<string>(errorMessage, null);
    public static ErrorResponse InvalidTypeError<T> (string? errorMessage, T? errorValue) 
    => new (ErrorTypeEnum.InvalidTypeError, errorMessage, GetValueToString(errorValue));

    public static ErrorResponse NotFoundError(string? errorMessage = null) 
    => NotFoundError<string>(errorMessage, null);
    public static ErrorResponse NotFoundError<T> (string? errorMessage, T? errorValue) 
    => new (ErrorTypeEnum.NotFoundError, errorMessage, GetValueToString(errorValue));

    public static ErrorResponse NoAccessError(string? errorMessage = null) 
    => NoAccessError<string>(errorMessage, null);
    public static ErrorResponse NoAccessError<T> (string? errorMessage, T? errorValue) 
    => new (ErrorTypeEnum.NoAccessError, errorMessage, GetValueToString(errorValue));

    public static ErrorResponse CriticalError(string? errorMessage = null) 
    => CriticalError<string>(errorMessage, null);
    public static ErrorResponse CriticalError<T> (string? errorMessage, T? errorValue) 
    => new (ErrorTypeEnum.CriticalError, errorMessage, GetValueToString(errorValue));

    private static string? GetValueToString<T>(T value)
    {
        if (value.IsGenericCollection()) 
            return string.Join(", ", value.GetStringsByGenericCollection());

        return value?.ToString() ?? null;
    }

    public string ErrorMessage() => string.IsNullOrEmpty(ErrorValue) 
    ? GetErrorMessageText() : ErrorMessageValue();

    public string GetErrorMessageText() => ErrorText;

    private string ErrorMessageValue() 
    => ErrorText.Replace(ReferenceToVariable, ErrorValue);
}
