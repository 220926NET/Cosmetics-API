using Data;
using Models;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce.Tests;
public class ProductTests
{
    private readonly Mock<IProductRepo> _mockRepo;
    private readonly ProductController _controller;

    public ProductTests() {
        _mockRepo = new Mock<IProductRepo>();
        _controller = new ProductController(new Logger<ProductController>(Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance), _mockRepo.Object);
    }

    [Fact]
    public void GetAllProductsByType_WithInvalidType_ReturnsNotFound()
    {
        // Arrange
        string prodType = "electronic";

        // Act
        ActionResult<ProductDetailsDto> result = _controller.GetAllProductsByType(prodType);

        // Assert
        _mockRepo.Verify(repo => repo.GetProductList(It.IsAny<string>()), Times.Never);
        Assert.IsType<NotFoundObjectResult>(result.Result);
        Assert.Equal(null, result.Value);
    }

    [Fact]
    public void GetAllProductsByType_WithValidType_ReturnsProducts()
    {
        // Arrange
        string prodType = "lipstick";
        List<ProductDetailsDto> products = new List<ProductDetailsDto> {
                                        new ProductDetailsDto {
                                            Id = 11,
                                            ApiId = 91,
                                            Name = "Acme Lipstick 1337",
                                            Type = "lipstick",
                                            Brand = "Acme",
                                            Price = 9.99m,
                                            Description = "The latest style of lipstick from Acme.",
                                            Image = "www.image.com/image",
                                            ColourName = "Tomato red",
                                            HexValue = "#ff0000",
                                            Inventory = 17
                                        },
                                        new ProductDetailsDto {
                                            Id = 12,
                                            ApiId = 91,
                                            Name = "Acme Lipstick 1338",
                                            Type = "lipstick",
                                            Brand = "Acme",
                                            Price = 9.99m,
                                            Description = "The latest style of lipstick from Acme.",
                                            Image = "www.image.com/image",
                                            ColourName = "Apple red",
                                            HexValue = "#ee0000",
                                            Inventory = 8
                                        },
                                        new ProductDetailsDto {
                                            Id = 17,
                                            ApiId = 97,
                                            Name = "Jessi's Lipstick",
                                            Type = "lipstick",
                                            Brand = "Jessi's",
                                            Price = 13.99m,
                                            Description = "The latest style of lipstick from Jessi's.",
                                            Image = "www.image.com/image",
                                            ColourName = "Sunset",
                                            HexValue = "#770000",
                                            Inventory = 11
                                        }
                                    };
        _mockRepo.Setup(repo => repo.GetProductList(prodType)).Returns(products);

        // Act
        ActionResult<ProductDetailsDto> result = _controller.GetAllProductsByType(prodType);

        // Assert
        _mockRepo.Verify(repo => repo.GetProductList(prodType), Times.Once);
        Assert.IsType<OkObjectResult>(result.Result);
        //Assert.IsType<List<ProductDetailsDto>>(result.Value);
        //Assert.Equal(products[0], result.Value);
    }

    [Fact]
    public void GetProductById_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        int prodId = 0;
        _mockRepo.Setup(repo => repo.GetById(prodId)).Throws(new IndexOutOfRangeException());

        // Act
        ActionResult result = _controller.GetProductById(prodId);

        // Assert
        _mockRepo.Verify(repo => repo.GetById(It.IsAny<int>()), Times.Once);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void GetProductById_WithValidId_ReturnsProduct()
    {
        // Arrange
        int prodId = 11;
        ProductDetailsDto product = new ProductDetailsDto {
                                            Id = 11,
                                            ApiId = 91,
                                            Name = "Acme Lipstick 1337",
                                            Type = "lipstick",
                                            Brand = "Acme",
                                            Price = 9.99m,
                                            Description = "The latest style of lipstick from Acme.",
                                            Image = "www.image.com/image",
                                            ColourName = "Tomato red",
                                            HexValue = "#ff0000",
                                            Inventory = 17
                                        };
        _mockRepo.Setup(repo => repo.GetById(prodId)).Returns(product);

        // Act
        ActionResult result = _controller.GetProductById(prodId);

        // Assert
        _mockRepo.Verify(repo => repo.GetById(prodId), Times.Once);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetProductByApiId_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        int apiId = 0;
        _mockRepo.Setup(repo => repo.GetByApiId(apiId)).Throws(new IndexOutOfRangeException());

        // Act
        ActionResult<List<ProductDetailsDto>> result = _controller.GetProductByApiId(apiId);

        // Assert
        _mockRepo.Verify(repo => repo.GetByApiId(It.IsAny<int>()), Times.Once);
        Assert.IsType<NotFoundResult>(result.Result);
        Assert.Equal(null, result.Value);
    }

    [Fact]
    public void GetProductByApiId_WithValidId_ReturnsProducts()
    {
        // Arrange
        int apiId = 91;
        List<ProductDetailsDto> products = new List<ProductDetailsDto> {
                                        new ProductDetailsDto {
                                            Id = 11,
                                            ApiId = 91,
                                            Name = "Acme Lipstick 1337",
                                            Type = "lipstick",
                                            Brand = "Acme",
                                            Price = 9.99m,
                                            Description = "The latest style of lipstick from Acme.",
                                            Image = "www.image.com/image",
                                            ColourName = "Tomato red",
                                            HexValue = "#ff0000",
                                            Inventory = 17
                                        },
                                        new ProductDetailsDto {
                                            Id = 12,
                                            ApiId = 91,
                                            Name = "Acme Lipstick 1338",
                                            Type = "lipstick",
                                            Brand = "Acme",
                                            Price = 9.99m,
                                            Description = "The latest style of lipstick from Acme.",
                                            Image = "www.image.com/image",
                                            ColourName = "Apple red",
                                            HexValue = "#ee0000",
                                            Inventory = 8
                                        }};
        _mockRepo.Setup(repo => repo.GetByApiId(apiId)).Returns(products);

        // Act
        ActionResult<List<ProductDetailsDto>> result = _controller.GetProductByApiId(apiId);

        // Assert
        _mockRepo.Verify(repo => repo.GetByApiId(apiId), Times.Once);
        Assert.IsType<OkObjectResult>(result.Result);
        //Assert.IsType<List<ProductDetailsDto>>(result.Value);
    }
}