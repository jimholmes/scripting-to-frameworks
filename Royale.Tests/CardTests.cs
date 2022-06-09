using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Royale.Pages;

namespace Royale.Tests;

public class CardTests
{
    IWebDriver driver;
    
    [SetUp]
    public void BeforeEach()
    {
        
        ChromeOptions opts = new ChromeOptions();
        opts.AddArgument("no-sandbox");
        opts.Proxy = null;
        //shut off proxy?
        // opts.AddArguments("--no-proxy-server");
        // driver = new FirefoxDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        // driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        string driverBinLoc = Path.GetFullPath(@"../../../../" + "_drivers");
        driver = new ChromeDriver(driverBinLoc, opts);
        driver.Url = "https://statsroyale.com";
    }
    
    [TearDown]
    public void AfterEach() {
        driver.Close();
    }

    [Test]
    public void Card_test() {
        driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
        driver.FindElement(By.CssSelector($"a[href*='Ice+Spirit']")).Click();
        IWebElement cardName = driver.FindElement(By.CssSelector("div[class*='cardName']"));
        Assert.AreEqual("Ice Spirit", cardName.Text);

    }

    /* [Test]
    public void Ice_Spirit_is_on_cards_page()
    {
        
        var cardsPage = new CardsPage(driver);
        var iceSpirit = cardsPage.Goto().GetCardByName("Ice Spirit");
        
        Assert.That(iceSpirit.Displayed);
    } */

    /* [Test]
    public void Ice_Spirit_headers_are_correct_on_Card_Details_Page()
    {
        new CardsPage(driver).Goto().GetCardByName("Ice Spirit");
        var cardDetails = new CardsDetailsPage(driver);

        var (category, arena) = cardDetails.GetCardCategory();
        var cardName = cardDetails.Map.CardName;
        var cardRarity = cardDetails.Map.CardRarity;

        Assert.AreEqual("Ice Spirit", cardName);
        Assert.AreEqual("Troop", category);
        Assert.AreEqual("Arena 8", arena);
        Assert.AreEqual("Common", cardRarity);
    } */
}