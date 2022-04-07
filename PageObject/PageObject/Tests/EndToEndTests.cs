using System.Linq;
using NUnit.Framework;
using PageObject.Pages;

namespace PageObject.Tests;

public class EndToEndTests : BaseTest
{
    private static readonly string FirstName = "vera";
    private static readonly string LastName = "vasjukevich";
    private static readonly string PostCode = "11111111";
    
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
        
        checkoutStepOnePage.FirstNameInput.SendKeys(FirstName);
        checkoutStepOnePage.LastNameInput.SendKeys(LastName);
        checkoutStepOnePage.PostalCodeInput.SendKeys(PostCode);
        checkoutStepOnePage.ContinueButton.Click();
        
        Assert.AreEqual("1", checkoutStepTwoPage.CartQuantityField.Text);
        Assert.IsTrue(checkoutStepTwoPage.SummaryValueLabelField.Displayed);

        checkoutStepTwoPage.FinishButton.Click();

        Assert.IsTrue(checkoutCompletePage.PonyExpressLogo.Displayed);

        checkoutCompletePage.BackHomeButton.Click();

        Assert.IsTrue(productsPage.Title.Displayed);
    }

}
