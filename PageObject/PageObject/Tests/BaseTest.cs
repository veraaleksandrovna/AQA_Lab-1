using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Services;
using PageObject.Steps;

namespace PageObject.Tests;

public class BaseTest
{
    protected IWebDriver? Driver;
    
    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        Driver = new BrowserService().Driver;
        LoginStep.LogIn(Driver);
    }
    
    [OneTimeTearDown]
    protected void OneTimeTearDown()
    {
        Driver!.Quit();
    }
}
