using AutoFixture;
using BaseUtils.FlowControl.ErrorType;

namespace BaseUtils.tests.FlowControl.ErrorType;
public class ErrorResponseTests
{
    private const string Message = $"default {ErrorResponse.ReferenceToVariable} message.";

    [Fact(DisplayName = "ERT-01.01.01: Create Invalid Operation Error. Mensage value")]
    public void CreateInvalidOperationError1()
    {
        // Given
        Fixture fixture = new();
        string code = fixture.Create<string>();
        string message = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.Create(code, message);

        // Then
        Assert.Equal(code, response.ErrorCode);
        Assert.Equal(message, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
        Assert.IsType<Guid>(response.ErrorId);
    }

    [Fact(DisplayName = "ERT-01.01.02: Create Invalid Operation Error. Mensage value")]
    public void CreateInvalidOperationError2()
    {
        // Given
        Fixture fixture = new();
        string code = fixture.Create<string>();
        string message = fixture.Create<string>() + ErrorResponse.ReferenceToVariable;
        int value = fixture.Create<int>();

        // When
        ErrorResponse response = ErrorResponse.Create(code, message, value);

        // Then
        Assert.Equal(code, response.ErrorCode);
        Assert.Equal(message.Replace(ErrorResponse.ReferenceToVariable, 
                                     value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
        Assert.IsType<Guid>(response.ErrorId);
    }
}