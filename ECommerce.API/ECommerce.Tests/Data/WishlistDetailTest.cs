using Xunit;
using Data.Entities;

namespace ECommerce.Tests.Data;
public class WishlistDetailTest
{
    [Fact]
    public void Create()
    {
        Wishlist wishlist = new Wishlist();
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

        WishlistDetail wishlistDetail = new WishlistDetail {
            DetailId = 11,
            Id = 22,
            ProductId = 33,
            Product = product,
            IdNavigation = wishlist
        };

        Assert.Equal(wishlistDetail.DetailId, 11);
        Assert.Equal(wishlistDetail.Id, 22);
        Assert.Equal(wishlistDetail.ProductId, 33);
        Assert.Equal(wishlistDetail.Product, product);
        Assert.Equal(wishlistDetail.IdNavigation, wishlist);
    }
}