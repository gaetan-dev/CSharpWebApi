using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebApiStarter.Components.Example;
using WebApiStarter.Components.Example.Model;

namespace WebApiStarter.AcceptanceTests.Tests.Example
{
    [Binding]
    public class CreatingExampleSteps : ExampleSteps
    {
        private ExampleModel _result;

        [Given(@"a new example '(.*)', '(.*)', '(.*)'")]
        public void GivenANewExample(string id, string p1, string p2)
        {
            // Arrange
            Example = new ExampleModel
            {
                Id    = id,
                Prop1 = p1,
                Prop2 = p2
            };
        }
        
        [When(@"a POST request is made")]
        public void WhenAPostRequestIsMade()
        {
            using (var client = CreateClient())
            {
                Response = client.PostAsJsonAsync(client.BaseAddress, Example).Result;
            }

            _result = Response.Content.ReadAsAsync<ExampleModel>().Result;
        }
        
        [Then(@"a '201 Created' status is returned")]
        public void ThenAStatusIsReturned()
        {
            // Assert
            Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);
        }

        [Then(@"the example should be added")]
        public void ThenTheExampleShouldBeAdded()
        {
            // Assert
            Assert.AreEqual(Example, _result);
        }

        [Then(@"the response location header will be set to the resource location")]
        public void ThenTheResponseLocationHeaderWillBeSetToTheResourceLocation()
        {
            // Assert
            Assert.AreEqual(new Uri(Url + Example.Id), Response.Headers.Location);
        }
    }
}
