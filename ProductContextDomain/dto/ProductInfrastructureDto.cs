﻿namespace ProductManagementAPI.Product.Domain.dto
{
    public class ProductInfrastructureDto
    {
        public string? ProductId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
