using AutoFixture;
using BaseUtils.FlowControl.ErrorType;
using BaseUtils.Utils;

namespace BaseUtils.tests.Utils;

public class BaseUtilsTypeExtensionsTests
{
    [Fact(DisplayName = "BUET-01.01: Verify if object is collection. int value.")]
    public void IsGenericCollectionTest1()
    {                
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        // When
        var result = value.IsGenericCollection();

        // Then
        Assert.False(result);
    }

    [Fact(DisplayName = "BUET-01.02: Verify if object is collection. string value.")]
    public void IsGenericCollectionTest2()
    {                
        // Given
        Fixture fixture = new();
        var value = fixture.Create<string>();

        // When
        var result = value.IsGenericCollection();

        // Then
        Assert.False(result);
    }

    [Fact(DisplayName = "BUET-01.03: Verify if object is collection. null value.")]
    public void IsGenericCollectionTest3()
    {                
        // Given
        int? value = null;

        // When
        var result = value.IsGenericCollection();

        // Then
        Assert.False(result);
    }

    [Fact(DisplayName = "BUET-01.04: Verify if object is collection. list int value.")]
    public void IsGenericCollectionTest4()
    {                
        // Given
        List<int> value = [];

        // When
        var result = value.IsGenericCollection();

        // Then
        Assert.True(result);
    }

    [Fact(DisplayName = "BUET-01.05: Verify if object is collection. int array value.")]
    public void IsGenericCollectionTest5()
    {                
        // Given
        int[] value = [];

        // When
        var result = value.IsGenericCollection();

        // Then
        Assert.True(result);
    }
    
    [Fact(DisplayName = "BUET-01.06: Verify if object is collection. ienumerable int value.")]
    public void IsGenericCollectionTest6()
    {                
        // Given
        IEnumerable<int> value = [];

        // When
        var result = value.IsGenericCollection();

        // Then
        Assert.True(result);
    }

    [Fact(DisplayName = "BUET-01.07: Verify if object is collection. dictionary int value.")]
    public void IsGenericCollectionTest7()
    {                
        // Given
        Dictionary<int, int> value = [];

        // When
        var result = value.IsGenericCollection();

        // Then
        Assert.True(result);
    }

    [Fact(DisplayName = "BUET-02.01: get strings by collection. int value.")]
    public void GetStringsByGenericCollectionTest1()
    {                
        // Given
        Fixture fixture = new();

        int value = fixture.Create<int>();

        // When
        var result = value.GetStringsByGenericCollection();

        // Then
        Assert.Equal<string>(result, [value.ToString()]);
    }

    [Fact(DisplayName = "BUET-02.02: get strings by collection. string value.")]
    public void GetStringsByGenericCollectionTest2()
    {                
        // Given
        Fixture fixture = new();

        string value = fixture.Create<string>();

        // When
        var result = value.GetStringsByGenericCollection();

        // Then
        Assert.Equal<string>(result, [value.ToString()]);
    }

    [Fact(DisplayName = "BUET-02.03: get strings by collection. null value.")]
    public void GetStringsByGenericCollectionTest3()
    {                
        // Given
        int? value = null;

        // When
        var result = value.GetStringsByGenericCollection();

        // Then
        Assert.Equal<string>(result, []);
    }

    [Fact(DisplayName = "BUET-02.04: get strings by collection. list int value.")]
    public void GetStringsByGenericCollectionTest4()
    {                
        // Given
        List<int> value = [1, 2, 3];

        // When
        var result = value.GetStringsByGenericCollection();

        // Then
        Assert.Equal<string>(result, ["1", "2", "3"]);
    }

    [Fact(DisplayName = "BUET-02.05: get strings by collection. int array value.")]
    public void GetStringsByGenericCollectionTest5()
    {                
        // Given
        int[] value = [1, 2, 3];

        // When
        var result = value.GetStringsByGenericCollection();

        // Then
        Assert.Equal<string>(result, ["1", "2", "3"]);
    }

    [Fact(DisplayName = "BUET-02.06: get strings by collection. ienumerable value.")]
    public void GetStringsByGenericCollectionTest6()
    {                
        // Given
        IEnumerable<int> value = [1, 2, 3];

        // When
        var result = value.GetStringsByGenericCollection();

        // Then
        Assert.Equal<string>(result, ["1", "2", "3"]);
    }

    [Fact(DisplayName = "BUET-02.07: get strings by collection. dictionary value.")]
    public void GetStringsByGenericCollectionTest7()
    {                
        // Given
        Dictionary<int, int> value = new()
        {
            {1, 2}, {2, 3}, {3, 4}
        };

        // When
        var result = value.GetStringsByGenericCollection();

        // Then
        Assert.Equal<string>(result, ["[1, 2]", "[2, 3]", "[3, 4]"]);
    }

    [Fact(DisplayName = "BUET-02.08: get strings by collection. dictionary value.")]
    public void GetStringsByGenericCollectionTest8()
    {                
        // Given
        List<int?> value = [1, null, 3];

        // When
        var result = value.GetStringsByGenericCollection();

        // Then
        Assert.Equal<string>(result, ["1", "", "3"]);
    }

    [Fact(DisplayName = "BUET-03.01: is Response type. response type.")]
    public void IsErrorResponseTypeTest1()
    {
        // Given
        var error = ErrorResponse.InvalidOperationError();

        // When
        var result = error.IsErrorResponseType();

        // Then
        Assert.True(result);
    }

    [Fact(DisplayName = "BUET-03.02: is Response type. int type.")]
    public void IsErrorResponseTypeTest2()
    {
        // Given
        var error = 2;

        // When
        var result = error.IsErrorResponseType();

        // Then
        Assert.False(result);
    }

    [Fact(DisplayName = "BUET-03.03: is Response type. list error response type.")]
    public void IsErrorResponseTypeTest3()
    {
        // Given
        List<ErrorResponse> error = [ErrorResponse.InvalidOperationError()];

        // When
        var result = error.IsErrorResponseType();

        // Then
        Assert.True(result);
    }

    [Fact(DisplayName = "BUET-03.04: is Response type. list error response empty type.")]
    public void IsErrorResponseTypeTest4()
    {
        // Given
        List<ErrorResponse> error = [];

        // When
        var result = error.IsErrorResponseType();

        // Then
        Assert.True(result);
    }

    [Fact(DisplayName = "BUET-03.05: is Response type. list int type.")]
    public void IsErrorResponseTypeTest5()
    {
        // Given
        List<int> error = [2];

        // When
        var result = error.IsErrorResponseType();

        // Then
        Assert.False(result);
    }

    [Fact(DisplayName = "BUET-03.06: is Response type. empty list int type.")]
    public void IsErrorResponseTypeTest6()
    {
        // Given
        List<int> error = [];

        // When
        var result = error.IsErrorResponseType();

        // Then
        Assert.False(result);
    }
}