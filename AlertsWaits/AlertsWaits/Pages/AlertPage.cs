using System;
using AlertsWaits.Services;
using OpenQA.Selenium;

namespace AlertsWaits.Pages;

public class AlertPage: BasePage
{
    private const string EndPoint = "/javascript_alerts";
    
    private static readonly By JsAlertButtonBy = By.CssSelector("button[onclick='jsAlert()']");
    private static readonly By JsConfirmButtonBy = By.CssSelector("button[onclick='jsConfirm()']");
    private static readonly By JsPromptButtonBy = By.CssSelector("button[onclick='jsPrompt()']");
    private static readonly By ResultOutputBy = By.Id("result");

    public AlertPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.HerokuappUrl + EndPoint);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return JsAlertButton.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    public IWebElement JsAlertButton => WaitService.WaitElementIsExists(JsAlertButtonBy);
    public IWebElement JsConfirmButton => WaitService.WaitElementIsExists(JsConfirmButtonBy);
    public IWebElement JsPromptButton => WaitService.WaitElementIsExists(JsPromptButtonBy);
    public IWebElement Result => WaitService.WaitElementIsExists(ResultOutputBy);
    
}