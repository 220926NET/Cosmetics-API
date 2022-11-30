﻿using Data;
using Models;
using Services;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repo;

        private readonly IProductRepo _productRepo;
        private readonly ILogger<ProductController> _logger;

        private readonly IProductService _productService;

        public ProductController(IRepository repo, ILogger<ProductController> logger, IProductRepo productRepo, IProductService productService)
        {
            this._repo = repo;
            this._logger = logger;
            this._productRepo = productRepo;
            _productService = productService;
        }


        [HttpGet("{productType}")]
        public async Task<ActionResult<ProductDTO>> GetAllLipStick(string productType)
        {
            List<Product> products = new List<Product>();
            Console.WriteLine("product type is " + productType);


            // _logger.LogInformation("api/product/{id} triggered");
            // try
            // {
            //     //return Ok(await _repo.GetProductByIdAsync(id));
            //     _logger.LogInformation("api/product/{id} completed successfully");
            // }
            // catch
            // {
            //     return BadRequest();
            //     _logger.LogWarning("api/product/{id} completed with errors");
            // }


            return Ok(_productService.getAllProducts(productType));
        }

        [HttpGet("id/{productId}")]
        public ActionResult GetProductById(int productId)
        {
            try
            {
                Data.Entities.Product product = _productRepo.GetById(productId);
                return Ok(product);
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
