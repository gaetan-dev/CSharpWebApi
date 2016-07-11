using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApiStarter.Commons.ExceptionLayer;
using WebApiStarter.Commons.LogLayer;

namespace WebApiStarter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Exception Handler
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            // Logger Handler
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

            // Log4net
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
