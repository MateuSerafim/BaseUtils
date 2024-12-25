using AutoFixture;
using BaseUtils.FlowControl.ErrorType;

namespace BaseUtils.tests.FlowControl.Response;

public class ErrorResponseTTests
{
    [Fact(DisplayName = "ER<T>T-01.01: Create Invalid Operation Error. Mensage value")]
    public void CreateInvalidOperationError1()
    {
        // Given
        Fixture fixture = new();
        string message = fixture.Create<string>();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.InvalidOperationError(message, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-01.02: Create Invalid Operation Error. Null message value.")]
    public void CreateInvalidOperationError2()
    {
        // Given
        Fixture fixture = new();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.InvalidOperationError(null, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(ErrorBase.InvalidOperationDefaultMessage, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-01.03: Create Invalid Operation Error. Empty value.")]
    public void CreateInvalidOperationError3()
    {     
        // Given
        Fixture fixture = new();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.InvalidOperationError("", errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(ErrorBase.InvalidOperationDefaultMessage, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-02.01: Create Invalid Type Error. Mensage value")]
    public void CreateInvalidTypeError1()
    {
        // Given
        Fixture fixture = new();
        string message = fixture.Create<string>();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.InvalidTypeError(message, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-02.02: Create Invalid Type Error. Null value.")]
    public void CreateInvalidTypeError2()
    {        
        // Given
        Fixture fixture = new();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.InvalidTypeError(null, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(ErrorBase.InvalidTypeDefaultMessage, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-02.03: Create Invalid Type Error. Empty value.")]
    public void CreateInvalidTypeError3()
    {        
        // Given
        Fixture fixture = new();
        int errorValue = fixture.Create<int>();
        
        // When
        ErrorResponse<int> response = ErrorResponse<int>.InvalidTypeError("", errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidTypeError, response.ErrorType);
        Assert.Equal(ErrorBase.InvalidTypeDefaultMessage, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-03.01: Create Not Found Error. Mensage value")]
    public void CreateNotFoundError1()
    {
        // Given
        Fixture fixture = new();
        string message = fixture.Create<string>();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.NotFoundError(message, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-03.02: Create Not Found Error. Null value.")]
    public void CreateNotFoundError2()
    {        
        // Given
        Fixture fixture = new();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.NotFoundError(null, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(ErrorBase.NotFoundDefaultMessage, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-03.03: Create Not Found Error. Empty value.")]
    public void CreateNotFoundError3()
    {         
        // Given
        Fixture fixture = new();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.NotFoundError("", errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.NotFoundError, response.ErrorType);
        Assert.Equal(ErrorBase.NotFoundDefaultMessage, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-04.01: Create No Access Error. Mensage value")]
    public void CreateNoAccessError1()
    {
        // Given
        Fixture fixture = new();
        string message = fixture.Create<string>();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.NoAccessError(message, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-04.02: Create No Access Error. Null value.")]
    public void CreateNoAccessError2()
    {                
        // Given
        Fixture fixture = new();
        int errorValue = fixture.Create<int>();
        
        // When
        ErrorResponse<int> response = ErrorResponse<int>.NoAccessError(null, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(ErrorBase.NoAccessDefaultMessage, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-04.03: Create No Access Error. Empty value.")]
    public void CreateNoAccessError3()
    {                
        // Given
        Fixture fixture = new();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.NoAccessError("", errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.NoAccessError, response.ErrorType);
        Assert.Equal(ErrorBase.NoAccessDefaultMessage, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-05.01: Create Critical Error. Mensage value")]
    public void CreateCriticalError1()
    {
        // Given
        Fixture fixture = new();
        string message = fixture.Create<string>();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.CriticalError(message, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(message, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-05.02: Create Critical Error. Null value.")]
    public void CreateCriticalError2()
    {            
        // Given
        Fixture fixture = new();
        int errorValue = fixture.Create<int>();   

        // When
        ErrorResponse<int> response = ErrorResponse<int>.CriticalError(null, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(ErrorBase.CriticalDefaultMessage, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-05.03: Create Critical Error. Empty value.")]
    public void CreateCriticalError3()
    {                
        // Given
        Fixture fixture = new();
        int errorValue = fixture.Create<int>();

        // When
        ErrorResponse<int> response = ErrorResponse<int>.CriticalError("", errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.CriticalError, response.ErrorType);
        Assert.Equal(ErrorBase.CriticalDefaultMessage, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-06.01.01: Create Error Response. int type.")]
    public void CreateErrorResponseIntegerType()
    {                
        // Given
        Fixture fixture = new();
        var errorValue = fixture.Create<int>();
        
        var errorMessage = $"This error is {ErrorResponse<int>.ReferenceToVariable} integer value.";
        var errorResult = errorMessage.Replace(ErrorResponse<int>.ReferenceToVariable, 
                                               errorValue.ToString());

        // When
        ErrorResponse<int> response = ErrorResponse<int>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(errorResult, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }
    
    [Fact(DisplayName = "ER<T>T-06.01.02: Create Error Response. double type.")]
    public void CreateErrorResponseDoubleType()
    {                
        // Given
        Fixture fixture = new();
        var errorValue = fixture.Create<double>();
        
        var errorMessage = $"This error is {ErrorResponse<double>.ReferenceToVariable} double value.";
        var errorResult = errorMessage.Replace(ErrorResponse<double>.ReferenceToVariable, 
                                               errorValue.ToString());

        // When
        ErrorResponse<double> response = 
        ErrorResponse<double>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(errorResult, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-06.01.03: Create Error Response. float type.")]
    public void CreateErrorResponseFloatType()
    {                
        // Given
        Fixture fixture = new();
        var errorValue = fixture.Create<float>();
        
        var errorMessage = $"This error is {ErrorResponse<float>.ReferenceToVariable} float value.";
        var errorResult = errorMessage.Replace(ErrorResponse<float>.ReferenceToVariable, 
                                               errorValue.ToString());

        // When
        ErrorResponse<float> response = 
        ErrorResponse<float>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(errorResult, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-06.01.04: Create Error Response. string type.")]
    public void CreateErrorResponseStringType()
    {                
        // Given
        Fixture fixture = new();
        var errorValue = fixture.Create<string>();
        
        var errorMessage = $"This error is {ErrorResponse<string>.ReferenceToVariable} string value.";
        var errorResult = errorMessage.Replace(ErrorResponse<string>.ReferenceToVariable, 
                                               errorValue.ToString());

        // When
        ErrorResponse<string> response = 
        ErrorResponse<string>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(ErrorTypeEnum.InvalidOperationError, response.ErrorType);
        Assert.Equal(errorResult, response.ErrorMessage());
        Assert.Equal(errorValue, response.ErrorValue);
    }

    [Fact(DisplayName = "ER<T>T-06.02.01: Create Error Response. integer list type.")]
    public void CreateErrorResponseListType1()
    {                
        // Given
                Fixture fixture = new();

        var error1 = fixture.Create<int>();
        var error2 = fixture.Create<int>();
        var error3 = fixture.Create<int>();

        List<int> errorValue = [error1, error2, error3];
        
        var errorMessage = $"This error is {ErrorResponse<List<int>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<List<int>>.ReferenceToVariable, 
                                               $"{error1}, {error2}, {error3}");

        // When
        ErrorResponse<List<int>> response = 
        ErrorResponse<List<int>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.02.02: Create Error Response. double list type.")]
    public void CreateErrorResponseListType2()
    {                
        // Given
        Fixture fixture = new();

        var error1 = fixture.Create<double>();
        var error2 = fixture.Create<double>();
        var error3 = fixture.Create<double>();

        List<double> errorValue = [error1, error2, error3];
        
        var errorMessage = $"This error is {ErrorResponse<List<double>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<List<double>>.ReferenceToVariable, 
                                               $"{error1}, {error2}, {error3}");

        // When
        ErrorResponse<List<double>> response = 
        ErrorResponse<List<double>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.02.03: Create Error Response. float list type.")]
    public void CreateErrorResponseListType3()
    {                
        // Given
        Fixture fixture = new();

        var error1 = fixture.Create<float>();
        var error2 = fixture.Create<float>();
        var error3 = fixture.Create<float>();

        List<float> errorValue = [error1, error2, error3];
        
        var errorMessage = $"This error is {ErrorResponse<List<float>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<List<float>>.ReferenceToVariable, 
                                               $"{error1}, {error2}, {error3}");

        // When
        ErrorResponse<List<float>> response = 
        ErrorResponse<List<float>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.02.04: Create Error Response. string list type.")]
    public void CreateErrorResponseListType4()
    {                
        // Given
        Fixture fixture = new();
        var error1 = fixture.Create<string>();
        var error2 = fixture.Create<string>();
        var error3 = fixture.Create<string>();

        List<string> errorValue = [error1, error2, error3];
        
        var errorMessage = $"This error is {ErrorResponse<List<string>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<List<string>>.ReferenceToVariable, 
                                               $"{error1}, {error2}, {error3}");

        // When
        ErrorResponse<List<string>> response = 
        ErrorResponse<List<string>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.02.05: Create Error Response. Empty string list type.")]
    public void CreateErrorResponseListType5()
    {                
        // Given
        List<string> errorValue = [];
        
        var errorMessage = $"This error is {ErrorResponse<List<string>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<List<string>>.ReferenceToVariable, "");

        // When
        ErrorResponse<List<string>> response = 
        ErrorResponse<List<string>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.02.06: Create Error Response. string list with one item type.")]
    public void CreateErrorResponseListType6()
    {                
        // Given
        Fixture fixture = new();
        var error1 = fixture.Create<string>();

        List<string> errorValue = [error1];
        
        var errorMessage = $"This error is {ErrorResponse<List<string>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<List<string>>.ReferenceToVariable, $"{error1}");

        // When
        ErrorResponse<List<string>> response = 
        ErrorResponse<List<string>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.02.07: Create Error Response. string list with null value item type.")]
    public void CreateErrorResponseListType7()
    {                
        // Given
        var errorMessage = $"This error is nullable list value.";

        // When
        ErrorResponse<List<string>> response = 
        ErrorResponse<List<string>>.InvalidOperationError(errorMessage, null);

        // Then
        Assert.Equal(errorMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.03.01: Create Error Response. integer array type.")]
    public void CreateErrorResponseArrayType1()
    {                
        // Given
        Fixture fixture = new();

        var error1 = fixture.Create<int>();
        var error2 = fixture.Create<int>();
        var error3 = fixture.Create<int>();

        int[] errorValue = [error1, error2, error3];
        
        var errorMessage = $"This error is {ErrorResponse<int[]>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<int[]>.ReferenceToVariable, 
                                               $"{error1}, {error2}, {error3}");

        // When
        ErrorResponse<int[]> response = 
        ErrorResponse<int[]>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.03.02: Create Error Response. integer array type (one item).")]
    public void CreateErrorResponseArrayType2()
    {                
        // Given
        Fixture fixture = new();

        var error1 = fixture.Create<int>();

        int[] errorValue = [error1];
        
        var errorMessage = $"This error is {ErrorResponse<int[]>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<int[]>.ReferenceToVariable, 
                                               $"{error1}");

        // When
        ErrorResponse<int[]> response = 
        ErrorResponse<int[]>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.03.03: Create Error Response. empty integer array type.")]
    public void CreateErrorResponseArrayType3()
    {                
        // Given
        int[] errorValue = [];
        
        var errorMessage = $"This error is {ErrorResponse<int[]>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<int[]>.ReferenceToVariable, "");

        // When
        ErrorResponse<int[]> response = 
        ErrorResponse<int[]>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.03.04: Create Error Response. null integer array type.")]
    public void CreateErrorResponseArrayType4()
    {                
        // Given
        var errorMessage = $"This error is null array list value.";

        // When
        ErrorResponse<int[]> response = ErrorResponse<int[]>.InvalidOperationError(errorMessage, null);

        // Then
        Assert.Equal(errorMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.04.01: Create Error Response. integer enumerable type.")]
    public void CreateErrorResponseEnumarableType1()
    {                
        // Given
        Fixture fixture = new();

        var error1 = fixture.Create<int>();
        var error2 = fixture.Create<int>();
        var error3 = fixture.Create<int>();

        IEnumerable<int> errorValue = [error1, error2, error3];
        
        var errorMessage = $"This error is {ErrorResponse<IEnumerable<int>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<IEnumerable<int>>.ReferenceToVariable, 
                                               $"{error1}, {error2}, {error3}");

        // When
        ErrorResponse<IEnumerable<int>> response = 
        ErrorResponse<IEnumerable<int>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.04.02: Create Error Response. integer enumerable type (one item).")]
    public void CreateErrorResponseEnumarableType2()
    {                
        // Given
        Fixture fixture = new();

        var error1 = fixture.Create<int>();

        IEnumerable<int> errorValue = [error1];
        
        var errorMessage = $"This error is {ErrorResponse<IEnumerable<int>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<IEnumerable<int>>.ReferenceToVariable, $"{error1}");

        // When
        ErrorResponse<IEnumerable<int>> response = 
        ErrorResponse<IEnumerable<int>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.04.03: Create Error Response. empty integer enumerable type.")]
    public void CreateErrorResponseEnumarableType3()
    {                
        // Given
        IEnumerable<int> errorValue = [];
        
        var errorMessage = $"This error is {ErrorResponse<IEnumerable<int>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<IEnumerable<int>>.ReferenceToVariable, string.Empty);

        // When
        ErrorResponse<IEnumerable<int>> response = 
        ErrorResponse<IEnumerable<int>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.04.04: Create Error Response. null integer enumerable type.")]
    public void CreateErrorResponseEnumarableType4()
    {                
        // Given
        var errorMessage = $"This error is null enumerable list value.";

        // When
        ErrorResponse<IEnumerable<int>> response = 
        ErrorResponse<IEnumerable<int>>.InvalidOperationError(errorMessage, null);

        // Then
        Assert.Equal(errorMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.05.01: Create Error Response. integer dictionary type.")]
    public void CreateErrorResponseDictionaryType1()
    {                
        // Given

        Dictionary<int, int> errorValue = new()
        {
            { 1, 2 }, {2, 3}, {3, 4}
        };
        
        var errorMessage = $"This error is {ErrorResponse<Dictionary<int, int>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<Dictionary<int, int>>.ReferenceToVariable, 
                           $"{errorValue.ElementAt(0)}, {errorValue.ElementAt(1)}, {errorValue.ElementAt(2)}");

        // When
        ErrorResponse<Dictionary<int, int>> response = 
        ErrorResponse<Dictionary<int, int>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.05.02: Create Error Response. integer dictionary type (one item).")]
    public void CreateErrorResponseDictionaryType2()
    {                
        // Given

        Dictionary<int, int> errorValue = new()
        {
            { 1, 2 }
        };
        
        var errorMessage = $"This error is {ErrorResponse<Dictionary<int, int>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<Dictionary<int, int>>.ReferenceToVariable, 
                           $"{errorValue.ElementAt(0)}");

        // When
        ErrorResponse<Dictionary<int, int>> response = 
        ErrorResponse<Dictionary<int, int>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.05.03: Create Error Response. empty integer dictionary type.")]
    public void CreateErrorResponseDictionaryType3()
    {                
        // Given

        Dictionary<int, int> errorValue = [];
        
        var errorMessage = $"This error is {ErrorResponse<Dictionary<int, int>>.ReferenceToVariable} list value.";
        var errorResult = errorMessage.Replace(ErrorResponse<Dictionary<int, int>>.ReferenceToVariable, string.Empty);

        // When
        ErrorResponse<Dictionary<int, int>> response = 
        ErrorResponse<Dictionary<int, int>>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorResult, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-06.05.04: Create Error Response. nullable integer dictionary type.")]
    public void CreateErrorResponseDictionaryType4()
    {                
        // Given
        var errorMessage = $"This error is null dictionary<int, int> list value.";

        // When
        ErrorResponse<Dictionary<int, int>> response = 
        ErrorResponse<Dictionary<int, int>>.InvalidOperationError(errorMessage, null);

        // Then
        Assert.Equal(errorMessage, response.ErrorMessage());
    }

    [Fact(DisplayName = "ER<T>T-07.01: Get message struct.")]
    public void GetErrorMessageStruct()
    {                
        // Given
        Fixture fixture = new();
        var errorValue = fixture.Create<int>();
        
        var errorMessage = $"This error is {ErrorResponse<int>.ReferenceToVariable} integer value.";
        var errorResult = errorMessage.Replace(ErrorResponse<int>.ReferenceToVariable, 
                                               errorValue.ToString());

        // When
        ErrorResponse<int> response = ErrorResponse<int>.InvalidOperationError(errorMessage, errorValue);

        // Then
        Assert.Equal(errorMessage, response.GetErrorMessageStruct());
        Assert.Equal(errorResult, response.ErrorMessage());
    }
}
