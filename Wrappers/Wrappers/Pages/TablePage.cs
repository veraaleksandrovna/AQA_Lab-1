using OpenQA.Selenium;

namespace Wrappers.Pages;

public class TablePage:BasePage
{
    private const string EndPoint = "/challenging_dom";
    
    public TablePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        throw new System.NotImplementedException();
    }

    protected override bool IsPageOpened()
    {
        throw new System.NotImplementedException();
    }
}
