using OpenQA.Selenium;

namespace PageObject.Steps;

public class BaseStep
{
    protected static IWebDriver Driver;

    public BaseStep(IWebDriver driver)
    {
        Driver = driver;
    }
}