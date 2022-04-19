using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using Wrappers.Services;

namespace Wrappers.Wrappers;

public class UIElement : IWebElement
{
    private By _locator;
    private IWebDriver _driver;
    private readonly IWebElement _webElement;
    private readonly WaitService _waitService;

    public UIElement(IWebDriver driver, By locator)
    {
        _locator = locator;
        _driver = driver;
        _waitService = new WaitService(_driver);
        _webElement = _waitService.WaitElementIsExists(_locator);
    }

    public UIElement(IWebDriver driver, IWebElement webElement)
    {
        _driver = driver;
        _waitService = new WaitService(_driver);
        _webElement = webElement;
    }

    public UIElement FindUIElement(By @by)
    {
        return new UIElement(_driver, _webElement.FindElement(by));
    }

    public IWebElement FindElement(By @by)
    {
        return _webElement.FindElement(by);
    }

    public ReadOnlyCollection<IWebElement> FindElements(By @by)
    {
        return _webElement.FindElements(by);
    }

    public void Clear()
    {
        _webElement.Clear();
    }

    public void SendKeys(string text)
    {
        _webElement.SendKeys(text);
    }

    public void Submit()
    {
        _webElement.Submit();
    }

    public void Click()
    {
        _waitService.WaitElementIsClickable(_webElement).Click();
    }

    public string GetAttribute(string attributeName)
    {
        return _webElement.GetAttribute(attributeName);
    }

    public string GetDomAttribute(string attributeName)
    {
        return _webElement.GetDomAttribute(attributeName);
    }

    public string GetProperty(string propertyName)
    {
        return _webElement.GetProperty(propertyName);
    }

    public string GetDomProperty(string propertyName)
    {
        return _webElement.GetDomProperty(propertyName);
    }

    public string GetCssValue(string propertyName)
    {
        return _webElement.GetCssValue(propertyName);
    }

    public ISearchContext GetShadowRoot()
    {
        return _webElement.GetShadowRoot();
    }

    public string TagName { get; set; }
    public string Text { get; set; }
    public bool Enabled { get; set; }
    public bool Selected { get; set; }
    public Point Location { get; set; }
    public Size Size { get; set; }
    public bool Displayed { get; set; }
}