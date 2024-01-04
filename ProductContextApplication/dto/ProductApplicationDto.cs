

using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Product.Application.dto
{
    public class ProductApplicationDto
    {
        public string? ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, 1)]
        public int Status { get; set; }

        public string? StatusName { get; set; } 

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public decimal? Discount { get; set; }

        public decimal FinalPrice { get; set; } 

    }
}
