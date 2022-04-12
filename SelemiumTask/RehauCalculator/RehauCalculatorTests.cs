using NUnit.Framework;
using SelemiumTask.BaseClasses;

namespace SelemiumTask.RehauCalculator;

public class RehauCalculatorTests : BaseTest
{
    private const string PathUrl = "https://kermi-fko.ru/raschety/Calc-Rehau-Solelec.aspx";

    private const string ExpectedFloorCablePower = "158";
    private const string ExpectedSecondFloorCablePower = "7";
    
    [Test]
    public void TestCalculatorRehau()
    {
        _driver.Navigate().GoToUrl(PathUrl);
        var rehauCalculatorPage = new RehauCalculatorPage(_driver);

        rehauCalculatorPage
            .WidthInputKey()
            .LengthInputKey()
            .WatLosesKey()
            .RoomTypeKey()
            .HeatingTypeKey()
            .ClickCountButton();
        
        Assert.Multiple(() =>
        {
            Assert.AreEqual(ExpectedFloorCablePower, rehauCalculatorPage.GetActualFirstValue());
            Assert.AreEqual(ExpectedSecondFloorCablePower, rehauCalculatorPage.GetActualSecondValue());
        });
    }
}
