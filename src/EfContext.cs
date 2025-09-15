using hotchocgraphql.Types;
using Microsoft.EntityFrameworkCore;

namespace hotchocgraphql;

public class EfContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public EfContext(DbContextOptions<EfContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product
            (
                1,
                "Coffee Mug",
                "A ceramic mug perfect for hot beverages like coffee or tea."
            ),
            new Product
            (
                2,
                "Notebook",
                "A lined notebook for writing and note-taking."
            ),
            new Product
            (
                3,
                "Wireless Mouse",
                "A compact wireless mouse with Bluetooth support."
            )
        );
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.ShortDesc).IsRequired().HasMaxLength(100);
            entity.Property(p => p.LongDesc).HasMaxLength(500);
        });
    }
}
