using Xunit;
using Moq;
using Data;
using Data.Entities;
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Tests;

public class SQLRepositoryTests
{
    [Fact]
    public void RegisterNewUser()
    {
        using(MockSQLRepo mock = new MockSQLRepo())
        {
            int userCount1 = mock.context.Users.Count();
            Models.User user = new Models.User {
                ID = 11,
                FirstName = "Harry",
                LastName = "Barry",
                Email = "harrybarry@mail.com",
                Password = "password"

            };
            mock.sqlRepo.RegisterNewUser(user);
            int userCount2 = mock.context.Users.Count();
            Assert.Equal(userCount1+1, userCount2);

        }
    }

    [Fact]
    public void CreateWishList()
    {
        using(MockSQLRepo mock = new MockSQLRepo())
        {
            int wishlistCount1 = mock.context.Wishlists.Count();
            Models.User user = new Models.User {
                ID = 11,
                FirstName = "Harry",
                LastName = "Barry",
                Email = "harrybarry@mail.com",
                Password = "password"
            };
            mock.sqlRepo.CreateWishList(user);
            int wishlistCount2 = mock.context.Wishlists.Count();
            Assert.Equal(wishlistCount1+1, wishlistCount2);
        }
    }

    [Fact]
    public void EmailTaken()
    {
        using(MockSQLRepo mock = new MockSQLRepo())
        {
            Assert.False(mock.sqlRepo.EmailTaken("harrybarry@mail.com"));
            Models.User user = new Models.User {
                ID = 11,
                FirstName = "Harry",
                LastName = "Barry",
                Email = "harrybarry@mail.com",
                Password = "password"
            };
            mock.sqlRepo.RegisterNewUser(user);
            Assert.True(mock.sqlRepo.EmailTaken("harrybarry@mail.com"));
        }
    }

    [Fact]
    public void VerifyCredentials()
    {
        using(MockSQLRepo mock = new MockSQLRepo())
        {
            Models.User user = new Models.User {
                ID = 11,
                FirstName = "Harry",
                LastName = "Barry",
                Email = "harrybarry@mail.com",
                Password = "password"
            };
            mock.sqlRepo.RegisterNewUser(user);
            Assert.Null(mock.sqlRepo.VerifyCredentials("harrybarry@mail.com", ""));
            Assert.NotNull(mock.sqlRepo.VerifyCredentials("harrybarry@mail.com", "password"));
        }
    }

    [Fact]
    public void GetWishlist()
    {
        using(MockSQLRepo mock = new MockSQLRepo())
        {
            Models.User user = new Models.User {
                ID = 11,
                FirstName = "Harry",
                LastName = "Barry",
                Email = "harrybarry@mail.com",
                Password = "password"
            };
            mock.sqlRepo.CreateWishList(user);
            Models.Wishlist wishlist = mock.sqlRepo.GetWishlist(11);
            Assert.NotNull(wishlist);
            Assert.Equal(0, wishlist.wishItems!.Count);

            mock.sqlRepo.CreateWishlistItem(wishlist.id, 21);
            wishlist = mock.sqlRepo.GetWishlist(11);
            Assert.Equal(1, wishlist.wishItems!.Count);
        }
    }

    [Fact]
    public void DeleteWishListItem()
    {
        using(MockSQLRepo mock = new MockSQLRepo())
        {
            Models.Wishlist wishlist = mock.sqlRepo.GetWishlist(2);
            mock.sqlRepo.CreateWishlistItem(wishlist.id, 21);
            mock.sqlRepo.DeleteWishListItem(0);
            wishlist = mock.sqlRepo.GetWishlist(2);
            Assert.Equal(0, wishlist.wishItems!.Count());

        }
    }

    [Fact]
    public void ReduceInventoryById()
    {
        using(MockSQLRepo mock = new MockSQLRepo(true, true))
        {
            Assert.Equal(8, mock.context.Products.Where(p => p.ProductId == 21).Select(p => p.Inventory).First());
            mock.sqlRepo.ReduceInventoryById(21,4,1);
            Assert.Equal(4, mock.context.Products.Where(p => p.ProductId == 21).Select(p => p.Inventory).First());
        }
    }
}