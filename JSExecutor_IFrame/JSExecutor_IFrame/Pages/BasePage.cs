using System;
using JSExecutor_IFrame.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace JSExecutor_IFrame.Pages;

public abstract class BasePage
{
    private const int WaitForPageLoadingTime = 60;
    [ThreadStatic] private static IWebDriver _driver;

    protected BasePage(IWebDriver driver, bool openPageByUrl)
    {
        Driver = driver;
        WaitService = new WaitService(Driver);

        if (openPageByUrl) OpenPage();

        WaitForOpen();
    }

    public static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }

    protected static WaitService WaitService { get; private set; }

    protected abstract void OpenPage();

    protected abstract bool IsPageOpened();

    private void WaitForOpen()
    {
        var secondsCount = 0;
        var isPageOpenedIndicator = IsPageOpened();

        while (isPageOpenedIndicator != true && secondsCount < WaitForPageLoadingTime / Configurator.WaitTimeout)
        {
            //Thread.Sleep(1000);
            secondsCount++;
            isPageOpenedIndicator = IsPageOpened();
        }

        if (!isPageOpenedIndicator) throw new AssertionException("Page was not opened...");
    }
}