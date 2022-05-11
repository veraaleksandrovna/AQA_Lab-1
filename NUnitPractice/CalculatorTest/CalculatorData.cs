using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitPractice.CalculatorTest;

public class CalculatorData
{
    public static IEnumerable<TestCaseData> AdditionMethodTestData
    {
        get
        {
            yield return new TestCaseData(-10000000, -1234567890, -1244567890);
            yield return new TestCaseData(123456789, 987654321, 1111111110);
            yield return new TestCaseData(0, 0, 0);
            yield return new TestCaseData(-1000, 1000, 0);
            yield return new TestCaseData(-100, 200, 100);
        }
    }

    public static IEnumerable<TestCaseData> DivideIntegerTestData
    {
        get
        {
            yield return new TestCaseData(12344, 2, 6172);
            yield return new TestCaseData(-12344, -2, 6172);
            yield return new TestCaseData(12344, -2, -6172);
            yield return new TestCaseData(-12344, 2, -6172);
            yield return new TestCaseData(0, 123578, 0);

        }
    }
    
    public static IEnumerable<TestCaseData> DivideDoubleTestData
    {
        get
        {
            yield return new TestCaseData(12344.222, 2, 6172.111);
            yield return new TestCaseData(-12344.222, -2, 6172.111);
            yield return new TestCaseData(10000d, -2d, -5000d);
            yield return new TestCaseData(-100000d, 2d, -50000d);
            yield return new TestCaseData(0d, 1000000d, 0d);

        }
    }
}
