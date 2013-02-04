namespace Mitre.PageFramework.Elements
{
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

        protected TComponent Component<TComponent>() where TComponent : Component, new()
        {
            return new TComponent();
        }

    }
}