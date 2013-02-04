using OpenQA.Selenium;

namespace Mitre.PageFramework.Elements
{
    public abstract class Component : UiElement
    {
         protected IWebElement Container(string selector)
         {
             return Find().TryFindElement(By.CssSelector(selector));
         }
    }
}