using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class InventoryPage : BasePage
{
    private const string EndPoint = "/inventory.html";

    private static readonly By TitleBy = By.ClassName("title");
    private static readonly By AddToCartBackPackBy = By.Id("add-to-cart-sauce-labs-backpack");
    private static readonly By AddToCartBikelightBy = By.Id("add-to-cart-sauce-labs-bike-light");
    private static readonly By AddToCartJacketBy = By.Id("add-to-cart-sauce-labs-fleece-jacket");
    private static readonly By ShoppingCartBadgeBy = By.ClassName("shopping_cart_badge");

    public InventoryPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return Title.Displayed;
        }
        catch (NoSuchElementException e)
        {
            return false;
        }
    }

    public IWebElement Title => Driver.FindElement(TitleBy);
    public IWebElement AddToCartBackpackButton => Driver.FindElement(AddToCartBackPackBy);
    public IWebElement AddToCartBikelightButton => Driver.FindElement(AddToCartBikelightBy);
    public IWebElement AddToCartJacketButton => Driver.FindElement(AddToCartJacketBy);
    public IWebElement ShoppingCartBadge => Driver.FindElement(ShoppingCartBadgeBy);
}
