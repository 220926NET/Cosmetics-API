using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Tests;

internal class MockProductRepo:IDisposable
{
    private DbContextOptions<CosmeticsContext> options;
    public CosmeticsContext context;
    private ILoggerFactory loggerFactory;
    private ILogger<ProductRepo> logger;
    public ProductRepo repo;
    public MockProductRepo()
    {
        // Create in memory database
        options = new DbContextOptionsBuilder<CosmeticsContext>()
            .UseInMemoryDatabase(databaseName: "MockProductDatabase")
            .Options;
        
        // Create mocked context
        context = new CosmeticsContext(options);

        // Create logger
        loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Trace));
        logger = loggerFactory.CreateLogger<ProductRepo>();

        // Create review repository
        repo = new ProductRepo(logger, context);

        SeedData();
    }

    private void SeedData()
    {
        context.Products.Add(
            new Product {
                ProductId = 11,
                ApiId = 91,
                ProductName = "Acme Lipstick 1337",
                ProductType = "lipstick",
                Brand = "Acme",
                Price = 9.99m,
                Description = "The latest style of lipstick from Acme.",
                Image = "www.image.com/image",
                ColourName = "Tomato red",
                HexValue = "#ff0000",
                Inventory = 17
            }
        );

        context.Products.Add(
            new Product {
                ProductId = 12,
                ApiId = 91,
                ProductName = "Acme Lipstick 1338",
                ProductType = "lipstick",
                Brand = "Acme",
                Price = 9.99m,
                Description = "The latest style of lipstick from Acme.",
                Image = "www.image.com/image",
                ColourName = "Apple red",
                HexValue = "#ee0000",
                Inventory = 8
            }
        );

        context.Products.Add(
            new Product {
                ProductId = 17,
                ApiId = 97,
                ProductName = "Jessi's Lipstick",
                ProductType = "lipstick",
                Brand = "Jessi's",
                Price = 13.99m,
                Description = "The latest style of lipstick from Jessi's.",
                Image = "www.image.com/image",
                ColourName = "Sunset",
                HexValue = "#770000",
                Inventory = 11
            }
        );

        context.Deals.Add(
            new Deal {
                Id=1,
                Discount=0.1m,
                StartTime=DateTime.Now,
                EndTime=DateTime.MaxValue,
                Product=11
            }
        );

        context.SaveChanges();
    }

    public void Dispose()
    {
        // Delete in-memory database in between unit tests
        context.Database.EnsureDeleted();
        context.Dispose();
        loggerFactory.Dispose();
    }
}