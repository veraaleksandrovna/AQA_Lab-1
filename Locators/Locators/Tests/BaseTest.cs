using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators.Tests;

public class BaseTest
{
    protected IWebDriver _driver;

    [OneTimeSetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(PathToFile.FilePath);
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
