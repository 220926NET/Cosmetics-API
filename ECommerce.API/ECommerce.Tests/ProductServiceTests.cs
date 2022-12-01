using Data;
using Moq;
using Services;
using Models;

namespace ECommerce.Tests;
public class ProductServiceTests
{

    private readonly Mock<IProductRepo> _productRepoMock = new Mock<IProductRepo>();

    [Fact]
    public void GetAllProducts_Lipstick()
    {

        //arrange

        // act 
        ProductDetailsDto
  _mockProducts = new ProductDetailsDto
 ()
  {
      Id = 1,
      Name = "test",
      Type = "lipstick",
      Brand = "maybelline",
      Inventory = 20,
      Price = 8.99m,
      Description = "lipstick",
      Image = "https://test.com",
      HexValue = "#c55555",

  };
        _productRepoMock.Setup(repo => repo.GetAllLipsticks()).Returns(new List<ProductDetailsDto
>() { _mockProducts });


        ProductService productService = new ProductService(_productRepoMock.Object);

        //assert 



        Assert.Equal(new List<ProductDetailsDto
>(){ _mockProducts
        }, productService.getAllProducts("lipstick"));

    }

    [Fact]
    public void GetAllProducts_EyeShadow()
    {

        //arrange

        // act 
        ProductDetailsDto
  _mockProducts = new ProductDetailsDto
 ()
  {
      Id = 1,
      Name = "test",
      Type = "eyeshadow",
      Brand = "maybelline",
      Inventory = 20,
      Price = 8.99m,
      Description = "eyeshadows",
      Image = "https://test.com",
      HexValue = "#c55555",

  };
        _productRepoMock.Setup(repo => repo.GetAllEyeShadow()).Returns(new List<ProductDetailsDto
>() { _mockProducts });


        ProductService productService = new ProductService(_productRepoMock.Object);

        Assert.Equal(new List<ProductDetailsDto
>(){ _mockProducts
        }, productService.getAllProducts("eyeshadow"));

    }

    [Fact]
    public void GetAllProducts_EyeLiner()
    {

        ProductDetailsDto
  _mockProducts = new ProductDetailsDto
 ()
  {
      Id = 1,
      Name = "test",
      Type = "eyeliner",
      Brand = "maybelline",
      Inventory = 20,
      Price = 8.99m,
      Description = "eyeliner",
      Image = "https://test.com",
      HexValue = "#c55555" ,

  };
        _productRepoMock.Setup(repo => repo.GetAllEyeLiner()).Returns(new List<ProductDetailsDto
>() { _mockProducts });


        ProductService productService = new ProductService(_productRepoMock.Object);

        Assert.Equal(new List<ProductDetailsDto
>(){ _mockProducts
        }, productService.getAllProducts("eyeliner"));

    }

    [Fact]
    public void GetAllProducts_Foundation()
    {

        ProductDetailsDto
  _mockProducts = new ProductDetailsDto
 ()
  {
      Id = 1,
      Name = "test",
      Type = "eyeliner",
      Brand = "foundation",
      Inventory = 20,
      Price = 8.99m,
      Description = "foundation",
      Image = "https://test.com",
      HexValue = "#c55555",

  };
        _productRepoMock.Setup(repo => repo.GetAllFoundation()).Returns(new List<ProductDetailsDto
>() { _mockProducts });


        ProductService productService = new ProductService(_productRepoMock.Object);

        Assert.Equal(new List<ProductDetailsDto
>(){ _mockProducts
        }, productService.getAllProducts("foundation"));

    }

    [Fact]
    public void GetAllProducts_Blush()
    {

        ProductDetailsDto
  _mockProducts = new ProductDetailsDto
 ()
  {
      Id = 1,
      Name = "test",
      Type = "eyeliner",
      Brand = "blush",
      Inventory = 20,
      Price = 8.99m,
      Description = "blush",
      Image = "https://test.com",
      HexValue = "#c55555",

  };
        _productRepoMock.Setup(repo => repo.GetAllBlush()).Returns(new List<ProductDetailsDto
>() { _mockProducts });


        ProductService productService = new ProductService(_productRepoMock.Object);

        Assert.Equal(new List<ProductDetailsDto
>(){ _mockProducts
        }, productService.getAllProducts("blush"));

    }
}