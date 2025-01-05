using AutoFixture;
using BaseUtils.Exceptions;
using BaseUtils.FlowControl.ErrorType;
using BaseUtils.FlowControl.ResultType;

namespace BaseUtils.tests.FlowControl.ResultType;
public class ResultTTests
{
    // TODO implement to many types
    [Fact(DisplayName = "RT<T>-01.01: Create result as sucessfull.")]
    public void CreateResult1()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        // When
        var result = Result<int>.Success(value);

        // Then
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Empty(result.Errors);
        Assert.Equal(value, result.GetValue());
    }

    [Fact(DisplayName = "RT<T>-01.02: Create result as sucessfull. null value expection.")]
    public void CreateResult2()
    {

        // When
        #pragma warning disable CS8625
        var ex = Assert.Throws<InvalidResultException>(() => Result<List<int>>.Success(null));
        #pragma warning restore CS8625

        // Then
        Assert.Equal(ResultBase.ExceptionNullableText, ex.Message);
        Assert.IsType<ArgumentNullException>(ex.InnerException);
    }

    [Fact(DisplayName = "RT<T>-01.03: Create result as sucessfull. Error Response expection.")]
    public void CreateResult3()
    {
        // Given
        var error1 = ErrorResponse.InvalidTypeError();

        // When
        var ex = Assert.Throws<InvalidResultException>(() => Result<ErrorResponse>.Success(error1));

        // Then
        Assert.Equal(ResultBase.ExceptionErrorResponseText, ex.Message);
    }

    [Fact(DisplayName = "RT<T>-01.04: Create result as sucessfull. Error list response expection.")]
    public void CreateResult4()
    {
        // Given
        var error1 = ErrorResponse.InvalidTypeError();
        // When
        var ex = Assert.Throws<InvalidResultException>(() 
              => Result<List<ErrorResponse>>.Success([error1]));
        // Then
        Assert.Equal(ResultBase.ExceptionErrorResponseText, ex.Message);
    }

    [Fact(DisplayName = "RT<T>-01.05: Create result as sucessfull. Empty Error list response expection.")]
    public void CreateResult5()
    {
        // When
        var ex = Assert.Throws<InvalidResultException>(() 
              => Result<List<ErrorResponse>>.Success([]));

        // Then
        Assert.Equal(ResultBase.ExceptionErrorResponseText, ex.Message);
    }

    [Fact(DisplayName = "RT<T>-01.06: Create result as sucessfull. null errorResponse value expection.")]
    public void CreateResult6()
    {

        // When
        #pragma warning disable CS8625
        var ex = Assert.Throws<InvalidResultException>(() => Result<ErrorResponse>.Success(null));
        #pragma warning restore CS8625

        // Then
        Assert.Equal(ResultBase.ExceptionNullableText, ex.Message);
        Assert.IsType<ArgumentNullException>(ex.InnerException);
    }

    [Fact(DisplayName = "RT<T>-01.07: Create result as sucessfull with empty list.")]
    public void CreateResult7()
    {
        // When
        var result = Result<List<int>>.Success([]);

        // Then
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Empty(result.Errors);
        Assert.IsType<List<int>>(result.GetValue());
        Assert.Empty(result.GetValue());
    }

    [Fact(DisplayName = "RT<T>-02.01: Create failure as sucessfull.")]
    public void CreateFailureResult1()
    {
        // Given
        var error = ErrorResponse.InvalidTypeError();
        // When
        var result = Result<List<int>>.Failure([error]);

        var ex = Assert.Throws<InvalidResultException>(result.GetValue);

        // Then
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors);

        Assert.Equal(ResultBase.ExceptionGetValueInFailureText, ex.Message);
        Assert.IsType<ArgumentNullException>(ex.InnerException);
    }

    [Fact(DisplayName = "RT<T>-02.02: Create failure as sucessfull. Unique errors.")]
    public void CreateFailureResult2()
    {
        // Given
        var error1 = ErrorResponse.InvalidTypeError();
        var error2 = ErrorResponse.NoAccessError();

        // When
        var result = Result<List<int>>.Failure([error1, error2, error1]);

        // Then
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(2, result.Errors.Count);
    }

    [Fact(DisplayName = "RT<T>-02.03: Create failure without errors.")]
    public void CreateFailureResult3()
    {
        // When
        var ex = Assert.Throws<InvalidResultException>(() => Result<List<int>>.Failure([]));

        // Then
        Assert.Equal(ResultBase.ExceptionErrorListNullText, ex.Message);
        Assert.IsType<ArgumentNullException>(ex.InnerException);
    }

    [Fact(DisplayName = "RT<T>-02.04: Create failure without errors.")]
    public void CreateFailureResult4()
    {
        // When
        #pragma warning disable CS8625
        var ex = Assert.Throws<InvalidResultException>(() => Result<List<int>>.Failure(null));
        #pragma warning restore CS8625

        // Then
        Assert.Equal(ResultBase.ExceptionErrorListNullText, ex.Message);
        Assert.IsType<ArgumentNullException>(ex.InnerException);
    }

    [Fact(DisplayName = "RT<T>-03.01: Convert value to result sucessful.")]
    public void ConvertToResult1()
    {
        // Given
        Fixture fixture = new();
        int value = fixture.Create<int>();

        // When
        Result<int> result = value;

        // Then
        Assert.True(result.IsSuccess);
        Assert.Equal(value, result.GetValue());
        Assert.Empty(result.Errors);
    }

    [Fact(DisplayName = "RT<T>-03.02: Convert error to result failure.")]
    public void ConvertToResult2()
    {
        // Given
        ErrorResponse error = ErrorResponse.InvalidTypeError();

        // When
        Result<int> result = error;

        // Then
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors);
    }

    [Fact(DisplayName = "RT<T>-03.03: Convert error to result failure.")]
    public void ConvertToResult3()
    {
        // Given
        List<ErrorResponse> errors = 
        [ErrorResponse.InvalidTypeError(), 
         ErrorResponse.NoAccessError()];

        // When
        Result<int> result = errors;

        // Then
        Assert.True(result.IsFailure);
        Assert.Equal(errors.Count, result.Errors.Count);
    }
}
