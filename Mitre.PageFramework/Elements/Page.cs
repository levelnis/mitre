namespace Mitre.PageFramework.Elements
{
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public abstract class Page : UiElement
    {
        public string Title
        {
            get { return Browser.Title; }
        }

        public string Url
        {
            get { return Browser.Url; }
        }

        protected IWebElement ClickElement(string id)
        {
            return Execute().ActionOnLocator(By.Id(id), e => e.Click());
        }

        /// <summary>
        /// Clicks an element by sending the enter key. Use when ClickElement does not work.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected IWebElement ClickElementViaKeys(string id)
        {
            return Execute().ActionOnLocator(By.Id(id), e => e.SendKeys(Keys.Enter));
        }

        protected TComponent Component<TComponent>() where TComponent : Component, new()
        {
            return new TComponent();
        }
        protected IWebElement EnterTextData(string id, string data)
        {
            return Execute().ActionOnLocator(By.Id(id), e => e.ClearAndSendKeys(data));
        }

        protected string FindTextById(string id)
        {
            return Find().TryFindElement(By.Id(id)).Text;
        }

        protected string FindTextBySelector(string selector)
        {
            return Find().TryFindElement(By.CssSelector(selector)).Text;
        }

        protected TTargetPage GoToPageById<TTargetPage>(string id) where TTargetPage : UiElement, new()
        {
            return Navigate().To<TTargetPage>(By.Id(id));
        }

        protected TTargetPage GoToPageByIdViaKeys<TTargetPage>(string id) where TTargetPage : UiElement, new()
        {
            return Navigate().ViaKeysTo<TTargetPage>(By.Id(id));
        }

        protected TTargetPage GoToPageByLinkText<TTargetPage>(string linkText) where TTargetPage : UiElement, new()
        {
            return Navigate().To<TTargetPage>(By.LinkText(linkText));
        }

        protected TTargetPage GoToPageByLinkText<TTargetPage>(string contextId, string linkText) where TTargetPage : UiElement, new()
        {
            return Navigate().To<TTargetPage>(contextId, By.LinkText(linkText));
        }

        protected TTargetPage GoToPageByLinkTextViaKeys<TTargetPage>(string linkText) where TTargetPage : UiElement, new()
        {
            return Navigate().ViaKeysTo<TTargetPage>(By.LinkText(linkText));
        }

        protected TTargetPage GoToPageByLinkTextViaKeys<TTargetPage>(string contextId, string linkText) where TTargetPage : UiElement, new()
        {
            return Navigate().ViaKeysTo<TTargetPage>(contextId, By.LinkText(linkText));
        }

        protected IWebElement SelectOption(string id, string optionText)
        {
            return Execute().ActionOnLocator(By.Id(id), e => new SelectElement(e).SelectByText(optionText));
        }

        protected IWebElement SelectRadioLabelText(string containerId, string labelText)
        {
            var context = FindContext(containerId);
            var labels = context.FindElements(By.TagName("label"));
            var matchingLabel = labels.FirstOrDefault(label => label.Text == labelText);
            if (matchingLabel != null)
            {
                matchingLabel.Click();
            }

            return matchingLabel;
        }

        protected IWebElement SubmitForm(string containerId)
        {
            return Execute().ActionOnLocator(FindContext(containerId), By.CssSelector("button[type='submit']"), e => e.Click());
        }

        /// <summary>
        /// Submits form by sending the enter key. Use when SubmitForm does not work.
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        protected IWebElement SubmitFormViaKeys(string containerId)
        {
            return Execute().ActionOnLocator(FindContext(containerId), By.CssSelector("button[type='submit']"), e => e.SendKeys(Keys.Enter));
        }
    }
}