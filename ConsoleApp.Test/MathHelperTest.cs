using ConsoleApp.TestData;
using Xunit.Abstractions;

namespace ConsoleApp.Test;

public class MathHelperTest
{
    private ITestOutputHelper _outputHelper;

    public MathHelperTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory(Skip="برای آموزش فعلا این بخش رو غیر فعال می‌کنم")]
    [Trait("Service", "Cart")]
    [InlineData(10,15,25)]
    [InlineData(-5,-5,-10)]
    [InlineData(1000,5000,6000)]
    public void JamTest(int x,int y,int expected)
    {
        var mathHelper=new MathHelper();

        var result=mathHelper.Jam(x,y);

        Assert.Equal(expected, result);
        Assert.IsType<int>(result);
    }

    [Theory]
    [Trait("Service", "Order")]
    [MemberData(nameof(DataForTest.GetData),MemberType=typeof(DataForTest))]
    public void Jam_MemberData_Test(int x,int y,int expected)
    {
        var mathHelper=new MathHelper();

        var result=mathHelper.Jam(x,y);

        Assert.Equal(expected, result);
        Assert.IsType<int>(result);
    }

    [Theory]
    [Trait("Endpoint", "Order")]
    [ClassData(typeof(MemberClassData))]
    public void Jam_ClassData_Test(int x,int y,int expected)
    {
        var mathHelper=new MathHelper();

        var result=mathHelper.Jam(x,y);

        _outputHelper.WriteLine("This is a test");
        _outputHelper.WriteLine(x.ToString());

        Assert.Equal(expected, result);
        Assert.IsType<int>(result);
    }
}