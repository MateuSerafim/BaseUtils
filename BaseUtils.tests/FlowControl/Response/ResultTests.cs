using BaseUtils.FlowControl.ErrorType;
using BaseUtils.FlowControl.ResultType;

namespace BaseUtils.tests.FlowControl.Response;
public class ResultTests
{
    [Fact(DisplayName = "RT-01.01: Create simple successful result value.")]
    public void CreateResultSuccessful()
    {
        // When
        var result = Result.Success();
        
        // Then
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal([], result.Errors);
    }

    [Fact(DisplayName = "RT-02.01: Create simple result with failure.")]
    public void CreateResultFailure1()
    {
        // When
        var result = Result.Failure();
        
        // Then
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors);
    }

    [Fact(DisplayName = "RT-02.02: Create simple result with one failure.")]
    public void CreateResultFailure2()
    {
        // Given
        var failureError = ErrorResponse.InvalidOperationError(null);
        // When
        var result = Result.Failure([failureError]);
        
        // Then
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors);

        Assert.Equal(failureError.ErrorType, result.Errors[0].ErrorType);
    }

    [Fact(DisplayName = "RT-02.03: Create simple result with multiple failures.")]
    public void CreateResultFailure3()
    {
        // Given
        var failureError1 = ErrorResponse.InvalidOperationError(null);
        var failureError2 = ErrorResponse.InvalidTypeError(null);
        var failureError3 = ErrorResponse.NoAccessError(null);
        // When
        var result = Result.Failure([failureError1, failureError2, failureError3]);
        
        // Then
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Contains(failureError1, result.Errors);
        Assert.Contains(failureError2, result.Errors);
        Assert.Contains(failureError3, result.Errors);
        Assert.Equal(3, result.Errors.Count);
    }

    [Fact(DisplayName = "RT-02.04: Create simple result with empty list (exception).")]
    public void CreateResultFailure4()
    {
        // Given
        var exceptionBase = new ArgumentNullException("errors", Result.NullListExceptionMessage);

        // When
        var resultException = Assert.Throws<ArgumentNullException>(() => Result.Failure([]));

        // then
        Assert.Equal(exceptionBase.Message, resultException.Message);
    }

    [Fact(DisplayName = "RT-02.05: Create simple result with null list (exception).")]
    public void CreateResultFailure5()
    {
        // Given
        var exceptionBase = new ArgumentNullException("errors", Result.NullListExceptionMessage);

        // When
        #pragma warning disable CS8625
        var resultException = Assert.Throws<ArgumentNullException>(() => Result.Failure(null));
        #pragma warning restore CS8625

        // Then
        Assert.Equal(exceptionBase.Message, resultException.Message);
    }

    [Fact(DisplayName = "RT-02.06: Create simple result with repeated")]
    public void CreateResultFailure6()
    {
        // Given
        var failureError1 = ErrorResponse.InvalidOperationError(null);

        // When
        var result = Result.Failure([failureError1, failureError1, failureError1]);

        // Then
        Assert.Single(result.Errors);
    }
}
