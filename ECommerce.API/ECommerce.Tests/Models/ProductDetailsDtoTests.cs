using Xunit;
using Models;

namespace ECommerce.Tests;

public class ProductDetailsDtoTests
{
    [Fact]
    public void ProductDetailsDto_Create()
    {
        ProductDetailsDto productDetailsDto = new ProductDetailsDto {
            Id = 33,
            ApiId = 44,
            Name = "Acme Lipstick 1337",
            Type = "lipstick",
            Brand = "Acme",
            Price = 9.99m,
            Description = "The latest style of lipstick from Acme.",
            Image = "www.image.com/image",
            ColourName = "Tomato red",
            HexValue = "#ff0000",
            Inventory = 17
        };

        Assert.Equal(productDetailsDto.Id, 33);
        Assert.Equal(productDetailsDto.ApiId, 44);
        Assert.Equal(productDetailsDto.Name, "Acme Lipstick 1337");
        Assert.Equal(productDetailsDto.Type, "lipstick");
        Assert.Equal(productDetailsDto.Brand, "Acme");
        Assert.Equal(productDetailsDto.Price, 9.99m);
        Assert.Equal(productDetailsDto.Description, "The latest style of lipstick from Acme.");
        Assert.Equal(productDetailsDto.Image, "www.image.com/image");
        Assert.Equal(productDetailsDto.ColourName, "Tomato red");
        Assert.Equal(productDetailsDto.HexValue, "#ff0000");
        Assert.Equal(productDetailsDto.Inventory, 17);
    }
}