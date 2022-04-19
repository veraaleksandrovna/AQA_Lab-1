using System;
using OpenQA.Selenium;

namespace Wrappers.Wrappers;

public class CheckBox
{
    private UIElement _uiElement;
    
    public CheckBox(IWebDriver driver, By locator)
    {
        _uiElement = new UIElement(driver, locator);
    }

    public string TagName => _uiElement.TagName;

    public bool Selected
    {
        get
        {
            try
            {
                return bool.Parse(_uiElement.GetAttribute("checked"));
            }
            catch (ArgumentNullException e)
            {
                return false;
            }
        }
    } 

    public bool Enabled => _uiElement.Enabled;
    public bool Displayed => _uiElement.Displayed;
    public ISearchContext GetShadowRoot() => _uiElement.GetShadowRoot();

    private void DoAction(bool flag)
    {
        if (Selected != flag)
        {
            _uiElement.Click();
        }
    }
    
    public void Check()
    {
        DoAction(true);
    }

    public void Uncheck()
    {
        DoAction(false);
    }
}