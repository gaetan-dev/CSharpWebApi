using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WebApiStarter.ExceptionLayer
{
    public class ModelNotValidException : Exception
    {
        public ModelNotValidException(string message) : base(message) { }
        public ModelNotValidException(string message, Exception ex) : base(message, ex) { }
    }

    public class ModelNotValidExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ModelNotValidException)
            {
                HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "ModelNotValid"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}