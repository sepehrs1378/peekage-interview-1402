using System.ComponentModel.DataAnnotations;

public class ItemDto
{
    [Required(ErrorMessage = "ProductName is required")]
    public required string ProductName { get; set; }

    [Required(ErrorMessage = "Count is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Count must be a positive integer")]
    public int Count { get; set; }

    [Required(ErrorMessage = "UnitPrice is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Unit price must be a positive integer")]
    public int UnitPrice { get; set; }
}