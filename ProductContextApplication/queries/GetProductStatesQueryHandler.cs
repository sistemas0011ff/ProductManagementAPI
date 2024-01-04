
using MediatR;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Domain.interfaces;

namespace ProductManagementAPI.Product.Application.queries
{
    public class GetProductStatesQueryHandler : IRequestHandler<GetProductStatesQuery, IEnumerable<ProductStateDto>>
    {
        private readonly IProductStateRepository _estadoProductoRepository;

        public GetProductStatesQueryHandler(IProductStateRepository estadoProductoRepository)
        {
            _estadoProductoRepository = estadoProductoRepository;
        }

        public async Task<IEnumerable<ProductStateDto>> Handle(GetProductStatesQuery request, CancellationToken cancellationToken)
        {
            var estados = await _estadoProductoRepository.GetProductStatesAsync();
            return estados.Select(estado => new ProductStateDto
            {
                Id = estado.Id,
                Name = estado.Name
            }).ToList();
        }
    }
}
