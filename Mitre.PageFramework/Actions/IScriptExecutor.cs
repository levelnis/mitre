using System;
using OpenQA.Selenium;

namespace Mitre.PageFramework.Actions
{
    public interface IScriptExecutor
    {
        IWebElement ActionOnLocator(By findElement, Action<IWebElement> action);
        IWebElement ActionOnLocator(IWebElement context, By findElement, Action<IWebElement> action);
    }
}