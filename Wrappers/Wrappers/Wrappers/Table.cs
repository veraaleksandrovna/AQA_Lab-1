using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Wrappers.Wrappers;

public class Table
{
    private UIElement _uiElement;
    private IWebDriver _driver;

    public Table(IWebDriver driver, By @by)
    {
        _driver = driver;
        _uiElement = new UIElement(driver, by);
    }

    public ReadOnlyCollection<IWebElement> GetHeaders => _uiElement.FindElements(By.TagName("th"));
    public ReadOnlyCollection<IWebElement> GetRows => _uiElement.FindElements(By.XPath("//tbody/tr"));
    public ReadOnlyCollection<IWebElement> GetCells(IWebElement row) => row.FindElements(By.TagName("td"));

    public UIElement GetElementFromCell(string headerName, string columnValue, string targetHeaderName)
    {
        var index = GetHeaders.TakeWhile(header => !header.Text.Normalize().Equals(headerName)).Count();
        var targetIndex = GetHeaders.TakeWhile(header => !header.Text.Normalize().Equals(targetHeaderName)).Count();

        if (index > GetHeaders.Count)
        {
            throw new AssertionException("ddd");
        }
        
        foreach (var row in GetRows)
        {
            var cells = GetCells(row);
            if (cells[index].Text.Normalize().Equals(columnValue))
            {
                return new UIElement(_driver, cells[targetIndex]);
            }
        }

        return null;
    }
}