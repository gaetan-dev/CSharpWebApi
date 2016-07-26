# C# Web API 2
---
## [Exceptions](https://www.exceptionnotfound.net/the-asp-net-web-api-exception-handling-pipeline-a-guided-tour/)
### Level 1 - HttpResponseException
 * Controller.cs

```csharp
[HttpGet]
[Route("CheckId/{id}")]
public IHttpActionResult Get(int id)  
{
    if (id > 100)
    {
        var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            Content = new StringContent("We cannot use IDs greater than 100.")
        };
        throw new HttpResponseException(message);
    }
    return Ok(id);
}

[HttpGet]
[Route("HttpError")]
public HttpResponseMessage HttpError()  
{
    return Request.CreateResponse(HttpStatusCode.Forbidden, "You cannot access this method at this time.");
}

[HttpGet]
[Route("Forbidden")]
public IHttpActionResult Forbidden()  
{
    return Forbidden();
}

[HttpGet]
[Route("OK")]
public IHttpActionResult OK()  
{
    return Ok();
}

[HttpGet]
[Route("NotFound")]
public IHttpActionResult NotFound()  
{
    return NotFound();
}
```

### Level 2 - Exception Filters
* Controller.cs

```csharp
[HttpGet]
[Route("ItemNotFound/{id}")]
[ItemNotFoundExceptionFilter]
public IHttpActionResult ItemNotFound(int id)  
{
    CustomExceptionService.ThrowItemNotFoundException();
    return Ok();
}
```

* CustomExceptionService.cs

```csharp
public class CustomExceptionService  
{
    public static void ThrowItemNotFoundException()
    {
        throw new ItemNotFoundException("This is a custom exception.");
    }
}
```

* ItemNotFoundException.cs

```csharp
public class ItemNotFoundException : Exception  
{
    public ItemNotFoundException(string message) : base(message) { }
    public ItemNotFoundException(string message, Exception ex) : base(message, ex) { }
}

public class ItemNotFoundExceptionFilterAttribute : ExceptionFilterAttribute  
{
    public override void OnException(HttpActionExecutedContext context)
    {
        if (context.Exception is ItemNotFoundException)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(context.Exception.Message),
                ReasonPhrase = "ItemNotFound"
            };
            throw new HttpResponseException(resp);
        }
    }
}
```

### Level 3 - Logging (go to Logs chapter)
* UnhandledExceptionLogger.cs

```csharp
public class UnhandledExceptionLogger : ExceptionLogger  
{
    public override void Log(ExceptionLoggerContext context)
    {
        var log = context.Exception.ToString();
        //Do whatever logging you need to do here.
    }
}
```

* In the WebApiConfig file

```csharp
config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());  
```

### Level 4 - Exception Handlers
The last step in our exception handling pipeline is an Exception Handler. Exception Handlers are called after Exception Filters and Exception Loggers, and only if the exception has not already been handled. Here's our Exception Handler:

* Controller.cs

```csharp
[Route("ArgumentNull/{id}")]
[HttpPost]
public IHttpActionResult ArgumentNull(int id)  
{
   CustomExceptionService.ThrowArgumentNullException();
   return Ok();
}
```

* GlobalExceptionHandler.cs

```csharp
public class GlobalExceptionHandler : ExceptionHandler  
{
    public override void Handle(ExceptionHandlerContext context)
    {
        if (context.Exception is ArgumentNullException)
        {
            var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(context.Exception.Message),
                ReasonPhrase = "ArgumentNullException"
            };

            context.Result = new ArgumentNullResult(context.Request, result);
        }
        else
        {
            // Handle other exceptions, do other things
        }
    }

    public class ArgumentNullResult : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private HttpResponseMessage _httpResponseMessage;


        public ArgumentNullResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
        {
            _request = request;
            _httpResponseMessage = httpResponseMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_httpResponseMessage);
        }
    }
}
```

* In the WebApiConfig file

```csharp
config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());  
```

## Logs
### [Log4net](http://lutecefalco.developpez.com/tutoriels/dotnet/log4net/introduction/)
* In Web.config

```xml
<configuration>
  <configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
  </configSections>
  <!-- ... -->
  <log4net debug="true">
    <appender name="RollingFileMonitoring" type="log4net.Appender.RollingFileAppender">
      <file value="C:\Logs\WebApi\log.txt" />
      <!-- La valeur doit être l'un des niveaux de log. La valeur par défaut est ALL. Modifier la valeur pour limiter les messages qui sont loggés dans l'application sans tenir compte du logger qui log le message. -->
      <threshold value="ALL" />
      <!-- indique si le fichier sera écrasé (false) ou si le les logs seront écrits à la suite (true). -->
      <appendToFile value="true" />
      <!-- définit le critère suivant lequel sera renommé le fichier. -->
      <rollingStyle value="Date" />
      <!-- définit le pattern utilisé pour renommer le fichier quand le rollingStyle a la valeur Date. -->
      <datePattern value="yyyyMMdd" />
      <encoding value="utf-8" />
      <!--Formatage du message-->
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%level||%date||%message||%newline" />
      </layout>
    </appender>
    <root>
      <level value="ALL" />
      <appender-ref ref="RollingFileMonitoring" />
    </root>
  </log4net>
  <!-- ... -->
</configuration>
```

* In Global.asax

```csharp
[assembly: XmlConfigurator(ConfigFile = "web.config", Watch = true)]
namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        /* ... */
    }
}
```

* In App_Start/WebApiConfig.cs

```csharp
namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /* ... */

            // Logger Handler
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());  

            // Log4net
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
```

* In UnhandledExceptionLogger.cs

```csharp
public class UnhandledExceptionLogger : ExceptionLogger
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(ExceptionLogger));

    public override void Log(ExceptionLoggerContext context)
    {
        Logger.Debug(context.Exception.ToString());
    }
}
```

## [Injection Dependency](http://bitoftech.net/2013/11/09/implementing-dependency-injection-using-ninject/)
* Create IExampleService.cs

```csharp
public interface IExampleService.cs
{
    void List<Example> getAll();
}
```

* In ExampleService.cs

```csharp
public class ExampleService : IExampleService
{
    public List<Example> GetAll()
    {
        List<Example> result = CallDb("PS_GetAllExamples", null);
        return result;
    }
}
```

* In MockExampleService.cs

```csharp
public class MockExampleService : IExampleService
{
    public List<Example> GetAll()
    {
        return new List<Example>
        {
            new Example()
            {
                Id = -1,
                Prop1 = "Mock01",
                Prop2 = "Mock02",
            },
                new Example()
            {
                Id = -2,
                Prop1 = "Mock11",
                Prop2 = "Mock12",
            }
        };
    }
}
```

* In ExampleController.cs

```csharp
public class ExampleController : ApiController, IController<Example>
{
    private readonly IExampleService _exampleService;

    public ExampleController()
    {
        _exampleService = new ExampleService();
    }

	// Required for Ninject
    public ExampleController(IExampleService service)
    {
        _exampleService = service;
    }

    [HttpGet]
    [Route("api/example/")]
    public IHttpActionResult GetAll()
    {
        var result = _exampleService.GetAll();
        return Ok(result);
    }
}
```

### [Ninject](http://www.peterprovost.org/blog/2012/06/19/adding-ninject-to-web-api)
```
PM> Install-Package Ninject.Web.WebApi
PM> Install-Package Ninject.Web.WebApi.WebHost
```

* Create NinjectDependencyScope.cs

```csharp
// Provides a Ninject implementation of IDependencyScope
// which resolves services using the Ninject container.
public class NinjectDependencyScope : IDependencyScope
{
    protected IResolutionRoot Resolver;

    public NinjectDependencyScope(IResolutionRoot resolver)
    {
        Resolver = resolver;
    }

    public object GetService(Type serviceType)
    {
        if (Resolver == null)
            throw new ObjectDisposedException("this", "This scope has been disposed");

        return Resolver.TryGet(serviceType);
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
        if (Resolver == null)
            throw new ObjectDisposedException("this", "This scope has been disposed");

        return Resolver.GetAll(serviceType);
    }

    public void Dispose()
    {
        IDisposable disposable = Resolver as IDisposable;
        if (disposable != null)
            disposable.Dispose();

        Resolver = null;
    }
}
```

* Create NinjectDependencyResolver.cs

```csharp
// This class is the _resolver, but it is also the global scope
// so we derive from NinjectScope.
public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
{
    private readonly IKernel _kernel;

    public NinjectDependencyResolver(IKernel kernel) : base(kernel)
    {
        _kernel = kernel;
    }

    public IDependencyScope BeginScope()
    {
        return new NinjectDependencyScope(_kernel.BeginBlock());
    }
}
```

* In App_Start.NinjectWebCommon.cs

```csharp
private static IKernel CreateKernel()
{
    var kernel = new StandardKernel();
    try
    {
        kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
        kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

		// Add this
        RegisterServices(kernel);

        return kernel;
    }
    catch
    {
        kernel.Dispose();
        throw;
    }
}

private static void RegisterServices(IKernel kernel)
{
    // This is where we tell Ninject how to resolve service requests
    kernel.Bind<IExampleService>().To<ExampleService>();
}  
```