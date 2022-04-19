using OpenQA.Selenium;

namespace Wrappers.Pages;

public class HorizontalSliderPage: BasePage
{
    private const string EndPoint = "/horizontal_slider";
    
    public HorizontalSliderPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
