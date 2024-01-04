namespace ProductManagementAPI.Product.Domain.valueObjects
{
    public class ProductId
    {
        public string Value { get; private set; }

        public ProductId(string value)
        { 
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }

}
