using Microsoft.EntityFrameworkCore;

public class InvoiceDbContext : DbContext
{
    public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Item> Items { get; set; }
}