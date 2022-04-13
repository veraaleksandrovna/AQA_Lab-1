using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public abstract class BasePage
{
    private const int WaitForPageLoadingTime = 60;
    [ThreadStatic] private static IWebDriver? _driver;
    private static WaitService _waitService;

    protected BasePage(IWebDriver? driver, bool openPageByUrl)
    {
        _driver = driver;
        Service = new WaitService(_driver);

        if (!openPageByUrl) return;
        OpenPage();

        WaitForOpen();
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

    protected abstract void OpenPage();

    public abstract bool IsPageOpened();

    private void WaitForOpen()
    {
        var secondsCount = 0;
        var isPageOpenedIndicator = IsPageOpened();

        while (!isPageOpenedIndicator && secondsCount < WaitForPageLoadingTime / Configurator.WaitTimeout)
        {
            secondsCount++;
            isPageOpenedIndicator = IsPageOpened();

            if (!isPageOpenedIndicator) throw new AssertionException("Page was not opened.");
        }
    }
}