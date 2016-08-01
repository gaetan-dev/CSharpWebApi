using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using MySql.Data.MySqlClient;
using WebApiStarter.Layers.ExceptionLayer.Exceptions;

namespace WebApiStarter.Layers.ExceptionLayer
{
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
            else if (context.Exception is SqlException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("SqlClientException"),
                    ReasonPhrase = "SqlClientException"
                };

                context.Result = new SqlClientException(context.Request, result);
            }
            else if (context.Exception is MySqlException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("MySqlClientException"),
                    ReasonPhrase = "MySqlClientException"
                };

                context.Result = new SqlClientException(context.Request, result);
            }
            else if (context.Exception is MappingNotValidException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("MappingException"),
                    ReasonPhrase = "MappingException"
                };

                context.Result = new MappingException(context.Request, result);
            }
            else if (context.Exception is ModelNotValidException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("ModelNotValidException"),
                    ReasonPhrase = "ModelNotValidException"
                };

                context.Result = new MappingException(context.Request, result);
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

        public class SqlClientException : IHttpActionResult
        {
            private HttpRequestMessage _request;
            private HttpResponseMessage _httpResponseMessage;


            public SqlClientException(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
            {
                _request = request;
                _httpResponseMessage = httpResponseMessage;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(_httpResponseMessage);
            }
        }

        public class MappingException : IHttpActionResult
        {
            private HttpRequestMessage _request;
            private HttpResponseMessage _httpResponseMessage;


            public MappingException(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
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
}