using Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Royale.Pages {

    public class CardsPage : PageBase {
        public readonly CardsPageMap Map;

        public CardsPage(IWebDriver driver) : base(driver)
        {
            Map = new CardsPageMap(driver);
        }

        public CardsPage Goto() {
            HeaderNav.GoToCardsPage();
            return this;
        }

        public IWebElement GetCardByName(string cardName) {
            if (cardName.Contains(" "))
            {
                cardName.Replace(" ", "+");
            }

            return Map.Card(cardName);
        }
    }

    public class CardsPageMap {

        IWebDriver _driver;

        public CardsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Card(string name) =>  Helpers.WaitAndReturnElement(_driver, By.CssSelector($"a[href*='{name}']"));
        
    }
}