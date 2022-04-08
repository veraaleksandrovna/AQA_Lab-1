using System;
using AlertsWaits.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AlertsWaits.Tests;

public class BaseTest
{
    protected static IWebDriver _driver;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _driver = new BrowserService().Driver;
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
    }
    
    public static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}