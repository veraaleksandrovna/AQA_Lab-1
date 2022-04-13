using AlertsWaits.Services;
using OpenQA.Selenium;

namespace AlertsWaits.Pages;

public class TwitterPage : BasePage
{
    private static readonly By OnlinerTitleBy = By.XPath("(//span[contains(text(), 'onlíner')]) [1]");
    private static readonly By TwitterLogoBy = By.CssSelector("h1[role = 'heading']");
    
    public TwitterPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.TwitterUrl);
    }

    protected override bool IsPageOpened()
    {
        return OnlinerTitle.Displayed;
    }
    
    public IWebElement OnlinerTitle = Driver.FindElement(OnlinerTitleBy);
    public IWebElement TwitterLogo = WaitService.WaitElementIsExists(TwitterLogoBy);
}
