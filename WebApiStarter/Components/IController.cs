using System.Web.Http;

namespace WebApiStarter.Components
{
    public interface IController<in T>
    {
        IHttpActionResult GetAll();
        IHttpActionResult Get(string id);
        IHttpActionResult Post(T model);
        IHttpActionResult Put(T model);
        IHttpActionResult Delete(string id);
    }
}
