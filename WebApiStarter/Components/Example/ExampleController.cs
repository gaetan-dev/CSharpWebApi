using System.Web.Http;
using WebApiStarter.Commons.ModelValidation;
using WebApiStarter.Components.Example.Model;
using WebApiStarter.Components.Example.Service;
using WebApiStarter.Layers.ExceptionLayer.Exceptions;

namespace WebApiStarter.Components.Example
{
    public class ExampleController : ApiController, IController<ExampleModel>
    {
        private readonly IExampleService _exampleService;

        // Required for Acceptance Tests
        public ExampleController()
        {
            _exampleService = new ExampleService();
        }

        // Required for Dependency Injection
        public ExampleController(IExampleService service)
        {
            _exampleService = service;
        }

        [HttpGet]
        [Route("api/example/")]
        public IHttpActionResult GetAll()
        {
            var result = _exampleService.ReadAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/example/{id}")]
        [ItemNotFoundExceptionFilter]
        public IHttpActionResult Get(string id)
        {
            var result = _exampleService.Read(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/example/")]
        [ValidationActionFilter]
        public IHttpActionResult Post(ExampleModel example)
        {
            example = _exampleService.Create(example);

            string location = Request.RequestUri + example.Id;
            return Created(location, example);
        }

        [HttpPut]
        [Route("api/example/")]
        public IHttpActionResult Put(ExampleModel example)
        {
            example = _exampleService.Update(example);
            return Ok(example);
        }

        [HttpDelete]
        [Route("api/example/{id}")]
        public IHttpActionResult Delete(string id)
        {
            _exampleService.Delete(id);
            return Ok();
        }
    }
}