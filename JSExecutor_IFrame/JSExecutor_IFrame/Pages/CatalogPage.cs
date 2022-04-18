using AngleSharp;
using JSExecutor_IFrame.Services;
using OpenQA.Selenium;

namespace JSExecutor_IFrame.Pages;

public class CatalogPage: BasePage
{
    private static readonly By SearchFieldBy = By.ClassName("fast-search__input");
    private static readonly  By SearchFrameBy = By.CssSelector(".modal-iframe");
    private static readonly  By FirstFrameItemBy = By.XPath("(//div[@class='product__title']/a)[1]");
    private static readonly By TextInSearchFieldBy = By.ClassName("search__input");

    public IWebElement SearchField => WaitService.WaitElementIsExists(SearchFieldBy);
    public IWebElement SearchFrame => WaitService.WaitElementIsExists(SearchFrameBy);
    public IWebElement FirsrFrameItem => WaitService.WaitElementIsExists(FirstFrameItemBy);
    public IWebElement SearcFieldFrame => WaitService.WaitElementIsExists(TextInSearchFieldBy);
    
    public CatalogPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.OnlinerUrl);
    }

    protected override bool IsPageOpened()
    {
        return SearchField.Displayed;
    }
}



