using System.ComponentModel.DataAnnotations;

public class InvoiceDto
{
    [Required(ErrorMessage = "BuyerName is required")]
    public required string BuyerName { get; set; }

    [Required(ErrorMessage = "PhoneNumber is required")]
    public required string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Items is required")]
    public required List<ItemDto> Items { get; set; }
}