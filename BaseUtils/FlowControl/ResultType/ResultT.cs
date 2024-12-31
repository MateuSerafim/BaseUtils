using BaseUtils.Exceptions;
using BaseUtils.FlowControl.ErrorType;
using BaseUtils.Utils;

namespace BaseUtils.FlowControl.ResultType;

public record Result<T> : ResultBase
{
    private readonly T? Value;

    protected Result(bool isSuccess, List<ErrorResponse> errors, T value) : 
    base(isSuccess, errors)
    {
        Value = value;
    }

    protected Result(bool isSuccess, List<ErrorResponse> errors) : 
    base(isSuccess, errors)
    {
    }

    public static Result<T> Success(T value)
    {
        if (value is null) 
            throw new InvalidResultException(ExceptionNullableText, new ArgumentNullException());
        if (value.IsErrorResponseType())
            throw new InvalidResultException(ExceptionErrorResponseText);
        return new (true, [], value);
    }

    public static Result<T> Failure(List<ErrorResponse> errors)
    {
        if (errors == null || errors.Count == 0) 
            throw new InvalidResultException(ExceptionErrorListNullText, new ArgumentNullException());
        return new(false, errors);
    }

    public T GetValue() 
    {
        if (Value is null)
            throw new InvalidResultException(ExceptionGetValueInFailureText, new ArgumentNullException());
        return Value;
    }
}
