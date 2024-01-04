using ProductManagementAPI.Controllers.Product.dto.ProductManagementAPI.Controllers.Product.dto;
using ProductManagementAPI.Controllers.Product.dto;
using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Controllers.Product.Mappers
{
    public static class ProductMapper
    {
        public static ProductApplicationDto MapToProductApplicationDto(ProductDto dto)
        {
            return new ProductApplicationDto
            {
                Name = dto.Name,
                Status = dto.Status,
                Stock = dto.Stock,
                Description = dto.Description,
                Price = dto.Price
            };
        }

        public static ProductCreateResponseDto MapToProductCreateResponseDto(ProductApplicationDto dto)
        {
            return new ProductCreateResponseDto
            {
                ProductId = dto.ProductId,
                Name = dto.Name,
                Status = dto.Status,
                Stock = dto.Stock,
                Description = dto.Description,
                Price = dto.Price
            };
        }

        public static ProductoGetResponseDto MapToProductoGetResponseDto(ProductApplicationDto dto)
        {
            return new ProductoGetResponseDto
            {
                ProductId = dto.ProductId,
                Name = dto.Name,
                Status = dto.Status,
                StatusName = dto.StatusName, // Asumiendo que tienes una manera de obtener el nombre del estado
                Stock = dto.Stock,
                Description = dto.Description,
                Price = dto.Price,
                Discount = dto.Discount,
                FinalPrice = dto.FinalPrice
            };
        }

        public static ProductUpdateApplicationDto MapToUpdateApplicationDto(string id, ProductUpdateDto dto)
        {
            return new ProductUpdateApplicationDto
            {
                ProductId = id,
                Name = dto.Name,
                Status = dto.Status.GetValueOrDefault(), // Asegúrate de manejar valores predeterminados correctamente
                Stock = dto.Stock.GetValueOrDefault(),
                Description = dto.Description,
                Price = dto.Price.GetValueOrDefault()
            };
        }

        public static ProductUpdateResponseDto MapToUpdateResponseDto(UpdateProductResponseDto dto)
        {
            return new ProductUpdateResponseDto
            {
                ProductId = dto.UpdatedProduct.ProductId,
                Name = dto.UpdatedProduct.Name,
                Status = dto.UpdatedProduct.Status,
                Stock = dto.UpdatedProduct.Stock,
                Description = dto.UpdatedProduct.Description,
                Price = dto.UpdatedProduct.Price
            };
        }
    }
}
