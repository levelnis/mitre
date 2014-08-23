using Mitre.PageFramework.Actions;
using Mitre.PageFramework.Elements;
using OpenQA.Selenium;

namespace Mitre.PageFramework
{
    internal class Navigator : INavigator
    {
        private readonly IWebDriver driver;
        private readonly IScriptExecutor executor;

        internal Navigator(IWebDriver driver, IScriptExecutor executor)
        {
            this.driver = driver;
            this.executor = executor;
        }

        /// <summary>
        /// Navigates by sending the enter key rather than clicking. Use when To does not work.
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <param name="clickDestination"></param>
        /// <returns></returns>
        public TPage ViaKeysTo<TPage>(By clickDestination) where TPage : UiElement, new()
        {
            executor.ActionOnLocator(clickDestination, e => e.SendKeys(Keys.Enter));
            return new TPage();
        }

        public TPage To<TPage>(By clickDestination) where TPage : UiElement, new()
        {
            executor.ActionOnLocator(clickDestination, e => e.Click());
            return new TPage();
        }

        public TPage ViaKeysTo<TPage>(string contextId, By clickDestination) where TPage : UiElement, new()
        {
            var contextElement = driver.TryFindElement(By.Id(contextId));
            executor.ActionOnLocator(contextElement, clickDestination, e => e.SendKeys(Keys.Enter));
            return new TPage();
        }

        public TPage To<TPage>(string contextId, By clickDestination) where TPage : UiElement, new()
        {
            var contextElement = driver.TryFindElement(By.Id(contextId));
            executor.ActionOnLocator(contextElement, clickDestination, e => e.Click());
            return new TPage();
        }

        public TPage To<TPage>(string relativeUrl) where TPage : UiElement, new()
        {
            driver.Navigate().GoToUrl(relativeUrl);
            return new TPage();
        }
    }
}