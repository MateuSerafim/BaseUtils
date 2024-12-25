namespace BaseUtils.FlowControl.ErrorType;

public abstract record class ErrorBase
{
    public ErrorTypeEnum ErrorType { get; }
    private string ErrorText { get; }

    public const string InvalidOperationDefaultMessage = "Invalid operation.";
    public const string InvalidTypeDefaultMessage = "Invalid object type.";
    public const string NotFoundDefaultMessage = "Object not found.";
    public const string NoAccessDefaultMessage = "Unauthorized operation.";
    public const string CriticalDefaultMessage = "Critical failure.";

    protected ErrorBase(ErrorTypeEnum errorType, string? errorMessage)
    {
        ErrorType = errorType;
        ErrorText = CheckErrorMessage(errorMessage);
    }

    protected virtual string CheckErrorMessage(string? errorMessage)
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

    public virtual string ErrorMessage() => ErrorText;
}