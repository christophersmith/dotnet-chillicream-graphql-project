using DatabaseSeeder.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductMicroservice.Contexts;

namespace DatabaseSeeder;

class Program
{
    static void Main(params string[] args)
    {
        try
        {
            Seed();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static void Seed()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ProductDbContext>();
        dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("ProductDatabase"));

        using (var context = new ProductDbContext(dbContextOptionsBuilder.Options))
        {
            var seeder = new ProductDbSeeder(context);
            seeder.Run();

            Console.WriteLine($"Product table has {context.Products.Count()} rows");
            Console.WriteLine($"ProductAttribute table has {context.ProductAttributes.Count()} rows");
            Console.WriteLine($"ProductAttributeType table has {context.ProductAttributeTypes.Count()} rows");
        }
    }
}
