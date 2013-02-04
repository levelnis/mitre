using Mitre.PageFramework.Actions;
using Mitre.PageFramework.Elements;
using OpenQA.Selenium;

namespace Mitre.PageFramework
{
    public class Navigator : INavigator
    {
        private readonly IWebDriver driver;
        private readonly IScriptExecutor executor;

        internal Navigator(IWebDriver driver, IScriptExecutor executor)
        {
            this.driver = driver;
            this.executor = executor;
        }

        public TPage To<TPage>(By clickDestination) where TPage : UiElement, new()
        {
            executor.ActionOnLocator(clickDestination, e => e.Click());
            return new TPage();
        }

        public TPage To<TPage>(string relativeUrl) where TPage : UiElement, new()
        {
            driver.Navigate().GoToUrl(relativeUrl);
            return new TPage();
        }
    }
}