using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.interfaces
{
    public interface IGetDiscountByIdUseCase
    {
        Task<DiscountApplicationDto> ExecuteAsync(string productId);
    }
}
