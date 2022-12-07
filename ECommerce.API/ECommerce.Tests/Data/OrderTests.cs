using Xunit;
using Data.Entities;

namespace ECommerce.Tests;
public class OrderTest
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

        DateTime now = new DateTime();

        Order order = new Order() {
            OrderId = 22,
            Purchaser = 11,
            TimeStamp = now,
            Amount = 11.11m,
            PurchaserNavigation = user
        };

        Assert.Equal(order.OrderId, 22);
        Assert.Equal(order.Purchaser, 11);
        Assert.Equal(order.TimeStamp, now);
        Assert.Equal(order.Amount, 11.11m);
        Assert.Equal(order.PurchaserNavigation, user);

    }
}