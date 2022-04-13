using NUnit.Framework;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Tests;

public class EndToEndTests : BaseTest
{
    [Test]
    public void EndToEndTest()
    {
        var productsPage = new InventoryPage(_driver, false);
        var cartPage = new CartPage(_driver, false);
        var checkoutStepOnePage = new CheckoutStepOnePage(_driver, false);
        var checkoutStepTwoPage = new CheckoutStepTwoPage(_driver, false);
        var checkoutCompletePage = new CheckoutCompletePage(_driver, false);

        productsPage.AddToCartBikelightButton.Click();
        productsPage.AddToCartBackpackButton.Click();
        productsPage.AddToCartJacketButton.Click();
        productsPage.ShoppingCartBadge.Click();
        
        cartPage.CheckoutButton.Click();
        
        checkoutStepOnePage.FirstNameInput.SendKeys(ConfiguratorCustomerInfo.Name);
        checkoutStepOnePage.LastNameInput.SendKeys(ConfiguratorCustomerInfo.LastName);
        checkoutStepOnePage.PostalCodeInput.SendKeys(ConfiguratorCustomerInfo.ZipCode);
        checkoutStepOnePage.ContinueButton.Click();
        
        Assert.AreEqual("1", checkoutStepTwoPage.CartQuantityField.Text);
        Assert.IsTrue(checkoutStepTwoPage.SummaryValueLabelField.Displayed);

        checkoutStepTwoPage.FinishButton.Click();

        Assert.IsTrue(checkoutCompletePage.PonyExpressLogo.Displayed);

        checkoutCompletePage.BackHomeButton.Click();

        Assert.IsTrue(productsPage.Title.Displayed);
    }

}
