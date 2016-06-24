using System;
using System.Web.Http;
using WebApiStarter.ExceptionLayer;

namespace WebApiStarter.Components.Example
{
    public class ExampleController : ApiController, IController<Example>
    {
        private readonly IRepoDb<Example>_exampleRepoDb;

        public ExampleController()
        {
            _exampleRepoDb = new ExampleRepoDb();
        }

        [HttpGet]
        [Route("api/example/")]
        public IHttpActionResult GetAll()
        {
            var result = _exampleRepoDb.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/example/{id}")]
        [ItemNotFoundExceptionFilter]
        public IHttpActionResult Get(int id)
        {
            var result = _exampleRepoDb.Get(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/example/")]
        [ModelNotValidExceptionFilter]
        public IHttpActionResult Post(Example example)
        {
            if (!ModelState.IsValid)
                CustomExceptionService.ThrowModelNotValidException();

            _exampleRepoDb.Set(example);
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
            _exampleRepoDb.Delete(id);
            return Ok();
        }
    }
}