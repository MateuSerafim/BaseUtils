using BaseUtils.FlowControl.ErrorType;

namespace BaseUtils.FlowControl.ResultType;

public record Result : ResultBase<ErrorResponse> 
{
    public const string NullListExceptionMessage = "You cannot pass a nullable Error List";
    protected Result(bool isSuccess, List<ErrorResponse> errors) : base(isSuccess, errors) 
    {

    }

    public static Result Success() => new(true, []);

    public static Result Failure() => Failure([ErrorResponse.InvalidOperationError(null)]);
    public static Result Failure(List<ErrorResponse> errors) 
    {
        if (errors is null || errors.Count == 0)
            throw new ArgumentNullException(nameof(errors), NullListExceptionMessage);

        return new(false, [.. errors.Distinct()]);
    }
}
