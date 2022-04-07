using OpenQA.Selenium;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Steps;

public static class LoginStep
{
    public static void LogIn(IWebDriver? driver)
    {
        var loginPage = new LoginPage(driver, true);
        loginPage.UsernameInput.SendKeys(Configurator.Username);
        loginPage.PasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Submit();
    }
}
