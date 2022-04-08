using System;
using AlertsWaits.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V94.Input;

namespace AlertsWaits.Tests;

public class AlertTest : BaseTest
{
    private const string PathUrl = "https://the-internet.herokuapp.com/javascript_alerts";

    private const string KeyJsPromt = "Great site";
    
    private const string ExpectedJsAlert = "You successfully clicked an alert";
    private const string ExpectedJsConfirmationAccept = "You clicked: Ok";
    private const string ExpectedJsConfirmationDismiss = "You clicked: Cancel"; 
    private const string ExpectedJsPromtAccept= "You entered: Great site";
    private const string ExpectedJsPromtDismiss= "You entered: null";
    
    [Test]
    public void Test_JS_Alert()
    { 
        Driver.Navigate().GoToUrl(PathUrl);
        
        Driver.FindElement(By.CssSelector("button[onclick='jsAlert()']")).Click();

        IAlert alert = Driver.SwitchTo().Alert();
        string alertText = alert.Text;
        Console.Out.Write(alertText);
        alert.Accept();

        var actualJsAlert = Driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual(ExpectedJsAlert, actualJsAlert);
    }

    [Test]
    public void Test_JS_ConfirmationAccept()
    {
        Driver.Navigate().GoToUrl(PathUrl);
        
        Driver.FindElement(By.CssSelector("button[onclick='jsConfirm()']")).Click();

        IAlert confirmationAlert = Driver.SwitchTo().Alert();
        confirmationAlert.Accept();

        var actualJsConfirmationAccept = Driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual(ExpectedJsConfirmationAccept, actualJsConfirmationAccept);
    }
    
    [Test]
    public void Test_JS_ConfirmationDismiss()
    {
        Driver.Navigate().GoToUrl(PathUrl);
        
        Driver.FindElement(By.CssSelector("button[onclick='jsConfirm()']")).Click();

        IAlert confirmationAlert = Driver.SwitchTo().Alert();
        confirmationAlert.Dismiss();

        var actualJsConfirmationDismiss = Driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual(ExpectedJsConfirmationDismiss, actualJsConfirmationDismiss);
    }
    
    [Test]
    public void Test_JS_PromtAccept()
    {
        Driver.Navigate().GoToUrl(PathUrl);
        
        Driver.FindElement(By.CssSelector("button[onclick='jsPrompt()']")).Click();

        IAlert promptAlert  = Driver.SwitchTo().Alert();
        promptAlert.SendKeys(KeyJsPromt);
        promptAlert.Accept();

        var actualJsPromtAccept = Driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual(ExpectedJsPromtAccept, actualJsPromtAccept);
    }
    
    [Test]
    public void Test_JS_PromtDismiss()
    {
        Driver.Navigate().GoToUrl(PathUrl);
        
        Driver.FindElement(By.CssSelector("button[onclick='jsPrompt()']")).Click();

        IAlert promptAlert  = Driver.SwitchTo().Alert();
        promptAlert.Dismiss();

        var actualJsPromtDismiss = Driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual(ExpectedJsPromtDismiss, actualJsPromtDismiss);
    }
    
}