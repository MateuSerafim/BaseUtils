namespace BaseUtils.FlowControl.ResultType.Extensions;
public static class ResultExtensions
{
    public static Result<U> Bind<T, U>(this Result<T> result, Func<T, Result<U>> funcToApply)
    {
        if (result.IsFailure)
            return result.Errors;

        return funcToApply(result.GetValue());
    }

    public static Result Bind<T>(this Result<T> result, Func<T, Result> funcToApply)
    {
        if (result.IsFailure)
            return result.Errors;

        var resultMethod = funcToApply(result.GetValue());
        if (resultMethod.IsFailure)
            return resultMethod.Errors;

        return Result.Success();
    }

    public static Result<T> Map<T, U>(this Result<T> result, Func<T, Result<U>> funcToApply)
    {
        if (result.IsFailure)
            return result.Errors;

        var resultMethod = funcToApply(result.GetValue());
        if (resultMethod.IsFailure)
            return resultMethod.Errors;

        return result.GetValue();
    }

    public static Result<T> Map<T>(this Result<T> result, Func<T, Result> funcToApply)
    {
        if (result.IsFailure)
            return result.Errors;

        var resultMethod = funcToApply(result.GetValue());
        if (resultMethod.IsFailure)
            return resultMethod.Errors;

        return result.GetValue();
    }
}
