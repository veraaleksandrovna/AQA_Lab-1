using System;
using System.Collections.Generic;
using AlertsWaits.Services;
using OpenQA.Selenium;

namespace AlertsWaits.Pages;

public class TvPage : BasePage
{
    private static readonly By FirstTvCheckBy = By.XPath("(( //div[@class='schema-product__group']) [1]// label) [1]");
    private static readonly By SecondTvCheckBy = By.XPath("(( //div[@class='schema-product__group']) [2]// label) [1]");
    private static readonly By TvListBy = By.ClassName("schema-product__group");
    private static readonly By ProductsComparisonButtonBy = By.ClassName("compare-button__sub_main");
    private static readonly By VkLinkBy = By.ClassName("footer-style__social-button_vk");
    private static readonly By YouTubeLinkBy = By.ClassName("footer-style__social-button_yt");
    private static readonly By TwitterLinkBy = By.ClassName("footer-style__social-button_tw");


    public TvPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.CatalogOnlinerUrl);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return FirstTvCheck.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    public List<IWebElement> TvList => WaitService.GetVisibleElements(TvListBy);
    public IWebElement ProductsComparisonButton => WaitService.GetVisibleElement(ProductsComparisonButtonBy);
    public IWebElement FirstTvCheck => WaitService.WaitElementIsExists(FirstTvCheckBy);
    public IWebElement SecondTvCheck => WaitService.WaitElementIsExists(SecondTvCheckBy);
    public IWebElement VkLink => WaitService.WaitElementIsExists(VkLinkBy);
    public IWebElement YouTubeLink => WaitService.WaitElementIsExists(YouTubeLinkBy);
    public IWebElement TwitterLink => WaitService.WaitElementIsExists(TwitterLinkBy);



}
