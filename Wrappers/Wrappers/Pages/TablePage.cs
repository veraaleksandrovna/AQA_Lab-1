using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Wrappers.Services.Configuration;
using Wrappers.Wrappers;

namespace Wrappers.Pages
{
    public class TablePage : BasePage
    {
        private static readonly By TableLocatorBy = By.TagName("table");

        public Table Table => new(Driver, TableLocatorBy);
    
        public TablePage(IWebDriver driver) : base(driver)
        {
        }

        protected override void NavigateToPage()
        {
            Driver.Navigate().GoToUrl(Configurator.TableUrl);
        }

        public override bool CheckIfPageOpened()
        {
            try
            {
                return Table.Displayed;
            }
            catch (TimeoutException)
            {
                throw new AssertionException("The page wasn't opened.");
            }
        }
    }
}
