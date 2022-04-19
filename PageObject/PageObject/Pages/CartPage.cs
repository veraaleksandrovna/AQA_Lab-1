using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CartPage : BasePage
{
    private const string EndPoint = "/cart.html";

    private static readonly By CheckoutBy = By.Name("checkout");

    public CartPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public IWebElement CheckoutButton => Driver.FindElement(CheckoutBy);

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + EndPoint);
    }

    public override bool IsPageOpened()
    {
        try
        {
            return CheckoutButton.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}