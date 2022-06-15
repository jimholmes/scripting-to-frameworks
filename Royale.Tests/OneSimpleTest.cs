using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System;

namespace Royale.Tests
{
    public class OneSimpleTest {

        [Test]
        public void CheckIceSpiritCard() {
            var timer = new Stopwatch();
            timer.Start();
            TimeSpan first = timer.Elapsed;
            ChromeOptions opts = new ChromeOptions();
            opts.Proxy = null;
            // IWebDriver driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
            IWebDriver driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"), opts);
            TimeSpan second = timer.Elapsed;
            driver.Url = "https://statsroyale.com";
            TimeSpan third = timer.Elapsed;
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            TimeSpan fourth = timer.Elapsed;
            driver.FindElement(By.CssSelector($"a[href*='Ice+Spirit']")).Click();
            TimeSpan fifth = timer.Elapsed;
            IWebElement cardName = driver.FindElement(By.CssSelector("div[class*='cardName']"));
            TimeSpan sixth = timer.Elapsed;
            // Assert.AreEqual("Ice Spirit", cardName.Text);
            driver.Close();
            string format = @"m\:ss\.fff";
            string message = "First: " + first.ToString(format)+ "\n" +
            "Second: " + second.ToString(format)+ "\n" +
            "Third: " + third.ToString(format)+ "\n" +
            "Fourth: " + fourth.ToString(format)+ "\n" +
            "Fifth: " + fifth.ToString(format)+ "\n" +
            "Sixth:" + sixth.ToString(format);            
            Assert.Pass(message);
        }
    }
}