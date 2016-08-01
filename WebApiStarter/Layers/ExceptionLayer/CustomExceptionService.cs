using WebApiStarter.Layers.ExceptionLayer.Exceptions;

namespace WebApiStarter.Layers.ExceptionLayer
{
    public static class CustomExceptionService
    {
        public static void ThrowItemNotFoundException()
        {
            throw new ItemNotFoundException("Item not found");
        }

        public static void ThrowModelNotValidException(string error)
        {
            throw new ModelNotValidException(string.Format("Model not valid: {0}", error));
        }

        public static void ThrowMappingNotValidException(string column)
        {
            throw new MappingNotValidException(string.Format("Mapping not valid: column \"{0}\" doesn't exist in DataReader", column));
        }
    }
}