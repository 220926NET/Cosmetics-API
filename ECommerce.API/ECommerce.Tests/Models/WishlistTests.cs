using Xunit;
using Models;

namespace ECommerce.Tests.Models;

public class WishlistTests
{
    [Fact]
    public void Wishlist_Create()
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

        Wishlist wishlist = new Wishlist(55,66, new HashSet<WishlistItem>{wishlistItem});

        Assert.Equal(wishlist.id, 55);
        Assert.Equal(wishlist.userId, 66);
        Assert.NotNull(wishlist.wishItems);
        Assert.True(wishlist.wishItems!.Contains(wishlistItem));

    }
}