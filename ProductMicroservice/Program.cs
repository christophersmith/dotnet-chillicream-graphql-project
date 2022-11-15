using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Contexts;
using ProductMicroservice.Services;
using ProductMicroservice.Types;
using ProductMicroservice.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<ProductDbContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:ProductDatabase");
});

builder.Services.AddTransient<ProductService>();

builder.Services.AddGraphQLServer()
    .RegisterDbContext<ProductDbContext>(DbContextKind.Pooled)
    .AddTypeConverter<GuidChangeTypeProvider>()
    .AddQueryType<QueryType>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.MapGraphQL();

app.Run();
