using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Wrappers.Services.Configuration;
using Wrappers.Wrappers;

namespace Wrappers.Pages
{
    public class SliderPage : BasePage
    {
        private static readonly By SliderLocatorBy = By.TagName("input");
        private static readonly By SliderValueLocatorBy = By.CssSelector("#range");

        public HorizontalSlider Slider => new(Driver, SliderLocatorBy);
        public IWebElement SliderValue => WaitService.WaitUntilElementExists(SliderValueLocatorBy);

        public SliderPage(IWebDriver driver) : base(driver)
        {
        }

        protected override void NavigateToPage()
        {
            Driver.Navigate().GoToUrl(Configurator.SliderUrl);
        }

        public override bool CheckIfPageOpened()
        {
            try
            {
                return Slider.Displayed;
            }
            catch (TimeoutException)
            {
                throw new AssertionException("The page wasn't opened.");
            }
        }
    }
}
