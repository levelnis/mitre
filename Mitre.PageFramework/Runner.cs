using System;
using Mitre.PageFramework.Actions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace Mitre.PageFramework
{
    public static class Runner
    {
        private static IScriptExecutor executor;
        private static INavigator navigator;

        internal static IWebDriver Host { get; private set; }

        public static IScriptExecutor Executor
        {
            get { return executor ?? (executor = new ScriptExecutor(Host)); }
        }

        public static INavigator Navigator
        {
            get { return navigator ?? (navigator = new Navigator(Host, Executor)); }
        }

        public static void InitialiseHost(HostTypeOption hostType, int windowWidth = 1024, int windowHeight = 768)
        {
            switch (hostType)
            {
                case HostTypeOption.Firefox:
                    Host = new FirefoxDriver();
                    break;
                case HostTypeOption.InternetExplorer:
                    Host = new InternetExplorerDriver();
                    break;
                case HostTypeOption.Chrome:
                    Host = new ChromeDriver();
                    break;
                case HostTypeOption.Safari:
                    Host = new SafariDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("hostType");
            }
            Host.Manage().Window.Size = new System.Drawing.Size(windowWidth, windowHeight);
            Host.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
        }

        public static void StopHost()
        {
            Host.Quit();
            ClearUp();
        }

        private static void ClearUp()
        {
            Host = null;
            executor = null;
            navigator = null;
        }
    }
}