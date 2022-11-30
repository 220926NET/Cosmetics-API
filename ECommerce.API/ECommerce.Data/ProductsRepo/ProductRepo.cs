using Models;
using Data;
using Data.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class ProductRepo : IProductRepo
{

    private readonly CosmeticsContext _context;

    private readonly ILogger<IProductRepo> _logger;

    public ProductRepo(ILogger<IProductRepo> logger, CosmeticsContext context)
    {
        _context = context;
        _logger = logger;

    }

    public List<ProductDetailsDto> GetAllLipsticks()
    {


        var lipstick = _context.Products.Where(product => product.ProductType == "lipstick");

        List<ProductDetailsDto> lipsticks = GetProductList(lipstick);

        return GetProductList(lipstick);
    }

    public List<ProductDetailsDto> GetAllBlush()
    {


        var blush = _context.Products.Where(product => product.ProductType == "blush");



        return GetProductList(blush);
    }

    public List<ProductDetailsDto> GetAllEyeShadow()
    {


        var eyeshadow = _context.Products.Where(product => product.ProductType == "eyeshadow");

        return GetProductList(eyeshadow);
    }

    public List<ProductDetailsDto> GetAllEyeLiner()
    {


        var eyeliner = _context.Products.Where(product => product.ProductType == "eyeliner");


        return GetProductList(eyeliner);
    }


    public List<ProductDetailsDto> GetAllFoundation()
    {

        var foundation = _context.Products.Where(product => product.ProductType == "foundation");


        return GetProductList(foundation);

    }



    public List<ProductDetailsDto> GetProductList(IQueryable<Entities.Product> result)
    {

        List<ProductDetailsDto> products = new List<ProductDetailsDto>();

        foreach (var item in result)
        {

            ProductDetailsDto product = new ProductDetailsDto()
            {
                Id = item.ProductId,
                Name = item.ProductName,
                Type = item.ProductType,
                Brand = item.Brand,
                Inventory = item.Inventory,
                Price = item.Price,
                Description = item.Description!,
                ImageUrl = item.Image!,
                ColorHexValues = new List<string>() { item.HexValue }
            };

            if (products.Count > 0)
            {

                if (products[products.Count - 1].Name == product.Name)
                {
                    products[products.Count - 1].ColorHexValues.Add(item.HexValue);
                }
            }
            else
            {
                products.Add(product);
            }

        }

        return products;

    }

    public Entities.Product GetById(int productId)
    {
        return _context.Products.Where(i => i.ProductId == productId).First();
    }

}