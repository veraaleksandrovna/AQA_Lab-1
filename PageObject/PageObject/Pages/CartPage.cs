using System;
using System.Collections.ObjectModel;
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

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + EndPoint);
    }

    protected override bool IsPageOpened()
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
    
    public IWebElement CheckoutButton => Driver.FindElement(CheckoutBy);
    
}
