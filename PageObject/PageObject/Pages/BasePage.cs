using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public abstract class BasePage
{
    [ThreadStatic] private static IWebDriver? _driver;
    private const int WaitForPageLoadingTime = 60;
    private static WaitService _waitService;

    protected abstract void OpenPage();

    protected abstract bool IsPageOpened();

    protected BasePage(IWebDriver? driver, bool openPageByUrl)
    {
        _driver = driver;
        Service = new WaitService(_driver);
        
        if (!openPageByUrl)
        {
            return;
        }
        OpenPage();
        
        WaitForOpen();
    }

    private void WaitForOpen()
    {
        var secondsCount = 0;
        var isPageOpenedIndicator = IsPageOpened();

        while (!isPageOpenedIndicator && secondsCount < WaitForPageLoadingTime / Configurator.WaitTimeout)
        {
            secondsCount++;
            isPageOpenedIndicator = IsPageOpened();

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page was not opened.");
            }
        }
    }

    protected static IWebDriver? Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentException(nameof(value));
    }

    public static WaitService Service
    {
        get => _waitService;
        set => _waitService = value ?? throw new ArgumentException(nameof(value));
    }
}
