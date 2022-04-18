using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace JSExecutor_IFrame.Services;

public class WaitService
{
    private readonly DefaultWait<IWebDriver> _fluentWait;
    private readonly WebDriverWait _wait;
    private readonly IWebDriver _driver;

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
        return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public IReadOnlyCollection<IWebElement> WaitAllElementIsVisible(By by)
    {
        return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
    }

    public IWebElement WaitElementIsExists(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementExists(locator));
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

    public bool GetInvisibleElement(By by)
    {
        try
        {
            return _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));

            // return _wait.Until(d => d.FindElement(by));
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
            return !_wait.Until(d => d.FindElement(@by)).Displayed;
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
}