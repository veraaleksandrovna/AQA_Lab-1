using System;
using OpenQA.Selenium;

namespace AlertsWaits.Pages;

public class AlertPage: BasePage
{
    private const string PathUrl = "https://the-internet.herokuapp.com/javascript_alerts";
    
    private static readonly By JsAlertButtonBy = By.CssSelector("button[onclick='jsAlert()']"); 
    private static readonly By JsConfirmButtonBy = By.CssSelector("button[onclick='jsConfirm()']"); 
    private static readonly By JsPromtButtonBy = By.CssSelector("button[onclick='jsPrompt()']");
    private static readonly By ResultOutputBy = By.Id("result");
    
    public AlertPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(PathUrl);
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
    
    public IWebElement JsAlertButton = Driver.FindElement(JsAlertButtonBy);
    public IWebElement JsConfirmButton = Driver.FindElement(JsConfirmButtonBy);
    public IWebElement JsPromtButton = Driver.FindElement(JsPromtButtonBy);
    public IWebElement ResultOutput = Driver.FindElement(ResultOutputBy);

}