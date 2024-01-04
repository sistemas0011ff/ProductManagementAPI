using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProductManagementAPI.Product.Application.commands;
using ProductManagementAPI.Product.Application.dto;
using ProductManagementAPI.Product.Application.interfaces;
using ProductManagementAPI.Product.Application.services;
using ProductManagementAPI.Product.Application.usecases;
using ProductManagementAPI.Product.Domain.interfaces;
using ProductManagementAPI.Product.Application.events;
using System.Reflection;
using ProductManagementAPI.Infrastructure.repositories;
using ProductManagementAPI.Product.Domain.services;
using ProductManagementAPI.Product.Domain.factory;
using ProductManagementAPI.Infrastructure.Configuration;
using ProductManagementAPI.Product.Infrastructure.repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ProductManagementAPI.Product.Application.queries;
using ProductManagementAPI.Infrastructure.HttpClients;
using ProductManagementAPI.Infrastructure.Interfaces;
using System.Text.Json;
using ProductManagementAPI.Product.Infrastructure.interfaces;
using ProductManagementAPI.Product.Infrastructure.Configuration;

namespace ProductManagementAPI.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ProductRepositorySettings>(configuration.GetSection("ProductRepositorySettings"));

            services.AddSingleton<IFileService, FileService>(); 

            services.AddScoped<IProductRepository>(provider =>
            {
                var settings = provider.GetRequiredService<IOptions<ProductRepositorySettings>>().Value;
                var fileService = provider.GetRequiredService<IFileService>();  
                return new ProductRepository(settings.FilePath, fileService);  
            });

            
            services.AddScoped<IProductStateRepository>(provider =>
            {
                var settings = provider.GetRequiredService<IOptions<ProductRepositorySettings>>().Value;
                var fileService = provider.GetRequiredService<IFileService>(); // Obtén la instancia de IFileService.
                return new ProductStateRepository(settings.FilePathStates, fileService); // Pasa IFileService al constructor.
            });

            var apiSettingsSection = configuration.GetSection("ApiSettings");
            var apiSettings = apiSettingsSection.Get<ApiSettings>();
            if (apiSettings?.BaseUrl == null)
            {
                throw new InvalidOperationException("Base URL for API is not configured.");
            }
          
            services.AddSingleton<JsonSerializerOptions>(new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            services.AddHttpClient<IApiClient, ApiClient>()
                    .ConfigureHttpClient((serviceProvider, client) =>
                    {
                        var apiSettingsSection = configuration.GetSection("ApiSettings");
                        var apiSettings = apiSettingsSection.Get<ApiSettings>();
                        client.BaseAddress = new Uri(apiSettings.BaseUrl);
                    });
             
            services.AddScoped<IDiscountRepository>(provider =>
            {
                var apiClient = provider.GetRequiredService<IApiClient>();



                var apiSettingsSection = configuration.GetSection("ApiSettings");
                var apiSettings = apiSettingsSection.Get<ApiSettings>();

                return new DiscountRepository(apiClient, apiSettings.Endpoints.Discount);
            });
             
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCreateUseCase, ProductCreateUseCase>();
            services.AddScoped<IProductIdentityService, ProductIdentityService>();
            services.AddScoped<IGetDiscountByIdUseCase, GetDiscountByIdUseCase>();
            services.AddScoped<IEventStore, SimpleEventStore>();
            services.AddScoped<IProductFactory, ProductFactory>();

            services.AddMemoryCache();
            services.AddScoped<IGetProductStatesUseCase, GetProductStatesUseCase>();
             
            services.AddScoped<IProductStateService, ProductStateService>(provider =>
            {
                var getProductStatesUseCase = provider.GetRequiredService<IGetProductStatesUseCase>();
                var cache = provider.GetRequiredService<IMemoryCache>();
                var logger = provider.GetRequiredService<ILogger<ProductStateService>>();
                return new ProductStateService(getProductStatesUseCase, cache, logger);
            });


            services.AddTransient<IRequestHandler<CreateProductCommand, ProductResponseApplicationDto>, CreateProductCommandHandler>();
            services.AddTransient<IRequestHandler<GetProductStatesQuery, IEnumerable<ProductStateDto>>, GetProductStatesQueryHandler>();
            services.AddTransient<IRequestHandler<GetProductDiscountQuery, DiscountApplicationDto>, GetProductDiscountQueryHandler>();
            services.AddTransient<IGetProductStateByIdUseCase, GetProductStateByIdUseCase>();
            services.AddTransient<IRequestHandler<GetProductStateByIdQuery, ProductStateDto>, GetProductStateByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetProductByIdQuery, ProductApplicationDto>, GetProductByIdQueryHandler>();
            services.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddTransient<IRequestHandler<CreateProductCommand, ProductResponseApplicationDto>, CreateProductCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateProductCommand, UpdateProductResponseDto>, UpdateProductCommandHandler>();
            services.AddScoped<IProductUpdateUseCase, ProductUpdateUseCase>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
