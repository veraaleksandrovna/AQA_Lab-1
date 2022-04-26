using System;
using OpenQA.Selenium;
using Wrappers.Services.Configuration;

namespace Wrappers.Services
{
    public class BrowserService
    {
        private readonly IWebDriver _driver;

        public IWebDriver Driver { get; set; }

        public BrowserService()
        {
            Driver = Configurator.BrowserType switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                "firefox" => new DriverFactory().GetFirefoxDriver(),
                _ => null
            };
            
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
