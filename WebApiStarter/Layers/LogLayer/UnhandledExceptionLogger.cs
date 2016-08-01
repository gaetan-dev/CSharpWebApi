using System.Web.Http.ExceptionHandling;
using log4net;

namespace WebApiStarter.Layers.LogLayer
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ExceptionLogger));

        public override void Log(ExceptionLoggerContext context)
        {
            Logger.Debug(context.Exception.ToString());
        }
    }
}