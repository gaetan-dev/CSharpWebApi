using System.Web.Http;
using WebApiStarter.Commons.ExceptionLayer;
using WebApiStarter.Commons.ModelValidation;

namespace WebApiStarter.Components.Example
{
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

        [HttpGet]
        [Route("api/example/{id}")]
        [ItemNotFoundExceptionFilter]
        public IHttpActionResult Get(int id)
        {
            var result = _exampleService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/example/")]
        [ValidationActionFilter]
        public IHttpActionResult Post(Example example)
        {
            _exampleService.Set(example);
            return Ok();
        }

        [HttpPut]
        [Route("api/example/")]
        public IHttpActionResult Put(Example model)
        {
            return Post(model);
        }

        [HttpDelete]
        [Route("api/example/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _exampleService.Delete(id);
            return Ok();
        }
    }
}