using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WebApiStarter.ExceptionLayer
{
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
                HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "ItemNotFound"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}