using Xunit;
using Data.Entities;

namespace ECommerce.Tests.Data;
public class UserTests
{
    [Fact]
    public void Create()
    {
        User user = new User {
            Id = 11, 
            FirstName = "John",
            LastName = "Smith",
            Email = "johnsmith@mail.com",
            Password = "password"
        };

        Assert.Equal(user.Id, 11);
        Assert.Equal(user.FirstName, "John");
        Assert.Equal(user.LastName, "Smith");
        Assert.Equal(user.Email, "johnsmith@mail.com");
        Assert.Equal(user.Password, "password");
        Assert.NotNull(user.Orders);
        Assert.NotNull(user.Reviews);
        Assert.NotNull(user.Wishlists);
    }
}