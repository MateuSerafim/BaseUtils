using AutoFixture;
using BaseUtils.FlowControl.ErrorType;

namespace BaseUtils.tests.FlowControl.Response;
public class ErrorResponseTests
{
    [Fact(DisplayName = "ERT-01.01: Create Invalid Operation Error. Mensage value")]
    public void CreateInvalidOperationError1()
    {
        // Given
        Fixture fixture = new();
        string message = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError(message);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-01.02: Create Invalid Operation Error. Null value.")]
    public void CreateInvalidOperationError2()
    {        
        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError(null);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(ErrorBase.InvalidOperationDefaultMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-01.03: Create Invalid Operation Error. Empty value.")]
    public void CreateInvalidOperationError3()
    {        
        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError("");

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(ErrorBase.InvalidOperationDefaultMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-02.01: Create Invalid Type Error. Mensage value")]
    public void CreateInvalidTypeError1()
    {
        // Given
        Fixture fixture = new();
        string message = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError(message);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-02.02: Create Invalid Type Error. Null value.")]
    public void CreateInvalidTypeError2()
    {        
        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError(null);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(ErrorBase.InvalidTypeDefaultMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-02.03: Create Invalid Type Error. Empty value.")]
    public void CreateInvalidTypeError3()
    {        
        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError("");

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(ErrorBase.InvalidTypeDefaultMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-03.01: Create Not Found Error. Mensage value")]
    public void CreateNotFoundError1()
    {
        // Given
        Fixture fixture = new();
        string message = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.NotFoundError(message);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-03.02: Create Not Found Error. Null value.")]
    public void CreateNotFoundError2()
    {        
        // When
        ErrorResponse response = ErrorResponse.NotFoundError(null);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(ErrorBase.NotFoundDefaultMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-03.03: Create Not Found Error. Empty value.")]
    public void CreateNotFoundError3()
    {        
        // When
        ErrorResponse response = ErrorResponse.NotFoundError("");

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(ErrorBase.NotFoundDefaultMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-04.01: Create No Access Error. Mensage value")]
    public void CreateNoAccessError1()
    {
        // Given
        Fixture fixture = new();
        string message = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.NoAccessError(message);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-04.02: Create No Access Error. Null value.")]
    public void CreateNoAccessError2()
    {        
        // When
        ErrorResponse response = ErrorResponse.NoAccessError(null);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(ErrorBase.NoAccessDefaultMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-04.03: Create No Access Error. Empty value.")]
    public void CreateNoAccessError3()
    {        
        // When
        ErrorResponse response = ErrorResponse.NoAccessError("");

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(ErrorBase.NoAccessDefaultMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-05.01: Create Critical Error. Mensage value")]
    public void CreateCriticalError1()
    {
        // Given
        Fixture fixture = new();
        string message = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.CriticalError(message);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-05.02: Create Critical Error. Null value.")]
    public void CreateCriticalError2()
    {        
        // When
        ErrorResponse response = ErrorResponse.CriticalError(null);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(ErrorBase.CriticalDefaultMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ERT-05.03: Create Critical Error. Empty value.")]
    public void CreateCriticalError3()
    {        
        // When
        ErrorResponse response = ErrorResponse.CriticalError("");

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(ErrorBase.CriticalDefaultMessage, response.ErrorMessage());
    }
}