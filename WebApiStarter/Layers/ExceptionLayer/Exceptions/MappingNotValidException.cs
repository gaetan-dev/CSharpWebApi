using System;

namespace WebApiStarter.Layers.ExceptionLayer.Exceptions
{
    public class MappingNotValidException : Exception
    {
        public MappingNotValidException(string message) : base(message) { }
        public MappingNotValidException(string message, Exception ex) : base(message, ex) { }
    }
}