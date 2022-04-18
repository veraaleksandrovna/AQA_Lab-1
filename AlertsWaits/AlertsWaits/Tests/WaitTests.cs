using AlertsWaits.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace AlertsWaits.Tests;

public class OnlinerTvTests : BaseTest
{
    [Test]
    public void Test_Waits_IconsDisplayed()
    {
        var tvPage = new TvPage(Driver,true);
        
        tvPage.FirstTvCheck.Click();
        tvPage.SecondTvCheck.Click();
        tvPage.ProductsComparisonButton.Click();

        var comparisonPage = new ComparisonPage(Driver, false);
        var actions = new Actions(Driver);
        
        actions.MoveToElement(comparisonPage.ScreenDiagonalTipButton).Perform();
        comparisonPage.ScreenDiagonalTipButton.Click();
        Assert.IsTrue(comparisonPage.ScreenDiagonalTipInfo.Displayed);
        comparisonPage.ScreenDiagonalTipButton.Click();
        Assert.IsTrue(comparisonPage.InvisibleScreenDiagonalTipInfo);
        
        comparisonPage.DeleteItem.Click();

        var expectedNumberOfSummary = 2;
       Assert.AreEqual(expectedNumberOfSummary,comparisonPage.ProductSummary.Count);

    }
}
