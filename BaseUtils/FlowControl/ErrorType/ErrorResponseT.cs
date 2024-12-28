using BaseUtils.Utils;

namespace BaseUtils.FlowControl.ErrorType;

public record ErrorResponse<T> : ErrorBase
{
    public T? ErrorValue { get; }

    public const string ReferenceToVariable = "{var}";

    protected ErrorResponse(ErrorTypeEnum errorType, string? errorMessage, T errorValue) 
            : base(errorType, errorMessage)
    {
        ErrorValue = errorValue;
    }

    public static ErrorResponse<T> InvalidOperationError (string? errorMessage, T errorValue) 
    => new (ErrorTypeEnum.InvalidOperationError, errorMessage, errorValue);

    public static ErrorResponse<T> InvalidTypeError (string? errorMessage, T errorValue) 
    => new (ErrorTypeEnum.InvalidTypeError, errorMessage, errorValue);

    public static ErrorResponse<T> NotFoundError (string? errorMessage, T errorValue) 
    => new (ErrorTypeEnum.NotFoundError, errorMessage, errorValue);

    public static ErrorResponse<T> NoAccessError (string? errorMessage, T errorValue) 
    => new (ErrorTypeEnum.NoAccessError, errorMessage, errorValue);

    public static ErrorResponse<T> CriticalError (string? errorMessage, T errorValue) 
    => new (ErrorTypeEnum.CriticalError, errorMessage, errorValue);

    public override string ErrorMessage() 
    => ErrorValue.IsGenericCollection() ? ErrorMessageList() : ErrorMessageValue();

    public string GetErrorMessageStruct() => base.ErrorMessage();

    private string ErrorMessageList()
    {
        var valuesArray = string.Join(", ", ErrorValue.GetStringsByGenericCollection());
        
        return base.ErrorMessage().Replace(ReferenceToVariable, valuesArray);
    }

    private string ErrorMessageValue() 
    => ErrorValue is null ? base.ErrorMessage() : 
                            base.ErrorMessage().Replace(ReferenceToVariable, 
                                                        ErrorValue.ToString());

}
