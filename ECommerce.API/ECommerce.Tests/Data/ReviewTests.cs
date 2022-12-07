using Xunit;
using Data.Entities;

namespace ECommerce.Tests;
public class ReviewTests
{
    [Fact]
    public void Create()
    {
        Review review = new Review {
            Id = 11,
            UserId = 22,
            ProductId = 33,
            Text = "Amazing",
            Rating = 5,
            User = new User {
                Id = 22, 
                FirstName = "John",
                LastName = "Smith"
            },
            Product = new Product {
                ProductId = 33,
                ApiId = 44,
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
        };

        Assert.Equal(review.Id, 11);
        Assert.Equal(review.UserId, 22);
        Assert.Equal(review.ProductId, 33);
        Assert.Equal(review.Text, "Amazing");
        Assert.Equal(review.Rating, 5);

        Assert.Equal(review.User.Id, 22);
        Assert.Equal(review.User.FirstName, "John");
        Assert.Equal(review.User.LastName, "Smith");

        Assert.Equal(review.Product.ProductId, 33);
        Assert.Equal(review.Product.ApiId, 44);
        Assert.Equal(review.Product.ProductName, "Acme Lipstick 1337");
        Assert.Equal(review.Product.ProductType, "lipstick");
        Assert.Equal(review.Product.Brand, "Acme");
        Assert.Equal(review.Product.Price, 9.99m);
        Assert.Equal(review.Product.Description, "The latest style of lipstick from Acme.");
        Assert.Equal(review.Product.Image, "www.image.com/image");
        Assert.Equal(review.Product.ColourName, "Tomato red");
        Assert.Equal(review.Product.HexValue, "#ff0000");
        Assert.Equal(review.Product.Inventory, 17);
    }
}