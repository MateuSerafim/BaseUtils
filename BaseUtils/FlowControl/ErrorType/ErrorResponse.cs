namespace BaseUtils.FlowControl.ErrorType;
public record ErrorResponse : ErrorBase
{
    protected ErrorResponse(ErrorTypeEnum errorType, string? errorMessage) : 
                            base(errorType, errorMessage) {}

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