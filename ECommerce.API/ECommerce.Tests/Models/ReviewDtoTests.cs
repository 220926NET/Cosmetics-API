using Xunit;
using Models;

namespace ECommerce.Tests;

public class ReviewDtoTests
{
    [Fact]
    public void ReviewDTO_Create()
    {
        ReviewDTO reviewDTO = new ReviewDTO {
            Id = 11,
            UserId = 22,
            ProductId = 33,
            Text = "Amazing",
            Rating = 5,
            User = new ReviewDTO.UserDTO {
                Id = 22, 
                FirstName = "John",
                LastName = "Smith"
            },
            Product = new ReviewDTO.ProductDTO {
                ProductId = 33,
                ApiId = 44,
                ProductName = "Acme Lipstick 1337",
                ProductType = "lipstick",
                Brand = "Acme",
                Price = 9.99m,
                Description = "The latest style of lipstick from Acme.",
                Image = "www.image.com/image",
                ColourName = "Tomato red",
                HexValue = "#ff0000"
            }
        };

        Assert.Equal(reviewDTO.Id, 11);
        Assert.Equal(reviewDTO.UserId, 22);
        Assert.Equal(reviewDTO.ProductId, 33);
        Assert.Equal(reviewDTO.Text, "Amazing");
        Assert.Equal(reviewDTO.Rating, 5);

        Assert.Equal(reviewDTO.User.Id, 22);
        Assert.Equal(reviewDTO.User.FirstName, "John");
        Assert.Equal(reviewDTO.User.LastName, "Smith");

        Assert.Equal(reviewDTO.Product.ProductId, 33);
        Assert.Equal(reviewDTO.Product.ApiId, 44);
        Assert.Equal(reviewDTO.Product.ProductName, "Acme Lipstick 1337");
        Assert.Equal(reviewDTO.Product.ProductType, "lipstick");
        Assert.Equal(reviewDTO.Product.Brand, "Acme");
        Assert.Equal(reviewDTO.Product.Price, 9.99m);
        Assert.Equal(reviewDTO.Product.Description, "The latest style of lipstick from Acme.");
        Assert.Equal(reviewDTO.Product.Image, "www.image.com/image");
        Assert.Equal(reviewDTO.Product.ColourName, "Tomato red");
        Assert.Equal(reviewDTO.Product.HexValue, "#ff0000");
    }
}