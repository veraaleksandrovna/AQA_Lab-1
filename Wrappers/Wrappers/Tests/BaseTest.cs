using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Wrappers.Services;

namespace Wrappers.Tests;

public class BaseTest
{
    protected static IWebDriver _driver;
    
    [SetUp]
    public void SetUp()
    {
        _driver = new BrowserService().Driver;
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
    
    public static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}