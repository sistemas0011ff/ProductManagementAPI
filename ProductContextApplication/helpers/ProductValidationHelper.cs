namespace ProductManagementAPI.Product.Application.helpers
{
    public static class ProductValidationHelper
    {
        public static void EnsureNotNull<T>(T obj, string errorMessage) where T : class
        {
            if (obj == null)
                throw new ApplicationException(errorMessage);
        }
    }
}
