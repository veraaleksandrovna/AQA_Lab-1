using AlertsWaits.Services;
using OpenQA.Selenium;

namespace AlertsWaits.Pages;

public class VkPage : BasePage
{
    private static readonly By OnlinerTitleBy = By.XPath("//h1[contains(text(), 'onlíner')]");

    public readonly  IWebElement OnlinerTitle = Driver.FindElement(OnlinerTitleBy);

    public VkPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.VkUrl);
    }

    protected override bool IsPageOpened()
    {
        return OnlinerTitle.Displayed;
    }
}
