using GreenDonut.Data;
using Microsoft.EntityFrameworkCore;

namespace hotchocgraphql;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<EfContext>(options =>
            options.UseSqlite("Data Source=products.db"));

        builder.AddGraphQL().AddTypes();

        var app = builder.Build();

        app.MapGraphQL();

        app.RunWithGraphQLCommands(args);
    } 
}