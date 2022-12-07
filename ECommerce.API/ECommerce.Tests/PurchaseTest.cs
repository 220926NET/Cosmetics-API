using Data;
using Moq;
using API.Controllers;
using Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Core;

public class PurchaseTest{

  

    [Fact]
    public void ReduceInventoryByIdShouldWork(){

        // Arrange
        // var mockedRepo = new Mock<IRepository>();
        // var mockedProductRepo = new Mock<IProductRepo>();
        // var mockeedLogger = new Mock<ILogger<PurchaseController>>();

        // ProductDetailsDto mockedProduct = new ProductDetailsDto {
        //     Id = 1,
        //     ApiId = 1,
        //     Name = "faked name",
        //     Type  = "type",
        //     Brand = "brand",
        //     Inventory = 20,
        //     Price = (decimal)9.99,
        //     Description = "description",
        //     Image = "image url",
        //     ColourName  = "color name",
        //     HexValue = "hexvalue",
        //     Discount  = 0.00,
        // };

        // OrderDTO[] mockedOrder = new OrderDTO[]{
        //     new OrderDTO(1,1)
        // };

        // mockedProductRepo.Setup(x => x.GetById(1)).Returns(mockedProduct);
        // mockedRepo.Setup(x => x.ReduceInventoryById(mockedOrder[0].Id, mockedOrder[0].Quantity,0)).Verifiable();

        // PurchaseController controller = new PurchaseController(mockedRepo.Object, mockeedLogger.Object, mockedProductRepo.Object);


        // //Act
        // var actionResult = controller.Purchase(mockedOrder,0).Value;

        //assert
        //Assert.NotNull(actionResult);
    }
    
}

  
