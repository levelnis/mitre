using System;
using OpenQA.Selenium;

namespace Mitre.PageFramework.Actions
{
    public class ScriptExecutor : IScriptExecutor
    {
        private readonly IWebDriver browser;

        internal ScriptExecutor(IWebDriver browser)
        {
            this.browser = browser;
        }

        public IWebElement ActionOnLocator(By findElement, Action<IWebElement> action)
        {
            var element = browser.TryFindElement(findElement);
            return element == null ? null : CallActionOnLocator(element, action);
        }

        public IWebElement ActionOnLocator(IWebElement context, By findElement, Action<IWebElement> action)
        {
            var element = context.TryFindElement(findElement);
            return element == null ? null : CallActionOnLocator(element, action);
        }

        private static IWebElement CallActionOnLocator(IWebElement element, Action<IWebElement> action)
        {
            action(element);
            return element;
        }
    }
}