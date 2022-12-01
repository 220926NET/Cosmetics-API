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


        var lipstick = _context.Products.Where(product => product.ProductType == "lipstick").ToList();

        List<ProductDetailsDto> lipsticks = GetProductList(lipstick);

        return GetProductList(lipstick);
    }

    public List<ProductDetailsDto> GetAllBlush()
    {


        var blush = _context.Products.Where(product => product.ProductType == "blush").ToList();



        return GetProductList(blush);
    }

    public List<ProductDetailsDto> GetAllEyeShadow()
    {


        var eyeshadow = _context.Products.Where(product => product.ProductType == "eyeshadow").ToList();

        return GetProductList(eyeshadow);
    }

    public List<ProductDetailsDto> GetAllEyeLiner()
    {


        var eyeliner = _context.Products.Where(product => product.ProductType == "eyeliner").ToList();


        return GetProductList(eyeliner);
    }


    public List<ProductDetailsDto> GetAllFoundation()
    {

        var foundation = _context.Products.Where(product => product.ProductType == "foundation").ToList();


        return GetProductList(foundation);

    }



    public List<ProductDetailsDto> GetProductList(List<Entities.Product> result)
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
                Image = item.Image!,
                ColorHexValues = new List<string>() { item.HexValue },
                Discount = DiscountPercent(item.ApiId)
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

    private double DiscountPercent(int productId) {
        double discount = 0.00;
        // Check if a Deal for the specified Product's ID exists
        if (_context.Deals.Any(d => d.Product == productId)) {
            foreach (Deal deal in _context.Deals.Where(d => d.Product == productId)) {
                if (deal.StartTime <= DateTime.UtcNow && deal.EndTime >= DateTime.UtcNow) {
                    discount += (double) deal.Discount;
                }
            }
        }
        
        return discount;
    }

    public ProductDetailsDto GetById(int productId)
    {
        Entities.Product info = _context.Products.Where(i => i.ProductId == productId).First();

        return new ProductDetailsDto()
                {
                    Id = info.ProductId,
                    Name = info.ProductName,
                    Type = info.ProductType,
                    Brand = info.Brand,
                    Inventory = info.Inventory,
                    Price = info.Price,
                    Description = info.Description!,
                    Image = info.Image!,
                    ColorHexValues = new List<string>() { info.HexValue },
                    Discount = DiscountPercent(info.ApiId)
                };
    }

    public ProductDetailsDto GetByApiId(int apiId)
    {

        List<Entities.Product> info = _context.Products.Where(i => i.ApiId == apiId).ToList();

        ProductDetailsDto product = new ProductDetailsDto()
                {
                    Id = info[0].ProductId,
                    Name = info[0].ProductName,
                    Type = info[0].ProductType,
                    Brand = info[0].Brand,
                    Inventory = info[0].Inventory,
                    Price = info[0].Price,
                    Description = info[0].Description!,
                    Image = info[0].Image!,
                    ColorHexValues = new List<string>() { info[0].HexValue! },
                    Discount = DiscountPercent(info[0].ApiId)
                };
        
        if (info.Count > 1) {
            for (int i = 1; i < info.Count; i++) {
                product.ColorHexValues.Add(info[i].HexValue!);
            }
        }

        return product;
    }
}