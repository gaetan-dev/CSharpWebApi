using TechTalk.SpecFlow;

namespace WebApiStarter.AcceptanceTests.Tests.Example
{
    [Binding]
    public class RetrievingAllExamplesSteps : ExampleSteps
    {
        [Given(@"existing examples")]
        public void GivenExistingExamples()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"all issues are retrieved")]
        public void WhenAllIssuesAreRetrieved()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"all issues are returned")]
        public void ThenAllIssuesAreReturned()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
