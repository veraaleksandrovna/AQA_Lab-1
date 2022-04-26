using System;
using NUnit.Framework;
using Wrappers.Pages;

namespace Wrappers.Tests
{
    public class HorizontalSliderTest : BaseTest
    {
        private SliderPage _sliderPage;
    
        [SetUp]
        public new void SetUp()
        {
            _sliderPage = new SliderPage(Driver);
            _sliderPage.NavigateToPageAndWaitUntilOpened();
        }

        [TestCase(5)]
        [TestCase(3)]
        [TestCase(0)]
        [Test]
        public void  SetSlider_PositiveValueTest(int positiveValue)
        {
            _sliderPage.Slider.SetSliderToValue(positiveValue);
            Assert.AreEqual(positiveValue, int.Parse(_sliderPage.SliderValue.Text));
        }

        [TestCase(-1)]
        [TestCase(6)]
        [Test]
        public void SetSlider_NegativeValues_Test(int negativeValue )
        {
            Assert.Throws<ArgumentException>(() => _sliderPage.Slider.SetSliderToValue(negativeValue));
        }
    }
}
