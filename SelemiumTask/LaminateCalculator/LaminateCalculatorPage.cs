using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SelemiumTask.LaminateCalculator;

public class LaminateCalculatorPage
{
    private const string BorderValueRoomWidth = "15";
    private const string BorderValueRoomHeight = "10";
    private const string BorderValueLamWidth = "5000";
    private const string BorderValueLamHeight = "1000";
    private const string BorderValueInPack = "100";
    private const string BorderValuePrice = "1000000";
    private const string ValueDirectionDropDown = "По длине комнаты";
    private const string BorderValueBias = "2500";
    private const string BorderValueWallDist = "100";

    private readonly IWebDriver? _driver;

    public LaminateCalculatorPage(IWebDriver? driver)
    {
        _driver = driver;
    }

    private IWebElement CalcRoomWidthInput => FindElementByName("calc_roomwidth");
    private IWebElement CalcRoomHeightInput => FindElementByName("calc_roomheight");
    private IWebElement CalcLamWidthInput => FindElementByName("calc_lamwidth");
    private IWebElement CalcLamHeightInput => FindElementByName("calc_lamheight");
    private IWebElement CalcInPackInput => FindElementByName("calc_inpack");
    private IWebElement CalcPriceInput => FindElementByName("calc_price");
    private SelectElement CalcDirectDropDown => new(FindElementByName("calc_direct"));
    private IWebElement CalcBiasInput => FindElementByName("calc_bias");
    private IWebElement CalcWallDistInput => FindElementByName("calc_walldist");
    private IWebElement CalculationButton => _driver.FindElement(By.ClassName("btn-secondary"));
    private IWebElement ActualSLam => FindElementByXpath("//*[@id=\"s_lam\"]/b");
    private IWebElement ActualLCount => FindElementByXpath("//*[@id=\"l_count\"]/ b");
    private IWebElement ActualLPacks => FindElementByXpath("//*[@id=\"l_packs\"]/ b");
    private IWebElement ActualLPrice => FindElementByXpath("//*[@id=\"l_price\"]/ b");
    private IWebElement ActualLOver => FindElementByXpath("//*[@id=\"l_over\"]/ b");
    private IWebElement ActualLTrash => FindElementByXpath("//*[@id=\"l_trash\"]/ b");

    private IWebElement FindElementByXpath(string xpath)
    {
        return _driver.FindElement(By.XPath(xpath));
    }
    
    private IWebElement FindElementByName(string name)
    {
        return _driver.FindElement(By.Name(name));
    }

    public LaminateCalculatorPage CalcRoomWidtInputhKey()
    {
        CalcRoomWidthInput.SendKeys(BorderValueRoomWidth);
        return this;
    }

    public LaminateCalculatorPage CalcRoomHeighInputtKey()
    {
        CalcRoomHeightInput.SendKeys(BorderValueRoomHeight);
        return this;
    }

    public LaminateCalculatorPage CalcLamWidthInputKey()
    {
        CalcLamWidthInput.Clear();
        CalcLamWidthInput.SendKeys(BorderValueLamWidth);
        return this;
    }

    public LaminateCalculatorPage CalcLamHeightInputKey()
    {
        CalcLamHeightInput.Clear();
        CalcLamHeightInput.SendKeys(BorderValueLamHeight);
        return this;
    }

    public LaminateCalculatorPage CalcInPackInputKey()
    {
        CalcInPackInput.Clear();
        CalcInPackInput.SendKeys(BorderValueInPack);
        return this;
    }

    public LaminateCalculatorPage CalcPriceInputKey()
    {
        CalcPriceInput.Clear();
        CalcPriceInput.SendKeys(BorderValuePrice);
        return this;
    }

    public LaminateCalculatorPage CalcDirectDropDownKey()
    {
        CalcDirectDropDown.SelectByText(ValueDirectionDropDown);
        return this;
    }

    public LaminateCalculatorPage CalcBiasInputKey()
    {
        CalcBiasInput.Clear();
        CalcBiasInput.SendKeys(BorderValueBias);
        return this;
    }

    public LaminateCalculatorPage CalcWallDistInputKey()
    {
        CalcWallDistInput.Clear();
        CalcWallDistInput.SendKeys(BorderValueWallDist);
        return this;
    }

    public void ClickCalculationButton()
    {
        CalculationButton.Click();
    }

    public string GetActualSLam()
    {
        var actualSLam = ActualSLam.Text;
        return actualSLam;
    }

    public string GetActualLCount()
    {
        var actualLCount = ActualLCount.Text;
        return actualLCount;
    }

    public string GetActualLPacks()
    {
        return ActualLPacks.Text;
    }

    public string GetActualLPrice()
    {
        return ActualLPrice.Text;
    }

    public string GetActualLOver()
    {
        return ActualLOver.Text;
    }

    public string GetActualLTrash()
    {
        return ActualLTrash.Text;
    }
}
