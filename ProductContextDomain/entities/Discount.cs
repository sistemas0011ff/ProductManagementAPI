namespace ProductManagementAPI.Product.Domain.entities
{
    public class Discount
    {
        public int Percentage { get; private set; }

        public Discount(int percentage)
        {
            Percentage = percentage;
        }
         
    }
}
