using OpenQA.Selenium;

namespace Mitre.PageFramework.Actions
{
    public interface IElementFinder
    {
        IWebElement TryFindElement(By by);
    }
}