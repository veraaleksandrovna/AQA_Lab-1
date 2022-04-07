using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CheckoutCompletePage : BasePage
{
    private const string EndPoint = "/checkout-complete.html";
    
    private static readonly By TitleBy = By.ClassName("title");
    private static readonly By PonyExpressLogoBy = By.CssSelector("img[alt='Pony Express']");
    private static readonly By BackHomeButtonBy = By.CssSelector("button[data-test='back-to-products']");

    public CheckoutCompletePage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + EndPoint);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return Title.Text.Equals("Checkout: Complete!");
        }
        catch (NoSuchElementException e)
        {
            return false;
        }
    }

    public IWebElement Title => WaitService.WaitElementVisible(TitleBy);
    public IWebElement PonyExpressLogo => WaitService.WaitElementVisible(PonyExpressLogoBy);
    public IWebElement BackHomeButton => Driver.FindElement(BackHomeButtonBy);
}
