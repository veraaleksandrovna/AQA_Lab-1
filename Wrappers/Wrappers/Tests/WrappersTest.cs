using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Wrappers.Wrappers;

namespace Wrappers.Tests;

public class WrappersTest : BaseTest
{

    [Test]
    public void CheckBox_Test()
    {
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");

        CheckBox checkBox_1 = new CheckBox(Driver, By.XPath("//*[@id = 'checkboxes']/input[1]"));
        checkBox_1.Check();
        Thread.Sleep(2000);
        checkBox_1.Uncheck();
        Thread.Sleep(2000);
    }

    [Test]
    public void Table_Test()
    {
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/challenging_dom");

        Table table = new Table(Driver, By.TagName("table"));
        IWebElement cell_1 = table.GetElementFromCell("Lorem1", "Iuvaret0", "Diceret");
        IWebElement cell_2 = table.GetElementFromCell("Ipsum", "Apeirian7", "Amet");
        
        Assert.AreEqual("Phaedrum0", cell_1.Text.Normalize());
        Assert.AreEqual("Consequuntur7", cell_2.Text.Normalize());
    }
}