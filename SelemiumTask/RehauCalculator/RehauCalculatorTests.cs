using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SelemiumTask.BaseClasses;

namespace SelemiumTask.RehauCalculator;

public class RehauCalculatorTests : BaseTest
{
    private const string PathUrl = "https://kermi-fko.ru/raschety/Calc-Rehau-Solelec.aspx";
    
    private const string WidthValue = "4";
    private const string LengthValue = "6";
    private const string RoomTypeDropDownValue = "2";
    private const string HeatingTypeDropDownValue = "2";
    private const string WatLossValue = "150";
        
    private const string ExpectedFloorCablePower = "158";
    private const string ExpectedSecondFloorCablePower = "7";
    
    [Test]
    public void CalculatorRehau_Data_Test()
    {
        _driver.Navigate().GoToUrl(PathUrl);
        
        var width = _driver.FindElement(By.Id("el_f_width"));
        var length = _driver.FindElement(By.Id("el_f_lenght"));
        var watLoses = _driver.FindElement(By.Id("el_f_losses"));
        var roomType = _driver.FindElement(By.Id("room_type"));
        var heatingType = _driver.FindElement(By.Id("heating_type"));
        var count = _driver.FindElement(By.ClassName("buttHFcalc"));

        var roomTypeDropDown = new SelectElement(roomType);
        var heatingTypeDropDown = new SelectElement(heatingType);

        width.SendKeys(WidthValue);
        length.SendKeys(LengthValue);
        roomTypeDropDown.SelectByValue(RoomTypeDropDownValue);
        heatingTypeDropDown.SelectByValue(HeatingTypeDropDownValue);
        watLoses.SendKeys(WatLossValue);

        count.Click();

        Thread.Sleep(3000);

        var actualFloorCablePower = _driver.FindElement(By.Id("floor_cable_power"));
        var actualSecondFloorCablePower = _driver.FindElement(By.Id("spec_floor_cable_power"));

        Thread.Sleep(3000);

        Assert.AreEqual(ExpectedFloorCablePower, actualFloorCablePower.GetAttribute("value"));
        Assert.AreEqual(ExpectedSecondFloorCablePower, actualSecondFloorCablePower.GetAttribute("value"));
    }
}
