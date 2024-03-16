using Microsoft.EntityFrameworkCore;

public class InvoiceDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Item> Items { get; set; }
}