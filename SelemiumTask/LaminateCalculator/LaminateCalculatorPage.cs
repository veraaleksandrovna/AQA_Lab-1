using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SelemiumTask.LaminateCalculator;

public class LaminateCalculatorPage
{
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
        CalcRoomWidthInput.SendKeys(BorderedValuesLaminate.BorderValueRoomWidth);
        return this;
    }

    public LaminateCalculatorPage CalcRoomHeighInputtKey()
    {
        CalcRoomHeightInput.SendKeys(BorderedValuesLaminate.BorderValueRoomHeight);
        return this;
    }

    public LaminateCalculatorPage CalcLamWidthInputKey()
    {
        CalcLamWidthInput.Clear();
        CalcLamWidthInput.SendKeys(BorderedValuesLaminate.BorderValueLamWidth);
        return this;
    }

    public LaminateCalculatorPage CalcLamHeightInputKey()
    {
        CalcLamHeightInput.Clear();
        CalcLamHeightInput.SendKeys(BorderedValuesLaminate.BorderValueLamHeight);
        return this;
    }

    public LaminateCalculatorPage CalcInPackInputKey()
    {
        CalcInPackInput.Clear();
        CalcInPackInput.SendKeys(BorderedValuesLaminate.BorderValueInPack);
        return this;
    }

    public LaminateCalculatorPage CalcPriceInputKey()
    {
        CalcPriceInput.Clear();
        CalcPriceInput.SendKeys(BorderedValuesLaminate.BorderValuePrice);
        return this;
    }

    public LaminateCalculatorPage CalcDirectDropDownKey()
    {
        CalcDirectDropDown.SelectByText(BorderedValuesLaminate.ValueDirectionDropDown);
        return this;
    }

    public LaminateCalculatorPage CalcBiasInputKey()
    {
        CalcBiasInput.Clear();
        CalcBiasInput.SendKeys(BorderedValuesLaminate.BorderValueBias);
        return this;
    }

    public LaminateCalculatorPage CalcWallDistInputKey()
    {
        CalcWallDistInput.Clear();
        CalcWallDistInput.SendKeys(BorderedValuesLaminate.BorderValueWallDist);
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
