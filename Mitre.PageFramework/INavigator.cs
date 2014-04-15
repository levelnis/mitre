using Mitre.PageFramework.Elements;
using OpenQA.Selenium;

namespace Mitre.PageFramework
{
    public interface INavigator
    {
        /// <summary>
        /// Navigates by sending the enter key rather than clicking. Use when To does not work.
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <param name="clickDestination"></param>
        /// <returns></returns>
        TPage ViaKeysTo<TPage>(By clickDestination) where TPage : UiElement, new();

        TPage To<TPage>(By clickDestination) where TPage : UiElement, new();

        TPage To<TPage>(string relativeUrl) where TPage : UiElement, new();
    }
}