using Mitre.PageFramework.Actions;
using OpenQA.Selenium;

namespace Mitre.PageFramework.Elements
{
    public abstract class UiElement
    {
        private readonly ElementFinder elementFinder;

        protected UiElement()
        {
            elementFinder = new ElementFinder(Browser);
        }

        protected static IWebDriver Browser
        {
            get { return Runner.Host; }
        }

        protected INavigator Navigate()
        {
            return Runner.Navigator;
        }

        protected IScriptExecutor Execute()
        {
            return Runner.Executor;
        }

        protected IElementFinder Find()
        {
            return elementFinder;
        }

        protected IWebElement FindContext(string contextId)
        {
            return Find().TryFindElement(By.Id(contextId));
        }
    }
}