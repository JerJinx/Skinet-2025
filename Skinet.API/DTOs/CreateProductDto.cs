using System.ComponentModel.DataAnnotations;

namespace Skinet.API.DTOs;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public string Description { get; set; } = default!;
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
    [Required]
    public string PictureUrl { get; set; } = default!;
    [Required]
    public string Type { get; set; } = default!;
    [Required]
    public string Brand { get; set; } = default!;
    [Range(1, int.MaxValue, ErrorMessage = "Quantity in stock must be at least 1")]
    public int QuantityInStock { get; set; }
}
