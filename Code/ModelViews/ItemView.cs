public class ItemView
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Count { get; set; }
    public int UnitPrice { get; set; }

    public ItemView(Item item)
    {
        Id = item.Id;
        ProductName = item.ProductName;
        Count = item.Count;
        UnitPrice = item.UnitPrice;
    }
}