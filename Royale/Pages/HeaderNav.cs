using OpenQA.Selenium;
using Framework;

namespace Royale.Pages;
public class HeaderNav
{
    public readonly HeaderNavMap Map;

    public HeaderNav(IWebDriver driver)
    {
        Map = new HeaderNavMap(driver);        
    }

    public void GoToCardsPage() {
        Map.CardsTabLink.Click();
    }

}

public class HeaderNavMap 
{
    IWebDriver _driver;

    public HeaderNavMap(IWebDriver driver)
    {
        _driver = driver;
    }
    public IWebElement CardsTabLink => Helpers.WaitAndReturnElement(_driver, By.CssSelector("a[href='/cards']"));
}
