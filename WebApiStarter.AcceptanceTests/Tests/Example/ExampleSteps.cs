using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;
using TechTalk.SpecFlow;
using WebApiStarter.AcceptanceTests.SelfHosting;
using WebApiStarter.Components.Example.Model;

namespace WebApiStarter.AcceptanceTests.Tests.Example
{
    [Binding]
    public class ExampleSteps
    {
        protected ExampleModel Example;

        private static IDisposable _server;

        protected const string Uri = "http://localhost:56127";
        protected const string Url = Uri + "/api/example/";
        protected HttpResponseMessage Response;

        [BeforeFeature]
        public static void CreateVirtualServer()
        {
            _server = WebApp.Start<Startup>(Uri);
        }

        [AfterFeature]
        public static void DisposeVirtualServer()
        {
            _server.Dispose();
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(Url)
            };
            return client;
        }
    }
}
