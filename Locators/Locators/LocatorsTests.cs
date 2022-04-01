using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators;

public class LocatorsTests
{
    private IWebDriver _driver;

    [OneTimeSetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(PathToFile.FilePath);
    }

    [Test]
    public void CssLocatorsTest()
    {
       Assert.IsTrue(_driver.FindElement(By.CssSelector("span[id*='123']")).Displayed);
       Assert.IsTrue(_driver.FindElement(By.CssSelector(".arrow")).Displayed);
       Assert.IsTrue(_driver.FindElement(By.CssSelector("span[id='123']")).Displayed);
       Assert.IsTrue(_driver.FindElement(By.CssSelector("h1>span")).Displayed);
       Assert.IsTrue(_driver.FindElement(By.CssSelector("span[value^='12']")).Displayed);

       Console.Out.WriteLineAsync($"{_driver.FindElement(By.CssSelector("span[id*='123']")).Text}");
       Console.Out.WriteLineAsync($"{_driver.FindElement(By.CssSelector(".arrow")).Text}");
       Console.Out.WriteLineAsync($"{_driver.FindElement(By.CssSelector("span[id='123']")).Text}");
       Console.Out.WriteLineAsync($"{_driver.FindElement(By.CssSelector("h1>span")).Text}");
       Console.Out.WriteLineAsync($"{_driver.FindElement(By.CssSelector("span[value^='12']")).Text}");
    }
    
    [Test]
    public void XPathTest()
    {
        Assert.IsTrue(_driver.FindElement(By.XPath("(//*[contains(text(),'Test')])[2]")).Displayed);
        Assert.IsTrue(_driver.FindElement(By.XPath("//*[contains(text(),'Test')][@ids]")).Displayed);
        Assert.IsTrue(_driver.FindElement(By.XPath("//*[contains(text(),'Title 2')]")).Displayed);
        Assert.IsTrue(_driver.FindElement(By.XPath("//h1/span[contains(text(),'Title 3')]")).Displayed);
        Assert.IsTrue(_driver.FindElement(By.XPath("(//div[contains(.//span, 'Title 2')]/descendant::span[@class='arrow'])[2]")).Displayed);
        
        Console.Out.WriteLineAsync($"{_driver.FindElement(By.XPath("(//*[contains(text(),'Test')])[2]")).Text}");
        Console.Out.WriteLineAsync($"{_driver.FindElement(By.XPath("//*[contains(text(),'Test')][@ids]")).Text}");
        Console.Out.WriteLineAsync($"{_driver.FindElement(By.XPath("//*[contains(text(),'Title 2')]")).Text}");
        Console.Out.WriteLineAsync($"{_driver.FindElement(By.XPath("//h1/span[contains(text(),'Title 3')]")).Text}");
        Console.Out.WriteLineAsync($"{_driver.FindElement(By.XPath("(//div[contains(.//span, 'Title 2')]/descendant::span[@class='arrow'])[2]")).Text}");
        
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
