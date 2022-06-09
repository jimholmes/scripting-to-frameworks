using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework;
public static class Helpers
{
    public static IWebElement WaitAndReturnElement(IWebDriver driver, By by)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        return wait.Until<IWebElement>(driver =>
        {
            IWebElement tempElement = driver.FindElement(by);
            return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
        }
        );
    }
}
