using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Locators.Tests;

public class CssSelectorsTests : BaseTest
{
    [Test]
    public void CssLocators_Display_Test()
    {
        Assert.Multiple(() =>
        {
            Assert.IsTrue(FindElement("span[id*='123']").Displayed);
            Assert.IsTrue(FindElement(".arrow").Displayed);
            Assert.IsTrue(FindElement("span[id='123']").Displayed);
            Assert.IsTrue(FindElement("h1>span").Displayed);
            Assert.IsTrue(FindElement("span[value^='12']").Displayed);
        });

        Console.Out.WriteLineAsync($"{FindElement("span[id*='123']").Text}");
        Console.Out.WriteLineAsync($"{FindElement(".arrow").Text}");
        Console.Out.WriteLineAsync($"{FindElement("[id='123']").Text}");
        Console.Out.WriteLineAsync($"{FindElement("h1>span").Text}");
        Console.Out.WriteLineAsync($"{FindElement("span[value^='12']").Text}");
    }

    private IWebElement FindElement(string selector)
    {
        return _driver.FindElement(By.CssSelector(selector));
    }
}
