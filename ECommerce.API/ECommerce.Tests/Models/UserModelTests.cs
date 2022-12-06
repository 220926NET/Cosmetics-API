using Xunit;
using Models;

namespace ECommerce.Tests;

public class UserModelTests
{
    [Fact]
    public void User_Create()
    {
        User user = new User {
            ID = 11,
            FirstName = "John",
            LastName = "Smith",
            Email = "johnsmith@mail.com",
        };

        Assert.Equal(user.ID, 11);
        Assert.Equal(user.FirstName, "John");
        Assert.Equal(user.LastName, "Smith");
        Assert.Equal(user.Email, "johnsmith@mail.com");
    }

    [Fact]
    public void User_CreateWithConstructor()
    {
        User user = new User(11,"John","Smith","johnsmith@mail.com");

        Assert.Equal(user.ID, 11);
        Assert.Equal(user.FirstName, "John");
        Assert.Equal(user.LastName, "Smith");
        Assert.Equal(user.Email, "johnsmith@mail.com");
    }
}