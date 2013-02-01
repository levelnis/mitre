using System.Configuration;

namespace Mitre.PageFramework
{
    public static class AppSettings
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        public static readonly string SiteRoot = ConfigurationManager.AppSettings["SiteRoot"];
    }
}