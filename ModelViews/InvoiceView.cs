public class InvoiceView
{
    public int Id { get; set; }
    public string BuyerName { get; set; }
    public string PhoneNumber { get; set; }
    public List<ItemView> Items { get; set; }

    public InvoiceView(Invoice invoice)
    {
        Id = invoice.Id;
        BuyerName = invoice.BuyerName;
        PhoneNumber = invoice.PhoneNumber;
        Items = invoice.Items.Select(i => new ItemView(i)).ToList();
    }
}