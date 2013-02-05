using OpenQA.Selenium;

namespace Mitre.PageFramework.Elements
{
    public abstract class Component : UiElement
    {
         protected IWebElement FindContainer(string selector)
         {
             return Find().TryFindElement(By.CssSelector(selector));
         }
    }
}