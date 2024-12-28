using BaseUtils.FlowControl.ErrorType;

namespace BaseUtils.FlowControl.ResultType;

public abstract record class ResultBase<E> where E : ErrorBase
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public List<E> Errors { get; } = [];

    protected ResultBase(bool isSuccess, List<E> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }
}
