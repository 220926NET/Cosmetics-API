using Xunit;
using Data.Entities;

namespace ECommerce.Tests;
public class DealTest
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

        DateTime now = new DateTime();
        DateTime tomorrow = new DateTime().AddDays(1);


        Deal deal = new Deal {
            Id = 11,
            Discount = 0.1m,
            StartTime = now,
            EndTime = tomorrow,
            Product = 33,
            ProductNavigation = product
        };

        Assert.Equal(deal.Id, 11);
        Assert.Equal(deal.Discount, 0.1m);
        Assert.Equal(deal.StartTime, now);
        Assert.Equal(deal.EndTime, tomorrow);
        Assert.Equal(deal.Product, 33);
        Assert.Equal(deal.ProductNavigation, product);
    }
}