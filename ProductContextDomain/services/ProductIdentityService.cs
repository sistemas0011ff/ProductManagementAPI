using ProductManagementAPI.Product.Domain.interfaces;

namespace ProductManagementAPI.Product.Domain.services
{
    public class ProductIdentityService : IProductIdentityService
    {
        public string GenerateUniqueId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
