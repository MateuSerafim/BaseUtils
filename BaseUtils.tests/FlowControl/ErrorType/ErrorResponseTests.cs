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
        string message = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError(message);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
        Assert.IsType<Guid>(response.ErrorId);
    }

    [Fact(DisplayName = "ERT-01.01.02: Create Invalid Operation Error. Null value.")]
    public void CreateInvalidOperationError2()
    {
        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError();

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(ErrorResponse.InvalidOperationDefaultMessage, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-01.01.03: Create Invalid Operation Error. Empty value.")]
    public void CreateInvalidOperationError3()
    {
        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError(string.Empty);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(ErrorResponse.InvalidOperationDefaultMessage, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-01.02.01: Create Invalid Operation Error. Int Mensage value")]
    public void CreateInvalidOperationError4()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
        Assert.Equal(Message, response.GetErrorMessageText());
    }

    [Fact(DisplayName = "ERT-01.02.02: Create Invalid Operation Error. Double Mensage value")]
    public void CreateInvalidOperationError5()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<double>();

        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-01.02.03: Create Invalid Operation Error. String Mensage value")]
    public void CreateInvalidOperationError6()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-01.02.04: Create Invalid Operation Error. List mensage value")]
    public void CreateInvalidOperationError7()
    {
        // Given
        List<int> value = [1, 2, 3];

        var valueToString = "1, 2, 3";

        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-01.02.05: Create Invalid Operation Error. Empty list mensage value")]
    public void CreateInvalidOperationError8()
    {
        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError(Message, new List<int>());

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(Message, response.ErrorMessage());
        Assert.Equal(string.Empty, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-01.02.06: Create Invalid Operation Error. dictionary mensage value")]
    public void CreateInvalidOperationError9()
    {
        // Given
        var value = new Dictionary<int, int>()
        {
            { 1, 2 }, {2, 3}, {3, 4}
        };
        var valueToString = "[1, 2], [2, 3], [3, 4]";

        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-01.02.07: Create Invalid Operation Error. Inenumerable mensage value")]
    public void CreateInvalidOperationError10()
    {
        // Given
        IEnumerable<int> value = [1, 2, 3];
        var valueToString = "1, 2, 3";

        // When
        ErrorResponse response = ErrorResponse.InvalidOperationError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-02.01.01: Create Invalid Type Error. Mensage value")]
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
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-02.01.02: Create Invalid Type Error. Null value.")]
    public void CreateInvalidTypeError2()
    {
        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError();

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(ErrorResponse.InvalidTypeDefaultMessage, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-02.01.03: Create Invalid Type Error. Empty value.")]
    public void CreateInvalidTypeError3()
    {
        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError(string.Empty);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(ErrorResponse.InvalidTypeDefaultMessage, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-02.02.01: Create Invalid Type Error. Int Mensage value")]
    public void CreateInvalidTypeError4()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
        Assert.Equal(Message, response.GetErrorMessageText());
    }

    [Fact(DisplayName = "ERT-02.02.02: Create Invalid Type Error. Double Mensage value")]
    public void CreateInvalidTypeError5()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<double>();

        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-02.02.03: Create Invalid Type Error. String Mensage value")]
    public void CreateInvalidTypeError6()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-02.02.04: Create Invalid Type Error. List mensage value")]
    public void CreateInvalidTypeError7()
    {
        // Given
        List<int> value = [1, 2, 3];

        var valueToString = "1, 2, 3";

        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-02.02.05: Create Invalid Type Error. Empty list mensage value")]
    public void CreateInvalidTypeError8()
    {
        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError(Message, new List<int>());

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(Message, response.ErrorMessage());
        Assert.Equal(string.Empty, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-02.02.06: Create Invalid Type Error. dictionary mensage value")]
    public void CreateInvalidTypeError9()
    {
        // Given
        var value = new Dictionary<int, int>()
        {
            { 1, 2 }, {2, 3}, {3, 4}
        };
        var valueToString = "[1, 2], [2, 3], [3, 4]";

        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-02.02.07: Create Invalid Type Error. Inenumerable mensage value")]
    public void CreateInvalidTypeError10()
    {
        // Given
        IEnumerable<int> value = [1, 2, 3];
        var valueToString = "1, 2, 3";

        // When
        ErrorResponse response = ErrorResponse.InvalidTypeError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-03.01.01: Create Not Found Error. Mensage value")]
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
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-03.01.02: Create Not Found Error. Null value.")]
    public void CreateNotFoundError2()
    {
        // When
        ErrorResponse response = ErrorResponse.NotFoundError();

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(ErrorResponse.NotFoundDefaultMessage, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-03.01.03: Create Not Found Error. Empty value.")]
    public void CreateNotFoundError3()
    {
        // When
        ErrorResponse response = ErrorResponse.NotFoundError(string.Empty);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(ErrorResponse.NotFoundDefaultMessage, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-03.02.01: Create Not Found Error. Int Mensage value")]
    public void CreateNotFoundError4()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        // When
        ErrorResponse response = ErrorResponse.NotFoundError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
        Assert.Equal(Message, response.GetErrorMessageText());
    }

    [Fact(DisplayName = "ERT-03.02.02: Create Not Found Error. Double Mensage value")]
    public void CreateNotFoundError5()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<double>();

        // When
        ErrorResponse response = ErrorResponse.NotFoundError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-03.02.03: Create Not Found Error. String Mensage value")]
    public void CreateNotFoundError6()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.NotFoundError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-03.02.04: Create Not Found Error. List mensage value")]
    public void CreateNotFoundError7()
    {
        // Given
        List<int> value = [1, 2, 3];

        var valueToString = "1, 2, 3";

        // When
        ErrorResponse response = ErrorResponse.NotFoundError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-03.02.05: Create Not Found Error. Empty list mensage value")]
    public void CreateNotFoundError8()
    {
        // When
        ErrorResponse response = ErrorResponse.NotFoundError(Message, new List<int>());

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(Message, response.ErrorMessage());
        Assert.Equal(string.Empty, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-03.02.06: Create Not Found Error. dictionary mensage value")]
    public void CreateNotFoundError9()
    {
        // Given
        var value = new Dictionary<int, int>()
        {
            { 1, 2 }, {2, 3}, {3, 4}
        };
        var valueToString = "[1, 2], [2, 3], [3, 4]";

        // When
        ErrorResponse response = ErrorResponse.NotFoundError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-03.02.07: Create Not Found Error. Inenumerable mensage value")]
    public void CreateNotFoundError10()
    {
        // Given
        IEnumerable<int> value = [1, 2, 3];
        var valueToString = "1, 2, 3";

        // When
        ErrorResponse response = ErrorResponse.NotFoundError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-04.01.01: Create No Access Error. Mensage value")]
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
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-04.01.02: Create No Access Error. Null value.")]
    public void CreateNoAccessError2()
    {
        // When
        ErrorResponse response = ErrorResponse.NoAccessError();

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(ErrorResponse.NoAccessDefaultMessage, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-04.01.03: Create No Access Error. Empty value.")]
    public void CreateNoAccessError3()
    {
        // When
        ErrorResponse response = ErrorResponse.NoAccessError(string.Empty);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(ErrorResponse.NoAccessDefaultMessage, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-04.02.01: Create No Access Error. Int Mensage value")]
    public void CreateNoAccessError4()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        // When
        ErrorResponse response = ErrorResponse.NoAccessError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
        Assert.Equal(Message, response.GetErrorMessageText());
    }

    [Fact(DisplayName = "ERT-04.02.02: Create No Access Error. Double Mensage value")]
    public void CreateNoAccessError5()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<double>();

        // When
        ErrorResponse response = ErrorResponse.NoAccessError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-04.02.03: Create No Access Error. String Mensage value")]
    public void CreateNoAccessError6()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.NoAccessError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-04.02.04: Create No Access Error. List mensage value")]
    public void CreateNoAccessError7()
    {
        // Given
        List<int> value = [1, 2, 3];

        var valueToString = "1, 2, 3";

        // When
        ErrorResponse response = ErrorResponse.NoAccessError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-04.02.05: Create No Access Error. Empty list mensage value")]
    public void CreateNoAccessError8()
    {
        // When
        ErrorResponse response = ErrorResponse.NoAccessError(Message, new List<int>());

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(Message, response.ErrorMessage());
        Assert.Equal(string.Empty, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-04.02.06: Create No Access Error. dictionary mensage value")]
    public void CreateNoAccessError9()
    {
        // Given
        var value = new Dictionary<int, int>()
        {
            { 1, 2 }, {2, 3}, {3, 4}
        };
        var valueToString = "[1, 2], [2, 3], [3, 4]";

        // When
        ErrorResponse response = ErrorResponse.NoAccessError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-04.02.07: Create No Access Error. Inenumerable mensage value")]
    public void CreateNoAccessError10()
    {
        // Given
        IEnumerable<int> value = [1, 2, 3];
        var valueToString = "1, 2, 3";

        // When
        ErrorResponse response = ErrorResponse.NoAccessError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-05.01.01: Create Critical Error. Mensage value")]
    public void CreateCriticalErrorError1()
    {
        // Given
        Fixture fixture = new();
        string message = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.CriticalError(message);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-05.01.02: Create Critical Error. Null value.")]
    public void CreateCriticalError2()
    {
        // When
        ErrorResponse response = ErrorResponse.CriticalError();

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(ErrorResponse.CriticalDefaultMessage, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-05.01.03: Create Critical Error. Empty value.")]
    public void CreateCriticalError3()
    {
        // When
        ErrorResponse response = ErrorResponse.CriticalError(string.Empty);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(ErrorResponse.CriticalDefaultMessage, response.ErrorMessage());
        Assert.Null(response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-05.02.01: Create Critical Error. Int Mensage value")]
    public void CreateCriticalError4()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        // When
        ErrorResponse response = ErrorResponse.CriticalError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
        Assert.Equal(Message, response.GetErrorMessageText());
    }

    [Fact(DisplayName = "ERT-05.02.02: Create Critical Error. Double Mensage value")]
    public void CreateCriticalError5()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<double>();

        // When
        ErrorResponse response = ErrorResponse.CriticalError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-05.02.03: Create Critical Error. String Mensage value")]
    public void CreateCriticalError6()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<string>();

        // When
        ErrorResponse response = ErrorResponse.CriticalError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, value.ToString()), 
                     response.ErrorMessage());
        Assert.Equal(value.ToString(), response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-05.02.04: Create Critical Error. List mensage value")]
    public void CreateCriticalError7()
    {
        // Given
        List<int> value = [1, 2, 3];

        var valueToString = "1, 2, 3";

        // When
        ErrorResponse response = ErrorResponse.CriticalError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-05.02.05: Create Critical Error. Empty list mensage value")]
    public void CreateCriticalError8()
    {
        // When
        ErrorResponse response = ErrorResponse.CriticalError(Message, new List<int>());

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(Message, response.ErrorMessage());
        Assert.Equal(string.Empty, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-05.02.06: Create Critical Error. dictionary mensage value")]
    public void CreateCriticalError9()
    {
        // Given
        var value = new Dictionary<int, int>()
        {
            { 1, 2 }, {2, 3}, {3, 4}
        };
        var valueToString = "[1, 2], [2, 3], [3, 4]";

        // When
        ErrorResponse response = ErrorResponse.CriticalError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

    [Fact(DisplayName = "ERT-05.02.07: Create Critical Error. Inenumerable mensage value")]
    public void CreateCriticalError10()
    {
        // Given
        IEnumerable<int> value = [1, 2, 3];
        var valueToString = "1, 2, 3";

        // When
        ErrorResponse response = ErrorResponse.CriticalError(Message, value);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(Message.Replace(ErrorResponse.ReferenceToVariable, valueToString), 
                     response.ErrorMessage());
        Assert.Equal(valueToString, response.ErrorValue);
    }

}