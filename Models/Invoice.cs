public class Invoice
{
    public int Id { get; set; }
    public string BuyerName { get; set; }
    public string PhoneNumber { get; set; }
    public List<Item> Items { get; set; }
}
