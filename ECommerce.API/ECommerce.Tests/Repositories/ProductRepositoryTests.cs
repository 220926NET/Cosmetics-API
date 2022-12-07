using Models;

namespace ECommerce.Tests;

public class ProductRepositoryTests
{
    [Fact]
    public void GetProductList()
    {
        using(MockProductRepo mock = new MockProductRepo())
        {
            List<ProductDetailsDto> productList = mock.repo.GetProductList("lipstick");
            Assert.Equal(2, productList.Count());
        }
    }

    [Fact]
    public void GetByApiId()
    {
        using(MockProductRepo mock = new MockProductRepo())
        {
            List<ProductDetailsDto> productList = mock.repo.GetByApiId(91);
            Assert.Equal(2, productList.Count());
        }
    }
 
}