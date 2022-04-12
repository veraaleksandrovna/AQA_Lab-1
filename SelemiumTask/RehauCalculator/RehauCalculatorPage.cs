using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SelemiumTask.RehauCalculator;

public class RehauCalculatorPage
{
    private readonly IWebDriver? _driver;

    private const string WidthValue = "4";
    private const string LengthValue = "6";
    private const string RoomTypeDropDownValue = "2";
    private const string HeatingTypeDropDownValue = "2";
    private const string WatLossValue = "150";

    public RehauCalculatorPage(IWebDriver? driver)
    {
        _driver = driver;
    }

    private static readonly By WidthBy = By.Id("el_f_width");
    private static readonly By LengthBy = By.Id("el_f_lenght");
    private static readonly By WatLosesBy = By.Id("el_f_losses");
    private static readonly By RoomTypeDropDownBy = By.Id("room_type");
    private static readonly By HeatingTypeDropDown = By.Id("heating_type");
    private static readonly By CountBy = By.ClassName("buttHFcalc");
    private static readonly By ActualFloorCablePowerBy = By.Id("floor_cable_power");
    private static readonly By ActualSecondFloorCablePowerBy = By.Id("spec_floor_cable_power");
    
    private IWebElement Width => _driver.FindElement(WidthBy);
    private IWebElement Length => _driver.FindElement(LengthBy);
    private IWebElement WatLoses => _driver.FindElement(WatLosesBy);
    private SelectElement RoomType => new(_driver.FindElement(RoomTypeDropDownBy));
    private SelectElement HeatingType => new(_driver.FindElement(HeatingTypeDropDown));
    private IWebElement Count => _driver.FindElement(CountBy);
    
    private IWebElement ActualFloorCablePower => _driver.FindElement(ActualFloorCablePowerBy);
    private IWebElement ActualactualSecondFloorCablePower => _driver.FindElement(ActualSecondFloorCablePowerBy);

    public RehauCalculatorPage WidthInputKey()
    {
        Width.SendKeys(WidthValue);
        return this;
    }

    public RehauCalculatorPage LengthInputKey()
    {
        Length.SendKeys(LengthValue);
        return this;
    }

    public RehauCalculatorPage WatLosesKey()
    {
        WatLoses.SendKeys(WatLossValue);
        return this;
    }

    public RehauCalculatorPage RoomTypeKey()
    {
        RoomType.SelectByValue(RoomTypeDropDownValue);
        return this;
    }

    public RehauCalculatorPage HeatingTypeKey()
    {
        HeatingType.SelectByValue(HeatingTypeDropDownValue);
        return this;
    }

    public void ClickCountButton()
    {
        Count.Click();
    }

    public string GetActualFirstValue()
    {
        return ActualFloorCablePower.GetAttribute("value");
    }
    
    public string GetActualSecondValue()
    {
        return ActualactualSecondFloorCablePower.GetAttribute("value");
    }
}
