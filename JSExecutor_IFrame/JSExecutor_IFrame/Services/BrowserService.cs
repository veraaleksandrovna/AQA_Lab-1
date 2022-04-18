using System;
using OpenQA.Selenium;

namespace JSExecutor_IFrame.Services;

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

        //Driver.Manage().Window.Maximize();
        Driver.Manage().Cookies.DeleteAllCookies();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }

    public IWebDriver Driver { get; set; }
}
