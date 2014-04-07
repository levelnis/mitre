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
    }
}