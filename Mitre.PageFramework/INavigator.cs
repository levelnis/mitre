using OpenQA.Selenium;

namespace Mitre.PageFramework
{
    public interface INavigator
    {
        TPage To<TPage>(By clickDestination) where TPage : UiElement, new();
        TPage To<TPage>(string relativeUrl) where TPage : UiElement, new();
    }
}