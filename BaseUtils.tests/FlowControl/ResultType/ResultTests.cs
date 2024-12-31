using AutoFixture;
using BaseUtils.Exceptions;
using BaseUtils.FlowControl.ErrorType;
using BaseUtils.FlowControl.ResultType;

namespace BaseUtils.tests.FlowControl.ResultType;
public class ResultTests
{
    [Fact(DisplayName = "RT-01.01.01: Create simple result as sucessfull.")]
    public void CreateResult1()
    {
        // When
        var result = Result.Success();

        // Then
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Empty(result.Errors);
    }

    [Fact(DisplayName = "RT-01.02.01: Create simple result as failure.")]
    public void CreateResult2()
    {
        // When
        var result = Result.Failure([ErrorResponse.NoAccessError()]);

        // Then
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors);
    }

    [Fact(DisplayName = "RT-01.02.02: Create simple result as failure with a list of errors.")]
    public void CreateResult3()
    {
        // Given
        var error1 = ErrorResponse.NoAccessError();
        var error2 = ErrorResponse.CriticalError();
        var error3 = ErrorResponse.NoAccessError();

        // When
        var result = Result.Failure([error1, error2, error3]);

        // Then
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(3, result.Errors.Count);
    }

    [Fact(DisplayName = "RT-01.02.03: Create simple result as failure with a list of errors.")]
    public void CreateResult4()
    {
        // Given
        var error1 = ErrorResponse.NoAccessError();
        var error2 = ErrorResponse.CriticalError();

        // When
        var result = Result.Failure([error1, error2, error1]);

        // Then
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(2, result.Errors.Count);
    }

    [Fact(DisplayName = "RT-01.02.04: Create simple result as failure with an empty list of errors.")]
    public void CreateResult5()
    {
        // When
        var ex = Assert.Throws<InvalidResultException>(() => Result.Failure([]));

        // Then
        Assert.Equal(Result.ExceptionErrorListNullText, ex.Message);
        Assert.IsType<ArgumentNullException>(ex.InnerException);
    }

    [Fact(DisplayName = "RT-01.02.05: Create simple result as failure with a null list of errors.")]
    public void CreateResult6()
    {
        // When
        #pragma warning disable CS8625
        var ex = Assert.Throws<InvalidResultException>(() => Result.Failure(null));
        #pragma warning restore CS8625
        // Then
        Assert.Equal(ResultBase.ExceptionErrorListNullText, ex.Message);
        Assert.IsType<ArgumentNullException>(ex.InnerException);
    }
}
