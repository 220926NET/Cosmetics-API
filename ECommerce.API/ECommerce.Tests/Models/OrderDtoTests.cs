using Xunit;
using Models;

namespace ECommerce.Tests.Models;

public class OrderDtoTests
{
    [Fact]
    public void OrderDto_Create()
    {
        OrderDTO orderDTO = new OrderDTO {
            Id = 11,
            Quantity = 3
        };

        Assert.Equal(orderDTO.Id, 11);
        Assert.Equal(orderDTO.Quantity, 3);
    }

    [Fact]
    public void OrderDto_CreateWithConstructor()
    {
        OrderDTO orderDTO = new OrderDTO(11,3);

        Assert.Equal(orderDTO.Id, 11);
        Assert.Equal(orderDTO.Quantity, 3);
    }
}