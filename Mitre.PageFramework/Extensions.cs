using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mitre.PageFramework
{
    public static class Extensions
    {
        public static void ClearAndSendKeys(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public static bool AsBool(this string visibility)
        {
            return visibility == "visible";
        }

        public static string AsAbsoluteUrl(this string relativeUrl)
        {
            return string.Concat(AppSettings.BaseUrl, relativeUrl);
        }

        public static IWebElement TryFindElement(this IWebDriver context, By by)
        {
            IWebElement result = null;
            try
            {
                var wait = new WebDriverWait(context, TimeSpan.FromSeconds(5));
                result = wait.Until(d => d.FindElement(by));
            }
            catch (NoSuchElementException)
            {
            }
            catch (TimeoutException)
            {
            }

            return result;
        }

        public static IWebElement TryFindElement(this IWebElement context, By by)
        {
            IWebElement result = null;
            try
            {
                result = context.FindElement(by);
            }
            catch (NoSuchElementException)
            {
            }

            return result;
        }

        public static void VerifyVisibility(this IWebElement webElement, string visibility)
        {
            if (visibility == "visible")
            {
                webElement.Displayed.Should().Be(true);
            }
            else
            {
                webElement.Should().Be(null);
            }
        }
    }
}