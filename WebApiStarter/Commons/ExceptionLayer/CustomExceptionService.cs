
namespace WebApiStarter.Commons.ExceptionLayer
{
    public static class CustomExceptionService
    {
        public static void ThrowItemNotFoundException()
        {
            throw new ItemNotFoundException("Item not found");
        }

        public static void ThrowModelNotValidException()
        {
            throw new ModelNotValidException("Model not valid");
        }

        public static void ThrowMappingNotValidException(string column)
        {
            throw new MappingNotValidException(string.Format("Mapping not valid: column \"{0}\" doesn't exist in DataReader", column));
        }
    }
}