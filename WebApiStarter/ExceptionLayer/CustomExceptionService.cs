
namespace WebApiStarter.ExceptionLayer
{
    public static class CustomExceptionService
    {
        public static void ThrowItemNotFoundException()
        {
            throw new ItemNotFoundException("Item not found");
        }

        public static void ThrowModelNotValidException()
        {
            throw new ModelNotValidException("Item not valid");
        }
    }
}