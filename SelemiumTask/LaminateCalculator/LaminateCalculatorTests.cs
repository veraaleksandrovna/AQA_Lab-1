using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SelemiumTask.LaminateCalculator;

public class LaminateCalculatorTests
{
    private const string ExpectedSLam = "145.04";
    private const string ExpectedLCount = "31";
    private const string ExpectedLPacks = "1";
    private const string ExpectedLPrice = "500000000";
    private const string ExpectedLOver = "69";
    private const string ExpectedLTrash = "7";

    private IWebDriver? _driver;
    private LaminateCalculatorPage? _laminateCalculatorPage;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _laminateCalculatorPage = new LaminateCalculatorPage(_driver);
        _driver.Navigate().GoToUrl(@"https://masterskayapola.ru/kalkulyator/laminata.html");
    }

    [Test]
    public void CalculationLaminateSmokeTest()
    {
        _laminateCalculatorPage
            .CalcLamWidthInputKey()
            .CalcLamHeightInputKey()
            .CalcRoomWidtInputhKey()
            .CalcRoomHeighInputtKey()
            .CalcInPackInputKey()
            .CalcPriceInputKey()
            .CalcDirectDropDownKey()
            .CalcBiasInputKey()
            .CalcWallDistInputKey()
            .ClickCalculationButton();

        Thread.Sleep(3000);

        var actualSLam = _laminateCalculatorPage.GetActualSLam();
        var actualLCount = _laminateCalculatorPage.GetActualLCount();
        var actualLPacks = _laminateCalculatorPage.GetActualLPacks();
        var actualLPrice = _laminateCalculatorPage.GetActualLPrice();
        var actualLOver = _laminateCalculatorPage.GetActualLOver();
        var actualLTrash = _laminateCalculatorPage.GetActualLTrash();

        Assert.AreEqual(ExpectedSLam, actualSLam);
        Assert.AreEqual(ExpectedLCount, actualLCount);
        Assert.AreEqual(ExpectedLPacks, actualLPacks);
        Assert.AreEqual(ExpectedLPrice, actualLPrice);
        Assert.AreEqual(ExpectedLOver, actualLOver);
        Assert.AreEqual(ExpectedLTrash, actualLTrash);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
