using BaseUtils.Utils;

namespace BaseUtils.FlowControl.ErrorType;
public record ErrorResponse
{
    public string ErrorCode {get; }
    public string? ErrorValue { get; }
    private string ErrorText { get; }
    public Guid ErrorId { get; }

    public const string ReferenceToVariable = "{var}";
    public const string DefaultErrorMessage = "Invalid operation.";
    public const string GenericErrorCode = "BU_GENERIC_ERROR.";

    protected ErrorResponse(string? errorCode, 
                            string? errorText, 
                            string? errorValue) 
    {
        ErrorCode = errorCode ?? GenericErrorCode;
        ErrorText = errorText ?? DefaultErrorMessage;
        ErrorValue = errorValue;
        ErrorId = Guid.NewGuid();
    }

    public static ErrorResponse Create(string? errorCode, 
                                       string? errorText) 
    => new(errorCode, errorText, null);

    public static ErrorResponse InvalidOperationError() 
    => new(GenericErrorCode, DefaultErrorMessage, null);

    public static ErrorResponse Create<T>(string? errorCode, 
                                       string? errorText, T value) 
    => new(errorCode, errorText, TransformVariableInString(value));

    private static string? TransformVariableInString<T>(T value)
    {
        if (value.IsGenericCollection()) 
            return string.Join(", ", value.GetStringsByGenericCollection());

        return value?.ToString() ?? null;
    }

    public string ErrorMessage() 
    => string.IsNullOrEmpty(ErrorValue) ? GetErrorMessageText() 
                                        : ErrorMessageWithVariable();

    public string GetErrorMessageText() => ErrorText;

    private string ErrorMessageWithVariable() 
    => ErrorText.Replace(ReferenceToVariable, ErrorValue);
}
