using CSharpLabs;

namespace TestProject;

public class UnitTestLab3
{
    [Theory]
    [InlineData(3, 10, new int[] {8, 3, 0, -4, -6, 12, -1}, new int[] {0, -4, -6, 8, 12, 3, -1})]
    [InlineData(10, -10, new int[] {0, -4, -6, 8, 12, 3, -1}, new int[] {0, -4, -6, 8, 12, 3, -1})]
    [InlineData(8, 8, new int[] {8, 0, 2, 0, 12, 3, -1}, new int[] {0, 2, 0, 8, 12, 3, -1})]
    public void TestRearrangeArray(int a, int b, int[] expected, int[] arr)
    {
        var l1 = new Lab1();
        int[] newArray = l1.RearrangeArray(a, b, arr);
        
        Assert.Equivalent(expected,newArray);
    }
    
    [Theory]
    [InlineData(4,0, -4, -6, 8, 12, 3, -1)]
    [InlineData(0,0, 0, 0, 0, 0, 0, 0)]
    [InlineData(4,-10, -4, -6, -8, -12, -3, -1)]
    [InlineData(0)]
    public void TestFindAbsMaxIndex(int expected, params int[] arr)
    {
        var l1 = new Lab1();
        int absMaxIndex = l1.FindAbsMaxIndex(arr);
        
        Assert.Equivalent(expected, absMaxIndex);
    }
    
    [Theory]
    [InlineData(14,0, -4, -6, 8, 12, 3, -1)]
    [InlineData(0,0, 0, 0, 0, 0, 0, 0)]
    [InlineData(0,0, 0, -6, -3, -4, -3, 1)]
    [InlineData(0)]
    public void TestFindSumAfterFirstPositive(int expected, params int[] arr)
    {
        var l1 = new Lab1();
        int sum = l1.FindSumAfterFirstPositive(arr);
        
        Assert.Equivalent(expected, sum);
    }
}