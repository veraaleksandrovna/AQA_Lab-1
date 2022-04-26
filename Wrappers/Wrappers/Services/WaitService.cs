using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Wrappers.Services.Configuration;

namespace Wrappers.Services
{
    public class WaitService
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _explicitWait;
        private readonly DefaultWait<IWebDriver> _fluentWait;

        public WaitService(IWebDriver driver)
        {
            _driver = driver;
            
            _explicitWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.WaitTimeout));
            
            _fluentWait = new DefaultWait<IWebDriver>(_driver)
            {
                Timeout = TimeSpan.FromSeconds(Configurator.WaitTimeout),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            _fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public IWebElement WaitUntilElementExists(By locator)
        {
            return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }
        
        public IWebElement WaitElementClickable(IWebElement webElement)
        {
            return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
        }
    }
}
