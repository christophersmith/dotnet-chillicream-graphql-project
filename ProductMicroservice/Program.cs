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
    .AddMutationConventions()
    .AddMutationType<MutationType>()
    .AddFiltering()
    .AddSorting();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder
            .WithOrigins("http://localhost:3000") // Allow only this origin
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

app.MapGraphQL();

app.Run();
