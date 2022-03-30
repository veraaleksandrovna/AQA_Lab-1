using System;
using NUnit.Framework;
using NUnitPractice.CalculatorClass;

namespace NUnitPractice.CalculatorTest;

[TestFixture]
public class Tests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
        Console.Out.WriteLineAsync("Test is running...");
    }

    [Test]
    [Category("SmokeTest")]
    [TestCaseSource(typeof(CalculatorData), nameof(CalculatorData.AdditionMethodTestData))]
    public void AdditionMethodTest(int firstNumber, int secondNumber, int expectedResult)
    {
        TestContext.Out.WriteLineAsync("First number is " + firstNumber);
        TestContext.Out.WriteLineAsync("Second number is" + secondNumber);

        var actualResult = _calculator.Sum(firstNumber, secondNumber);
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    [Category("SmokeTest")]
    [TestCaseSource(typeof(CalculatorData), nameof(CalculatorData.DivideIntegerTestData))]
    public void DivideIntegerTest(int firstNumber, int secondNumber, int expectedResult)
    {
        TestContext.Out.WriteLineAsync("First number is " + firstNumber);
        TestContext.Out.WriteLineAsync("Second number is" + secondNumber);

        var actualResult = _calculator.Div(firstNumber, secondNumber);
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    [Category("SmokeTest")]
    [TestCase(int.MaxValue, 0)]
    [TestCase(int.MinValue, 0)]
    [TestCase(0, 0)]
    public void DivideByZeroIntegerTest(int firstNumber, int secondNumber)
    {
        Assert.Throws<DivideByZeroException>(delegate { _calculator.Div(firstNumber, secondNumber); });
    }

    [Test]
    [Category("SmokeTest")]
    [TestCaseSource(typeof(CalculatorData), nameof(CalculatorData.DivideDoubleTestData))]
    public void DivideDoubleTest(double firstNumber, double secondNumber, double expectedResult)
    {
        TestContext.Out.WriteLineAsync("First number is " + firstNumber);
        TestContext.Out.WriteLineAsync("Second number is" + secondNumber);

        var actualResult = _calculator.Div(firstNumber, secondNumber);
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    [Category("SmokeTest")]
    public void DivideByZeroDoubleTest()
    {
        Assert.True(Double.IsPositiveInfinity(_calculator.Div(Double.MaxValue, 0d)));
        Assert.IsTrue(Double.IsNegativeInfinity(_calculator.Div(Double.MinValue, 0d)));
        Assert.IsTrue(Double.IsNaN(_calculator.Div(0d, 0d)));
    }

    [TearDown]
    public void TearDown()
    {
        Console.Out.WriteLineAsync("TearDown....");
    }
}
