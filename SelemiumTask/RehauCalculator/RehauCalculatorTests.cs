using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SelemiumTask.RehauCalculator;

public class RehauCalculatorTests
{
    private IWebDriver _driver;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _driver = new ChromeDriver();

        _driver.Navigate().GoToUrl(@"https://kermi-fko.ru/raschety/Calc-Rehau-Solelec.aspx");

        Console.WriteLine("Driver is initialized");
        Console.WriteLine("Page opened");
    }

    [Test]
    public void CalculatorRehauSmokeTest()
    {
        var width = _driver.FindElement(By.Id("el_f_width"));
        var length = _driver.FindElement(By.Id("el_f_lenght"));
        var watLoses = _driver.FindElement(By.Id("el_f_losses"));
        var roomType = _driver.FindElement(By.Id("room_type"));
        var heatingType = _driver.FindElement(By.Id("heating_type"));
        var count = _driver.FindElement(By.ClassName("buttHFcalc"));

        var roomTypeDropDown = new SelectElement(roomType);
        var heatingTypeDropDown = new SelectElement(heatingType);

        width.SendKeys("4");
        length.SendKeys("6");
        roomTypeDropDown.SelectByValue("2");
        heatingTypeDropDown.SelectByValue("2");
        watLoses.SendKeys("150");

        count.Click();

        Thread.Sleep(3000);

        var actualFloorCablePower = _driver.FindElement(By.Id("floor_cable_power"));
        var actualSecondFloorCablePower = _driver.FindElement(By.Id("spec_floor_cable_power"));

        Thread.Sleep(3000);

        Assert.AreEqual("158", actualFloorCablePower.GetAttribute("value"));
        Assert.AreEqual("7", actualSecondFloorCablePower.GetAttribute("value"));
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
        Console.WriteLine("Page closed");
    }
}
