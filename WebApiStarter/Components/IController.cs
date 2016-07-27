using System.Web.Http;

namespace WebApiStarter.Components
{
    internal interface IController<in T>
    {
        IHttpActionResult GetAll();
        IHttpActionResult Get(int id);
        IHttpActionResult Post(T model);
        IHttpActionResult Put(T model);
        IHttpActionResult Delete(int id);
    }
}
