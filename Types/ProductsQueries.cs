using GreenDonut.Data;
using Microsoft.EntityFrameworkCore;

namespace hotchocgraphql.Types;

[QueryType]
public static class ProductsQueries
{
    public static async Task<Product?> GetProductById(
        int id,
        EfContext context,
        CancellationToken cancellationToken)
        => await context.Products
        .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    public static async Task<List<Product>> GetProductsAsync(
        EfContext context,
        CancellationToken cancellationToken)
        => await context.Products.OrderBy(t => t.ShortDesc)
        .ToListAsync(cancellationToken);
}