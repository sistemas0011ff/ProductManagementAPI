using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging; 
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.interfaces;

namespace ProductManagementAPI.Product.Application.services
{
    public class ProductStateService : IProductStateService
    {
        private const string CacheKey = "ProductStates";
        private readonly IGetProductStatesUseCase _getProductStatesUseCase;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ProductStateService> _logger;

        public ProductStateService(IGetProductStatesUseCase getProductStatesUseCase, IMemoryCache cache, ILogger<ProductStateService> logger)
        {
            _getProductStatesUseCase = getProductStatesUseCase ?? throw new ArgumentNullException(nameof(getProductStatesUseCase));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductStateDto>> LoadStatesAsync()
        {
            return await GetCachedStatesAsync();
        }
        private async Task<IEnumerable<ProductStateDto>> GetCachedStatesAsync()
        {
            if (!_cache.TryGetValue(CacheKey, out IEnumerable<ProductStateDto> cachedStates))
            {
                _logger.LogInformation("Cargando estados de producto desde la fuente de datos...");
                cachedStates = await _getProductStatesUseCase.ExecuteAsync();
                CacheProductStates(cachedStates);
                _logger.LogInformation("Estados de producto almacenados en caché.");
            }
            else
            {
                _logger.LogInformation("Recuperando estados de producto desde la caché.");
            }
            return cachedStates;
        }

        private void CacheProductStates(IEnumerable<ProductStateDto> states)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            _cache.Set(CacheKey, states, cacheEntryOptions);
        }
    }
 
}
