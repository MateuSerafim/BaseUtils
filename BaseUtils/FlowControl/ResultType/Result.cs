using BaseUtils.Exceptions;
using BaseUtils.FlowControl.ErrorType;

namespace BaseUtils.FlowControl.ResultType;
public record class Result : ResultBase
{
    protected Result(bool isSuccess, List<ErrorResponse> errors) : 
    base(isSuccess, errors) { }

    public static Result Success() => new(true, []);
    
    public static Result Failure(List<ErrorResponse> errors) 
    {
        if (errors is null)
            throw new ArgumentNullException(nameof(errors), ExceptionErrorListNullText);

        if (errors.Count == 0)
            throw new InvalidResultException(ExceptionErrorListNullText);
        
        return new(false, errors);
    }

    public static implicit operator Result(ErrorResponse error) 
        => Failure([error]);
    
    public static implicit operator Result(List<ErrorResponse> errors) 
        => Failure(errors);
}
