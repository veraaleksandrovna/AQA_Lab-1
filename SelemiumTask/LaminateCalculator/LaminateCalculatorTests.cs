using System.Threading;
using NUnit.Framework;
using SelemiumTask.BaseClasses;

namespace SelemiumTask.LaminateCalculator;

public class LaminateCalculatorTests : BaseTest
{
    private const string PathUrl = "https://masterskayapola.ru/kalkulyator/laminata.html";

    private const string ExpectedSLam = "145.04";
    private const string ExpectedLCount = "31";
    private const string ExpectedLPacks = "1";
    private const string ExpectedLPrice = "500000000";
    private const string ExpectedLOver = "69";
    private const string ExpectedLTrash = "7";

    [Test]
    public void TestLaminateCalculator()
    {
        _driver.Navigate().GoToUrl(PathUrl);
        var _laminateCalculatorPage = new LaminateCalculatorPage(_driver);

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

        var actualSLam = _laminateCalculatorPage.GetActualSLam();
        var actualLCount = _laminateCalculatorPage.GetActualLCount();
        var actualLPacks = _laminateCalculatorPage.GetActualLPacks();
        var actualLPrice = _laminateCalculatorPage.GetActualLPrice();
        var actualLOver = _laminateCalculatorPage.GetActualLOver();
        var actualLTrash = _laminateCalculatorPage.GetActualLTrash();
        
        Assert.Multiple(() =>
        {
            Assert.AreEqual(ExpectedSLam, actualSLam);
            Assert.AreEqual(ExpectedLCount, actualLCount);
            Assert.AreEqual(ExpectedLPacks, actualLPacks);
            Assert.AreEqual(ExpectedLPrice, actualLPrice);
            Assert.AreEqual(ExpectedLOver, actualLOver);
            Assert.AreEqual(ExpectedLTrash, actualLTrash);
        });
    }
}
