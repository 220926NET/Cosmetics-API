using Xunit;
using Models;

namespace ECommerce.Tests;

public class WishlistItemTests
{
    [Fact]
    public void WishlistItem_Create()
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

        WishlistItem wishlistItem = new WishlistItem(22, 11, 33, productDetailsDto);

        Assert.Equal(wishlistItem.DetailId, 22);
        Assert.Equal(wishlistItem.Id, 11);
        Assert.Equal(wishlistItem.ProductId, 33);

        Assert.Equal(wishlistItem.Product.Id, 33);
        Assert.Equal(wishlistItem.Product.ApiId, 44);
        Assert.Equal(wishlistItem.Product.Name, "Acme Lipstick 1337");
        Assert.Equal(wishlistItem.Product.Type, "lipstick");
        Assert.Equal(wishlistItem.Product.Brand, "Acme");
        Assert.Equal(wishlistItem.Product.Price, 9.99m);
        Assert.Equal(wishlistItem.Product.Description, "The latest style of lipstick from Acme.");
        Assert.Equal(wishlistItem.Product.Image, "www.image.com/image");
        Assert.Equal(wishlistItem.Product.ColourName, "Tomato red");
        Assert.Equal(wishlistItem.Product.HexValue, "#ff0000");
        Assert.Equal(wishlistItem.Product.Inventory, 17);
        /*
         {
            Id = 11,
            DetailId = 22,
            ProductId = 33,
            Product = wishlistItem.Product
        };
        */
    }
}