using AutoFixture;
using BaseUtils.FlowControl.ErrorType;
using BaseUtils.Utils;

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

    [Fact(DisplayName = "ERT-01.01.03: Create Invalid Operation Error. Mensage value")]
    public void CreateInvalidOperationError3()
    {
        // Given

        // When
        ErrorResponse response = ErrorResponse.Create(null, null);

        // Then
        Assert.Equal(ErrorResponse.GenericErrorCode, response.ErrorCode);
        Assert.Equal(ErrorResponse.DefaultErrorMessage, response.ErrorMessage());
        Assert.IsType<Guid>(response.ErrorId);
    }

    [Fact(DisplayName = "ERT-01.01.04: Create Invalid Operation Error. Mensage value in list")]
    public void CreateInvalidOperationError4()
    {
        // Given
        Fixture fixture = new();
        string code = fixture.Create<string>();
        string message = fixture.Create<string>() + ErrorResponse.ReferenceToVariable;
        
        int value_1 = fixture.Create<int>();
        int value_2 = fixture.Create<int>();
        
        List<int> values = [value_1, value_2];

        // When
        ErrorResponse response = ErrorResponse.Create(code, message, values);

        // Then
        Assert.Equal(code, response.ErrorCode);
        Assert.Equal(message.Replace(ErrorResponse.ReferenceToVariable, string.Join(", ", values.GetStringsByGenericCollection())), 
                     response.ErrorMessage());
        Assert.Equal(string.Join(", ", values.GetStringsByGenericCollection()), response.ErrorValue);
        Assert.IsType<Guid>(response.ErrorId);
    }

    [Fact(DisplayName = "ERT-01.01.05: Create Invalid Operation Error. Mensage value in empty list")]
    public void CreateInvalidOperationError5()
    {
        // Given
        Fixture fixture = new();
        string code = fixture.Create<string>();
        string message = fixture.Create<string>() + ErrorResponse.ReferenceToVariable;
        
        List<int> values = [];

        // When
        ErrorResponse response = ErrorResponse.Create(code, message, values);

        // Then
        Assert.Equal(code, response.ErrorCode);
        Assert.Equal(message.Replace(ErrorResponse.ReferenceToVariable, 
        string.Join(", ", values.GetStringsByGenericCollection())), 
                     response.ErrorMessage());
        Assert.Equal(string.Join(", ", values.GetStringsByGenericCollection()), response.ErrorValue);
        Assert.IsType<Guid>(response.ErrorId);
    }

    [Fact(DisplayName = "ERT-01.01.06: Create Invalid Operation Error. Mensage value in empty list")]
    public void CreateInvalidOperationError6()
    {
        // Given
        Fixture fixture = new();
        string code = fixture.Create<string>();
        string message = fixture.Create<string>() + ErrorResponse.ReferenceToVariable;


        // When
        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        ErrorResponse response = ErrorResponse.Create<List<int>>(code, message, null);
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        // Then
        Assert.Equal(code, response.ErrorCode);
        Assert.Equal(message, response.ErrorMessage());
        Assert.IsType<Guid>(response.ErrorId);
    }
}