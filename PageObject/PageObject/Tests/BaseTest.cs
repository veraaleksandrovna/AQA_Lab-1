using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Services;
using PageObject.Steps;

namespace PageObject.Tests;

public class BaseTest
{
    protected IWebDriver? Driver;

    protected LoginStep LoginStep;

    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        Driver = new BrowserService().Driver;
        LoginStep = new LoginStep(Driver);
    }

    [OneTimeTearDown]
    protected void OneTimeTearDown()
    {
        Driver!.Quit();
    }
}
