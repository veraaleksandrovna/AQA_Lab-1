using System;
using OpenQA.Selenium;

namespace PageObject.Services;

public class BrowserService
{
    public BrowserService()
    {
        Driver = Configurator.BrowserType.ToLower() switch
        {
            "chrome" => new DriverFactory().GetChromeDriver(),
            "firefox" => new DriverFactory().GetFirefoxDriver(),
            _ => Driver
        };

        Driver.Manage().Window.Maximize();
        Driver.Manage().Cookies.DeleteAllCookies();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(0);
    }

    public IWebDriver? Driver { get; set; }
}