using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Tests;

[TestFixture]
[AllureNUnit]
[AllureSuite("LoginTest")]
public class LoginTests : BaseTest
{
    [Test]
    [AllureTag("StandardUser")]
    public void StandardUserLoginTest()
    {
        LoginStep.Login(UsersConfigurator.StandardUserName, UsersConfigurator.Password);
        Assert.IsTrue(new InventoryPage(Driver, false).IsPageOpened());
        StringAssert.AreEqualIgnoringCase("Swag Labs", Driver.Title);
    }

    [Test]
    [AllureTag("LockedOutUser")]
    public void LockedOutUserLoginTest()
    {
        LoginStep.Login(UsersConfigurator.LockedOutUserName, UsersConfigurator.Password);

        var errorElement = Driver.FindElement(By.ClassName("error-message-container"));
        var actualResult = errorElement.GetAttribute("textContent");
        var expectedResult = "Epic sadface: Sorry, this user has been locked out.";

        StringAssert.AreEqualIgnoringCase(expectedResult, actualResult);
    }
}
