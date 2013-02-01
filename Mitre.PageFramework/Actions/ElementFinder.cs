using OpenQA.Selenium;

namespace Mitre.PageFramework.Actions
{
    public class ElementFinder : IElementFinder
    {
        private readonly IWebDriver browser;

        public ElementFinder(IWebDriver browser)
        {
            this.browser = browser;
        }

        public IWebElement TryFindElement(By by)
        {
            return browser.TryFindElement(by);
        }
    }
}