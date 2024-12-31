using BaseUtils.FlowControl.ErrorType;

namespace BaseUtils.FlowControl.ResultType;
public abstract record class ResultBase
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public List<ErrorResponse> Errors { get; } = [];

    public const string ExceptionNullableText = "Result cannot recevied null value.";
    public const string ExceptionGetValueInFailureText = "Failure result cannot have value";
    public const string ExceptionErrorResponseText = "Result value cannot error response type.";
    public const string ExceptionErrorListNullText = "Result failure cannot recevied empty error list.";

    protected ResultBase(bool isSuccess, List<ErrorResponse> errors)
    {
        IsSuccess = isSuccess;
        Errors = [.. errors.Distinct()];
    }
}
