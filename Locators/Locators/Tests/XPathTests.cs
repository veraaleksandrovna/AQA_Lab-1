using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Locators.Tests;

public class XPathTests : BaseTest
{
    [Test]
    public void XPath_Display_Test()
    {
        Assert.Multiple(() =>
        {
            Assert.IsTrue(FindElement("(//*[contains(text(),'Test')])[2]").Displayed);
            Assert.IsTrue(FindElement("//*[text() ='Test'][@ids]").Displayed);
            Assert.IsTrue(FindElement("//*[contains(text(),'Title 2')]").Displayed);
            Assert.IsTrue(FindElement("//*[normalize-space() ='Title 3']/ancestor::h1").Displayed);
            Assert.IsTrue(FindElement("(//div[contains(.//span, 'Title 2')]/descendant::span[@class='arrow'])[2]")
                .Displayed);
        });

        Console.Out.WriteLineAsync($"{FindElement("(//*[contains(text(),'Test')])[2]").Text}");
        Console.Out.WriteLineAsync($"{FindElement("//*[text() ='Test'][@ids]").Text}");
        Console.Out.WriteLineAsync($"{FindElement("//*[contains(text(),'Title 2')]").Text}");
        Console.Out.WriteLineAsync($"{FindElement("//*[normalize-space() ='Title 3']/ancestor::h1").Text}");
        Console.Out.WriteLineAsync($"{FindElement("(//div[contains(.//span, 'Title 2')]/descendant::span[@class='arrow'])[2]").Text}");
    }

    private IWebElement FindElement(string xpath)
    {
        return _driver.FindElement(By.XPath(xpath));
    }
}
