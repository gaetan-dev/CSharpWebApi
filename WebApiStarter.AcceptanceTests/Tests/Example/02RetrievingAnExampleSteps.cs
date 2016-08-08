using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebApiStarter.Components.Example.Model;

namespace WebApiStarter.AcceptanceTests.Tests.Example
{
    [Binding]
    public class RetrievingAnExampleSteps : ExampleSteps
    {
        private ExampleModel _expect;

        [Given(@"an existing example '(.*)', '(.*)', '(.*)'")]
        public void GivenAnExistingExample(string id, string p1, string p2)
        {
            _expect = new ExampleModel
            {
                Id = id,
                Prop1 = p1,
                Prop2 = p2
            };
        }

        [When(@"it is retrieved")]
        public void ItIsRetrieved()
        {
            using (var client = CreateClient())
            {
                Response = client.GetAsync(new Uri(client.BaseAddress, _expect.Id)).Result;
            }

            Example = Response.Content.ReadAsAsync<ExampleModel>().Result;
        }

        [Then(@"a '200 Ok' status is returned")]
        public void ThenAStatusIsReturned()
        {
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, Response.StatusCode);
        }
        
        [Then(@"it is returned")]
        public void ThenItIsReturned()
        {
            // Assert
            Assert.NotNull(Example);
        }

        [Then(@"it should have an id")]
        public void ThenItShouldHaveAnId()
        {
            // Assert 
            Assert.AreEqual(_expect.Id, Example.Id);
        }

        [Then(@"it should have a prop1 and a prop2")]
        public void ThenItShouldHaveAProp1()
        {
            // Assert 
            Assert.AreEqual(_expect.Prop1, Example.Prop1);
            Assert.AreEqual(_expect.Prop2, Example.Prop2);
        }
    }
}
