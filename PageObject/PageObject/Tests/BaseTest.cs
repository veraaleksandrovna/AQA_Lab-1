using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Services;
using PageObject.Steps;

namespace PageObject.Tests;

public class BaseTest
{
    protected IWebDriver? _driver;
    
    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        _driver = new BrowserService().Driver;
        LoginStep.LogIn(_driver);
    }
    
    [OneTimeTearDown]
    protected void OneTimeTearDown()
    {
        _driver!.Quit();
    }
}
