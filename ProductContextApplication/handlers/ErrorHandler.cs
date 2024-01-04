
using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.handlers
{
    public static class ErrorHandler
    {
        /// <summary>
        /// Maneja los fallos en la creación de productos y genera una respuesta adecuada.
        /// </summary>
        /// <param name="response">La respuesta del intento de creación del producto.</param>
        /// <returns>Un DTO de aplicación de producto con detalles del error.</returns>
        public static ProductApplicationDto HandleProductCreationFailure(ProductResponseApplicationDto response)
        {
            return new ProductApplicationDto
            {
                ProductId = null, // O un identificador específico para indicar un error
                Name = "Error en la creación del producto",
                Status = 0, // Un estado que indique error o fallo
                Stock = 0,
                Description = $"Error: {response.Message}",
                Price = 0,
                Discount = null,
                FinalPrice = 0
            };
        }
    }
}
