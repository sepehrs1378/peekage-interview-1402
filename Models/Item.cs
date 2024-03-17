public class Item
{
    public int Id { get; set; }
    public required Invoice Invoice { get; set; }
    public required string ProductName { get; set; }
    public int Count { get; set; }
    public int UnitPrice { get; set; }
}