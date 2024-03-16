using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly InvoiceDbContext _context;

    public InvoiceController(InvoiceDbContext context)
    {
        _context = context;
    }

    [HttpGet("getinvoice/{id}")]
    public async Task<ActionResult<Invoice>> GetInvoice(int id)
    {
        Console.WriteLine("GET called");

        var invoice = await _context.Invoices.FindAsync(id);

        if (invoice == null)
        {
            return NotFound();
        }

        return invoice;
    }

    [HttpPost("registerinvoice")]
    public async Task<ActionResult<Invoice>> RegisterInvoice(Invoice invoice)
    {
        Console.WriteLine("POST called");

        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
    }
}
