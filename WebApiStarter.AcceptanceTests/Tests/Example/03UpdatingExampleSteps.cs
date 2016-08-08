using System.Net;
using System.Net.Http;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebApiStarter.Components.Example;
using WebApiStarter.Components.Example.Model;

namespace WebApiStarter.AcceptanceTests.Tests.Example
{
    [Binding]
    public class UpdatingExampleSteps : ExampleSteps
    {
        private ExampleModel _result;

        [Given(@"an example '(.*)', '(.*)', '(.*)'")]
        public void GivenAnExample(string id, string p1, string p2)
        {
            // Arrange
            Example = new ExampleModel
            {
                Id = id,
                Prop1 = p1,
                Prop2 = p2
            };
        }
        
        [When(@"a PUT request is made")]
        public void WhenAPutRequestIsMade()
        {
            using (var client = CreateClient())
            {
                Response = client.PutAsJsonAsync(client.BaseAddress, Example).Result;
            }

            _result = Response.Content.ReadAsAsync<ExampleModel>().Result;
        }

        [Then(@"a '200 Ok' status is returned"), Scope(Tag = "update")]
        public void ThenAStatusIsReturned()
        {
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, Response.StatusCode);
        }
        
        [Then(@"the example should be updated")]
        public void ThenTheExampleShouldBeUpdated()
        {
            // Assert
            Assert.AreEqual(Example, _result);
        }
    }
}
