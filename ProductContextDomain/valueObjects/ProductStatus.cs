 namespace ProductManagementAPI.Product.Domain.valueObjects
{
    public class ProductStatus
    {
        public int Value { get; private set; } 

        public ProductStatus(int value)
        {
            Value = value;
        }
         
    }
}
