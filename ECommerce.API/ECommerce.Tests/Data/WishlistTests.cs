using Xunit;
using Data.Entities;

namespace ECommerce.Tests.Data;
public class WishListTest
{
    [Fact]
    public void Create()
    {
        User user = new User {
            Id = 22, 
            FirstName = "John",
            LastName = "Smith",
            Email = "johnsmith@mail.com",
            Password = "password"
        };

        Wishlist wishlist = new Wishlist{
            Id = 11,
            UserId = 22,
            User = user
        };

        Assert.Equal(wishlist.Id, 11);
        Assert.Equal(wishlist.UserId, 22);
        Assert.Equal(wishlist.User, user);
        Assert.NotNull(wishlist.WishlistDetails);
    }
}