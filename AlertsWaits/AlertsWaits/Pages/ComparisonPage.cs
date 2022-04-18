using System.Collections.ObjectModel;
using AlertsWaits.Services;
using OpenQA.Selenium;

namespace AlertsWaits.Pages;

public class ComparisonPage : BasePage
{
    private string EndPoint = "/compare";
    
    private static readonly By ScreenDiagonalBy = By.XPath("// * [contains(text(), 'Диагональ экрана')]");//span[contains(text(),'Диагональ экрана')]
    private static readonly By ScreenDiagonalTipButtonBy = By.CssSelector("[data-tip-term = 'Диагональ экрана']");
    private static readonly By ScreenDiagonalTipInfoBy= By.CssSelector(".product-table-tip__content");
    private static readonly By DeleteItemBy = By.XPath("(//*[@class='product-summary']/ following-sibling :: a) [1]");
    private static readonly By ProductsSummaryBy = By.CssSelector(".product-summary");
    
    public ComparisonPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.CatalogOnlinerUrl + EndPoint);
    }

    protected override bool IsPageOpened()
    {
        var element = WaitService.GetVisibleElement(By.ClassName("b-offers-title"));
        var elementText = element.GetAttribute("textContent");
        return elementText.Equals("Сравнение товаров");
    }

    public IWebElement ScreenDiagonal => WaitService.WaitElementIsExists(ScreenDiagonalBy);
    public IWebElement ScreenDiagonalTipButton => WaitService.WaitElementIsExists(ScreenDiagonalTipButtonBy);
    public IWebElement ScreenDiagonalTipInfo => WaitService.WaitElementIsExists(ScreenDiagonalTipInfoBy);

    public bool InvisibleScreenDiagonalTipInfo => WaitService.GetInvisibleElement(ScreenDiagonalTipInfoBy);
    public IWebElement DeleteItem => WaitService.WaitElementIsExists(DeleteItemBy);
    public ReadOnlyCollection<IWebElement> ProductSummary => (ReadOnlyCollection<IWebElement>) WaitService.WaitAllElementIsVisible(ProductsSummaryBy);
}
