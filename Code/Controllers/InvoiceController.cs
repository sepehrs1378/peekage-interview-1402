using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly InvoiceDbContext _context;
    private readonly IMessenger _messanger;

    public InvoiceController(InvoiceDbContext context, IMessenger messenger)
    {
        _context = context;
        _messanger = messenger;
    }

    [HttpGet("getall")]
    public async Task<ActionResult<Invoice>> GetAllInvoices()
    {
        var allInvoices = await _context.Invoices.Include(i => i.Items).ToListAsync();

        var allInvoicesViews = allInvoices.Select(i => new InvoiceView(i)).ToList();
        return new JsonResult(allInvoicesViews);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Invoice>> GetInvoice(int id)
    {
        var invoice = await _context.Invoices.Include(i => i.Items).FirstOrDefaultAsync(i => i.Id == id);

        if (invoice == null)
        {
            return NotFound();
        }

        return new JsonResult(new InvoiceView(invoice));
    }

    [HttpPost("register")]
    public async Task<ActionResult<Invoice>> RegisterInvoice([FromBody] InvoiceDto invoiceDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var invoice = new Invoice
        {
            BuyerName = invoiceDto.BuyerName,
            PhoneNumber = invoiceDto.PhoneNumber,
            Items = new List<Item>(),
            TotalCost = invoiceDto.Items.Select(i => i.UnitPrice * i.Count).Sum()
        };

        foreach (var ItemDto in invoiceDto.Items)
        {
            var item = new Item
            {
                Invoice = invoice,
                ProductName = ItemDto.ProductName,
                Count = ItemDto.Count,
                UnitPrice = ItemDto.UnitPrice
            };
            invoice.Items.Add(item);
        }

        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        _messanger.sendMessage($"An invoice with ID {invoice.Id} has been registered. Total cost is {invoice.TotalCost}.");

        return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, new InvoiceView(invoice));
    }
}
