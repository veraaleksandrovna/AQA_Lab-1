using NUnit.Framework;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Tests;

public class LoginTest : BaseTest
{
    [Test]  
    public void Test_SuccessLogin()
    {
        var loginPage = new LoginPage(Driver, true);
        loginPage.UsernameInput.SendKeys(Configurator.Username);
        loginPage.PasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Submit();

        var inventoryPage = new InventoryPage(Driver, false);
        
        Assert.AreEqual("products", inventoryPage.Title.Text.ToLower());
    }
}
