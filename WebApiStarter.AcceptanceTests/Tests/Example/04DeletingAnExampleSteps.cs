using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebApiStarter.Components.Example.Model;

namespace WebApiStarter.AcceptanceTests.Tests.Example
{
    [Binding]
    public class DeletingAnExampleSteps : ExampleSteps
    {
        [Given(@"an existing example's id '(.*)'")]
        public void GivenAnExistingExampleId(string id)
        {
            Example = new ExampleModel
            {
                Id = id
            };
        }

        [When(@"it is deleted")]
        public void WhenItIsDeleted()
        {
            using (var client = CreateClient())
            {
                Response = client.DeleteAsync(new Uri(client.BaseAddress, Example.Id.ToString(CultureInfo.InvariantCulture))).Result;
            }
        }

        [Then(@"a '200 Ok' status is returned"), Scope(Tag = "delete")]
        public void ThenAStatusIsReturned()
        {
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, Response.StatusCode);
        }
        
        [Then(@"the issue should be removed")]
        public void ThenTheIssueShouldBeRemoved()
        {
            // Act
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.GetAsync(new Uri(client.BaseAddress, Example.Id.ToString(CultureInfo.InvariantCulture))).Result;
            }

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
