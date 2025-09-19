using Microsoft.EntityFrameworkCore;
using Test_Assignment.Models;

namespace Test_Assignment.ContextDB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<InvoiceItems> InvoiceItems { get; set; }
    }

}
