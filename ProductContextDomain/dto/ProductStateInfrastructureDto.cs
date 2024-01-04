using System.Text.Json.Serialization;

namespace ProductManagementAPI.Product.Domain.dto
{
    public class EstadosWrapper
    {
        [JsonPropertyName("Estados")]
        public List<ProductStateInfrastructureDto> Estados { get; set; }
    }

    public class ProductStateInfrastructureDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Nombre")]
        public string Name { get; set; }
    }
}
