using Data;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductRepo productRepo, IProductService productService) {
            this._logger = logger;
            this._productRepo = productRepo;
            this._productService = productService;
        }

        /// <c> GetAllProductsByType </c>
        /// <returns> a list of ProductDtos
        [HttpGet("{productType}")]
        public ActionResult<ProductDetailsDto> GetAllProductsByType(string productType) {
            if (ProductsValidator.IsValidProductType(productType)) {
                //_logger.LogInformation("api/product/{id} completed successfully");
                return Ok(_productService.getAllProducts(productType));
            }
            else {
                _logger.LogWarning("User queried product type of  " + productType);
                return NotFound("Products types available are : foundation, blush, lipstick, eyeliner, eyeshadow");
            }
        }

        [HttpGet("id/{productId}")]
        public ActionResult GetProductById(int productId)
        {
            try {
                ProductDetailsDto product = _productRepo.GetById(productId);
                return Ok(product);
            }
            catch {
                return NotFound();
            }
        }

        [HttpGet("apiId/{apiId}")]
        public ActionResult<List<ProductDetailsDto>> GetProductByApiId(int apiId)
        {
            try
            {
                List<ProductDetailsDto> list = _productRepo.GetByApiId(apiId);
                return Ok(list);
            }
            catch
            {
                return NotFound();
            }
        }

        // [HttpGet]
        // public async Task<ActionResult<Product[]>> GetAll()
        // {
        //     _logger.LogInformation("api/product triggered");
        //     try
        //     {
        //         return Ok(await _repo.GetAllProductsAsync());
        //         _logger.LogInformation("api/product completed successfully");
        //     }
        //     catch
        //     {
        //         return BadRequest();
        //         _logger.LogWarning("api/product completed with errors");
        //     }
        // }

        // [HttpPatch]
        // public async Task<ActionResult<Product[]>> Purchase([FromBody] ProductDTO[] purchaseProducts)
        // {
        //     _logger.LogInformation("PATCH api/product triggered");
        //     List<Product> products = new List<Product>();
        //     try
        //     {
        //         foreach(ProductDTO item in purchaseProducts)
        //         {
        //             Product tmp = await _repo.GetProductByIdAsync(item.id);
        //             if ((tmp.quantity - item.quantity) >= 0)
        //             {
        //                 await _repo.ReduceInventoryByIdAsync(item.id, item.quantity);
        //                 products.Add(await _repo.GetProductByIdAsync(item.id));
        //             }
        //             else
        //             {
        //                 throw new Exception("Insuffecient inventory.");
        //             }
        //         }
        //         return Ok(products);
        //         _logger.LogInformation("PATCH api/product completed successfully");
        //     }
        //     catch
        //     {
        //         return BadRequest();
        //         _logger.LogWarning("PATCH api/product completed with errors");

        //     }


        // }

    }
}
