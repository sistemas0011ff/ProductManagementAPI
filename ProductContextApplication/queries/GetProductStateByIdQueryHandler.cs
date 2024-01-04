using MediatR;
using Microsoft.Extensions.Caching.Memory;
using ProductManagementAPI.Product.Application.dto;

namespace ProductManagementAPI.Product.Application.queries
{
    public class GetProductStateByIdQueryHandler : IRequestHandler<GetProductStateByIdQuery, ProductStateDto>
    {
        private readonly IMemoryCache _cache;

        public GetProductStateByIdQueryHandler(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task<ProductStateDto> Handle(GetProductStateByIdQuery request, CancellationToken cancellationToken)
        {
            var states = _cache.Get<IEnumerable<ProductStateDto>>("ProductStates");
            var state = states?.FirstOrDefault(s => s.Id == request.StateId)
                        ?? throw new KeyNotFoundException($"No state found with ID {request.StateId}.");

            return Task.FromResult(state);
        }
    }
}
