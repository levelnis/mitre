namespace Mitre.PageFramework
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
    }
}