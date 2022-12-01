using Data;
using Models;
// using Services;
// using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IRepository _repo;

        private readonly ILogger<PurchaseController> _logger;

        private readonly IProductRepo _productRepo;

        public PurchaseController(IRepository repo, ILogger<PurchaseController> logger, IProductRepo productRepo)
        {
            this._repo = repo;
            this._logger = logger;
            this._productRepo = productRepo;
        }

        [HttpPut("Purchase")]
        public  ActionResult<OrderDTO[]> Purchase(OrderDTO[] purchaseProducts)
        {   
            // product list if purchase success
            List<OrderDTO> updatedProductList = new List<OrderDTO>();

            // check quantity for each product
            foreach(OrderDTO item in purchaseProducts){

                // get product quantity
                ProductDetailsDto product = _productRepo.GetById(item.Id);
                // if inventory is insufficient
                if(product.Inventory - item.Quantity < 0){

                    //update inventory
                    // _repo.ReduceInventoryById(item.id, item.quantity);
                    // updatedProductList.Add(item);
                    return BadRequest();
                    
                }
                
            }

            // all products' inventory is sufficient
            // do trasaction
            foreach(OrderDTO item in purchaseProducts)
            {
                _repo.ReduceInventoryById(item.Id, item.Quantity);
                updatedProductList.Add(item);
            }

            return NoContent();
        }
    }
}