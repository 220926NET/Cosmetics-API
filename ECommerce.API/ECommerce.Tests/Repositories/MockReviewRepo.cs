using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Tests;

internal class MockReviewRepo:IDisposable
{
    private DbContextOptions<CosmeticsContext> options;
    public CosmeticsContext context;
    private ILoggerFactory loggerFactory;
    private ILogger<ReviewRepository> logger;
    public ReviewRepository reviewRepository;
    public MockReviewRepo()
    {
        // Create in memory database
        options = new DbContextOptionsBuilder<CosmeticsContext>()
            .UseInMemoryDatabase(databaseName: "MockReviewDatabase")
            .Options;
        
        // Create mocked context
        context = new CosmeticsContext(options);

        // Create logger
        loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Trace));
        logger = loggerFactory.CreateLogger<ReviewRepository>();

        // Create review repository
        reviewRepository = new ReviewRepository(logger, context);

        SeedData();
    }

    private void SeedData()
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

        context.Reviews.Add(new Review {
            Id = 21,
            UserId = 1,
            ProductId = 11,
            Text = "Great product! My wife loves it!",
            Rating = 5
        });

        context.Reviews.Add(new Review {
            Id = 22,
            UserId = 2,
            ProductId = 11,
            Text = "Terrible",
            Rating = 1
        });

        context.Reviews.Add(new Review {
            Id = 23,
            UserId = 2,
            ProductId = 17,
            Text = "Simply the best!",
            Rating = 5
        });

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