using GreenDonut.Data;
using Microsoft.EntityFrameworkCore;

namespace hotchocgraphql.Types;

[QueryType]
public static class Queries
{
    public static string SayHello(string name = "World")
        => $"Hello {name}!";

  
}