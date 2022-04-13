using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PageObject.Services;

public class WaitService
{
    private static IWebDriver? _driver;
    private static WebDriverWait _wait = null!;

    public WaitService(IWebDriver? driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.WaitTimeout));
    }

    public static IWebElement WaitElementVisible(By locator)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        return _driver!.FindElement(locator);
    }

    public static IWebElement WaitElementExist(By locator)
    {
        _wait.Until(ExpectedConditions.ElementExists(locator));
        return _driver!.FindElement(locator);
    }
}