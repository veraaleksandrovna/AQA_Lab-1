using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Tests;

[TestFixture]
[AllureNUnit]
[AllureSuite("E2E Test")]
public class EndToEndTests : BaseTest
{
    [Test]
    [AllureTag("StandardUser")]
    public void EndToEndTest()
    {
        LoginStep.Login(UsersConfigurator.StandardUserName, UsersConfigurator.Password);
        
        var productsPage = new InventoryPage(Driver, false);
        var cartPage = new CartPage(Driver, false);
        var checkoutStepOnePage = new CheckoutStepOnePage(Driver, false);
        var checkoutStepTwoPage = new CheckoutStepTwoPage(Driver, false);
        var checkoutCompletePage = new CheckoutCompletePage(Driver, false);

        productsPage.AddToCartBikelightButton.Click();
        productsPage.AddToCartBackpackButton.Click();
        productsPage.AddToCartJacketButton.Click();
        productsPage.ShoppingCartBadge.Click();

        cartPage.CheckoutButton.Click();

        checkoutStepOnePage.FirstNameInput.SendKeys(UsersConfigurator.FirstName);
        checkoutStepOnePage.LastNameInput.SendKeys(UsersConfigurator.LastName);
        checkoutStepOnePage.PostalCodeInput.SendKeys(UsersConfigurator.PostalCode);
        checkoutStepOnePage.ContinueButton.Click();

        var textActualResult = checkoutStepTwoPage.CartQuantityField.Text;
        
        textActualResult.Should().BeEquivalentTo("1");
        checkoutStepTwoPage.SummaryValueLabelField.Displayed.Should().BeTrue();
        
            
        checkoutStepTwoPage.FinishButton.Click();

        checkoutCompletePage.PonyExpressLogo.Displayed.Should().BeTrue();

        checkoutCompletePage.BackHomeButton.Click();

        productsPage.Title.Displayed.Should().BeTrue();
    }
}
