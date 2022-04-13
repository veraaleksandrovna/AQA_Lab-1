using AlertsWaits.Services;
using OpenQA.Selenium;

namespace AlertsWaits.Pages;

public class FacebookPage : BasePage
{
    private static readonly By TitleBy = By.TagName("h1");

    public FacebookPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.FacebookUrl);
    }

    protected override bool IsPageOpened()
    {
        return Title.Displayed;
    }
    public IWebElement Title => WaitService.WaitElementIsExists(TitleBy);
}
