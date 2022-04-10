using System;
using AlertsWaits.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AlertsWaits.Tests;

public class AlertTests : BaseTest
{
    private const string KeyJsPromt = "Great site";
    
    private const string ExpectedJsAlert = "You successfully clicked an alert";
    private const string ExpectedJsConfirmationAccept = "You clicked: Ok";
    private const string ExpectedJsConfirmationDismiss = "You clicked: Cancel"; 
    private const string ExpectedJsPromtAccept= "You entered: Great site";
    private const string ExpectedJsPromtDismiss= "You entered: null";
    
    [Test]
    public void Test_JS_Alert()
    { 
        var alertPage = new AlertPage(Driver, true);

        alertPage.JsAlertButton.Click();

        IAlert alert = Driver.SwitchTo().Alert();
        var alertText = alert.Text;
        Console.Out.Write(alertText);
        alert.Accept();

        var actualJsAlert = GetActualResult(alertPage);
        Assert.AreEqual(ExpectedJsAlert, actualJsAlert);
    }

    [Test]
    public void Test_JS_ConfirmationAccept()
    {
        var alertPage = new AlertPage(Driver, true);

        alertPage.JsConfirmButton.Click();

        IAlert confirmationAlert = Driver.SwitchTo().Alert();
        var confirmationAcceptAlertText = confirmationAlert.Text;
        Console.Out.Write(confirmationAcceptAlertText);    
        confirmationAlert.Accept();

        var actualJsConfirmationAccept = GetActualResult(alertPage);
        Assert.AreEqual(ExpectedJsConfirmationAccept, actualJsConfirmationAccept);
    }
    
    [Test]
    public void Test_JS_ConfirmationDismiss()
    {
        var alertPage = new AlertPage(Driver, true);

        alertPage.JsConfirmButton.Click();;

        IAlert confirmationAlert = Driver.SwitchTo().Alert();
        var confirmationDismissAlertText = confirmationAlert.Text;
        Console.Out.Write(confirmationDismissAlertText);
        confirmationAlert.Dismiss();

        var actualJsConfirmationDismiss = GetActualResult(alertPage);
        Assert.AreEqual(ExpectedJsConfirmationDismiss, actualJsConfirmationDismiss);
    }
    
    [Test]
    public void Test_JS_PromtAccept()
    {
        var alertPage = new AlertPage(Driver, true);

        alertPage.JsPromptButton.Click();

        IAlert promptAlert  = Driver.SwitchTo().Alert();
        var promtAlertText = promptAlert.Text;
        Console.Out.Write(promtAlertText);
        promptAlert.SendKeys(KeyJsPromt);
        promptAlert.Accept();

        var actualJsPromtAccept = GetActualResult(alertPage);
        Assert.AreEqual(ExpectedJsPromtAccept, actualJsPromtAccept);
    }
    
    [Test]
    public void Test_JS_PromtDismiss()
    {
        var alertPage = new AlertPage(Driver, true);

        alertPage.JsPromptButton.Click();

        IAlert promptAlert  = Driver.SwitchTo().Alert();
        var promtAlertText = promptAlert.Text;
        Console.Out.Write(promtAlertText); 
        promptAlert.Dismiss();

        var actualJsPromtDismiss = GetActualResult(alertPage);
        Assert.AreEqual(ExpectedJsPromtDismiss, actualJsPromtDismiss);
    }
    
    private static string GetActualResult(AlertPage alertPage)
    {
        return alertPage.Result.Text;
    }
    
}
