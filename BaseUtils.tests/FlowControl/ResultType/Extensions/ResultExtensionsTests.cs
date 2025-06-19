using BaseUtils.FlowControl.ErrorType;
using BaseUtils.FlowControl.ResultType;
using BaseUtils.FlowControl.ResultType.Extensions;

namespace BaseUtils.tests.FlowControl.ResultType.Extensions;

public class ResultExtensionsTests
{
    public class MockedDataOperation(int value)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Value { get; set; } = value;

        public Result SumNumber(int valueTosum)
        {
            Value += valueTosum;
            return Result.Success();
        }

        public Result DivideNumber(int number)
        {
            if (number == 0)
                return ErrorResponse.InvalidOperationError();
            Value /= number;

            return Result.Success();
        }
        public Result<MockedDataOperation> CloneWithMultiplyValue(int number)
        {
            return new MockedDataOperation(Value * number);
        }

        public Result<MockedDataOperation> CloneWithErrorValue()
        {
            return ErrorResponse.NotFoundError();
        }

        public Result IsBiggerThanZero()
        {
            return Value > 0 ? Result.Success() : ErrorResponse.InvalidOperationError();
        }
    }

    [Fact(DisplayName = "RET-01.01: Bind a result with sucess.")]
    public void ResultBindExtensionsTest1()
    {
        //given
        var number = Result<MockedDataOperation>.Success(new MockedDataOperation(1));

        // when
        var numberResult = number.Bind(n => n.CloneWithMultiplyValue(2));

        // then
        Assert.True(numberResult.IsSuccess);
        Assert.NotEqual(number.GetValue().Id, numberResult.GetValue().Id);
        Assert.Equal(2, numberResult.GetValue().Value);
    }

    [Fact(DisplayName = "RET-01.02: Bind a result with error.")]
    public void ResultBindExtensionsTest2()
    {
        //given
        var number = Result<MockedDataOperation>.Success(new MockedDataOperation(1));

        // when
        var numberResult = number.Bind(n => n.CloneWithErrorValue())
                                 .Bind(n => n.CloneWithMultiplyValue(2));

        // then
        Assert.True(numberResult.IsFailure);
    }

    [Fact(DisplayName = "RET-01.03: Bind a result with success and change type.")]
    public void ResultBindExtensionsTest3()
    {
        //given
        var number = Result<MockedDataOperation>.Success(new MockedDataOperation(1));

        // when
        var numberResult = number.Bind(n => n.SumNumber(3));

        // then
        Assert.True(numberResult.IsSuccess);
    }

    [Fact(DisplayName = "RET-01.04: Bind a result with success and change type.")]
    public void ResultBindExtensionsTest4()
    {
        //given
        var number = Result<MockedDataOperation>.Failure([ErrorResponse.InvalidOperationError()]);

        // when
        var numberResult = number.Bind(n => n.SumNumber(3));

        // then
        Assert.True(numberResult.IsFailure);
    }

    [Fact(DisplayName = "RET-01.05: Bind a result with success and change type.")]
    public void ResultBindExtensionsTest5()
    {
        //given
        var number = Result<MockedDataOperation>.Success(new MockedDataOperation(-4));

        // when
        var numberResult = number.Bind(n => n.IsBiggerThanZero());

        // then
        Assert.True(numberResult.IsFailure);
    }

    [Fact(DisplayName = "RET-02.01: Map a result.")]
    public void ResultMapExtensionsTest1()
    {
        var number = Result<MockedDataOperation>.Success(new MockedDataOperation(1));

        // when
        var numberResult = number.Map(n => n.SumNumber(2));

        // then
        Assert.True(numberResult.IsSuccess);
        Assert.Equal(number.GetValue().Id, numberResult.GetValue().Id);
        Assert.Equal(3, numberResult.GetValue().Value);
    }

    [Fact(DisplayName = "RET-02.02: Map a result failure.")]
    public void ResultMapExtensionsTest2()
    {
        var number = Result<MockedDataOperation>.Success(new MockedDataOperation(1));

        // when
        var numberResult = number.Map(n => n.DivideNumber(0)).Map(n => n.SumNumber(2));

        // then
        Assert.True(numberResult.IsFailure);
    }

    [Fact(DisplayName = "RET-02.03: Map a result failure.")]
    public void ResultMapExtensionsTest3()
    {
        var number = Result<MockedDataOperation>.Success(new MockedDataOperation(1));

        // when
        var numberResult = number.Map(n => n.DivideNumber(0)).Map(n => n.SumNumber(2));

        // then
        Assert.True(numberResult.IsFailure);
    }

    [Fact(DisplayName = "RET-02.04: Map a result failure.")]
    public void ResultMapExtensionsTest4()
    {
        // Given
        var number = Result<MockedDataOperation>.Failure([ErrorResponse.InvalidOperationError()]);

        // when
        var numberResult = number.Map(n => n.CloneWithErrorValue());

        // then
        Assert.True(numberResult.IsFailure);
    }

    [Fact(DisplayName = "RET-02.05: Map a result failure.")]
    public void ResultMapExtensionsTest5()
    {
        // Given
        var number = Result<MockedDataOperation>.Success(new MockedDataOperation(1));

        // when
        var numberResult = number.Map(n => n.CloneWithErrorValue());

        // then
        Assert.True(numberResult.IsFailure);
    }

    [Fact(DisplayName = "RET-02.06: Map a result failure.")]
    public void ResultMapExtensionsTest6()
    {
        // Given
        var number = Result<MockedDataOperation>.Success(new MockedDataOperation(1));

        // when
        var numberResult = number.Map(n => n.DivideNumber(0));

        // then
        Assert.True(numberResult.IsFailure);
    }
    
    [Fact(DisplayName = "RET-02.07: Map a result success.")]
    public void ResultMapExtensionsTest7()
    {
        // Given
        var number = Result<MockedDataOperation>.Success(new MockedDataOperation(1));

        // when
        var numberResult = number.Map(n => n.CloneWithMultiplyValue(2));

        // then
        Assert.True(numberResult.IsSuccess);
    }
}
