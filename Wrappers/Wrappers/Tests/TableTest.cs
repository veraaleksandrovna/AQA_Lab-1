using NUnit.Framework;
using Wrappers.Pages;

namespace Wrappers.Tests
{
    public class TableTest : BaseTest
    {
        [Test]
        public void CellSearch()
        {
            var tablePage = new TablePage(Driver);
            tablePage.NavigateToPageAndWaitUntilOpened();

            var expectedResult = "Definiebas9";
            var cellElement = tablePage.Table.GetCellElement("Sit", "Iuvaret9");
            var actualResult = cellElement.Text;
            Assert.AreEqual(expectedResult, actualResult);

            var expectedUrl = "https://the-internet.herokuapp.com/challenging_dom#edit";
            var actualUrl = Driver.Url;
            tablePage.Table.GetDeleteEditElement("Iuvaret9", "edit").Click();
            Assert.AreEqual(expectedUrl, actualUrl);
        }
    }
}
