using OpenQA.Selenium;

namespace Royale.Pages {

    public class CardsDetailsPage : PageBase {
        public readonly CardsDetailsPageMap Map;

        public CardsDetailsPage(IWebDriver driver) : base(driver)
        {
            Map = new CardsDetailsPageMap(driver);
        }

        public (string Category, string Arena) GetCardCategory() {
            var categories = Map.CardCategory.Text.Split(',');
            return (categories[0].Trim(), categories[1].Trim());
        }
    }

    public class CardsDetailsPageMap {

        IWebDriver _driver;

        public CardsDetailsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement CardName => _driver.FindElement(By.CssSelector("div[class*='cardName'"));
        public IWebElement CardCategory => _driver.FindElement(By.CssSelector("div[class*='card__rarity'"));
        public IWebElement CardRarity => _driver.FindElement(By.CssSelector("div[class*='rarityCaption'"));
    }
}