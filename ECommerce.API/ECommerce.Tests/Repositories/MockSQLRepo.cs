using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Tests;

internal class MockSQLRepo:IDisposable
{
    private DbContextOptions<CosmeticsContext> options;
    public CosmeticsContext context;
    private ILoggerFactory loggerFactory;
    private ILogger<SQLRepository> logger;
    public SQLRepository sqlRepo;
    public MockSQLRepo(bool seedUsers = false, bool seedProducts = false)
    {
        // Create in memory database
        options = new DbContextOptionsBuilder<CosmeticsContext>()
            .UseInMemoryDatabase(databaseName: "MockSQLDatabase")
            .EnableSensitiveDataLogging()
            .Options;
        
        // Create mocked context
        context = new CosmeticsContext(options);

        // Create logger
        loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Trace));
        logger = loggerFactory.CreateLogger<SQLRepository>();

        // Create repository
        sqlRepo = new SQLRepository(logger, context);

        //SeedData();
        //if (seedUsers)
            SeedUsers();
        //if (seedProducts)
            SeedProducts();
    }

    public void SeedUsers()
    {
        context.Users.Add(
            new User {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "johnsmith@mail.com",
                Password = "password"
            }
        );

        context.Users.Add(
            new User {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "janedoe@mail.com",
                Password = "password"
            }
        );

        context.SaveChanges();
    }

    public void SeedProducts()
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

        context.Products.Add(
            new Product {
                ProductId = 21,
                ApiId = 102,
                ProductName = "Jessi's Blush",
                ProductType = "blush",
                Brand = "Jessi's",
                Price = 13.99m,
                Description = "The latest style of blush from Jessi's.",
                Image = "www.image.com/image",
                ColourName = "Aquamarine",
                HexValue = "#0000bb",
                Inventory = 8
            }
        );

        context.SaveChanges();
    }

    public void SeedWishlist()
    {
        /*
        context.Wishlists.Add(
            new Wishlist {
                Id = 1,
                UserId = 2
            }
        );

        context.WishlistDetails.Add(
            new WishlistDetail {
                DetailId = 1,
                Id = 1,
                ProductId = 17
            }
        );

        context.WishlistDetails.Add(
            new WishlistDetail {
                DetailId = 2,
                Id = 1,
                ProductId = 17
            }
        );
        */
    }

    public void Dispose()
    {
        // Delete in-memory database in between unit tests
        context.Database.EnsureDeleted();
        context.Dispose();
        loggerFactory.Dispose();
    }
}