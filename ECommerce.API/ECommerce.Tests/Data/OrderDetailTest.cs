using Xunit;
using Data.Entities;

namespace ECommerce.Tests.Data;
public class OrderDetailTest
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

        OrderDetail orderDetail = new OrderDetail {
            OrderId = 22,
            ProductId = 33,
            Quantity = 3,
            Order = order,
            Product = product
        };

        Assert.Equal(orderDetail.OrderId, 22);
        Assert.Equal(orderDetail.ProductId, 33);
        Assert.Equal(orderDetail.Quantity, 3);
        Assert.Equal(orderDetail.Order, order);
        Assert.Equal(orderDetail.Product, product);
    }
}