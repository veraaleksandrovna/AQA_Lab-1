using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class LoginPage : BasePage
{
    private const string EndPoint = "/";

    private static readonly By UserNameInputBy = By.Id("user-name");
    private static readonly By PasswordInputBy = By.Id("password");
    private static readonly By LoginButtonBy = By.Id("login-button");

    public LoginPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return LoginButton.Displayed;
        }
        catch (NoSuchElementException e)
        {
            return false;
        }
    }
    
    public IWebElement UsernameInput => WaitService.WaitElementExist(UserNameInputBy);
    public IWebElement PasswordInput => WaitService.WaitElementExist(PasswordInputBy);
    public IWebElement LoginButton => WaitService.WaitElementExist(LoginButtonBy);
}
