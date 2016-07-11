using System;

namespace WebApiStarter.Commons.ExceptionLayer
{
    public class MappingNotValidException : Exception
    {
        public MappingNotValidException(string message) : base(message) { }
        public MappingNotValidException(string message, Exception ex) : base(message, ex) { }
    }
}