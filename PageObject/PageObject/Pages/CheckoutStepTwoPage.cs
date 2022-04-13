using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CheckoutStepTwoPage : BasePage
{
    private const string EndPoint = "/checkout-step-two.html";

    private static readonly By TitleBy = By.ClassName("title");
    private static readonly By ItemsListBy = By.ClassName("inventory_item_name");
    private static readonly By FinishButtonBy = By.CssSelector("button[data-test='finish']");
    private static readonly By CartQuantityBy = By.ClassName("cart_quantity");
    private static readonly By SummaryValueLabelBy = By.ClassName("summary_value_label");

    public CheckoutStepTwoPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public IWebElement Title => WaitService.WaitElementVisible(TitleBy);
    public IWebElement FinishButton => Driver.FindElement(FinishButtonBy);
    public IWebElement CartQuantityField => Driver.FindElement(CartQuantityBy);
    public IWebElement SummaryValueLabelField => Driver.FindElement(SummaryValueLabelBy);

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