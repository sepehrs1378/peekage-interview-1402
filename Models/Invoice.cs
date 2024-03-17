public class Invoice
{
    public int Id { get; set; }
    public required string BuyerName { get; set; }
    public required string PhoneNumber { get; set; }
    public required List<Item> Items { get; set; }

    public Invoice()
    {
        Items = new List<Item>();
    }
}