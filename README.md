Mitre
=====

Mitre is a simple fluent page framework for acceptance test driven development, written in C#. It allows you to create Page objects that mirror the actual pages within the site you are testing, so that you can separate the responsibility of interacting with elements on different pages.

Usage is controlled via a static Runner class, which uses a fluent interface to abstract the actual DOM manipulation and navigation, which happens under the hood via Selenium WebDriver.

Typical Usage with SpecFlow
---------------------------

Within your acceptance test project, create a suitable namespace (e.g. Pages)

Create classes inheriting from Mitre.PageFramework.Elements.Page (e.g. HomePage)

If there is a DOM navigation element on a page that links to another page, create a method to replicate that behaviour, which returns an instance of the target page

If there is a form to be filled in, create methods that handle the text input and submit the form

e.g. For a simple about us form with name, email address and message fields, which displays a success message once the form has been sent:

Pages
-----

    public class HomePage : Page 
    {
        public AboutUsPage GoToAboutUs()
        {
            return GoToPageById<AboutUsPage>("aboutUsLinkId");
        }
    }
    
    public class AboutUsPage : Page
    {
        public string SuccessMessage
        {
            // replace with meaningful css selector to find the element that you want
            get { return FindTextBySelector("#MessageContainer .alert span"); }
        }
        
        public AboutUsPage EnterName(string name)
        {
            EnterTextData("Name", name);
            return this;
        }
        
        public AboutUsPage EnterEmailAddress(string emailAddress)
        {
            EnterTextData("EmailAddress", emailAddress);
            return this;
        }
        
        
        public AboutUsPage EnterMessage(string message)
        {
            EnterTextData("Message", message);
            return this;
        }
        
        public void SendMessage()
        {
            // this method looks for a button of type submit within the DOM element with id of buttonContainerId
            SubmitForm("buttonContainerId");
        }
        
    }
    

SpecFlow Steps
--------------

    [Given(@"I am on the about us page")]
    public void GivenIAmOnTheAboutUsPage()
    {
        Runner.GoTo<HomePage>(AppSettings.BaseUrl)
            .GoToAboutUs();
    }

    [Given(@"I enter the following message details")]
    public void GivenIHaveEnteredSomethingAsTheName(Table table)
    {
        var row = table.Rows[0];
        Runner.Page<AboutUsPage>()
            .EnterName(row["Name"])
            .EnterEmailAddress(row["Email address"])
            .EnterMessage(row["Message"]);
    }

    [When(@"I send the message")]
    public void WhenISendTheMessage()
    {
        Runner.Page<AboutUsPage>()
            .SendMessage();
    }

    [Then(@"I should see a success message saying '(.*)'")]
    public void ThenIShouldSeeASuccessMessageSayingSomething(string messageText)
    {
        Assert.That(Runner.Page<AboutUsPage>().SuccessMessage, Is.EqualTo(messageText));
    }
