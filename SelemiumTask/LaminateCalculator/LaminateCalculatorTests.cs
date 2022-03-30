using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SelemiumTask.LaminateCalculator;

public class LaminateCalculatorTests
{
    private IWebDriver _driver;
    private LaminateCalculatorPage _laminateCalculatorPage;

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

        Assert.AreEqual("145.04", actualSLam);
        Assert.AreEqual("31", actualLCount);
        Assert.AreEqual("1", actualLPacks);
        Assert.AreEqual("500000000", actualLPrice);
        Assert.AreEqual("69", actualLOver);
        Assert.AreEqual("7", actualLTrash);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
