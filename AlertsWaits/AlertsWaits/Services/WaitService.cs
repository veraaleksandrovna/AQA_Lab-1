using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AlertsWaits.Services;

public class WaitService
{
    private IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private readonly DefaultWait<IWebDriver> _fluentWait;

    public WaitService(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.WaitTimeout));

        _fluentWait = new DefaultWait<IWebDriver>(_driver)
        {
            Timeout = TimeSpan.FromSeconds(Configurator.WaitTimeout),
            PollingInterval = TimeSpan.FromMilliseconds(250)
        };
        _fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
    }

    public IWebElement WaitElementIsVisible(By locator)
    {
        return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }

    public IWebElement WaitElementIsExists(By locator)
    {
        return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
    }

    public IWebElement WaitQuickElement(By locator)
    {
        return _fluentWait.Until(x => x.FindElement(locator));
    }
    
    public IWebElement GetVisibleElement(By by)
    {
        try
        {
            return _wait.Until(d => d.FindElement(by));
        }
        catch (Exception e)
        {
            throw new AssertionException(e.Message, e);
        }
    }
    
    public List<IWebElement> GetVisibleElements(By by)
    {
        try
        {
            return new List<IWebElement>(_wait.Until(d => d.FindElements(by)));
        }
        catch (Exception e)
        {
            throw new AssertionException(e.Message, e);
        }
    }

    public bool InvisibilityOfElementLocated(By by)
    {
        try
        {
            return !(_wait.Until(d => d.FindElement(by))).Displayed;
        }
        catch (NoSuchElementException e)
        {
            return true;
        }
        catch (StaleElementReferenceException e)
        {
            return true;
        }
    }
    
    public bool GetInvisibleElement(By by)
    {
        try
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
            
        }
        catch (Exception e)
        {
            throw new AssertionException(e.Message, e);
        }
    }
    
    public IReadOnlyCollection<IWebElement> WaitAllElementIsVisible(By by)
    {
        return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
    }
}
