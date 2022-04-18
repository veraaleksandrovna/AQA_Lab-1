using JSExecutor_IFrame.Tests;
using JSExecutor_IFrame.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace JSExecutor_IFrame.Tests;

public class OnlinerTest : BaseTest
{
    
    private const string SearchKey = "asus";
    private const string ExpectedResult = "asus";

    [Test]
    public void OnlinerSearchFrameTest()
    {
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor) Driver;
        Actions actions = new Actions(Driver);
       var catalogPage = new CatalogPage(Driver,true);

        actions.MoveToElement(catalogPage.SearchField);

        jsExecutor.ExecuteScript("arguments[0].click();", catalogPage.SearchField);
        catalogPage.SearchField.SendKeys(SearchKey);

        Driver.SwitchTo().Frame(catalogPage.SearchFrame);
        
        Assert.IsTrue(catalogPage.FirsrFrameItem.Displayed);

        actions.MoveToElement(catalogPage.FirsrFrameItem);

        var actualResult = catalogPage.SearcFieldFrame.Text;
        
        Assert.AreEqual(ExpectedResult,actualResult);



    }
}
