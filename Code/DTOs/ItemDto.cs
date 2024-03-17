using System.ComponentModel.DataAnnotations;

public class ItemDto
{
    [Required(ErrorMessage = "ProductName is required")]
    public required string ProductName { get; set; }

    [Required(ErrorMessage = "Count is required")]
    public int Count { get; set; }

    [Required(ErrorMessage = "UnitPrice is required")]
    public int UnitPrice { get; set; }
}