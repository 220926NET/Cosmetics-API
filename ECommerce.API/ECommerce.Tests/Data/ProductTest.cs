using Xunit;
using Data.Entities;

namespace ECommerce.Tests.Data;
public class ProductTest
{
    [Fact]
    public void Create()
    {
        Product product = new Product {
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
        };

        Assert.Equal(product.ProductId, 33);
        Assert.Equal(product.ApiId, 44);
        Assert.Equal(product.ProductName, "Acme Lipstick 1337");
        Assert.Equal(product.ProductType, "lipstick");
        Assert.Equal(product.Brand, "Acme");
        Assert.Equal(product.Price, 9.99m);
        Assert.Equal(product.Description, "The latest style of lipstick from Acme.");
        Assert.Equal(product.Image, "www.image.com/image");
        Assert.Equal(product.ColourName, "Tomato red");
        Assert.Equal(product.HexValue, "#ff0000");
        Assert.Equal(product.Inventory, 17);
    }
}