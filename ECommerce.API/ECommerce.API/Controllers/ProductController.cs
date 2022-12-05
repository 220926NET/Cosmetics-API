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
        private readonly ILogger<ProductController> _logger;

        private readonly IConfiguration _config;

        public ProductController(ILogger<ProductController> logger, IProductRepo productRepo)
        {
            this._logger = logger;
            this._productRepo = productRepo;
        }

        [HttpGet("{productType}")]
        public ActionResult<ProductDetailsDto> GetAllProductsByType(string productType)
        {

            if (ProductsValidator.IsValidProductType(productType))
            {
                //_logger.LogInformation("api/product/{id} completed successfully");
                return Ok(_productRepo.GetProductList(productType));
            }
            else
            {
                _logger.LogWarning("User queried product type of  " + productType);
                return NotFound("Products types available are : foundation, blush, lipstick, eyeliner, eyeshadow");
            }
        }

        [HttpGet("id/{productId}")]
        public ActionResult GetProductById(int productId)
        {
            try
            {
                ProductDetailsDto product = _productRepo.GetById(productId);
                return Ok(product);
            }
            catch
            {
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
    }
}
