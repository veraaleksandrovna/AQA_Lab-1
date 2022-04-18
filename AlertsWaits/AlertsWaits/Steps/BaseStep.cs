using OpenQA.Selenium;

namespace AlertsWaits.Steps;

public class BaseStep
{
     protected IWebDriver Driver;
    
            public BaseStep(IWebDriver driver)
            {
                Driver = driver;
            }
}
