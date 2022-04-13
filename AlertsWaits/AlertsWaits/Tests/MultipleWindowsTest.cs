using AlertsWaits.Pages;
using NUnit.Framework;

namespace AlertsWaits.Tests;

public class MultipleWindowsTest : BaseTest
{
    [Test]
    public void Test_OpenNewWindows()
    {
        var tvPage = new TvPage(Driver, true);
        var parentWindow = Driver.CurrentWindowHandle;
        
        tvPage.VkLink.Click();
        tvPage.TwitterLink.Click();
        tvPage.FacebookLink.Click();
       
        var windows = _driver.WindowHandles;
        
        var expectedAmmountOfWindows = 4;
        var actualAmmountOfWindows = Driver.WindowHandles.Count;
        Assert.AreEqual(expectedAmmountOfWindows, actualAmmountOfWindows);

        Driver.SwitchTo().Window(windows[3]);
        var vkPage = new VkPage(Driver, false);
        Assert.IsTrue(vkPage.OnlinerTitle.Displayed);

        Driver.SwitchTo().Window(windows[2]);
        var twitterPage = new TwitterPage(Driver, false);
        Assert.IsTrue(twitterPage.OnlinerTitle.Displayed);
        twitterPage.TwitterLogo.Click();

        Driver.SwitchTo().Window(windows[1]);
        var facebookPage = new FacebookPage(Driver, false);
        Assert.IsTrue(facebookPage.Title.Displayed);
        
        Driver.SwitchTo().Window(parentWindow);
        Assert.IsTrue(tvPage.FirstTvCheck.Displayed);

        foreach (var window in Driver.WindowHandles)
        {
            Driver.SwitchTo().Window(window).Close();
        }
    }
}
