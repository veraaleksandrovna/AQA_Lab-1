using System;
using JSExecutor_IFrame.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace JSExecutor_IFrame.Tests;

public class BaseTest
{
    protected static IWebDriver _driver;

    public static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }

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
}