using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CheckoutStepOnePage : BasePage
{
    private const string EndPoint = "/checkout-step-one.html";

    private static readonly By TitleBy = By.ClassName("title");
    private static readonly By FirstNameFieldBy = By.Id("first-name");
    private static readonly By LastNameFieldBy = By.Id("last-name");
    private static readonly By PostalCodeFieldBy = By.Id("postal-code");
    private static readonly By ContinueButtonBy = By.Id("continue");

    public CheckoutStepOnePage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public IWebElement Title => WaitService.WaitElementVisible(TitleBy);
    public IWebElement FirstNameInput => Driver.FindElement(FirstNameFieldBy);
    public IWebElement LastNameInput => Driver.FindElement(LastNameFieldBy);
    public IWebElement PostalCodeInput => Driver.FindElement(PostalCodeFieldBy);
    public IWebElement ContinueButton => Driver.FindElement(ContinueButtonBy);

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + EndPoint);
    }

    public override bool IsPageOpened()
    {
        try
        {
            return Title.Displayed;
        }
        catch (NoSuchElementException e)
        {
            return false;
        }
    }
}